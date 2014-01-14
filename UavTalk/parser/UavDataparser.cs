using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace UavTalk.parser
{
    public class UavDataparser
    {
        private enum commState
        {
            SYNC,
            TYPE,
            SIZE,
            OBJID,
            INSTID,
            DATA,
            CS
        }

        private byte[] prebuffer = new byte[12];
        private int preBufferIdx = 0;
        private UInt32 last_timestamp;
        private ComStats _stats;
        private commState rxState;
        private int rxCSPacket, rxCS, rxPacketLength, rxCount, packetSize, rxType;
        private ByteBuffer rxTmpBuffer, rxBuffer;
        private UInt32 rxObjId, rxInstId;
        private int rxLength;
        private UAVObjectManager _objMgr;
        public ComStats stats { get { return _stats; } }

        public delegate void onObjectReceivedDelegate(int type, uint objId, uint instId, UInt32 timestamp, ByteBuffer data);
        public event onObjectReceivedDelegate onObjectReceived;

        public UavDataparser(UAVObjectManager dataManager)
        {
            rxTmpBuffer = new ByteBuffer(4);
            rxBuffer = new ByteBuffer(uavConsts.MAX_PAYLOAD_LENGTH);
            _stats = new ComStats();
            rxState = commState.SYNC;
            rxPacketLength = 0;
            _objMgr = dataManager;
        }

        public void processInputByte(byte data)
        {
            _stats.Bytes++;

            rxPacketLength++; // update packet byte count

            switch (rxState)
            {
                case commState.SYNC:
                    if (data != uavConsts.SYNC_VAL)
                    {
                        if (preBufferIdx < prebuffer.Length)
                        {
                            prebuffer[preBufferIdx++] = data;
                        }
                        break;
                    }

                    // Initialize and update CRC
                    rxCS = CRC.updateCRC(0, data);
                    rxPacketLength = 1;
                    rxState = commState.TYPE;
                    break;
                case commState.TYPE:
                    // Update CRC
                    rxCS = CRC.updateCRC(rxCS, data);

                    if ((data & uavConsts.TYPE_MASK) != uavConsts.TYPE_VER)
                    {
                        if (preBufferIdx + 1 < prebuffer.Length)
                        {
                            prebuffer[preBufferIdx++] = uavConsts.SYNC_VAL;
                            prebuffer[preBufferIdx++] = data;
                        }
                        //Debug.WriteLine( "Unknown UAVTalk type: {0:X}", data);
                        rxState = commState.SYNC;
                        break;
                    }

                    if (preBufferIdx == prebuffer.Length)
                    {
                        last_timestamp = BitConverter.ToUInt32(prebuffer, 0);
                        UInt64 packetSize_pre = BitConverter.ToUInt64(prebuffer, 4);
                    }
                    preBufferIdx = 0;
                    rxType = data;
                    //Debug.WriteLine("Received packet type:  {0:X}", data);
                    packetSize = 0;

                    rxState = commState.SIZE;
                    rxCount = 0;
                    break;
                case commState.SIZE:
                    // Update CRC
                    rxCS = CRC.updateCRC(rxCS, data);

                    if (rxCount == 0)
                    {
                        packetSize += data;
                        rxCount++;
                        break;
                    }

                    packetSize += (data << 8) & 0xff00;

                    if (packetSize < uavConsts.MIN_HEADER_LENGTH
                            || packetSize > uavConsts.MAX_HEADER_LENGTH + uavConsts.MAX_PAYLOAD_LENGTH)
                    { // incorrect
                        // packet
                        // size
                        rxState = commState.SYNC;
                        break;
                    }

                    rxCount = 0;
                    rxState = commState.OBJID;
                    rxTmpBuffer.position(0);
                    break;
                case commState.OBJID:
                    // Update CRC
                    rxCS = CRC.updateCRC(rxCS, data);

                    rxTmpBuffer.put(rxCount++, data);
                    if (rxCount < 4)
                        break;

                    // Search for object, if not found reset state machine
                    rxObjId = rxTmpBuffer.getInt(0);
                    // Because java treats ints as only signed we need to do this manually

                    UAVObject rxObj = _objMgr.getObject(rxObjId);
                    if (rxObj == null)
                    {
                        Debug.WriteLine("Unknown ID: " + rxObjId);
                        _stats.Errors++;
                        rxState = commState.SYNC;
                        break;
                    }

                    // Determine data length
                    if (rxType == uavConsts.TYPE_OBJ_REQ || rxType == uavConsts.TYPE_ACK || rxType == uavConsts.TYPE_NACK)
                        rxLength = 0;
                    else
                        rxLength = rxObj.getNumBytes();

                    // Check length and determine next state
                    if (rxLength >= uavConsts.MAX_PAYLOAD_LENGTH)
                    {
                        Debug.WriteLine("Greater than max payload length");
                        _stats.Errors++;
                        rxState = commState.SYNC;
                        break;
                    }

                    // Check if this is a single instance object (i.e. if the
                    // instance ID field is coming next)
                    if (rxObj.isSingleInstance())
                    {
                        // If there is a payload get it, otherwise receive checksum
                        if (rxLength > 0)
                            rxState = commState.DATA;
                        else
                            rxState = commState.CS;
                        rxInstId = 0;
                        rxCount = 0;
                    }
                    else
                    {
                        rxState = commState.INSTID;
                        rxCount = 0;
                    }

                    break;
                case commState.INSTID:

                    // Update CRC
                    rxCS = CRC.updateCRC(rxCS, data);

                    rxTmpBuffer.put(rxCount++, data);
                    if (rxCount < 2)
                        break;

                    rxInstId = rxTmpBuffer.getShort(0);

                    rxCount = 0;

                    // If there is a payload get it, otherwise receive checksum
                    if (rxLength > 0)
                        rxState = commState.DATA;
                    else
                        rxState = commState.CS;

                    break;
                case commState.DATA:

                    // Update CRC
                    rxCS = CRC.updateCRC(rxCS, data);

                    rxBuffer.put(rxCount++, data);
                    if (rxCount < rxLength)
                        break;

                    rxState = commState.CS;
                    rxCount = 0;
                    break;
                case commState.CS:

                    // The CRC byte
                    rxCSPacket = data;

                    if (rxCS != rxCSPacket)
                    { // packet error - faulty CRC
                        Debug.WriteLine("Bad crc");
                        _stats.Errors++;
                        rxState = commState.SYNC;
                        break;
                    }

                    if (rxPacketLength != (packetSize + 1))
                    { // packet error -
                        // mismatched packet
                        // size
                        Debug.WriteLine("Bad size");
                        _stats.Errors++;
                        rxState = commState.SYNC;
                        break;
                    }

                    rxBuffer.position(0);
                    if(onObjectReceived != null)
                        onObjectReceived(rxType, rxObjId, rxInstId, last_timestamp, rxBuffer);
                    _stats.ObjectBytes += rxLength;
                    _stats.Objects++;

                    rxState = commState.SYNC;
                    break;
                default:
                    Debug.WriteLine("Bad state");
                    rxState = commState.SYNC;
                    _stats.Errors++;
                    break;
            }
        }
    }
}

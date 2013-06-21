using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace UavTalk
{
    public class UavTalk
    {
        private ICommChannel ch;
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

        	private const byte SYNC_VAL = 0x3C;

	    private readonly byte[] crc_table = { 0x00, 0x07, 0x0e, 0x09, 0x1c,
			0x1b, 0x12, 0x15, 0x38, 0x3f, 0x36, 0x31, 0x24, 0x23, 0x2a, 0x2d,
			0x70, 0x77, 0x7e, 0x79, 0x6c, 0x6b, 0x62, 0x65, 0x48, 0x4f, 0x46,
			0x41, 0x54, 0x53, 0x5a, 0x5d, 0xe0, 0xe7, 0xee, 0xe9, 0xfc, 0xfb,
			0xf2, 0xf5, 0xd8, 0xdf, 0xd6, 0xd1, 0xc4, 0xc3, 0xca, 0xcd, 0x90,
			0x97, 0x9e, 0x99, 0x8c, 0x8b, 0x82, 0x85, 0xa8, 0xaf, 0xa6, 0xa1,
			0xb4, 0xb3, 0xba, 0xbd, 0xc7, 0xc0, 0xc9, 0xce, 0xdb, 0xdc, 0xd5,
			0xd2, 0xff, 0xf8, 0xf1, 0xf6, 0xe3, 0xe4, 0xed, 0xea, 0xb7, 0xb0,
			0xb9, 0xbe, 0xab, 0xac, 0xa5, 0xa2, 0x8f, 0x88, 0x81, 0x86, 0x93,
			0x94, 0x9d, 0x9a, 0x27, 0x20, 0x29, 0x2e, 0x3b, 0x3c, 0x35, 0x32,
			0x1f, 0x18, 0x11, 0x16, 0x03, 0x04, 0x0d, 0x0a, 0x57, 0x50, 0x59,
			0x5e, 0x4b, 0x4c, 0x45, 0x42, 0x6f, 0x68, 0x61, 0x66, 0x73, 0x74,
			0x7d, 0x7a, 0x89, 0x8e, 0x87, 0x80, 0x95, 0x92, 0x9b, 0x9c, 0xb1,
			0xb6, 0xbf, 0xb8, 0xad, 0xaa, 0xa3, 0xa4, 0xf9, 0xfe, 0xf7, 0xf0,
			0xe5, 0xe2, 0xeb, 0xec, 0xc1, 0xc6, 0xcf, 0xc8, 0xdd, 0xda, 0xd3,
			0xd4, 0x69, 0x6e, 0x67, 0x60, 0x75, 0x72, 0x7b, 0x7c, 0x51, 0x56,
			0x5f, 0x58, 0x4d, 0x4a, 0x43, 0x44, 0x19, 0x1e, 0x17, 0x10, 0x05,
			0x02, 0x0b, 0x0c, 0x21, 0x26, 0x2f, 0x28, 0x3d, 0x3a, 0x33, 0x34,
			0x4e, 0x49, 0x40, 0x47, 0x52, 0x55, 0x5c, 0x5b, 0x76, 0x71, 0x78,
			0x7f, 0x6a, 0x6d, 0x64, 0x63, 0x3e, 0x39, 0x30, 0x37, 0x22, 0x25,
			0x2c, 0x2b, 0x06, 0x01, 0x08, 0x0f, 0x1a, 0x1d, 0x14, 0x13, 0xae,
			0xa9, 0xa0, 0xa7, 0xb2, 0xb5, 0xbc, 0xbb, 0x96, 0x91, 0x98, 0x9f,
			0x8a, 0x8d, 0x84, 0x83, 0xde, 0xd9, 0xd0, 0xd7, 0xc2, 0xc5, 0xcc,
			0xcb, 0xe6, 0xe1, 0xe8, 0xef, 0xfa, 0xfd, 0xf4, 0xf3 };
        const int TYPE_MASK = 0xF8;
	    const int TYPE_VER = 0x20;
	    //! Packet contains an object
	    const int TYPE_OBJ = (TYPE_VER | 0x00);
	    //! Packet is a request for an object
	    const int TYPE_OBJ_REQ = (TYPE_VER | 0x01);
	    //! Packet is an object with a request for an ack
	    const int TYPE_OBJ_ACK = (TYPE_VER | 0x02);
	    //! Packet is an ack for an object
	    const int TYPE_ACK = (TYPE_VER | 0x03);
	    const int TYPE_NACK = (TYPE_VER | 0x04);

	    const int MIN_HEADER_LENGTH = 8; // sync(1), type (1), size(2),
											    // object ID(4)
	    const int MAX_HEADER_LENGTH = 10; // sync(1), type (1), size(2),
												    // object ID (4), instance ID(2,
												    // not used in single objects)

	    const int CHECKSUM_LENGTH = 1;

	    const int MAX_PAYLOAD_LENGTH = 256;

        const int MAX_PACKET_LENGTH = (MAX_HEADER_LENGTH
			    + MAX_PAYLOAD_LENGTH + CHECKSUM_LENGTH);

        const int ALL_INSTANCES = 0xFFFF;

        private commState rxState;
        private int rxCSPacket, rxCS, rxPacketLength, rxCount, packetSize, rxType;
        private ByteBuffer rxTmpBuffer, rxBuffer;
        private UInt32 rxObjId,rxInstId;
        private UAVObjectManager objMgr;
        private ComStats stats;
        private int rxLength;
        private int receivedbytes;
        private UAVObject respObj;
        private int respType;
        private bool respAllInstances;
        private Timer statTimer;

        public UavTalk(ICommChannel communicationChannel, UAVObjectManager objMgr)
        {
            this.objMgr = objMgr;
            rxState = commState.SYNC;
            rxPacketLength = 0;
            stats = new ComStats();
            rxTmpBuffer = new ByteBuffer(4);
            rxBuffer = new ByteBuffer(MAX_PAYLOAD_LENGTH);
            ch = communicationChannel;
            ch.onDataReceived += ch_onDataReceived;
            statTimer = new Timer(1000);
            statTimer.Elapsed += statTimer_Elapsed;
            statTimer.Start();
        }

        void statTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int bs = stats.rxBytes - receivedbytes;
            Debug.WriteLine("Received {0} B/s", bs);
            receivedbytes = stats.rxBytes;
        }

        public bool sendObjectRequest(UAVObject obj, bool allInstances) {
		    return objectTransaction(obj, TYPE_OBJ_REQ, allInstances);
	    }

        public bool sendObject(UAVObject obj, bool acked, bool allInstances) {
		    if (acked) {
			    return objectTransaction(obj, TYPE_OBJ_ACK, allInstances);
		    } else {
			    return objectTransaction(obj, TYPE_OBJ, allInstances);
		    }
	    }
        
        private bool objectTransaction(UAVObject obj, int type, bool allInstances) {
		    if (type == TYPE_OBJ_ACK || type == TYPE_OBJ_REQ || type == TYPE_OBJ) {
			    return transmitObject(obj, type, allInstances);
		    } else {
			    return false;
		    }
	    }

        void ch_onDataReceived(byte[] data)
        {
            foreach (byte b in data)
                processInputByte(b);
        }

        private void processInputByte(byte data)
        {
            stats.rxBytes++;

            rxPacketLength++; // update packet byte count

            switch (rxState)
            {
                case commState.SYNC:
                    if (data != SYNC_VAL)
                        break;
                    // Initialize and update CRC
                    rxCS = updateCRC(0, data);
                    rxPacketLength = 1;
                    rxState = commState.TYPE;
                    break;
                case commState.TYPE:
                    // Update CRC
                    rxCS = updateCRC(rxCS, data);

                    if ((data & TYPE_MASK) != TYPE_VER)
                    {
                        Debug.WriteLine( "Unknown UAVTalk type: {0:X}", data);
                        rxState = commState.SYNC;
                        break;
                    }

                    rxType = data;
                    //Debug.WriteLine("Received packet type:  {0:X}", data);
                    packetSize = 0;

                    rxState = commState.SIZE;
                    rxCount = 0;
                    break;
                case commState.SIZE:
                    // Update CRC
                    rxCS = updateCRC(rxCS, data);

                    if (rxCount == 0)
                    {
                        packetSize += data;
                        rxCount++;
                        break;
                    }

                    packetSize += (data << 8) & 0xff00;

                    if (packetSize < MIN_HEADER_LENGTH
                            || packetSize > MAX_HEADER_LENGTH + MAX_PAYLOAD_LENGTH)
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
				    rxCS = updateCRC(rxCS, data);

				    rxTmpBuffer.put(rxCount++, data);
				    if (rxCount < 4)
					    break;

				    // Search for object, if not found reset state machine
				    rxObjId = rxTmpBuffer.getInt(0);
				    // Because java treats ints as only signed we need to do this manually
				    
					UAVObject rxObj = objMgr.getObject(rxObjId);
					if (rxObj == null) {
						Debug.WriteLine("Unknown ID: " + rxObjId);
						stats.rxErrors++;
						rxState = commState.SYNC;
						break;
					}

					// Determine data length
					if (rxType == TYPE_OBJ_REQ || rxType == TYPE_ACK || rxType == TYPE_NACK)
						rxLength = 0;
					else
						rxLength = rxObj.getNumBytes();

					// Check length and determine next state
					if (rxLength >= MAX_PAYLOAD_LENGTH) {
                        Debug.WriteLine("Greater than max payload length");
						stats.rxErrors++;
						rxState = commState.SYNC;
						break;
					}

					// Check if this is a single instance object (i.e. if the
					// instance ID field is coming next)
					if (rxObj.isSingleInstance()) {
						// If there is a payload get it, otherwise receive checksum
						if (rxLength > 0)
							rxState = commState.DATA;
						else
                            rxState = commState.CS;
						rxInstId = 0;
						rxCount = 0;
					} else {
                        rxState = commState.INSTID;
						rxCount = 0;
					}
				  
                    break;
                case commState.INSTID:

                    // Update CRC
                    rxCS = updateCRC(rxCS, data);

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
                    rxCS = updateCRC(rxCS, data);

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
                        stats.rxErrors++;
                        rxState = commState.SYNC;
                        break;
                    }

                    if (rxPacketLength != (packetSize + 1))
                    { // packet error -
                        // mismatched packet
                        // size
                        Debug.WriteLine("Bad size");
                        stats.rxErrors++;
                        rxState = commState.SYNC;
                        break;
                    }

                    rxBuffer.position(0);
                    receiveObject(rxType, rxObjId, rxInstId, rxBuffer);
                    stats.rxObjectBytes += rxLength;
                    stats.rxObjects++;

                    rxState = commState.SYNC;
                    break;
                default:
                    Debug.WriteLine("Bad state");
                    rxState = commState.SYNC;
                    stats.rxErrors++;
                    break;
            }
        }

        private bool receiveObject(int type, uint objId, uint instId, ByteBuffer data)
        {
            //Debug.WriteLine("Received object ID: " + objId);
            bool error = false;
            UAVObject obj = null;
            bool allInstances = (instId == ALL_INSTANCES ? true : false);

            // Process message type
            switch (type)
            {
                case TYPE_OBJ:
                    // All instances, not allowed for OBJ messages
                    if (!allInstances)
                    {
                        //Debug.WriteLine(string.Format( "{0:ss:fff} Received object: {1}" ,DateTime.Now, objMgr.getObject(objId).getName()));

                        // Get object and update its data
                        obj = updateObject(objId, instId, data);

                        if (obj != null)
                        {
                            // Check if this is a response to a UAVTalk transaction
                            updateObjReq(obj);
                        }
                        else
                        {
                            error = true;
                        }
                    }
                    else
                    {
                        error = true;
                    }
                    break;
                case TYPE_OBJ_ACK:
                    // All instances, not allowed for OBJ_ACK messages
                    if (!allInstances)
                    {
                        Debug.WriteLine("Received object ack: " + objId + " " + objMgr.getObject(objId).getName());
                        // Get object and update its data
                        obj = updateObject(objId, instId, data);
                        // Transmit ACK
                        if (obj != null)
                        {
                            transmitObject(obj, TYPE_ACK, false);
                        }
                        else
                        {
                            error = true;
                        }
                    }
                    else
                    {
                        error = true;
                    }
                    break;
                case TYPE_OBJ_REQ:
                    // Get object, if all instances are requested get instance 0 of the
                    // object
                    Debug.WriteLine( "Received object request: " + objId + " " +
                     objMgr.getObject(objId).getName());
                    if (allInstances)
                    {
                        obj = objMgr.getObject(objId);
                    }
                    else
                    {
                        obj = objMgr.getObject(objId, instId);
                    }
                    // If object was found transmit it
                    if (obj != null)
                    {
                        transmitObject(obj, TYPE_OBJ, allInstances);
                    }
                    else
                    {
                        error = true;
                    }
                    break;
                case TYPE_NACK:
                    Debug.WriteLine("Received NAK: " + objId + " " + objMgr.getObject(objId).getName());
                    // All instances, not allowed for NACK messages
                    if (!allInstances)
                    {
                        // Get object
                        obj = objMgr.getObject(objId, instId);
                        // Check if object exists:
                        if (obj != null)
                        {
                            receivedNack(obj);
                        }
                        else
                        {
                            error = true;
                        }
                    }
                    break;
                case TYPE_ACK:
                    // All instances, not allowed for ACK messages
                    if (!allInstances)
                    {
                        Debug.WriteLine("Received ack: " + objId + " " + objMgr.getObject(objId).getName());
                        // Get object
                        obj = objMgr.getObject(objId, instId);
                        // Check if an ack is pending
                        if (obj != null)
                        {
                            updateAck(obj);
                        }
                        else
                        {
                            error = true;
                        }
                    }
                    break;
                default:
                    error = true;
                    break;
            }
            return error;
        }

        /**
	     * Check if a transaction is pending and if yes complete it.
	     */
        private readonly object receivedNackSyncLock = new object();
	    private void receivedNack(UAVObject obj)
	    {
            lock (receivedNackSyncLock)
            {
                if (respObj != null && (respType == TYPE_OBJ_REQ || respType == TYPE_OBJ_ACK) &&
                        respObj.getObjID() == obj.getObjID())
                {

                    Debug.WriteLine("NAK: " + obj.getName());

                    // Indicate complete
                    respObj = null;

                    // Notify listener
                    if (transactionListener != null)
                        transactionListener.TransactionFailed(obj);
                }
            }
	    }

        /**
	     * Check if a transaction is pending that this acked object corresponds to
	     * and if yes complete it.
	     */
        private readonly object updateAckSyncLock = new object();
	    private void updateAck(UAVObject obj) {
            lock (updateAckSyncLock)
            {
                Debug.WriteLine("Received ack: " + obj.getName());
                //Assert.assertNotNull(obj);
                if (respObj != null && respObj.getObjID() == obj.getObjID()
                        && (respObj.getInstID() == obj.getInstID() || respAllInstances))
                {

                    // Indicate complete
                    respObj = null;

                    // Notify listener
                    if (transactionListener != null)
                        transactionListener.TransactionSucceeded(obj);
                }
            }
	    }

        /**
	     * Send an object through the telemetry link.
	     * @param[in] obj Object to send
	     * @param[in] type Transaction type
	     * @param[in] allInstances True is all instances of the object are to be sent
	     * @return Success (true), Failure (false)
	     * @throws IOException
	     */
	    private bool transmitObject(UAVObject obj, int type, bool allInstances) 
        {
		    // If all instances are requested on a single instance object it is an
		    // error
		    if (allInstances && obj.isSingleInstance()) {
			    allInstances = false;
		    }

		    // Process message type
		    if (type == TYPE_OBJ || type == TYPE_OBJ_ACK) {
			    if (allInstances) {
				    // Get number of instances
				    int numInst = objMgr.getNumInstances(obj.getObjID());
				    // Send all instances
				    for (int instId = 0; instId < numInst; ++instId) {
					    // TODO: This code is buggy probably.  We should send each request
					    // and wait for an ack in the case of an TYPE_OBJ_ACK
					    Debug.Assert(type != TYPE_OBJ_ACK); // catch any buggy calls

					    UAVObject inst = objMgr.getObject(obj.getObjID(), instId);
					    transmitSingleObject(inst, type, false);
				    }
				    return true;
			    } else {
				    return transmitSingleObject(obj, type, false);
			    }
		    } else if (type == TYPE_OBJ_REQ) {
			    return transmitSingleObject(obj, TYPE_OBJ_REQ, allInstances);
		    } else if (type == TYPE_ACK) {
			    if (!allInstances) {
				    return transmitSingleObject(obj, TYPE_ACK, false);
			    } else {
				    return false;
			    }
		    } else {
			    return false;
		    }
	    }

        /**
	     * Send an object through the telemetry link.
	     * @throws IOException
	     * @param[in] obj Object handle to send
	     * @param[in] type Transaction type \return Success (true), Failure (false)
	     */
        private bool transmitSingleObject(UAVObject obj, int type, bool allInstances)
        {
            int length;
            int allInstId = ALL_INSTANCES;

            ByteBuffer bbuf = new ByteBuffer(MAX_PACKET_LENGTH);
            
            // Determine data length
            if (type == TYPE_OBJ_REQ || type == TYPE_ACK)
            {
                length = 0;
            }
            else
            {
                length = obj.getNumBytes();
            }

            // Setup type and object id fields
            bbuf.put((byte)(SYNC_VAL & 0xff));
            bbuf.put((byte)(type & 0xff));
            bbuf.putShort((UInt16)(length + 2 /* SYNC, Type */+ 2 /* Size */+ 4 /* ObjID */+ (obj
                            .isSingleInstance() ? 0 : 2)));
            bbuf.putUint32((UInt32)obj.getObjID());

            // Setup instance ID if one is required
            if (!obj.isSingleInstance())
            {
                // Check if all instances are requested
                if (allInstances)
                    bbuf.putShort((UInt16)(allInstId & 0xffff));
                else
                    bbuf.putShort((UInt16)(obj.getInstID() & 0xffff));
            }

            // Check length
            if (length >= MAX_PAYLOAD_LENGTH)
                return false;

            // Copy data (if any)
            if (length > 0)
                try
                {
                    if (obj.pack(bbuf) == 0)
                        return false;
                }
                catch (Exception e)
                {
                    // TODO Auto-generated catch block
                    Debug.Write(e.Message);
                    return false;
                }

            // Calculate checksum
            bbuf.put((byte)(updateCRC(0, bbuf.array(), bbuf.position()) & 0xff));

            int packlen = bbuf.position();
            bbuf.position(0);
            byte[] dst = new byte[packlen];
            bbuf.get(dst, 0, packlen);

            if (type == TYPE_OBJ_ACK || type == TYPE_OBJ_REQ)
            {
                // Once we send a UAVTalk packet that requires an ack or object let's set up
                // the transaction here
                setupTransaction(obj, allInstances, type);
            }

            ch.write(dst);


            // Update stats
            ++stats.txObjects;
            stats.txBytes += bbuf.position();
            stats.txObjectBytes += length;

            // Done
            return true;
        }

        /**
	     * This is the code that sets up a new UAVTalk packet that expects a response.
	     */
        private void setupTransaction(UAVObject obj, bool allInstances, int type) {
            lock(this)
            {
			    // Only cancel if it is for a different object
			    if(respObj != null && respObj.getObjID() != obj.getObjID())
				    cancelPendingTransaction(obj);

			    respObj = obj;
			    respAllInstances = allInstances;
			    respType = type;
		    }
	    }

        /**
	     * UAVTalk takes care of it's own transactions but if the caller knows
	     * it wants to give up on one (after a timeout) then it can cancel it
	     * @return True if that object was pending, False otherwise
	     */
        public bool cancelPendingTransaction(UAVObject obj) {
		    lock (respObj) {
			    if(respObj != null && respObj.getObjID() == obj.getObjID()) {
				    if(transactionListener != null) {
					   Debug.WriteLine("Canceling transaction: " + respObj.getName());
					    transactionListener.TransactionFailed(respObj);
				    }
				    respObj = null;
				    return true;
			    } else
				    return false;
		    }
	    }

        /**
	     * Called when an object is received to check if this completes
	     * a UAVTalk transaction
	     */
        private readonly object updateObjReqSyncLock = new object();
        private void updateObjReq(UAVObject obj) {
		    bool succeeded = false;

		    // The lock on UAVTalk must be release before the transaction succeeded signal is sent
		    // because otherwise if a transaction timeout occurs at the same time we can get a
		    // deadlock:
		    // 1. processInputStream -> updateObjReq (locks uavtalk) -> tranactionCompleted (locks transInfo)
		    // 2. transactionTimeout (locks transInfo) -> sendObjectRequest -> ? -> setupTransaction (locks uavtalk)
            lock (updateObjReqSyncLock)
            {
			    if(respObj != null && respType == TYPE_OBJ_REQ && respObj.getObjID() == obj.getObjID() &&
					    ((respObj.getInstID() == obj.getInstID() || !respAllInstances))) {

				    // Indicate complete
				    respObj = null;
				    succeeded = true;
			    }
		    }

		    // Notify listener
		    if (succeeded && transactionListener != null)
				    transactionListener.TransactionSucceeded(obj);
	    }

        private UAVObject updateObject(uint objId, uint instId, ByteBuffer data)
        {
            // Get object
            UAVObject obj = objMgr.getObject(objId, instId);

            // If the instance does not exist create it
            if (obj == null)
            {
                // Get the object type
                UAVObject tobj = objMgr.getObject(objId);
                if (tobj == null)
                {
                    // TODO: Return a NAK since we don't know this object
                    return null;
                }
                // Make sure this is a data object
                UAVDataObject dobj = null;
                try
                {
                    dobj = (UAVDataObject)tobj;
                }
                catch (Exception)
                {
                    // Failed to cast to a data object
                    return null;
                }

                // Create a new instance, unpack and register
                UAVDataObject instobj = dobj.clone(instId);
                try
                {
                    if (!objMgr.registerObject(instobj))
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    // TODO Auto-generated catch block
                    Debug.WriteLine(e.Message);
                }
                //Debug.WriteLine("Unpacking new object");
                instobj.unpack(data);
                return instobj;
            }
            else
            {
                // Unpack data into object instance
                //Debug.WriteLine( "Unpacking existing object: " + obj.getName());
                obj.unpack(data);
                return obj;
            }
        }

        private int updateCRC(int crc, int data)
        {
            return crc_table[crc ^ (data & 0xff)];
        }

        private int updateCRC(int crc, byte[] data, int length)
        {
            for (int i = 0; i < length; i++)
                crc = updateCRC(crc, data[i]);
            return crc;
        }

        private OnTransactionCompletedListener transactionListener = null;
        public abstract class OnTransactionCompletedListener
        {
            public abstract void TransactionSucceeded(UAVObject data);
            public abstract void TransactionFailed(UAVObject data);
        };

        void setOnTransactionCompletedListener(OnTransactionCompletedListener onTransactionListener)
        {
            this.transactionListener = onTransactionListener;
        }

    }
}

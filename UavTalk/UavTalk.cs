using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UavTalk.parser;

namespace UavTalk
{
    public class UavTalkProto
    {
        private ICommChannel ch;
        
        private UAVObjectManager objMgr;
                
        private UAVObject respObj;
        private int respType;
        private bool respAllInstances;
        private Timer statTimer;
        private int receivedbytes;
        private UavDataparser parser;
        private ComStats txStats;

        public UavTalkProto(ICommChannel communicationChannel, UAVObjectManager objMgr)
        {
            this.objMgr = objMgr;
            parser = new UavDataparser(objMgr);
            parser.onObjectReceived += new UavDataparser.onObjectReceivedDelegate(parser_onObjectReceived);
            txStats = new ComStats();
            ch = communicationChannel;
            ch.onDataReceived += ch_onDataReceived;
            statTimer = new Timer(1000);
            statTimer.Elapsed += statTimer_Elapsed;
            statTimer.Start();
        }
        
        void statTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int bs = parser.stats.Bytes - receivedbytes;
            Debug.WriteLine("Received {0} B/s", bs);
            receivedbytes = parser.stats.Bytes;
        }

        public bool sendObjectRequest(UAVObject obj, bool allInstances) {
		    return objectTransaction(obj, uavConsts.TYPE_OBJ_REQ, allInstances);
	    }

        public bool sendObject(UAVObject obj, bool acked, bool allInstances) {
		    if (acked) {
                return objectTransaction(obj, uavConsts.TYPE_OBJ_ACK, allInstances);
		    } else {
                return objectTransaction(obj, uavConsts.TYPE_OBJ, allInstances);
		    }
	    }
        
        private bool objectTransaction(UAVObject obj, int type, bool allInstances) {
            if (type == uavConsts.TYPE_OBJ_ACK || type == uavConsts.TYPE_OBJ_REQ || type == uavConsts.TYPE_OBJ)
            {
			    return transmitObject(obj, type, allInstances);
		    } else {
			    return false;
		    }
	    }

        void ch_onDataReceived(byte[] data)
        {
            foreach (byte b in data)
                parser.processInputByte(b);
        }

        void parser_onObjectReceived(int type, uint objId, uint instId, uint timestamp, ByteBuffer data)
        {
            //Debug.WriteLine("Received object ID: " + objId);
            bool error = false;
            UAVObject obj = null;
            bool allInstances = (instId == uavConsts.ALL_INSTANCES ? true : false);

            // Process message type
            switch (type)
            {
                case uavConsts.TYPE_OBJ:
                    // All instances, not allowed for OBJ messages
                    if (!allInstances)
                    {
                        //Debug.WriteLine(string.Format( "{0:ss:fff} Received object: {1}" ,DateTime.Now, objMgr.getObject(objId).getName()));

                        // Get object and update its data
                        obj = updateObject(objId, instId, data);
                        
                        if (obj != null)
                        {
                            obj.timestamp = timestamp;
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
                case uavConsts.TYPE_OBJ_ACK:
                    // All instances, not allowed for OBJ_ACK messages
                    if (!allInstances)
                    {
                        Debug.WriteLine("Received object ack: " + objId + " " + objMgr.getObject(objId).getName());
                        // Get object and update its data
                        obj = updateObject(objId, instId, data);
                        // Transmit ACK
                        if (obj != null)
                        {
                            transmitObject(obj, uavConsts.TYPE_ACK, false);
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
                case uavConsts.TYPE_OBJ_REQ:
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
                        transmitObject(obj, uavConsts.TYPE_OBJ, allInstances);
                    }
                    else
                    {
                        error = true;
                    }
                    break;
                case uavConsts.TYPE_NACK:
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
                case uavConsts.TYPE_ACK:
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
            //return error;
        }

        /**
	     * Check if a transaction is pending and if yes complete it.
	     */
        private readonly object receivedNackSyncLock = new object();
	    private void receivedNack(UAVObject obj)
	    {
            lock (receivedNackSyncLock)
            {
                if (respObj != null && (respType == uavConsts.TYPE_OBJ_REQ || respType == uavConsts.TYPE_OBJ_ACK) &&
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
            if (type == uavConsts.TYPE_OBJ || type == uavConsts.TYPE_OBJ_ACK)
            {
			    if (allInstances) {
				    // Get number of instances
				    int numInst = objMgr.getNumInstances(obj.getObjID());
				    // Send all instances
				    for (int instId = 0; instId < numInst; ++instId) {
					    // TODO: This code is buggy probably.  We should send each request
					    // and wait for an ack in the case of an TYPE_OBJ_ACK
                        Debug.Assert(type != uavConsts.TYPE_OBJ_ACK); // catch any buggy calls

					    UAVObject inst = objMgr.getObject(obj.getObjID(), instId);
					    transmitSingleObject(inst, type, false);
				    }
				    return true;
			    } else {
				    return transmitSingleObject(obj, type, false);
			    }
            }
            else if (type == uavConsts.TYPE_OBJ_REQ)
            {
                return transmitSingleObject(obj, uavConsts.TYPE_OBJ_REQ, allInstances);
            }
            else if (type == uavConsts.TYPE_ACK)
            {
			    if (!allInstances) {
                    return transmitSingleObject(obj, uavConsts.TYPE_ACK, false);
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
            int allInstId = uavConsts.ALL_INSTANCES;

            ByteBuffer bbuf = new ByteBuffer(uavConsts.MAX_PACKET_LENGTH);
            
            // Determine data length
            if (type == uavConsts.TYPE_OBJ_REQ || type == uavConsts.TYPE_ACK)
            {
                length = 0;
            }
            else
            {
                length = obj.getNumBytes();
            }

            // Setup type and object id fields
            bbuf.put((byte)(uavConsts.SYNC_VAL & 0xff));
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
            if (length >= uavConsts.MAX_PAYLOAD_LENGTH)
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
            bbuf.put((byte)(CRC.updateCRC(0, bbuf.array(), bbuf.position()) & 0xff));

            int packlen = bbuf.position();
            bbuf.position(0);
            byte[] dst = new byte[packlen];
            bbuf.get(dst, 0, packlen);

            if (type == uavConsts.TYPE_OBJ_ACK || type == uavConsts.TYPE_OBJ_REQ)
            {
                // Once we send a UAVTalk packet that requires an ack or object let's set up
                // the transaction here
                setupTransaction(obj, allInstances, type);
            }

            ch.write(dst);


            // Update stats
            ++txStats.Objects;
            txStats.Bytes += bbuf.position();
            txStats.ObjectBytes += length;

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
			    if(respObj != null && respType == uavConsts.TYPE_OBJ_REQ && respObj.getObjID() == obj.getObjID() &&
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

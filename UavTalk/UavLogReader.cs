using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UavTalk
{
    public class UavLogReader
    {
        private parser.UavDataparser parser;
        private UAVObjectManager _objmgr;
        private List<UAVObject> retVal = new List<UAVObject>();

        public UavLogReader(UAVObjectManager mgr)
        {
            _objmgr = mgr;
            parser = new parser.UavDataparser(mgr);
            parser.onObjectReceived += new UavTalk.parser.UavDataparser.onObjectReceivedDelegate(parser_onObjectReceived);
        }

        public List<UAVObject> parseFile(string logFile)
        {
            retVal = new List<UAVObject>();
            FileStream reader = File.OpenRead(logFile);
            byte[] data = new byte[1];
            int count;
            
            while ((count = reader.Read(data, 0, 1)) > 0)
            {
                parser.processInputByte(data[0]);
            }

            return retVal;
        }

        void parser_onObjectReceived(int type, uint objId, uint instId, uint timestamp, ByteBuffer data)
        {
            UAVObject tobj = _objmgr.getObject(objId);
            if (tobj == null)
            {
                // TODO: Return a NAK since we don't know this object
                return;
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
                return;
            }

            // Create a new instance, unpack and register
            UAVDataObject instobj = dobj.clone(instId);
            instobj.unpack(data);
            instobj.timestamp = timestamp;
            retVal.Add(instobj);
        }
        
    }
}

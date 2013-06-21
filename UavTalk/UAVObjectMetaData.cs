using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UavTalk.enums;

namespace UavTalk
{
  
    public class UAVObjectMetaData {

	    public static String getAccessString(AccessMode access_mode) {
		    switch (access_mode) {
		    case AccessMode.ACCESS_READWRITE:
			    return "Read/Write";
            //case AccessMode.ACCESS_WRITEONLY:
			//    return "Write only";
            case AccessMode.ACCESS_READONLY:
			    return "Read only";
		    default:
			    return "unknowm Access Mode";
		    }
	    }
	
	   
	    public static String getUpdateModeString(UpdateMode update_mode) {
		    switch(update_mode) {
		    case UpdateMode.UPDATEMODE_NEVER:
			    return "never";
            case UpdateMode.UPDATEMODE_MANUAL:
			    return "manual";
            case UpdateMode.UPDATEMODE_ONCHANGE:
			    return "on change";
            case UpdateMode.UPDATEMODE_PERIODIC:
			    return "periodic";
		    default:
			    return "unknown";
			
		    }
	    }
	
	    public const bool TRUE=true;
	    public const bool FALSE=false;
	
	    /* constant */
	    public byte gcsAccess;
        public bool gcsTelemetryAcked;
        public byte gcsTelemetryUpdateMode;
        public int gcsTelemetryUpdatePeriod;
      
        public byte flightAccess;
        public bool flightTelemetryAcked;
        public byte  flightTelemetryUpdateMode;
        public int flightTelemetryUpdatePeriod;
      
        public byte loggingUpdateMode;
        public int loggingUpdatePeriod;

        /* changing */
        public long last_serialize;
        public long last_deserialize;
    
        public long last_log;
        public long last_gcs_update;
        public long last_fligt_update;

        public long last_send_time;

        public bool gcs_flight_was_acked = false;
        public bool gcs_ground_was_acked = false;

        public bool req_pending = false;
        public bool ack_pending = false;
    }

}

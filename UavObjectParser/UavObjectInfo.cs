using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UavObjectParser;

namespace UavObjectParser
{
    public class UavObjectInfo
    {
        public string name { get; set; }
        public string filename { get;set; }
        public UInt32 id { get;set; }
        public bool isSingleInst { get;set; }
        public bool isSettings {get;set; }
        public AccessMode gcsAccess {get;set;}
        public AccessMode flightAccess {get;set;}
        public bool flightTelemetryAcked { get; set; }
        public UPDATEMODE flightTelemetryUpdateMode { get; set; } /** Update mode used by the autopilot (UpdateMode) */
        public int flightTelemetryUpdatePeriod { get; set; } /** Update period used by the autopilot (only if telemetry mode is PERIODIC) */
        public bool gcsTelemetryAcked { get; set; }
        public UPDATEMODE gcsTelemetryUpdateMode{ get; set; } /** Update mode used by the GCS (UpdateMode) */
        public int gcsTelemetryUpdatePeriod { get; set; } /** Update period used by the GCS (only if telemetry mode is PERIODIC) */
        public UPDATEMODE loggingUpdateMode { get; set; } /** Update mode used by the logging module (UpdateMode) */
        public int loggingUpdatePeriod { get; set; } /** Update period used by the logging module (only if logging mode is PERIODIC) */
        public List<FieldInfo> fields { get; set; } /** The data fields for the object **/
        public String description { get; set; } /** Description used for Doxygen **/
        public String category { get; set; } /** Description used for Doxygen **/

        public UavObjectInfo()
        {
            fields = new List<FieldInfo>();
        }
    }    
} 

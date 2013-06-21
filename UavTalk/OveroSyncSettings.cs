// Object ID: 2712388216
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class OveroSyncSettings : UAVDataObject
	{
		public const long OBJID = 2712388216;
		public int NUMBYTES { get; set; }
		protected const String NAME = "OveroSyncSettings";
	    protected static String DESCRIPTION = @"Settings to control the behavior of the overo sync module";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public enum LogOnUavEnum
		{
			[Description("Never")]
			Never = 0, 
			[Description("Always")]
			Always = 1, 
			[Description("Armed")]
			Armed = 2, 
		}
		public UAVObjectField<LogOnUavEnum> LogOn;

		public OveroSyncSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> LogOnElemNames = new List<String>();
			LogOnElemNames.Add("0");
			List<String> LogOnEnumOptions = new List<String>();
			LogOnEnumOptions.Add("Never");
			LogOnEnumOptions.Add("Always");
			LogOnEnumOptions.Add("Armed");
			LogOn=new UAVObjectField<LogOnUavEnum>("LogOn", "", LogOnElemNames, LogOnEnumOptions, this);
			fields.Add(LogOn);

	

			// Compute the number of bytes for this object
            NUMBYTES = fields.Sum(j => j.getNumBytes());
			
			// Initialize object
			initializeFields(fields, new ByteBuffer(NUMBYTES), NUMBYTES);
			// Set the default field values
			setDefaultFieldValues();
			// Set the object description
			setDescription(DESCRIPTION);
		}

		/**
		 * Create a Metadata object filled with default values for this object
		 * @return Metadata object with default values
		 */
		public override Metadata getDefaultMetadata() {
			Metadata metadata = new Metadata();
    		metadata.flags =
				(int)AccessMode.ACCESS_READWRITE << Metadata.UAVOBJ_ACCESS_SHIFT |
				(int)AccessMode.ACCESS_READWRITE << Metadata.UAVOBJ_GCS_ACCESS_SHIFT |
				0 << Metadata.UAVOBJ_TELEMETRY_ACKED_SHIFT |
				0 << Metadata.UAVOBJ_GCS_TELEMETRY_ACKED_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_ONCHANGE << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_MANUAL << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
    		metadata.flightTelemetryUpdatePeriod = 0;
    		metadata.gcsTelemetryUpdatePeriod = 0;
    		metadata.loggingUpdatePeriod = 1000;
 
			return metadata;
		}

		/**
		 * Initialize object fields with the default values.
		 * If a default value is not specified the object fields
		 * will be initialized to zero.
		 */
		public void setDefaultFieldValues()
		{
			LogOn.setValue(LogOnUavEnum.Armed);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				OveroSyncSettings obj = new OveroSyncSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public OveroSyncSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (OveroSyncSettings)(objMngr.getObject(OveroSyncSettings.OBJID, instID));
		}
	}
}

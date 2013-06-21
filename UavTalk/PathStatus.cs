// Object ID: 11292708
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class PathStatus : UAVDataObject
	{
		public const long OBJID = 11292708;
		public int NUMBYTES { get; set; }
		protected const String NAME = "PathStatus";
	    protected static String DESCRIPTION = @"Status of the current path mode  Can come from any @ref PathFollower module";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> fractional_progress;
		public UAVObjectField<float> error;
		public enum StatusUavEnum
		{
			[Description("InProgress")]
			InProgress = 0, 
			[Description("Completed")]
			Completed = 1, 
			[Description("Warning")]
			Warning = 2, 
			[Description("Critical")]
			Critical = 3, 
		}
		public UAVObjectField<StatusUavEnum> Status;

		public PathStatus() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> fractional_progressElemNames = new List<String>();
			fractional_progressElemNames.Add("0");
			fractional_progress=new UAVObjectField<float>("fractional_progress", "", fractional_progressElemNames, null, this);
			fields.Add(fractional_progress);

			List<String> errorElemNames = new List<String>();
			errorElemNames.Add("0");
			error=new UAVObjectField<float>("error", "m", errorElemNames, null, this);
			fields.Add(error);

			List<String> StatusElemNames = new List<String>();
			StatusElemNames.Add("0");
			List<String> StatusEnumOptions = new List<String>();
			StatusEnumOptions.Add("InProgress");
			StatusEnumOptions.Add("Completed");
			StatusEnumOptions.Add("Warning");
			StatusEnumOptions.Add("Critical");
			Status=new UAVObjectField<StatusUavEnum>("Status", "", StatusElemNames, StatusEnumOptions, this);
			fields.Add(Status);

	

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
    		metadata.loggingUpdatePeriod = 0;
 
			return metadata;
		}

		/**
		 * Initialize object fields with the default values.
		 * If a default value is not specified the object fields
		 * will be initialized to zero.
		 */
		public void setDefaultFieldValues()
		{
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				PathStatus obj = new PathStatus();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public PathStatus GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (PathStatus)(objMngr.getObject(PathStatus.OBJID, instID));
		}
	}
}

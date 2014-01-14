// Object ID: 1339817706
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class StabilizationDesired : UAVDataObject
	{
		public const long OBJID = 1339817706;
		public int NUMBYTES { get; set; }
		protected const String NAME = "StabilizationDesired";
	    protected static String DESCRIPTION = @"The desired attitude that @ref StabilizationModule will try and achieve if FlightMode is Stabilized.  Comes from @ref ManaulControlModule.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> Roll;
		public UAVObjectField<float> Pitch;
		public UAVObjectField<float> Yaw;
		public UAVObjectField<float> Throttle;
		public enum StabilizationModeUavEnum
		{
			[Description("None")]
			None = 0, 
			[Description("Rate")]
			Rate = 1, 
			[Description("Attitude")]
			Attitude = 2, 
			[Description("AxisLock")]
			AxisLock = 3, 
			[Description("WeakLeveling")]
			WeakLeveling = 4, 
			[Description("VirtualBar")]
			VirtualBar = 5, 
			[Description("RelayRate")]
			RelayRate = 6, 
			[Description("RelayAttitude")]
			RelayAttitude = 7, 
		}
		public UAVObjectField<StabilizationModeUavEnum> StabilizationMode;

		public StabilizationDesired() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> RollElemNames = new List<String>();
			RollElemNames.Add("0");
			Roll=new UAVObjectField<float>("Roll", "degrees", RollElemNames, null, this);
			fields.Add(Roll);

			List<String> PitchElemNames = new List<String>();
			PitchElemNames.Add("0");
			Pitch=new UAVObjectField<float>("Pitch", "degrees", PitchElemNames, null, this);
			fields.Add(Pitch);

			List<String> YawElemNames = new List<String>();
			YawElemNames.Add("0");
			Yaw=new UAVObjectField<float>("Yaw", "degrees", YawElemNames, null, this);
			fields.Add(Yaw);

			List<String> ThrottleElemNames = new List<String>();
			ThrottleElemNames.Add("0");
			Throttle=new UAVObjectField<float>("Throttle", "%", ThrottleElemNames, null, this);
			fields.Add(Throttle);

			List<String> StabilizationModeElemNames = new List<String>();
			StabilizationModeElemNames.Add("Roll");
			StabilizationModeElemNames.Add("Pitch");
			StabilizationModeElemNames.Add("Yaw");
			List<String> StabilizationModeEnumOptions = new List<String>();
			StabilizationModeEnumOptions.Add("None");
			StabilizationModeEnumOptions.Add("Rate");
			StabilizationModeEnumOptions.Add("Attitude");
			StabilizationModeEnumOptions.Add("AxisLock");
			StabilizationModeEnumOptions.Add("WeakLeveling");
			StabilizationModeEnumOptions.Add("VirtualBar");
			StabilizationModeEnumOptions.Add("RelayRate");
			StabilizationModeEnumOptions.Add("RelayAttitude");
			StabilizationMode=new UAVObjectField<StabilizationModeUavEnum>("StabilizationMode", "", StabilizationModeElemNames, StabilizationModeEnumOptions, this);
			fields.Add(StabilizationMode);

	

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
				(int)UPDATEMODE.UPDATEMODE_PERIODIC << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_MANUAL << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
    		metadata.flightTelemetryUpdatePeriod = 1000;
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
				StabilizationDesired obj = new StabilizationDesired();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public StabilizationDesired GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (StabilizationDesired)(objMngr.getObject(StabilizationDesired.OBJID, instID));
		}
	}
}

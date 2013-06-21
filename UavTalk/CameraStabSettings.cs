// Object ID: 4194936090
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class CameraStabSettings : UAVDataObject
	{
		public const long OBJID = 4194936090;
		public int NUMBYTES { get; set; }
		protected const String NAME = "CameraStabSettings";
	    protected static String DESCRIPTION = @"Settings for the @ref CameraStab mmodule";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> MaxAxisLockRate;
		public UAVObjectField<float> MaxAccel;
		public enum InputUavEnum
		{
			[Description("Accessory0")]
			Accessory0 = 0, 
			[Description("Accessory1")]
			Accessory1 = 1, 
			[Description("Accessory2")]
			Accessory2 = 2, 
			[Description("Accessory3")]
			Accessory3 = 3, 
			[Description("Accessory4")]
			Accessory4 = 4, 
			[Description("Accessory5")]
			Accessory5 = 5, 
			[Description("POI")]
			POI = 6, 
			[Description("None")]
			None = 7, 
		}
		public UAVObjectField<InputUavEnum> Input;
		public UAVObjectField<byte> InputRange;
		public UAVObjectField<byte> InputRate;
		public UAVObjectField<byte> OutputRange;
		public UAVObjectField<byte> FeedForward;
		public enum StabilizationModeUavEnum
		{
			[Description("Attitude")]
			Attitude = 0, 
			[Description("AxisLock")]
			AxisLock = 1, 
		}
		public UAVObjectField<StabilizationModeUavEnum> StabilizationMode;
		public UAVObjectField<byte> AttitudeFilter;
		public UAVObjectField<byte> InputFilter;
		public UAVObjectField<byte> FeedForwardTime;

		public CameraStabSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> MaxAxisLockRateElemNames = new List<String>();
			MaxAxisLockRateElemNames.Add("0");
			MaxAxisLockRate=new UAVObjectField<float>("MaxAxisLockRate", "deg/s", MaxAxisLockRateElemNames, null, this);
			fields.Add(MaxAxisLockRate);

			List<String> MaxAccelElemNames = new List<String>();
			MaxAccelElemNames.Add("0");
			MaxAccel=new UAVObjectField<float>("MaxAccel", "units/sec", MaxAccelElemNames, null, this);
			fields.Add(MaxAccel);

			List<String> InputElemNames = new List<String>();
			InputElemNames.Add("Roll");
			InputElemNames.Add("Pitch");
			InputElemNames.Add("Yaw");
			List<String> InputEnumOptions = new List<String>();
			InputEnumOptions.Add("Accessory0");
			InputEnumOptions.Add("Accessory1");
			InputEnumOptions.Add("Accessory2");
			InputEnumOptions.Add("Accessory3");
			InputEnumOptions.Add("Accessory4");
			InputEnumOptions.Add("Accessory5");
			InputEnumOptions.Add("POI");
			InputEnumOptions.Add("None");
			Input=new UAVObjectField<InputUavEnum>("Input", "channel", InputElemNames, InputEnumOptions, this);
			fields.Add(Input);

			List<String> InputRangeElemNames = new List<String>();
			InputRangeElemNames.Add("Roll");
			InputRangeElemNames.Add("Pitch");
			InputRangeElemNames.Add("Yaw");
			InputRange=new UAVObjectField<byte>("InputRange", "deg", InputRangeElemNames, null, this);
			fields.Add(InputRange);

			List<String> InputRateElemNames = new List<String>();
			InputRateElemNames.Add("Roll");
			InputRateElemNames.Add("Pitch");
			InputRateElemNames.Add("Yaw");
			InputRate=new UAVObjectField<byte>("InputRate", "deg/s", InputRateElemNames, null, this);
			fields.Add(InputRate);

			List<String> OutputRangeElemNames = new List<String>();
			OutputRangeElemNames.Add("Roll");
			OutputRangeElemNames.Add("Pitch");
			OutputRangeElemNames.Add("Yaw");
			OutputRange=new UAVObjectField<byte>("OutputRange", "deg", OutputRangeElemNames, null, this);
			fields.Add(OutputRange);

			List<String> FeedForwardElemNames = new List<String>();
			FeedForwardElemNames.Add("Roll");
			FeedForwardElemNames.Add("Pitch");
			FeedForwardElemNames.Add("Yaw");
			FeedForward=new UAVObjectField<byte>("FeedForward", "", FeedForwardElemNames, null, this);
			fields.Add(FeedForward);

			List<String> StabilizationModeElemNames = new List<String>();
			StabilizationModeElemNames.Add("Roll");
			StabilizationModeElemNames.Add("Pitch");
			StabilizationModeElemNames.Add("Yaw");
			List<String> StabilizationModeEnumOptions = new List<String>();
			StabilizationModeEnumOptions.Add("Attitude");
			StabilizationModeEnumOptions.Add("AxisLock");
			StabilizationMode=new UAVObjectField<StabilizationModeUavEnum>("StabilizationMode", "", StabilizationModeElemNames, StabilizationModeEnumOptions, this);
			fields.Add(StabilizationMode);

			List<String> AttitudeFilterElemNames = new List<String>();
			AttitudeFilterElemNames.Add("0");
			AttitudeFilter=new UAVObjectField<byte>("AttitudeFilter", "ms", AttitudeFilterElemNames, null, this);
			fields.Add(AttitudeFilter);

			List<String> InputFilterElemNames = new List<String>();
			InputFilterElemNames.Add("0");
			InputFilter=new UAVObjectField<byte>("InputFilter", "ms", InputFilterElemNames, null, this);
			fields.Add(InputFilter);

			List<String> FeedForwardTimeElemNames = new List<String>();
			FeedForwardTimeElemNames.Add("0");
			FeedForwardTime=new UAVObjectField<byte>("FeedForwardTime", "ms", FeedForwardTimeElemNames, null, this);
			fields.Add(FeedForwardTime);

	

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
				1 << Metadata.UAVOBJ_TELEMETRY_ACKED_SHIFT |
				1 << Metadata.UAVOBJ_GCS_TELEMETRY_ACKED_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_ONCHANGE << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_ONCHANGE << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
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
			MaxAxisLockRate.setValue((float)1);
			MaxAccel.setValue((float)1000);
			Input.setValue(InputUavEnum.None,0);
			Input.setValue(InputUavEnum.None,1);
			Input.setValue(InputUavEnum.None,2);
			InputRange.setValue((byte)20,0);
			InputRange.setValue((byte)20,1);
			InputRange.setValue((byte)20,2);
			InputRate.setValue((byte)50,0);
			InputRate.setValue((byte)50,1);
			InputRate.setValue((byte)50,2);
			OutputRange.setValue((byte)20,0);
			OutputRange.setValue((byte)20,1);
			OutputRange.setValue((byte)20,2);
			FeedForward.setValue((byte)0,0);
			FeedForward.setValue((byte)0,1);
			FeedForward.setValue((byte)0,2);
			StabilizationMode.setValue(StabilizationModeUavEnum.Attitude,0);
			StabilizationMode.setValue(StabilizationModeUavEnum.Attitude,1);
			StabilizationMode.setValue(StabilizationModeUavEnum.Attitude,2);
			AttitudeFilter.setValue((byte)0);
			InputFilter.setValue((byte)0);
			FeedForwardTime.setValue((byte)0);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				CameraStabSettings obj = new CameraStabSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public CameraStabSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (CameraStabSettings)(objMngr.getObject(CameraStabSettings.OBJID, instID));
		}
	}
}

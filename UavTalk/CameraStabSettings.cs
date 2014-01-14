// Object ID: 3931694394
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
		public const long OBJID = 3931694394;
		public int NUMBYTES { get; set; }
		protected const String NAME = "CameraStabSettings";
	    protected static String DESCRIPTION = @"Settings for the @ref CameraStab mmodule";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> MaxAxisLockRate;
		public UAVObjectField<UInt16> MaxAccel;
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
			[Description("None")]
			None = 6, 
		}
		public UAVObjectField<InputUavEnum> Input;
		public UAVObjectField<byte> InputRange;
		public UAVObjectField<byte> InputRate;
		public enum StabilizationModeUavEnum
		{
			[Description("Attitude")]
			Attitude = 0, 
			[Description("AxisLock")]
			AxisLock = 1, 
		}
		public UAVObjectField<StabilizationModeUavEnum> StabilizationMode;
		public UAVObjectField<byte> OutputRange;
		public UAVObjectField<byte> ResponseTime;
		public enum GimbalTypeUavEnum
		{
			[Description("Generic")]
			Generic = 0, 
			[Description("Yaw-Roll-Pitch")]
			YawRollPitch = 1, 
			[Description("Yaw-Pitch-Roll")]
			YawPitchRoll = 2, 
			[Description("Roll-Pitch-Mixed")]
			RollPitchMixed = 3, 
		}
		public UAVObjectField<GimbalTypeUavEnum> GimbalType;
		public UAVObjectField<byte> FeedForward;
		public UAVObjectField<byte> AccelTime;
		public UAVObjectField<byte> DecelTime;
		public enum Servo1PitchReverseUavEnum
		{
			[Description("FALSE")]
			FALSE = 0, 
			[Description("TRUE")]
			TRUE = 1, 
		}
		public UAVObjectField<Servo1PitchReverseUavEnum> Servo1PitchReverse;
		public enum Servo2PitchReverseUavEnum
		{
			[Description("FALSE")]
			FALSE = 0, 
			[Description("TRUE")]
			TRUE = 1, 
		}
		public UAVObjectField<Servo2PitchReverseUavEnum> Servo2PitchReverse;

		public CameraStabSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> MaxAxisLockRateElemNames = new List<String>();
			MaxAxisLockRateElemNames.Add("0");
			MaxAxisLockRate=new UAVObjectField<float>("MaxAxisLockRate", "deg/s", MaxAxisLockRateElemNames, null, this);
			fields.Add(MaxAxisLockRate);

			List<String> MaxAccelElemNames = new List<String>();
			MaxAccelElemNames.Add("0");
			MaxAccel=new UAVObjectField<UInt16>("MaxAccel", "units/sec", MaxAccelElemNames, null, this);
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

			List<String> StabilizationModeElemNames = new List<String>();
			StabilizationModeElemNames.Add("Roll");
			StabilizationModeElemNames.Add("Pitch");
			StabilizationModeElemNames.Add("Yaw");
			List<String> StabilizationModeEnumOptions = new List<String>();
			StabilizationModeEnumOptions.Add("Attitude");
			StabilizationModeEnumOptions.Add("AxisLock");
			StabilizationMode=new UAVObjectField<StabilizationModeUavEnum>("StabilizationMode", "", StabilizationModeElemNames, StabilizationModeEnumOptions, this);
			fields.Add(StabilizationMode);

			List<String> OutputRangeElemNames = new List<String>();
			OutputRangeElemNames.Add("Roll");
			OutputRangeElemNames.Add("Pitch");
			OutputRangeElemNames.Add("Yaw");
			OutputRange=new UAVObjectField<byte>("OutputRange", "deg", OutputRangeElemNames, null, this);
			fields.Add(OutputRange);

			List<String> ResponseTimeElemNames = new List<String>();
			ResponseTimeElemNames.Add("Roll");
			ResponseTimeElemNames.Add("Pitch");
			ResponseTimeElemNames.Add("Yaw");
			ResponseTime=new UAVObjectField<byte>("ResponseTime", "ms", ResponseTimeElemNames, null, this);
			fields.Add(ResponseTime);

			List<String> GimbalTypeElemNames = new List<String>();
			GimbalTypeElemNames.Add("0");
			List<String> GimbalTypeEnumOptions = new List<String>();
			GimbalTypeEnumOptions.Add("Generic");
			GimbalTypeEnumOptions.Add("Yaw-Roll-Pitch");
			GimbalTypeEnumOptions.Add("Yaw-Pitch-Roll");
			GimbalTypeEnumOptions.Add("Roll-Pitch-Mixed");
			GimbalType=new UAVObjectField<GimbalTypeUavEnum>("GimbalType", "", GimbalTypeElemNames, GimbalTypeEnumOptions, this);
			fields.Add(GimbalType);

			List<String> FeedForwardElemNames = new List<String>();
			FeedForwardElemNames.Add("Roll");
			FeedForwardElemNames.Add("Pitch");
			FeedForwardElemNames.Add("Yaw");
			FeedForward=new UAVObjectField<byte>("FeedForward", "", FeedForwardElemNames, null, this);
			fields.Add(FeedForward);

			List<String> AccelTimeElemNames = new List<String>();
			AccelTimeElemNames.Add("Roll");
			AccelTimeElemNames.Add("Pitch");
			AccelTimeElemNames.Add("Yaw");
			AccelTime=new UAVObjectField<byte>("AccelTime", "ms", AccelTimeElemNames, null, this);
			fields.Add(AccelTime);

			List<String> DecelTimeElemNames = new List<String>();
			DecelTimeElemNames.Add("Roll");
			DecelTimeElemNames.Add("Pitch");
			DecelTimeElemNames.Add("Yaw");
			DecelTime=new UAVObjectField<byte>("DecelTime", "ms", DecelTimeElemNames, null, this);
			fields.Add(DecelTime);

			List<String> Servo1PitchReverseElemNames = new List<String>();
			Servo1PitchReverseElemNames.Add("0");
			List<String> Servo1PitchReverseEnumOptions = new List<String>();
			Servo1PitchReverseEnumOptions.Add("FALSE");
			Servo1PitchReverseEnumOptions.Add("TRUE");
			Servo1PitchReverse=new UAVObjectField<Servo1PitchReverseUavEnum>("Servo1PitchReverse", "", Servo1PitchReverseElemNames, Servo1PitchReverseEnumOptions, this);
			fields.Add(Servo1PitchReverse);

			List<String> Servo2PitchReverseElemNames = new List<String>();
			Servo2PitchReverseElemNames.Add("0");
			List<String> Servo2PitchReverseEnumOptions = new List<String>();
			Servo2PitchReverseEnumOptions.Add("FALSE");
			Servo2PitchReverseEnumOptions.Add("TRUE");
			Servo2PitchReverse=new UAVObjectField<Servo2PitchReverseUavEnum>("Servo2PitchReverse", "", Servo2PitchReverseElemNames, Servo2PitchReverseEnumOptions, this);
			fields.Add(Servo2PitchReverse);

	

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
			MaxAccel.setValue((UInt16)500);
			Input.setValue(InputUavEnum.None,0);
			Input.setValue(InputUavEnum.None,1);
			Input.setValue(InputUavEnum.None,2);
			InputRange.setValue((byte)20,0);
			InputRange.setValue((byte)20,1);
			InputRange.setValue((byte)20,2);
			InputRate.setValue((byte)50,0);
			InputRate.setValue((byte)50,1);
			InputRate.setValue((byte)50,2);
			StabilizationMode.setValue(StabilizationModeUavEnum.Attitude,0);
			StabilizationMode.setValue(StabilizationModeUavEnum.Attitude,1);
			StabilizationMode.setValue(StabilizationModeUavEnum.Attitude,2);
			OutputRange.setValue((byte)20,0);
			OutputRange.setValue((byte)20,1);
			OutputRange.setValue((byte)20,2);
			ResponseTime.setValue((byte)0,0);
			ResponseTime.setValue((byte)0,1);
			ResponseTime.setValue((byte)0,2);
			GimbalType.setValue(GimbalTypeUavEnum.Generic);
			FeedForward.setValue((byte)0,0);
			FeedForward.setValue((byte)0,1);
			FeedForward.setValue((byte)0,2);
			AccelTime.setValue((byte)5,0);
			AccelTime.setValue((byte)5,1);
			AccelTime.setValue((byte)5,2);
			DecelTime.setValue((byte)5,0);
			DecelTime.setValue((byte)5,1);
			DecelTime.setValue((byte)5,2);
			Servo1PitchReverse.setValue(Servo1PitchReverseUavEnum.FALSE);
			Servo2PitchReverse.setValue(Servo2PitchReverseUavEnum.FALSE);
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

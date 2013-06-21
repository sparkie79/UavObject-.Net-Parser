// Object ID: 1119015598
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class TxPIDSettings : UAVDataObject
	{
		public const long OBJID = 1119015598;
		public int NUMBYTES { get; set; }
		protected const String NAME = "TxPIDSettings";
	    protected static String DESCRIPTION = @"Settings used by @ref TxPID optional module to tune PID settings using R/C transmitter";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> ThrottleRange;
		public UAVObjectField<float> MinPID;
		public UAVObjectField<float> MaxPID;
		public enum UpdateModeUavEnum
		{
			[Description("Never")]
			Never = 0, 
			[Description("When Armed")]
			WhenArmed = 1, 
			[Description("Always")]
			Always = 2, 
		}
		public UAVObjectField<UpdateModeUavEnum> UpdateMode;
		public enum InputsUavEnum
		{
			[Description("Throttle")]
			Throttle = 0, 
			[Description("Accessory0")]
			Accessory0 = 1, 
			[Description("Accessory1")]
			Accessory1 = 2, 
			[Description("Accessory2")]
			Accessory2 = 3, 
			[Description("Accessory3")]
			Accessory3 = 4, 
			[Description("Accessory4")]
			Accessory4 = 5, 
			[Description("Accessory5")]
			Accessory5 = 6, 
		}
		public UAVObjectField<InputsUavEnum> Inputs;
		public enum PIDsUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Roll Rate.Kp")]
			RollRateKp = 1, 
			[Description("Pitch Rate.Kp")]
			PitchRateKp = 2, 
			[Description("Roll+Pitch Rate.Kp")]
			RollPitchRateKp = 3, 
			[Description("Yaw Rate.Kp")]
			YawRateKp = 4, 
			[Description("Roll Rate.Ki")]
			RollRateKi = 5, 
			[Description("Pitch Rate.Ki")]
			PitchRateKi = 6, 
			[Description("Roll+Pitch Rate.Ki")]
			RollPitchRateKi = 7, 
			[Description("Yaw Rate.Ki")]
			YawRateKi = 8, 
			[Description("Roll Rate.Kd")]
			RollRateKd = 9, 
			[Description("Pitch Rate.Kd")]
			PitchRateKd = 10, 
			[Description("Roll+Pitch Rate.Kd")]
			RollPitchRateKd = 11, 
			[Description("Yaw Rate.Kd")]
			YawRateKd = 12, 
			[Description("Roll Rate.ILimit")]
			RollRateILimit = 13, 
			[Description("Pitch Rate.ILimit")]
			PitchRateILimit = 14, 
			[Description("Roll+Pitch Rate.ILimit")]
			RollPitchRateILimit = 15, 
			[Description("Yaw Rate.ILimit")]
			YawRateILimit = 16, 
			[Description("Roll Attitude.Kp")]
			RollAttitudeKp = 17, 
			[Description("Pitch Attitude.Kp")]
			PitchAttitudeKp = 18, 
			[Description("Roll+Pitch Attitude.Kp")]
			RollPitchAttitudeKp = 19, 
			[Description("Yaw Attitude.Kp")]
			YawAttitudeKp = 20, 
			[Description("Roll Attitude.Ki")]
			RollAttitudeKi = 21, 
			[Description("Pitch Attitude.Ki")]
			PitchAttitudeKi = 22, 
			[Description("Roll+Pitch Attitude.Ki")]
			RollPitchAttitudeKi = 23, 
			[Description("Yaw Attitude.Ki")]
			YawAttitudeKi = 24, 
			[Description("Roll Attitude.ILimit")]
			RollAttitudeILimit = 25, 
			[Description("Pitch Attitude.ILimit")]
			PitchAttitudeILimit = 26, 
			[Description("Roll+Pitch Attitude.ILimit")]
			RollPitchAttitudeILimit = 27, 
			[Description("Yaw Attitude.ILimit")]
			YawAttitudeILimit = 28, 
			[Description("GyroTau")]
			GyroTau = 29, 
		}
		public UAVObjectField<PIDsUavEnum> PIDs;

		public TxPIDSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ThrottleRangeElemNames = new List<String>();
			ThrottleRangeElemNames.Add("Min");
			ThrottleRangeElemNames.Add("Max");
			ThrottleRange=new UAVObjectField<float>("ThrottleRange", "%", ThrottleRangeElemNames, null, this);
			fields.Add(ThrottleRange);

			List<String> MinPIDElemNames = new List<String>();
			MinPIDElemNames.Add("Instance1");
			MinPIDElemNames.Add("Instance2");
			MinPIDElemNames.Add("Instance3");
			MinPID=new UAVObjectField<float>("MinPID", "", MinPIDElemNames, null, this);
			fields.Add(MinPID);

			List<String> MaxPIDElemNames = new List<String>();
			MaxPIDElemNames.Add("Instance1");
			MaxPIDElemNames.Add("Instance2");
			MaxPIDElemNames.Add("Instance3");
			MaxPID=new UAVObjectField<float>("MaxPID", "", MaxPIDElemNames, null, this);
			fields.Add(MaxPID);

			List<String> UpdateModeElemNames = new List<String>();
			UpdateModeElemNames.Add("0");
			List<String> UpdateModeEnumOptions = new List<String>();
			UpdateModeEnumOptions.Add("Never");
			UpdateModeEnumOptions.Add("When Armed");
			UpdateModeEnumOptions.Add("Always");
			UpdateMode=new UAVObjectField<UpdateModeUavEnum>("UpdateMode", "option", UpdateModeElemNames, UpdateModeEnumOptions, this);
			fields.Add(UpdateMode);

			List<String> InputsElemNames = new List<String>();
			InputsElemNames.Add("Instance1");
			InputsElemNames.Add("Instance2");
			InputsElemNames.Add("Instance3");
			List<String> InputsEnumOptions = new List<String>();
			InputsEnumOptions.Add("Throttle");
			InputsEnumOptions.Add("Accessory0");
			InputsEnumOptions.Add("Accessory1");
			InputsEnumOptions.Add("Accessory2");
			InputsEnumOptions.Add("Accessory3");
			InputsEnumOptions.Add("Accessory4");
			InputsEnumOptions.Add("Accessory5");
			Inputs=new UAVObjectField<InputsUavEnum>("Inputs", "channel", InputsElemNames, InputsEnumOptions, this);
			fields.Add(Inputs);

			List<String> PIDsElemNames = new List<String>();
			PIDsElemNames.Add("Instance1");
			PIDsElemNames.Add("Instance2");
			PIDsElemNames.Add("Instance3");
			List<String> PIDsEnumOptions = new List<String>();
			PIDsEnumOptions.Add("Disabled");
			PIDsEnumOptions.Add("Roll Rate.Kp");
			PIDsEnumOptions.Add("Pitch Rate.Kp");
			PIDsEnumOptions.Add("Roll+Pitch Rate.Kp");
			PIDsEnumOptions.Add("Yaw Rate.Kp");
			PIDsEnumOptions.Add("Roll Rate.Ki");
			PIDsEnumOptions.Add("Pitch Rate.Ki");
			PIDsEnumOptions.Add("Roll+Pitch Rate.Ki");
			PIDsEnumOptions.Add("Yaw Rate.Ki");
			PIDsEnumOptions.Add("Roll Rate.Kd");
			PIDsEnumOptions.Add("Pitch Rate.Kd");
			PIDsEnumOptions.Add("Roll+Pitch Rate.Kd");
			PIDsEnumOptions.Add("Yaw Rate.Kd");
			PIDsEnumOptions.Add("Roll Rate.ILimit");
			PIDsEnumOptions.Add("Pitch Rate.ILimit");
			PIDsEnumOptions.Add("Roll+Pitch Rate.ILimit");
			PIDsEnumOptions.Add("Yaw Rate.ILimit");
			PIDsEnumOptions.Add("Roll Attitude.Kp");
			PIDsEnumOptions.Add("Pitch Attitude.Kp");
			PIDsEnumOptions.Add("Roll+Pitch Attitude.Kp");
			PIDsEnumOptions.Add("Yaw Attitude.Kp");
			PIDsEnumOptions.Add("Roll Attitude.Ki");
			PIDsEnumOptions.Add("Pitch Attitude.Ki");
			PIDsEnumOptions.Add("Roll+Pitch Attitude.Ki");
			PIDsEnumOptions.Add("Yaw Attitude.Ki");
			PIDsEnumOptions.Add("Roll Attitude.ILimit");
			PIDsEnumOptions.Add("Pitch Attitude.ILimit");
			PIDsEnumOptions.Add("Roll+Pitch Attitude.ILimit");
			PIDsEnumOptions.Add("Yaw Attitude.ILimit");
			PIDsEnumOptions.Add("GyroTau");
			PIDs=new UAVObjectField<PIDsUavEnum>("PIDs", "option", PIDsElemNames, PIDsEnumOptions, this);
			fields.Add(PIDs);

	

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
			ThrottleRange.setValue((float)0.2,0);
			ThrottleRange.setValue((float)0.8,1);
			MinPID.setValue((float)0,0);
			MinPID.setValue((float)0,1);
			MinPID.setValue((float)0,2);
			MaxPID.setValue((float)0,0);
			MaxPID.setValue((float)0,1);
			MaxPID.setValue((float)0,2);
			UpdateMode.setValue(UpdateModeUavEnum.WhenArmed);
			Inputs.setValue(InputsUavEnum.Throttle,0);
			Inputs.setValue(InputsUavEnum.Accessory0,1);
			Inputs.setValue(InputsUavEnum.Accessory1,2);
			PIDs.setValue(PIDsUavEnum.Disabled,0);
			PIDs.setValue(PIDsUavEnum.Disabled,1);
			PIDs.setValue(PIDsUavEnum.Disabled,2);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				TxPIDSettings obj = new TxPIDSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public TxPIDSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (TxPIDSettings)(objMngr.getObject(TxPIDSettings.OBJID, instID));
		}
	}
}

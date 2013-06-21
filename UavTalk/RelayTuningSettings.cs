// Object ID: 3929375078
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class RelayTuningSettings : UAVDataObject
	{
		public const long OBJID = 3929375078;
		public int NUMBYTES { get; set; }
		protected const String NAME = "RelayTuningSettings";
	    protected static String DESCRIPTION = @"Setting to run a relay tuning algorithm";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> RateGain;
		public UAVObjectField<float> AttitudeGain;
		public UAVObjectField<float> Amplitude;
		public UAVObjectField<byte> HysteresisThresh;
		public enum ModeUavEnum
		{
			[Description("Rate")]
			Rate = 0, 
			[Description("Attitude")]
			Attitude = 1, 
		}
		public UAVObjectField<ModeUavEnum> Mode;
		public enum BehaviorUavEnum
		{
			[Description("Measure")]
			Measure = 0, 
			[Description("Compute")]
			Compute = 1, 
			[Description("Save")]
			Save = 2, 
		}
		public UAVObjectField<BehaviorUavEnum> Behavior;

		public RelayTuningSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> RateGainElemNames = new List<String>();
			RateGainElemNames.Add("0");
			RateGain=new UAVObjectField<float>("RateGain", "", RateGainElemNames, null, this);
			fields.Add(RateGain);

			List<String> AttitudeGainElemNames = new List<String>();
			AttitudeGainElemNames.Add("0");
			AttitudeGain=new UAVObjectField<float>("AttitudeGain", "", AttitudeGainElemNames, null, this);
			fields.Add(AttitudeGain);

			List<String> AmplitudeElemNames = new List<String>();
			AmplitudeElemNames.Add("0");
			Amplitude=new UAVObjectField<float>("Amplitude", "", AmplitudeElemNames, null, this);
			fields.Add(Amplitude);

			List<String> HysteresisThreshElemNames = new List<String>();
			HysteresisThreshElemNames.Add("0");
			HysteresisThresh=new UAVObjectField<byte>("HysteresisThresh", "deg/s", HysteresisThreshElemNames, null, this);
			fields.Add(HysteresisThresh);

			List<String> ModeElemNames = new List<String>();
			ModeElemNames.Add("0");
			List<String> ModeEnumOptions = new List<String>();
			ModeEnumOptions.Add("Rate");
			ModeEnumOptions.Add("Attitude");
			Mode=new UAVObjectField<ModeUavEnum>("Mode", "", ModeElemNames, ModeEnumOptions, this);
			fields.Add(Mode);

			List<String> BehaviorElemNames = new List<String>();
			BehaviorElemNames.Add("0");
			List<String> BehaviorEnumOptions = new List<String>();
			BehaviorEnumOptions.Add("Measure");
			BehaviorEnumOptions.Add("Compute");
			BehaviorEnumOptions.Add("Save");
			Behavior=new UAVObjectField<BehaviorUavEnum>("Behavior", "", BehaviorElemNames, BehaviorEnumOptions, this);
			fields.Add(Behavior);

	

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
			RateGain.setValue((float)3333);
			AttitudeGain.setValue((float)2);
			Amplitude.setValue((float)25);
			HysteresisThresh.setValue((byte)5);
			Mode.setValue(ModeUavEnum.Attitude);
			Behavior.setValue(BehaviorUavEnum.Compute);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				RelayTuningSettings obj = new RelayTuningSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public RelayTuningSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (RelayTuningSettings)(objMngr.getObject(RelayTuningSettings.OBJID, instID));
		}
	}
}

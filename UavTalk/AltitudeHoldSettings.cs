// Object ID: 47767504
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class AltitudeHoldSettings : UAVDataObject
	{
		public const long OBJID = 47767504;
		public int NUMBYTES { get; set; }
		protected const String NAME = "AltitudeHoldSettings";
	    protected static String DESCRIPTION = @"Settings for the @ref AltitudeHold module";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> Kp;
		public UAVObjectField<float> Ki;
		public UAVObjectField<float> Kd;
		public UAVObjectField<float> Ka;
		public UAVObjectField<float> PressureNoise;
		public UAVObjectField<float> AccelNoise;
		public UAVObjectField<float> AccelDrift;
		public UAVObjectField<byte> ThrottleExp;
		public UAVObjectField<byte> ThrottleRate;

		public AltitudeHoldSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> KpElemNames = new List<String>();
			KpElemNames.Add("0");
			Kp=new UAVObjectField<float>("Kp", "throttle/m", KpElemNames, null, this);
			fields.Add(Kp);

			List<String> KiElemNames = new List<String>();
			KiElemNames.Add("0");
			Ki=new UAVObjectField<float>("Ki", "throttle/m", KiElemNames, null, this);
			fields.Add(Ki);

			List<String> KdElemNames = new List<String>();
			KdElemNames.Add("0");
			Kd=new UAVObjectField<float>("Kd", "throttle/m", KdElemNames, null, this);
			fields.Add(Kd);

			List<String> KaElemNames = new List<String>();
			KaElemNames.Add("0");
			Ka=new UAVObjectField<float>("Ka", "throttle/(m/s^2)", KaElemNames, null, this);
			fields.Add(Ka);

			List<String> PressureNoiseElemNames = new List<String>();
			PressureNoiseElemNames.Add("0");
			PressureNoise=new UAVObjectField<float>("PressureNoise", "m", PressureNoiseElemNames, null, this);
			fields.Add(PressureNoise);

			List<String> AccelNoiseElemNames = new List<String>();
			AccelNoiseElemNames.Add("0");
			AccelNoise=new UAVObjectField<float>("AccelNoise", "m/s^2", AccelNoiseElemNames, null, this);
			fields.Add(AccelNoise);

			List<String> AccelDriftElemNames = new List<String>();
			AccelDriftElemNames.Add("0");
			AccelDrift=new UAVObjectField<float>("AccelDrift", "m/s^2", AccelDriftElemNames, null, this);
			fields.Add(AccelDrift);

			List<String> ThrottleExpElemNames = new List<String>();
			ThrottleExpElemNames.Add("0");
			ThrottleExp=new UAVObjectField<byte>("ThrottleExp", "", ThrottleExpElemNames, null, this);
			fields.Add(ThrottleExp);

			List<String> ThrottleRateElemNames = new List<String>();
			ThrottleRateElemNames.Add("0");
			ThrottleRate=new UAVObjectField<byte>("ThrottleRate", "m/s", ThrottleRateElemNames, null, this);
			fields.Add(ThrottleRate);

	

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
			Kp.setValue((float)1);
			Ki.setValue((float)0);
			Kd.setValue((float)5);
			Ka.setValue((float)5);
			PressureNoise.setValue((float)4);
			AccelNoise.setValue((float)5);
			AccelDrift.setValue((float)1);
			ThrottleExp.setValue((byte)128);
			ThrottleRate.setValue((byte)5);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				AltitudeHoldSettings obj = new AltitudeHoldSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public AltitudeHoldSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (AltitudeHoldSettings)(objMngr.getObject(AltitudeHoldSettings.OBJID, instID));
		}
	}
}

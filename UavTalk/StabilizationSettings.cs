// Object ID: 2779700644
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class StabilizationSettings : UAVDataObject
	{
		public const long OBJID = 2779700644;
		public int NUMBYTES { get; set; }
		protected const String NAME = "StabilizationSettings";
	    protected static String DESCRIPTION = @"PID settings used by the Stabilization module to combine the @ref AttitudeActual and @ref AttitudeDesired to compute @ref ActuatorDesired";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> ManualRate;
		public UAVObjectField<float> MaximumRate;
		public UAVObjectField<float> PoiMaximumRate;
		public UAVObjectField<float> RollRatePID;
		public UAVObjectField<float> PitchRatePID;
		public UAVObjectField<float> YawRatePID;
		public UAVObjectField<float> RollPI;
		public UAVObjectField<float> PitchPI;
		public UAVObjectField<float> YawPI;
		public UAVObjectField<float> VbarSensitivity;
		public UAVObjectField<float> VbarRollPI;
		public UAVObjectField<float> VbarPitchPI;
		public UAVObjectField<float> VbarYawPI;
		public UAVObjectField<float> VbarTau;
		public UAVObjectField<float> GyroTau;
		public UAVObjectField<float> DerivativeGamma;
		public UAVObjectField<float> WeakLevelingKp;
		public UAVObjectField<byte> RollMax;
		public UAVObjectField<byte> PitchMax;
		public UAVObjectField<byte> YawMax;
		public UAVObjectField<sbyte> VbarGyroSuppress;
		public enum VbarPiroCompUavEnum
		{
			[Description("FALSE")]
			FALSE = 0, 
			[Description("TRUE")]
			TRUE = 1, 
		}
		public UAVObjectField<VbarPiroCompUavEnum> VbarPiroComp;
		public UAVObjectField<byte> VbarMaxAngle;
		public UAVObjectField<byte> DerivativeCutoff;
		public UAVObjectField<byte> MaxAxisLock;
		public UAVObjectField<byte> MaxAxisLockRate;
		public UAVObjectField<byte> MaxWeakLevelingRate;
		public enum LowThrottleZeroIntegralUavEnum
		{
			[Description("FALSE")]
			FALSE = 0, 
			[Description("TRUE")]
			TRUE = 1, 
		}
		public UAVObjectField<LowThrottleZeroIntegralUavEnum> LowThrottleZeroIntegral;

		public StabilizationSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ManualRateElemNames = new List<String>();
			ManualRateElemNames.Add("Roll");
			ManualRateElemNames.Add("Pitch");
			ManualRateElemNames.Add("Yaw");
			ManualRate=new UAVObjectField<float>("ManualRate", "degrees/sec", ManualRateElemNames, null, this);
			fields.Add(ManualRate);

			List<String> MaximumRateElemNames = new List<String>();
			MaximumRateElemNames.Add("Roll");
			MaximumRateElemNames.Add("Pitch");
			MaximumRateElemNames.Add("Yaw");
			MaximumRate=new UAVObjectField<float>("MaximumRate", "degrees/sec", MaximumRateElemNames, null, this);
			fields.Add(MaximumRate);

			List<String> PoiMaximumRateElemNames = new List<String>();
			PoiMaximumRateElemNames.Add("Roll");
			PoiMaximumRateElemNames.Add("Pitch");
			PoiMaximumRateElemNames.Add("Yaw");
			PoiMaximumRate=new UAVObjectField<float>("PoiMaximumRate", "degrees/sec", PoiMaximumRateElemNames, null, this);
			fields.Add(PoiMaximumRate);

			List<String> RollRatePIDElemNames = new List<String>();
			RollRatePIDElemNames.Add("Kp");
			RollRatePIDElemNames.Add("Ki");
			RollRatePIDElemNames.Add("Kd");
			RollRatePIDElemNames.Add("ILimit");
			RollRatePID=new UAVObjectField<float>("RollRatePID", "", RollRatePIDElemNames, null, this);
			fields.Add(RollRatePID);

			List<String> PitchRatePIDElemNames = new List<String>();
			PitchRatePIDElemNames.Add("Kp");
			PitchRatePIDElemNames.Add("Ki");
			PitchRatePIDElemNames.Add("Kd");
			PitchRatePIDElemNames.Add("ILimit");
			PitchRatePID=new UAVObjectField<float>("PitchRatePID", "", PitchRatePIDElemNames, null, this);
			fields.Add(PitchRatePID);

			List<String> YawRatePIDElemNames = new List<String>();
			YawRatePIDElemNames.Add("Kp");
			YawRatePIDElemNames.Add("Ki");
			YawRatePIDElemNames.Add("Kd");
			YawRatePIDElemNames.Add("ILimit");
			YawRatePID=new UAVObjectField<float>("YawRatePID", "", YawRatePIDElemNames, null, this);
			fields.Add(YawRatePID);

			List<String> RollPIElemNames = new List<String>();
			RollPIElemNames.Add("Kp");
			RollPIElemNames.Add("Ki");
			RollPIElemNames.Add("ILimit");
			RollPI=new UAVObjectField<float>("RollPI", "", RollPIElemNames, null, this);
			fields.Add(RollPI);

			List<String> PitchPIElemNames = new List<String>();
			PitchPIElemNames.Add("Kp");
			PitchPIElemNames.Add("Ki");
			PitchPIElemNames.Add("ILimit");
			PitchPI=new UAVObjectField<float>("PitchPI", "", PitchPIElemNames, null, this);
			fields.Add(PitchPI);

			List<String> YawPIElemNames = new List<String>();
			YawPIElemNames.Add("Kp");
			YawPIElemNames.Add("Ki");
			YawPIElemNames.Add("ILimit");
			YawPI=new UAVObjectField<float>("YawPI", "", YawPIElemNames, null, this);
			fields.Add(YawPI);

			List<String> VbarSensitivityElemNames = new List<String>();
			VbarSensitivityElemNames.Add("Roll");
			VbarSensitivityElemNames.Add("Pitch");
			VbarSensitivityElemNames.Add("Yaw");
			VbarSensitivity=new UAVObjectField<float>("VbarSensitivity", "frac", VbarSensitivityElemNames, null, this);
			fields.Add(VbarSensitivity);

			List<String> VbarRollPIElemNames = new List<String>();
			VbarRollPIElemNames.Add("Kp");
			VbarRollPIElemNames.Add("Ki");
			VbarRollPI=new UAVObjectField<float>("VbarRollPI", "1/(deg/s)", VbarRollPIElemNames, null, this);
			fields.Add(VbarRollPI);

			List<String> VbarPitchPIElemNames = new List<String>();
			VbarPitchPIElemNames.Add("Kp");
			VbarPitchPIElemNames.Add("Ki");
			VbarPitchPI=new UAVObjectField<float>("VbarPitchPI", "1/(deg/s)", VbarPitchPIElemNames, null, this);
			fields.Add(VbarPitchPI);

			List<String> VbarYawPIElemNames = new List<String>();
			VbarYawPIElemNames.Add("Kp");
			VbarYawPIElemNames.Add("Ki");
			VbarYawPI=new UAVObjectField<float>("VbarYawPI", "1/(deg/s)", VbarYawPIElemNames, null, this);
			fields.Add(VbarYawPI);

			List<String> VbarTauElemNames = new List<String>();
			VbarTauElemNames.Add("0");
			VbarTau=new UAVObjectField<float>("VbarTau", "sec", VbarTauElemNames, null, this);
			fields.Add(VbarTau);

			List<String> GyroTauElemNames = new List<String>();
			GyroTauElemNames.Add("0");
			GyroTau=new UAVObjectField<float>("GyroTau", "", GyroTauElemNames, null, this);
			fields.Add(GyroTau);

			List<String> DerivativeGammaElemNames = new List<String>();
			DerivativeGammaElemNames.Add("0");
			DerivativeGamma=new UAVObjectField<float>("DerivativeGamma", "", DerivativeGammaElemNames, null, this);
			fields.Add(DerivativeGamma);

			List<String> WeakLevelingKpElemNames = new List<String>();
			WeakLevelingKpElemNames.Add("0");
			WeakLevelingKp=new UAVObjectField<float>("WeakLevelingKp", "(deg/s)/deg", WeakLevelingKpElemNames, null, this);
			fields.Add(WeakLevelingKp);

			List<String> RollMaxElemNames = new List<String>();
			RollMaxElemNames.Add("0");
			RollMax=new UAVObjectField<byte>("RollMax", "degrees", RollMaxElemNames, null, this);
			fields.Add(RollMax);

			List<String> PitchMaxElemNames = new List<String>();
			PitchMaxElemNames.Add("0");
			PitchMax=new UAVObjectField<byte>("PitchMax", "degrees", PitchMaxElemNames, null, this);
			fields.Add(PitchMax);

			List<String> YawMaxElemNames = new List<String>();
			YawMaxElemNames.Add("0");
			YawMax=new UAVObjectField<byte>("YawMax", "degrees", YawMaxElemNames, null, this);
			fields.Add(YawMax);

			List<String> VbarGyroSuppressElemNames = new List<String>();
			VbarGyroSuppressElemNames.Add("0");
			VbarGyroSuppress=new UAVObjectField<sbyte>("VbarGyroSuppress", "%", VbarGyroSuppressElemNames, null, this);
			fields.Add(VbarGyroSuppress);

			List<String> VbarPiroCompElemNames = new List<String>();
			VbarPiroCompElemNames.Add("0");
			List<String> VbarPiroCompEnumOptions = new List<String>();
			VbarPiroCompEnumOptions.Add("FALSE");
			VbarPiroCompEnumOptions.Add("TRUE");
			VbarPiroComp=new UAVObjectField<VbarPiroCompUavEnum>("VbarPiroComp", "", VbarPiroCompElemNames, VbarPiroCompEnumOptions, this);
			fields.Add(VbarPiroComp);

			List<String> VbarMaxAngleElemNames = new List<String>();
			VbarMaxAngleElemNames.Add("0");
			VbarMaxAngle=new UAVObjectField<byte>("VbarMaxAngle", "deg", VbarMaxAngleElemNames, null, this);
			fields.Add(VbarMaxAngle);

			List<String> DerivativeCutoffElemNames = new List<String>();
			DerivativeCutoffElemNames.Add("0");
			DerivativeCutoff=new UAVObjectField<byte>("DerivativeCutoff", "Hz", DerivativeCutoffElemNames, null, this);
			fields.Add(DerivativeCutoff);

			List<String> MaxAxisLockElemNames = new List<String>();
			MaxAxisLockElemNames.Add("0");
			MaxAxisLock=new UAVObjectField<byte>("MaxAxisLock", "deg", MaxAxisLockElemNames, null, this);
			fields.Add(MaxAxisLock);

			List<String> MaxAxisLockRateElemNames = new List<String>();
			MaxAxisLockRateElemNames.Add("0");
			MaxAxisLockRate=new UAVObjectField<byte>("MaxAxisLockRate", "deg/s", MaxAxisLockRateElemNames, null, this);
			fields.Add(MaxAxisLockRate);

			List<String> MaxWeakLevelingRateElemNames = new List<String>();
			MaxWeakLevelingRateElemNames.Add("0");
			MaxWeakLevelingRate=new UAVObjectField<byte>("MaxWeakLevelingRate", "deg/s", MaxWeakLevelingRateElemNames, null, this);
			fields.Add(MaxWeakLevelingRate);

			List<String> LowThrottleZeroIntegralElemNames = new List<String>();
			LowThrottleZeroIntegralElemNames.Add("0");
			List<String> LowThrottleZeroIntegralEnumOptions = new List<String>();
			LowThrottleZeroIntegralEnumOptions.Add("FALSE");
			LowThrottleZeroIntegralEnumOptions.Add("TRUE");
			LowThrottleZeroIntegral=new UAVObjectField<LowThrottleZeroIntegralUavEnum>("LowThrottleZeroIntegral", "", LowThrottleZeroIntegralElemNames, LowThrottleZeroIntegralEnumOptions, this);
			fields.Add(LowThrottleZeroIntegral);

	

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
			ManualRate.setValue((float)150,0);
			ManualRate.setValue((float)150,1);
			ManualRate.setValue((float)150,2);
			MaximumRate.setValue((float)300,0);
			MaximumRate.setValue((float)300,1);
			MaximumRate.setValue((float)300,2);
			PoiMaximumRate.setValue((float)30,0);
			PoiMaximumRate.setValue((float)30,1);
			PoiMaximumRate.setValue((float)30,2);
			RollRatePID.setValue((float)0.002,0);
			RollRatePID.setValue((float)0,1);
			RollRatePID.setValue((float)0,2);
			RollRatePID.setValue((float)0.3,3);
			PitchRatePID.setValue((float)0.002,0);
			PitchRatePID.setValue((float)0,1);
			PitchRatePID.setValue((float)0,2);
			PitchRatePID.setValue((float)0.3,3);
			YawRatePID.setValue((float)0.0035,0);
			YawRatePID.setValue((float)0.0035,1);
			YawRatePID.setValue((float)0,2);
			YawRatePID.setValue((float)0.3,3);
			RollPI.setValue((float)2,0);
			RollPI.setValue((float)0,1);
			RollPI.setValue((float)50,2);
			PitchPI.setValue((float)2,0);
			PitchPI.setValue((float)0,1);
			PitchPI.setValue((float)50,2);
			YawPI.setValue((float)2,0);
			YawPI.setValue((float)0,1);
			YawPI.setValue((float)50,2);
			VbarSensitivity.setValue((float)0.5,0);
			VbarSensitivity.setValue((float)0.5,1);
			VbarSensitivity.setValue((float)0.5,2);
			VbarRollPI.setValue((float)0.005,0);
			VbarRollPI.setValue((float)0.002,1);
			VbarPitchPI.setValue((float)0.005,0);
			VbarPitchPI.setValue((float)0.002,1);
			VbarYawPI.setValue((float)0.005,0);
			VbarYawPI.setValue((float)0.002,1);
			VbarTau.setValue((float)5);
			GyroTau.setValue((float)5);
			DerivativeGamma.setValue((float)1);
			WeakLevelingKp.setValue((float)1);
			RollMax.setValue((byte)55);
			PitchMax.setValue((byte)55);
			YawMax.setValue((byte)35);
			VbarGyroSuppress.setValue((sbyte)30);
			VbarPiroComp.setValue(VbarPiroCompUavEnum.FALSE);
			VbarMaxAngle.setValue((byte)10);
			DerivativeCutoff.setValue((byte)20);
			MaxAxisLock.setValue((byte)15);
			MaxAxisLockRate.setValue((byte)2);
			MaxWeakLevelingRate.setValue((byte)5);
			LowThrottleZeroIntegral.setValue(LowThrottleZeroIntegralUavEnum.TRUE);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				StabilizationSettings obj = new StabilizationSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public StabilizationSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (StabilizationSettings)(objMngr.getObject(StabilizationSettings.OBJID, instID));
		}
	}
}

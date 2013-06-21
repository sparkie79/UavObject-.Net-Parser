// Object ID: 151587862
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class GroundPathFollowerSettings : UAVDataObject
	{
		public const long OBJID = 151587862;
		public int NUMBYTES { get; set; }
		protected const String NAME = "GroundPathFollowerSettings";
	    protected static String DESCRIPTION = @"Settings for the @ref GroundPathFollowerModule";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> HorizontalPosPI;
		public UAVObjectField<float> HorizontalVelPID;
		public UAVObjectField<float> VelocityFeedforward;
		public UAVObjectField<float> MaxThrottle;
		public UAVObjectField<Int32> UpdatePeriod;
		public UAVObjectField<UInt16> HorizontalVelMax;
		public enum ManualOverrideUavEnum
		{
			[Description("FALSE")]
			FALSE = 0, 
			[Description("TRUE")]
			TRUE = 1, 
		}
		public UAVObjectField<ManualOverrideUavEnum> ManualOverride;
		public enum ThrottleControlUavEnum
		{
			[Description("MANUAL")]
			MANUAL = 0, 
			[Description("PROPORTIONAL")]
			PROPORTIONAL = 1, 
			[Description("AUTO")]
			AUTO = 2, 
		}
		public UAVObjectField<ThrottleControlUavEnum> ThrottleControl;
		public enum VelocitySourceUavEnum
		{
			[Description("EKF")]
			EKF = 0, 
			[Description("NEDVEL")]
			NEDVEL = 1, 
			[Description("GPSPOS")]
			GPSPOS = 2, 
		}
		public UAVObjectField<VelocitySourceUavEnum> VelocitySource;
		public enum PositionSourceUavEnum
		{
			[Description("EKF")]
			EKF = 0, 
			[Description("GPSPOS")]
			GPSPOS = 1, 
		}
		public UAVObjectField<PositionSourceUavEnum> PositionSource;
		public UAVObjectField<byte> EndpointRadius;

		public GroundPathFollowerSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> HorizontalPosPIElemNames = new List<String>();
			HorizontalPosPIElemNames.Add("Kp");
			HorizontalPosPIElemNames.Add("Ki");
			HorizontalPosPIElemNames.Add("ILimit");
			HorizontalPosPI=new UAVObjectField<float>("HorizontalPosPI", "(m/s)/m", HorizontalPosPIElemNames, null, this);
			fields.Add(HorizontalPosPI);

			List<String> HorizontalVelPIDElemNames = new List<String>();
			HorizontalVelPIDElemNames.Add("Kp");
			HorizontalVelPIDElemNames.Add("Ki");
			HorizontalVelPIDElemNames.Add("Kd");
			HorizontalVelPIDElemNames.Add("ILimit");
			HorizontalVelPID=new UAVObjectField<float>("HorizontalVelPID", "deg/(m/s)", HorizontalVelPIDElemNames, null, this);
			fields.Add(HorizontalVelPID);

			List<String> VelocityFeedforwardElemNames = new List<String>();
			VelocityFeedforwardElemNames.Add("0");
			VelocityFeedforward=new UAVObjectField<float>("VelocityFeedforward", "deg/(m/s)", VelocityFeedforwardElemNames, null, this);
			fields.Add(VelocityFeedforward);

			List<String> MaxThrottleElemNames = new List<String>();
			MaxThrottleElemNames.Add("0");
			MaxThrottle=new UAVObjectField<float>("MaxThrottle", "%", MaxThrottleElemNames, null, this);
			fields.Add(MaxThrottle);

			List<String> UpdatePeriodElemNames = new List<String>();
			UpdatePeriodElemNames.Add("0");
			UpdatePeriod=new UAVObjectField<Int32>("UpdatePeriod", "ms", UpdatePeriodElemNames, null, this);
			fields.Add(UpdatePeriod);

			List<String> HorizontalVelMaxElemNames = new List<String>();
			HorizontalVelMaxElemNames.Add("0");
			HorizontalVelMax=new UAVObjectField<UInt16>("HorizontalVelMax", "m/s", HorizontalVelMaxElemNames, null, this);
			fields.Add(HorizontalVelMax);

			List<String> ManualOverrideElemNames = new List<String>();
			ManualOverrideElemNames.Add("0");
			List<String> ManualOverrideEnumOptions = new List<String>();
			ManualOverrideEnumOptions.Add("FALSE");
			ManualOverrideEnumOptions.Add("TRUE");
			ManualOverride=new UAVObjectField<ManualOverrideUavEnum>("ManualOverride", "", ManualOverrideElemNames, ManualOverrideEnumOptions, this);
			fields.Add(ManualOverride);

			List<String> ThrottleControlElemNames = new List<String>();
			ThrottleControlElemNames.Add("0");
			List<String> ThrottleControlEnumOptions = new List<String>();
			ThrottleControlEnumOptions.Add("MANUAL");
			ThrottleControlEnumOptions.Add("PROPORTIONAL");
			ThrottleControlEnumOptions.Add("AUTO");
			ThrottleControl=new UAVObjectField<ThrottleControlUavEnum>("ThrottleControl", "", ThrottleControlElemNames, ThrottleControlEnumOptions, this);
			fields.Add(ThrottleControl);

			List<String> VelocitySourceElemNames = new List<String>();
			VelocitySourceElemNames.Add("0");
			List<String> VelocitySourceEnumOptions = new List<String>();
			VelocitySourceEnumOptions.Add("EKF");
			VelocitySourceEnumOptions.Add("NEDVEL");
			VelocitySourceEnumOptions.Add("GPSPOS");
			VelocitySource=new UAVObjectField<VelocitySourceUavEnum>("VelocitySource", "", VelocitySourceElemNames, VelocitySourceEnumOptions, this);
			fields.Add(VelocitySource);

			List<String> PositionSourceElemNames = new List<String>();
			PositionSourceElemNames.Add("0");
			List<String> PositionSourceEnumOptions = new List<String>();
			PositionSourceEnumOptions.Add("EKF");
			PositionSourceEnumOptions.Add("GPSPOS");
			PositionSource=new UAVObjectField<PositionSourceUavEnum>("PositionSource", "", PositionSourceElemNames, PositionSourceEnumOptions, this);
			fields.Add(PositionSource);

			List<String> EndpointRadiusElemNames = new List<String>();
			EndpointRadiusElemNames.Add("0");
			EndpointRadius=new UAVObjectField<byte>("EndpointRadius", "m", EndpointRadiusElemNames, null, this);
			fields.Add(EndpointRadius);

	

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
			HorizontalPosPI.setValue((float)1,0);
			HorizontalPosPI.setValue((float)0,1);
			HorizontalPosPI.setValue((float)0,2);
			HorizontalVelPID.setValue((float)5,0);
			HorizontalVelPID.setValue((float)0,1);
			HorizontalVelPID.setValue((float)1,2);
			HorizontalVelPID.setValue((float)0,3);
			VelocityFeedforward.setValue((float)0);
			MaxThrottle.setValue((float)1);
			UpdatePeriod.setValue((Int32)100);
			HorizontalVelMax.setValue((UInt16)10);
			ManualOverride.setValue(ManualOverrideUavEnum.FALSE);
			ThrottleControl.setValue(ThrottleControlUavEnum.PROPORTIONAL);
			VelocitySource.setValue(VelocitySourceUavEnum.EKF);
			PositionSource.setValue(PositionSourceUavEnum.EKF);
			EndpointRadius.setValue((byte)2);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				GroundPathFollowerSettings obj = new GroundPathFollowerSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public GroundPathFollowerSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (GroundPathFollowerSettings)(objMngr.getObject(GroundPathFollowerSettings.OBJID, instID));
		}
	}
}

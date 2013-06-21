// Object ID: 3294770436
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class FixedWingPathFollowerSettingsCC : UAVDataObject
	{
		public const long OBJID = 3294770436;
		public int NUMBYTES { get; set; }
		protected const String NAME = "FixedWingPathFollowerSettingsCC";
	    protected static String DESCRIPTION = @"Settings for the @ref FixedWingPathFollowerModule";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> VerticalVelMax;
		public UAVObjectField<float> VectorFollowingGain;
		public UAVObjectField<float> OrbitFollowingGain;
		public UAVObjectField<float> FollowerIntegralGain;
		public UAVObjectField<float> VerticalPosP;
		public UAVObjectField<float> HeadingPI;
		public UAVObjectField<float> AirspeedPI;
		public UAVObjectField<float> VerticalToPitchCrossFeed;
		public UAVObjectField<float> AirspeedToVerticalCrossFeed;
		public UAVObjectField<float> ThrottlePI;
		public UAVObjectField<float> RollLimit;
		public UAVObjectField<float> PitchLimit;
		public UAVObjectField<float> ThrottleLimit;
		public UAVObjectField<Int16> UpdatePeriod;

		public FixedWingPathFollowerSettingsCC() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> VerticalVelMaxElemNames = new List<String>();
			VerticalVelMaxElemNames.Add("0");
			VerticalVelMax=new UAVObjectField<float>("VerticalVelMax", "m/s", VerticalVelMaxElemNames, null, this);
			fields.Add(VerticalVelMax);

			List<String> VectorFollowingGainElemNames = new List<String>();
			VectorFollowingGainElemNames.Add("0");
			VectorFollowingGain=new UAVObjectField<float>("VectorFollowingGain", "(m/s)/m", VectorFollowingGainElemNames, null, this);
			fields.Add(VectorFollowingGain);

			List<String> OrbitFollowingGainElemNames = new List<String>();
			OrbitFollowingGainElemNames.Add("0");
			OrbitFollowingGain=new UAVObjectField<float>("OrbitFollowingGain", "(m/s)/m", OrbitFollowingGainElemNames, null, this);
			fields.Add(OrbitFollowingGain);

			List<String> FollowerIntegralGainElemNames = new List<String>();
			FollowerIntegralGainElemNames.Add("0");
			FollowerIntegralGain=new UAVObjectField<float>("FollowerIntegralGain", "(m/s)/m", FollowerIntegralGainElemNames, null, this);
			fields.Add(FollowerIntegralGain);

			List<String> VerticalPosPElemNames = new List<String>();
			VerticalPosPElemNames.Add("0");
			VerticalPosP=new UAVObjectField<float>("VerticalPosP", "(m/s)/m", VerticalPosPElemNames, null, this);
			fields.Add(VerticalPosP);

			List<String> HeadingPIElemNames = new List<String>();
			HeadingPIElemNames.Add("Kp");
			HeadingPIElemNames.Add("Ki");
			HeadingPIElemNames.Add("ILimit");
			HeadingPI=new UAVObjectField<float>("HeadingPI", "deg/deg", HeadingPIElemNames, null, this);
			fields.Add(HeadingPI);

			List<String> AirspeedPIElemNames = new List<String>();
			AirspeedPIElemNames.Add("Kp");
			AirspeedPIElemNames.Add("Ki");
			AirspeedPIElemNames.Add("ILimit");
			AirspeedPI=new UAVObjectField<float>("AirspeedPI", "deg / (m/s^2)", AirspeedPIElemNames, null, this);
			fields.Add(AirspeedPI);

			List<String> VerticalToPitchCrossFeedElemNames = new List<String>();
			VerticalToPitchCrossFeedElemNames.Add("Kp");
			VerticalToPitchCrossFeedElemNames.Add("Max");
			VerticalToPitchCrossFeed=new UAVObjectField<float>("VerticalToPitchCrossFeed", "deg / m", VerticalToPitchCrossFeedElemNames, null, this);
			fields.Add(VerticalToPitchCrossFeed);

			List<String> AirspeedToVerticalCrossFeedElemNames = new List<String>();
			AirspeedToVerticalCrossFeedElemNames.Add("Kp");
			AirspeedToVerticalCrossFeedElemNames.Add("Max");
			AirspeedToVerticalCrossFeed=new UAVObjectField<float>("AirspeedToVerticalCrossFeed", "(m/s) / ((m/s)/(m/s))", AirspeedToVerticalCrossFeedElemNames, null, this);
			fields.Add(AirspeedToVerticalCrossFeed);

			List<String> ThrottlePIElemNames = new List<String>();
			ThrottlePIElemNames.Add("Kp");
			ThrottlePIElemNames.Add("Ki");
			ThrottlePIElemNames.Add("ILimit");
			ThrottlePI=new UAVObjectField<float>("ThrottlePI", "1/(m/s)", ThrottlePIElemNames, null, this);
			fields.Add(ThrottlePI);

			List<String> RollLimitElemNames = new List<String>();
			RollLimitElemNames.Add("Min");
			RollLimitElemNames.Add("Neutral");
			RollLimitElemNames.Add("Max");
			RollLimit=new UAVObjectField<float>("RollLimit", "deg", RollLimitElemNames, null, this);
			fields.Add(RollLimit);

			List<String> PitchLimitElemNames = new List<String>();
			PitchLimitElemNames.Add("Min");
			PitchLimitElemNames.Add("Neutral");
			PitchLimitElemNames.Add("Max");
			PitchLimit=new UAVObjectField<float>("PitchLimit", "deg", PitchLimitElemNames, null, this);
			fields.Add(PitchLimit);

			List<String> ThrottleLimitElemNames = new List<String>();
			ThrottleLimitElemNames.Add("Min");
			ThrottleLimitElemNames.Add("Neutral");
			ThrottleLimitElemNames.Add("Max");
			ThrottleLimit=new UAVObjectField<float>("ThrottleLimit", "", ThrottleLimitElemNames, null, this);
			fields.Add(ThrottleLimit);

			List<String> UpdatePeriodElemNames = new List<String>();
			UpdatePeriodElemNames.Add("0");
			UpdatePeriod=new UAVObjectField<Int16>("UpdatePeriod", "ms", UpdatePeriodElemNames, null, this);
			fields.Add(UpdatePeriod);

	

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
			VerticalVelMax.setValue((float)10);
			VectorFollowingGain.setValue((float)5);
			OrbitFollowingGain.setValue((float)5);
			FollowerIntegralGain.setValue((float)0);
			VerticalPosP.setValue((float)5);
			HeadingPI.setValue((float)0.6,0);
			HeadingPI.setValue((float)0,1);
			HeadingPI.setValue((float)0,2);
			AirspeedPI.setValue((float)1,0);
			AirspeedPI.setValue((float)0.05,1);
			AirspeedPI.setValue((float)5,2);
			VerticalToPitchCrossFeed.setValue((float)0.2,0);
			VerticalToPitchCrossFeed.setValue((float)10,1);
			AirspeedToVerticalCrossFeed.setValue((float)10,0);
			AirspeedToVerticalCrossFeed.setValue((float)100,1);
			ThrottlePI.setValue((float)0.001,0);
			ThrottlePI.setValue((float)0.0001,1);
			ThrottlePI.setValue((float)0.5,2);
			RollLimit.setValue((float)-35,0);
			RollLimit.setValue((float)0,1);
			RollLimit.setValue((float)35,2);
			PitchLimit.setValue((float)-10,0);
			PitchLimit.setValue((float)0,1);
			PitchLimit.setValue((float)10,2);
			ThrottleLimit.setValue((float)0,0);
			ThrottleLimit.setValue((float)0.5,1);
			ThrottleLimit.setValue((float)1,2);
			UpdatePeriod.setValue((Int16)100);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				FixedWingPathFollowerSettingsCC obj = new FixedWingPathFollowerSettingsCC();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public FixedWingPathFollowerSettingsCC GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (FixedWingPathFollowerSettingsCC)(objMngr.getObject(FixedWingPathFollowerSettingsCC.OBJID, instID));
		}
	}
}

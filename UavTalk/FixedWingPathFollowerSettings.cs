// Object ID: 1455625946
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class FixedWingPathFollowerSettings : UAVDataObject
	{
		public const long OBJID = 1455625946;
		public int NUMBYTES { get; set; }
		protected const String NAME = "FixedWingPathFollowerSettings";
	    protected static String DESCRIPTION = @"Settings for the @ref FixedWingPathFollowerModule";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> HorizontalPosP;
		public UAVObjectField<float> VerticalPosP;
		public UAVObjectField<float> BearingPI;
		public UAVObjectField<float> PowerPI;
		public UAVObjectField<float> VerticalToPitchCrossFeed;
		public UAVObjectField<float> AirspeedToVerticalCrossFeed;
		public UAVObjectField<float> SpeedPI;
		public UAVObjectField<float> RollLimit;
		public UAVObjectField<float> PitchLimit;
		public UAVObjectField<float> ThrottleLimit;
		public UAVObjectField<float> OrbitRadius;
		public UAVObjectField<Int16> UpdatePeriod;

		public FixedWingPathFollowerSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> HorizontalPosPElemNames = new List<String>();
			HorizontalPosPElemNames.Add("0");
			HorizontalPosP=new UAVObjectField<float>("HorizontalPosP", "", HorizontalPosPElemNames, null, this);
			fields.Add(HorizontalPosP);

			List<String> VerticalPosPElemNames = new List<String>();
			VerticalPosPElemNames.Add("0");
			VerticalPosP=new UAVObjectField<float>("VerticalPosP", "(m/s)/m", VerticalPosPElemNames, null, this);
			fields.Add(VerticalPosP);

			List<String> BearingPIElemNames = new List<String>();
			BearingPIElemNames.Add("Kp");
			BearingPIElemNames.Add("Ki");
			BearingPIElemNames.Add("ILimit");
			BearingPI=new UAVObjectField<float>("BearingPI", "deg/deg", BearingPIElemNames, null, this);
			fields.Add(BearingPI);

			List<String> PowerPIElemNames = new List<String>();
			PowerPIElemNames.Add("Kp");
			PowerPIElemNames.Add("Ki");
			PowerPIElemNames.Add("ILimit");
			PowerPI=new UAVObjectField<float>("PowerPI", "deg / (m/s)", PowerPIElemNames, null, this);
			fields.Add(PowerPI);

			List<String> VerticalToPitchCrossFeedElemNames = new List<String>();
			VerticalToPitchCrossFeedElemNames.Add("Kp");
			VerticalToPitchCrossFeedElemNames.Add("Max");
			VerticalToPitchCrossFeed=new UAVObjectField<float>("VerticalToPitchCrossFeed", "deg / ((m/s)/(m/s))", VerticalToPitchCrossFeedElemNames, null, this);
			fields.Add(VerticalToPitchCrossFeed);

			List<String> AirspeedToVerticalCrossFeedElemNames = new List<String>();
			AirspeedToVerticalCrossFeedElemNames.Add("Kp");
			AirspeedToVerticalCrossFeedElemNames.Add("Max");
			AirspeedToVerticalCrossFeed=new UAVObjectField<float>("AirspeedToVerticalCrossFeed", "(m/s) / ((m/s)/(m/s))", AirspeedToVerticalCrossFeedElemNames, null, this);
			fields.Add(AirspeedToVerticalCrossFeed);

			List<String> SpeedPIElemNames = new List<String>();
			SpeedPIElemNames.Add("Kp");
			SpeedPIElemNames.Add("Ki");
			SpeedPIElemNames.Add("ILimit");
			SpeedPI=new UAVObjectField<float>("SpeedPI", "1/(m/s)", SpeedPIElemNames, null, this);
			fields.Add(SpeedPI);

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

			List<String> OrbitRadiusElemNames = new List<String>();
			OrbitRadiusElemNames.Add("0");
			OrbitRadius=new UAVObjectField<float>("OrbitRadius", "m", OrbitRadiusElemNames, null, this);
			fields.Add(OrbitRadius);

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
			HorizontalPosP.setValue((float)6);
			VerticalPosP.setValue((float)5);
			BearingPI.setValue((float)0.6,0);
			BearingPI.setValue((float)0,1);
			BearingPI.setValue((float)0,2);
			PowerPI.setValue((float)1.5,0);
			PowerPI.setValue((float)0.15,1);
			PowerPI.setValue((float)20,2);
			VerticalToPitchCrossFeed.setValue((float)5,0);
			VerticalToPitchCrossFeed.setValue((float)10,1);
			AirspeedToVerticalCrossFeed.setValue((float)10,0);
			AirspeedToVerticalCrossFeed.setValue((float)100,1);
			SpeedPI.setValue((float)0.01,0);
			SpeedPI.setValue((float)0.01,1);
			SpeedPI.setValue((float)0.8,2);
			RollLimit.setValue((float)-35,0);
			RollLimit.setValue((float)0,1);
			RollLimit.setValue((float)35,2);
			PitchLimit.setValue((float)-10,0);
			PitchLimit.setValue((float)0,1);
			PitchLimit.setValue((float)10,2);
			ThrottleLimit.setValue((float)0,0);
			ThrottleLimit.setValue((float)0.5,1);
			ThrottleLimit.setValue((float)1,2);
			OrbitRadius.setValue((float)50);
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
				FixedWingPathFollowerSettings obj = new FixedWingPathFollowerSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public FixedWingPathFollowerSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (FixedWingPathFollowerSettings)(objMngr.getObject(FixedWingPathFollowerSettings.OBJID, instID));
		}
	}
}

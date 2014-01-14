// Object ID: 3874321172
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
		public const long OBJID = 3874321172;
		public int NUMBYTES { get; set; }
		protected const String NAME = "FixedWingPathFollowerSettings";
	    protected static String DESCRIPTION = @"Settings for the @ref FixedWingPathFollowerModule";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> HorizontalVelMax;
		public UAVObjectField<float> HorizontalVelMin;
		public UAVObjectField<float> VerticalVelMax;
		public UAVObjectField<float> CourseFeedForward;
		public UAVObjectField<float> HorizontalPosP;
		public UAVObjectField<float> VerticalPosP;
		public UAVObjectField<float> CoursePI;
		public UAVObjectField<float> SpeedPI;
		public UAVObjectField<float> VerticalToPitchCrossFeed;
		public UAVObjectField<float> AirspeedToPowerCrossFeed;
		public UAVObjectField<float> PowerPI;
		public UAVObjectField<float> RollLimit;
		public UAVObjectField<float> PitchLimit;
		public UAVObjectField<float> ThrottleLimit;
		public UAVObjectField<float> Safetymargins;
		public UAVObjectField<Int32> UpdatePeriod;

		public FixedWingPathFollowerSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> HorizontalVelMaxElemNames = new List<String>();
			HorizontalVelMaxElemNames.Add("0");
			HorizontalVelMax=new UAVObjectField<float>("HorizontalVelMax", "m/s", HorizontalVelMaxElemNames, null, this);
			fields.Add(HorizontalVelMax);

			List<String> HorizontalVelMinElemNames = new List<String>();
			HorizontalVelMinElemNames.Add("0");
			HorizontalVelMin=new UAVObjectField<float>("HorizontalVelMin", "m/s", HorizontalVelMinElemNames, null, this);
			fields.Add(HorizontalVelMin);

			List<String> VerticalVelMaxElemNames = new List<String>();
			VerticalVelMaxElemNames.Add("0");
			VerticalVelMax=new UAVObjectField<float>("VerticalVelMax", "m/s", VerticalVelMaxElemNames, null, this);
			fields.Add(VerticalVelMax);

			List<String> CourseFeedForwardElemNames = new List<String>();
			CourseFeedForwardElemNames.Add("0");
			CourseFeedForward=new UAVObjectField<float>("CourseFeedForward", "s", CourseFeedForwardElemNames, null, this);
			fields.Add(CourseFeedForward);

			List<String> HorizontalPosPElemNames = new List<String>();
			HorizontalPosPElemNames.Add("0");
			HorizontalPosP=new UAVObjectField<float>("HorizontalPosP", "(m/s)/m", HorizontalPosPElemNames, null, this);
			fields.Add(HorizontalPosP);

			List<String> VerticalPosPElemNames = new List<String>();
			VerticalPosPElemNames.Add("0");
			VerticalPosP=new UAVObjectField<float>("VerticalPosP", "(m/s)/m", VerticalPosPElemNames, null, this);
			fields.Add(VerticalPosP);

			List<String> CoursePIElemNames = new List<String>();
			CoursePIElemNames.Add("Kp");
			CoursePIElemNames.Add("Ki");
			CoursePIElemNames.Add("ILimit");
			CoursePI=new UAVObjectField<float>("CoursePI", "deg/deg", CoursePIElemNames, null, this);
			fields.Add(CoursePI);

			List<String> SpeedPIElemNames = new List<String>();
			SpeedPIElemNames.Add("Kp");
			SpeedPIElemNames.Add("Ki");
			SpeedPIElemNames.Add("ILimit");
			SpeedPI=new UAVObjectField<float>("SpeedPI", "deg / (m/s)", SpeedPIElemNames, null, this);
			fields.Add(SpeedPI);

			List<String> VerticalToPitchCrossFeedElemNames = new List<String>();
			VerticalToPitchCrossFeedElemNames.Add("Kp");
			VerticalToPitchCrossFeedElemNames.Add("Max");
			VerticalToPitchCrossFeed=new UAVObjectField<float>("VerticalToPitchCrossFeed", "deg / (m/s)", VerticalToPitchCrossFeedElemNames, null, this);
			fields.Add(VerticalToPitchCrossFeed);

			List<String> AirspeedToPowerCrossFeedElemNames = new List<String>();
			AirspeedToPowerCrossFeedElemNames.Add("Kp");
			AirspeedToPowerCrossFeedElemNames.Add("Max");
			AirspeedToPowerCrossFeed=new UAVObjectField<float>("AirspeedToPowerCrossFeed", "1 / (m/s)", AirspeedToPowerCrossFeedElemNames, null, this);
			fields.Add(AirspeedToPowerCrossFeed);

			List<String> PowerPIElemNames = new List<String>();
			PowerPIElemNames.Add("Kp");
			PowerPIElemNames.Add("Ki");
			PowerPIElemNames.Add("ILimit");
			PowerPI=new UAVObjectField<float>("PowerPI", "1/(m/s)", PowerPIElemNames, null, this);
			fields.Add(PowerPI);

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

			List<String> SafetymarginsElemNames = new List<String>();
			SafetymarginsElemNames.Add("Wind");
			SafetymarginsElemNames.Add("Stallspeed");
			SafetymarginsElemNames.Add("Lowspeed");
			SafetymarginsElemNames.Add("Highspeed");
			SafetymarginsElemNames.Add("Overspeed");
			SafetymarginsElemNames.Add("Lowpower");
			SafetymarginsElemNames.Add("Highpower");
			SafetymarginsElemNames.Add("Pitchcontrol");
			Safetymargins=new UAVObjectField<float>("Safetymargins", "", SafetymarginsElemNames, null, this);
			fields.Add(Safetymargins);

			List<String> UpdatePeriodElemNames = new List<String>();
			UpdatePeriodElemNames.Add("0");
			UpdatePeriod=new UAVObjectField<Int32>("UpdatePeriod", "ms", UpdatePeriodElemNames, null, this);
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
			HorizontalVelMax.setValue((float)20);
			HorizontalVelMin.setValue((float)10);
			VerticalVelMax.setValue((float)10);
			CourseFeedForward.setValue((float)30);
			HorizontalPosP.setValue((float)5);
			VerticalPosP.setValue((float)2);
			CoursePI.setValue((float)0.2,0);
			CoursePI.setValue((float)0,1);
			CoursePI.setValue((float)0,2);
			SpeedPI.setValue((float)2.5,0);
			SpeedPI.setValue((float)0.25,1);
			SpeedPI.setValue((float)10,2);
			VerticalToPitchCrossFeed.setValue((float)5,0);
			VerticalToPitchCrossFeed.setValue((float)10,1);
			AirspeedToPowerCrossFeed.setValue((float)0.2,0);
			AirspeedToPowerCrossFeed.setValue((float)1,1);
			PowerPI.setValue((float)0.01,0);
			PowerPI.setValue((float)0.05,1);
			PowerPI.setValue((float)0.5,2);
			RollLimit.setValue((float)-35,0);
			RollLimit.setValue((float)0,1);
			RollLimit.setValue((float)35,2);
			PitchLimit.setValue((float)-10,0);
			PitchLimit.setValue((float)5,1);
			PitchLimit.setValue((float)20,2);
			ThrottleLimit.setValue((float)0.1,0);
			ThrottleLimit.setValue((float)0.5,1);
			ThrottleLimit.setValue((float)0.9,2);
			Safetymargins.setValue((float)90,0);
			Safetymargins.setValue((float)1,1);
			Safetymargins.setValue((float)0.5,2);
			Safetymargins.setValue((float)1.5,3);
			Safetymargins.setValue((float)1,4);
			Safetymargins.setValue((float)1,5);
			Safetymargins.setValue((float)1,6);
			Safetymargins.setValue((float)1,7);
			UpdatePeriod.setValue((Int32)100);
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

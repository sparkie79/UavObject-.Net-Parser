// Object ID: 3703285786
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class OsdSettings : UAVDataObject
	{
		public const long OBJID = 3703285786;
		public int NUMBYTES { get; set; }
		protected const String NAME = "OsdSettings";
	    protected static String DESCRIPTION = @"OSD settings used by the OSDgen module";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<Int16> AttitudeSetup;
		public UAVObjectField<Int16> TimeSetup;
		public UAVObjectField<Int16> BatterySetup;
		public UAVObjectField<Int16> SpeedSetup;
		public UAVObjectField<Int16> AltitudeSetup;
		public UAVObjectField<Int16> HeadingSetup;
		public enum AttitudeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Enabled")]
			Enabled = 1, 
		}
		public UAVObjectField<AttitudeUavEnum> Attitude;
		public enum TimeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Enabled")]
			Enabled = 1, 
		}
		public UAVObjectField<TimeUavEnum> Time;
		public enum BatteryUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Enabled")]
			Enabled = 1, 
		}
		public UAVObjectField<BatteryUavEnum> Battery;
		public enum SpeedUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Enabled")]
			Enabled = 1, 
		}
		public UAVObjectField<SpeedUavEnum> Speed;
		public enum AltitudeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Enabled")]
			Enabled = 1, 
		}
		public UAVObjectField<AltitudeUavEnum> Altitude;
		public enum HeadingUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Enabled")]
			Enabled = 1, 
		}
		public UAVObjectField<HeadingUavEnum> Heading;
		public UAVObjectField<byte> Screen;
		public UAVObjectField<byte> White;
		public UAVObjectField<byte> Black;
		public enum AltitudeSourceUavEnum
		{
			[Description("GPS")]
			GPS = 0, 
			[Description("Baro")]
			Baro = 1, 
		}
		public UAVObjectField<AltitudeSourceUavEnum> AltitudeSource;

		public OsdSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> AttitudeSetupElemNames = new List<String>();
			AttitudeSetupElemNames.Add("X");
			AttitudeSetupElemNames.Add("Y");
			AttitudeSetup=new UAVObjectField<Int16>("AttitudeSetup", "", AttitudeSetupElemNames, null, this);
			fields.Add(AttitudeSetup);

			List<String> TimeSetupElemNames = new List<String>();
			TimeSetupElemNames.Add("X");
			TimeSetupElemNames.Add("Y");
			TimeSetup=new UAVObjectField<Int16>("TimeSetup", "", TimeSetupElemNames, null, this);
			fields.Add(TimeSetup);

			List<String> BatterySetupElemNames = new List<String>();
			BatterySetupElemNames.Add("X");
			BatterySetupElemNames.Add("Y");
			BatterySetup=new UAVObjectField<Int16>("BatterySetup", "", BatterySetupElemNames, null, this);
			fields.Add(BatterySetup);

			List<String> SpeedSetupElemNames = new List<String>();
			SpeedSetupElemNames.Add("X");
			SpeedSetupElemNames.Add("Y");
			SpeedSetup=new UAVObjectField<Int16>("SpeedSetup", "", SpeedSetupElemNames, null, this);
			fields.Add(SpeedSetup);

			List<String> AltitudeSetupElemNames = new List<String>();
			AltitudeSetupElemNames.Add("X");
			AltitudeSetupElemNames.Add("Y");
			AltitudeSetup=new UAVObjectField<Int16>("AltitudeSetup", "", AltitudeSetupElemNames, null, this);
			fields.Add(AltitudeSetup);

			List<String> HeadingSetupElemNames = new List<String>();
			HeadingSetupElemNames.Add("X");
			HeadingSetupElemNames.Add("Y");
			HeadingSetup=new UAVObjectField<Int16>("HeadingSetup", "", HeadingSetupElemNames, null, this);
			fields.Add(HeadingSetup);

			List<String> AttitudeElemNames = new List<String>();
			AttitudeElemNames.Add("0");
			List<String> AttitudeEnumOptions = new List<String>();
			AttitudeEnumOptions.Add("Disabled");
			AttitudeEnumOptions.Add("Enabled");
			Attitude=new UAVObjectField<AttitudeUavEnum>("Attitude", "", AttitudeElemNames, AttitudeEnumOptions, this);
			fields.Add(Attitude);

			List<String> TimeElemNames = new List<String>();
			TimeElemNames.Add("0");
			List<String> TimeEnumOptions = new List<String>();
			TimeEnumOptions.Add("Disabled");
			TimeEnumOptions.Add("Enabled");
			Time=new UAVObjectField<TimeUavEnum>("Time", "", TimeElemNames, TimeEnumOptions, this);
			fields.Add(Time);

			List<String> BatteryElemNames = new List<String>();
			BatteryElemNames.Add("0");
			List<String> BatteryEnumOptions = new List<String>();
			BatteryEnumOptions.Add("Disabled");
			BatteryEnumOptions.Add("Enabled");
			Battery=new UAVObjectField<BatteryUavEnum>("Battery", "", BatteryElemNames, BatteryEnumOptions, this);
			fields.Add(Battery);

			List<String> SpeedElemNames = new List<String>();
			SpeedElemNames.Add("0");
			List<String> SpeedEnumOptions = new List<String>();
			SpeedEnumOptions.Add("Disabled");
			SpeedEnumOptions.Add("Enabled");
			Speed=new UAVObjectField<SpeedUavEnum>("Speed", "", SpeedElemNames, SpeedEnumOptions, this);
			fields.Add(Speed);

			List<String> AltitudeElemNames = new List<String>();
			AltitudeElemNames.Add("0");
			List<String> AltitudeEnumOptions = new List<String>();
			AltitudeEnumOptions.Add("Disabled");
			AltitudeEnumOptions.Add("Enabled");
			Altitude=new UAVObjectField<AltitudeUavEnum>("Altitude", "", AltitudeElemNames, AltitudeEnumOptions, this);
			fields.Add(Altitude);

			List<String> HeadingElemNames = new List<String>();
			HeadingElemNames.Add("0");
			List<String> HeadingEnumOptions = new List<String>();
			HeadingEnumOptions.Add("Disabled");
			HeadingEnumOptions.Add("Enabled");
			Heading=new UAVObjectField<HeadingUavEnum>("Heading", "", HeadingElemNames, HeadingEnumOptions, this);
			fields.Add(Heading);

			List<String> ScreenElemNames = new List<String>();
			ScreenElemNames.Add("0");
			Screen=new UAVObjectField<byte>("Screen", "", ScreenElemNames, null, this);
			fields.Add(Screen);

			List<String> WhiteElemNames = new List<String>();
			WhiteElemNames.Add("0");
			White=new UAVObjectField<byte>("White", "", WhiteElemNames, null, this);
			fields.Add(White);

			List<String> BlackElemNames = new List<String>();
			BlackElemNames.Add("0");
			Black=new UAVObjectField<byte>("Black", "", BlackElemNames, null, this);
			fields.Add(Black);

			List<String> AltitudeSourceElemNames = new List<String>();
			AltitudeSourceElemNames.Add("0");
			List<String> AltitudeSourceEnumOptions = new List<String>();
			AltitudeSourceEnumOptions.Add("GPS");
			AltitudeSourceEnumOptions.Add("Baro");
			AltitudeSource=new UAVObjectField<AltitudeSourceUavEnum>("AltitudeSource", "", AltitudeSourceElemNames, AltitudeSourceEnumOptions, this);
			fields.Add(AltitudeSource);

	

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
			AttitudeSetup.setValue((Int16)168,0);
			AttitudeSetup.setValue((Int16)135,1);
			TimeSetup.setValue((Int16)10,0);
			TimeSetup.setValue((Int16)250,1);
			BatterySetup.setValue((Int16)316,0);
			BatterySetup.setValue((Int16)210,1);
			SpeedSetup.setValue((Int16)2,0);
			SpeedSetup.setValue((Int16)145,1);
			AltitudeSetup.setValue((Int16)2,0);
			AltitudeSetup.setValue((Int16)145,1);
			HeadingSetup.setValue((Int16)168,0);
			HeadingSetup.setValue((Int16)240,1);
			Attitude.setValue(AttitudeUavEnum.Enabled);
			Time.setValue(TimeUavEnum.Enabled);
			Battery.setValue(BatteryUavEnum.Enabled);
			Speed.setValue(SpeedUavEnum.Enabled);
			Altitude.setValue(AltitudeUavEnum.Enabled);
			Heading.setValue(HeadingUavEnum.Enabled);
			Screen.setValue((byte)0);
			White.setValue((byte)4);
			Black.setValue((byte)1);
			AltitudeSource.setValue(AltitudeSourceUavEnum.GPS);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				OsdSettings obj = new OsdSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public OsdSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (OsdSettings)(objMngr.getObject(OsdSettings.OBJID, instID));
		}
	}
}

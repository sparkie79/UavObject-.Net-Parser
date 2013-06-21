// Object ID: 1549656906
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class ManualControlSettings : UAVDataObject
	{
		public const long OBJID = 1549656906;
		public int NUMBYTES { get; set; }
		protected const String NAME = "ManualControlSettings";
	    protected static String DESCRIPTION = @"Settings to indicate how to decode receiver input by @ref ManualControlModule.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> Deadband;
		public UAVObjectField<Int16> ChannelMin;
		public UAVObjectField<Int16> ChannelNeutral;
		public UAVObjectField<Int16> ChannelMax;
		public UAVObjectField<UInt16> ArmedTimeout;
		public enum ChannelGroupsUavEnum
		{
			[Description("PWM")]
			PWM = 0, 
			[Description("PPM")]
			PPM = 1, 
			[Description("DSM (MainPort)")]
			DSMMainPort = 2, 
			[Description("DSM (FlexiPort)")]
			DSMFlexiPort = 3, 
			[Description("S.Bus")]
			SBus = 4, 
			[Description("GCS")]
			GCS = 5, 
			[Description("None")]
			None = 6, 
		}
		public UAVObjectField<ChannelGroupsUavEnum> ChannelGroups;
		public UAVObjectField<byte> ChannelNumber;
		public enum ArmingUavEnum
		{
			[Description("Always Disarmed")]
			AlwaysDisarmed = 0, 
			[Description("Always Armed")]
			AlwaysArmed = 1, 
			[Description("Roll Left")]
			RollLeft = 2, 
			[Description("Roll Right")]
			RollRight = 3, 
			[Description("Pitch Forward")]
			PitchForward = 4, 
			[Description("Pitch Aft")]
			PitchAft = 5, 
			[Description("Yaw Left")]
			YawLeft = 6, 
			[Description("Yaw Right")]
			YawRight = 7, 
		}
		public UAVObjectField<ArmingUavEnum> Arming;
		public enum Stabilization1SettingsUavEnum
		{
			[Description("None")]
			None = 0, 
			[Description("Rate")]
			Rate = 1, 
			[Description("Attitude")]
			Attitude = 2, 
			[Description("AxisLock")]
			AxisLock = 3, 
			[Description("WeakLeveling")]
			WeakLeveling = 4, 
			[Description("VirtualBar")]
			VirtualBar = 5, 
			[Description("RelayRate")]
			RelayRate = 6, 
			[Description("RelayAttitude")]
			RelayAttitude = 7, 
			[Description("POI")]
			POI = 8, 
			[Description("CoordinatedFlight")]
			CoordinatedFlight = 9, 
		}
		public UAVObjectField<Stabilization1SettingsUavEnum> Stabilization1Settings;
		public enum Stabilization2SettingsUavEnum
		{
			[Description("None")]
			None = 0, 
			[Description("Rate")]
			Rate = 1, 
			[Description("Attitude")]
			Attitude = 2, 
			[Description("AxisLock")]
			AxisLock = 3, 
			[Description("WeakLeveling")]
			WeakLeveling = 4, 
			[Description("VirtualBar")]
			VirtualBar = 5, 
			[Description("RelayRate")]
			RelayRate = 6, 
			[Description("RelayAttitude")]
			RelayAttitude = 7, 
			[Description("POI")]
			POI = 8, 
			[Description("CoordinatedFlight")]
			CoordinatedFlight = 9, 
		}
		public UAVObjectField<Stabilization2SettingsUavEnum> Stabilization2Settings;
		public enum Stabilization3SettingsUavEnum
		{
			[Description("None")]
			None = 0, 
			[Description("Rate")]
			Rate = 1, 
			[Description("Attitude")]
			Attitude = 2, 
			[Description("AxisLock")]
			AxisLock = 3, 
			[Description("WeakLeveling")]
			WeakLeveling = 4, 
			[Description("VirtualBar")]
			VirtualBar = 5, 
			[Description("RelayRate")]
			RelayRate = 6, 
			[Description("RelayAttitude")]
			RelayAttitude = 7, 
			[Description("POI")]
			POI = 8, 
			[Description("CoordinatedFlight")]
			CoordinatedFlight = 9, 
		}
		public UAVObjectField<Stabilization3SettingsUavEnum> Stabilization3Settings;
		public UAVObjectField<byte> FlightModeNumber;
		public enum FlightModePositionUavEnum
		{
			[Description("Manual")]
			Manual = 0, 
			[Description("Stabilized1")]
			Stabilized1 = 1, 
			[Description("Stabilized2")]
			Stabilized2 = 2, 
			[Description("Stabilized3")]
			Stabilized3 = 3, 
			[Description("Autotune")]
			Autotune = 4, 
			[Description("AltitudeHold")]
			AltitudeHold = 5, 
			[Description("VelocityControl")]
			VelocityControl = 6, 
			[Description("PositionHold")]
			PositionHold = 7, 
			[Description("ReturnToHome")]
			ReturnToHome = 8, 
			[Description("PathPlanner")]
			PathPlanner = 9, 
			[Description("TabletControl")]
			TabletControl = 10, 
		}
		public UAVObjectField<FlightModePositionUavEnum> FlightModePosition;

		public ManualControlSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> DeadbandElemNames = new List<String>();
			DeadbandElemNames.Add("0");
			Deadband=new UAVObjectField<float>("Deadband", "%", DeadbandElemNames, null, this);
			fields.Add(Deadband);

			List<String> ChannelMinElemNames = new List<String>();
			ChannelMinElemNames.Add("Throttle");
			ChannelMinElemNames.Add("Roll");
			ChannelMinElemNames.Add("Pitch");
			ChannelMinElemNames.Add("Yaw");
			ChannelMinElemNames.Add("FlightMode");
			ChannelMinElemNames.Add("Collective");
			ChannelMinElemNames.Add("Accessory0");
			ChannelMinElemNames.Add("Accessory1");
			ChannelMinElemNames.Add("Accessory2");
			ChannelMin=new UAVObjectField<Int16>("ChannelMin", "us", ChannelMinElemNames, null, this);
			fields.Add(ChannelMin);

			List<String> ChannelNeutralElemNames = new List<String>();
			ChannelNeutralElemNames.Add("Throttle");
			ChannelNeutralElemNames.Add("Roll");
			ChannelNeutralElemNames.Add("Pitch");
			ChannelNeutralElemNames.Add("Yaw");
			ChannelNeutralElemNames.Add("FlightMode");
			ChannelNeutralElemNames.Add("Collective");
			ChannelNeutralElemNames.Add("Accessory0");
			ChannelNeutralElemNames.Add("Accessory1");
			ChannelNeutralElemNames.Add("Accessory2");
			ChannelNeutral=new UAVObjectField<Int16>("ChannelNeutral", "us", ChannelNeutralElemNames, null, this);
			fields.Add(ChannelNeutral);

			List<String> ChannelMaxElemNames = new List<String>();
			ChannelMaxElemNames.Add("Throttle");
			ChannelMaxElemNames.Add("Roll");
			ChannelMaxElemNames.Add("Pitch");
			ChannelMaxElemNames.Add("Yaw");
			ChannelMaxElemNames.Add("FlightMode");
			ChannelMaxElemNames.Add("Collective");
			ChannelMaxElemNames.Add("Accessory0");
			ChannelMaxElemNames.Add("Accessory1");
			ChannelMaxElemNames.Add("Accessory2");
			ChannelMax=new UAVObjectField<Int16>("ChannelMax", "us", ChannelMaxElemNames, null, this);
			fields.Add(ChannelMax);

			List<String> ArmedTimeoutElemNames = new List<String>();
			ArmedTimeoutElemNames.Add("0");
			ArmedTimeout=new UAVObjectField<UInt16>("ArmedTimeout", "ms", ArmedTimeoutElemNames, null, this);
			fields.Add(ArmedTimeout);

			List<String> ChannelGroupsElemNames = new List<String>();
			ChannelGroupsElemNames.Add("Throttle");
			ChannelGroupsElemNames.Add("Roll");
			ChannelGroupsElemNames.Add("Pitch");
			ChannelGroupsElemNames.Add("Yaw");
			ChannelGroupsElemNames.Add("FlightMode");
			ChannelGroupsElemNames.Add("Collective");
			ChannelGroupsElemNames.Add("Accessory0");
			ChannelGroupsElemNames.Add("Accessory1");
			ChannelGroupsElemNames.Add("Accessory2");
			List<String> ChannelGroupsEnumOptions = new List<String>();
			ChannelGroupsEnumOptions.Add("PWM");
			ChannelGroupsEnumOptions.Add("PPM");
			ChannelGroupsEnumOptions.Add("DSM (MainPort)");
			ChannelGroupsEnumOptions.Add("DSM (FlexiPort)");
			ChannelGroupsEnumOptions.Add("S.Bus");
			ChannelGroupsEnumOptions.Add("GCS");
			ChannelGroupsEnumOptions.Add("None");
			ChannelGroups=new UAVObjectField<ChannelGroupsUavEnum>("ChannelGroups", "Channel Group", ChannelGroupsElemNames, ChannelGroupsEnumOptions, this);
			fields.Add(ChannelGroups);

			List<String> ChannelNumberElemNames = new List<String>();
			ChannelNumberElemNames.Add("Throttle");
			ChannelNumberElemNames.Add("Roll");
			ChannelNumberElemNames.Add("Pitch");
			ChannelNumberElemNames.Add("Yaw");
			ChannelNumberElemNames.Add("FlightMode");
			ChannelNumberElemNames.Add("Collective");
			ChannelNumberElemNames.Add("Accessory0");
			ChannelNumberElemNames.Add("Accessory1");
			ChannelNumberElemNames.Add("Accessory2");
			ChannelNumber=new UAVObjectField<byte>("ChannelNumber", "channel", ChannelNumberElemNames, null, this);
			fields.Add(ChannelNumber);

			List<String> ArmingElemNames = new List<String>();
			ArmingElemNames.Add("0");
			List<String> ArmingEnumOptions = new List<String>();
			ArmingEnumOptions.Add("Always Disarmed");
			ArmingEnumOptions.Add("Always Armed");
			ArmingEnumOptions.Add("Roll Left");
			ArmingEnumOptions.Add("Roll Right");
			ArmingEnumOptions.Add("Pitch Forward");
			ArmingEnumOptions.Add("Pitch Aft");
			ArmingEnumOptions.Add("Yaw Left");
			ArmingEnumOptions.Add("Yaw Right");
			Arming=new UAVObjectField<ArmingUavEnum>("Arming", "", ArmingElemNames, ArmingEnumOptions, this);
			fields.Add(Arming);

			List<String> Stabilization1SettingsElemNames = new List<String>();
			Stabilization1SettingsElemNames.Add("Roll");
			Stabilization1SettingsElemNames.Add("Pitch");
			Stabilization1SettingsElemNames.Add("Yaw");
			List<String> Stabilization1SettingsEnumOptions = new List<String>();
			Stabilization1SettingsEnumOptions.Add("None");
			Stabilization1SettingsEnumOptions.Add("Rate");
			Stabilization1SettingsEnumOptions.Add("Attitude");
			Stabilization1SettingsEnumOptions.Add("AxisLock");
			Stabilization1SettingsEnumOptions.Add("WeakLeveling");
			Stabilization1SettingsEnumOptions.Add("VirtualBar");
			Stabilization1SettingsEnumOptions.Add("RelayRate");
			Stabilization1SettingsEnumOptions.Add("RelayAttitude");
			Stabilization1SettingsEnumOptions.Add("POI");
			Stabilization1SettingsEnumOptions.Add("CoordinatedFlight");
			Stabilization1Settings=new UAVObjectField<Stabilization1SettingsUavEnum>("Stabilization1Settings", "", Stabilization1SettingsElemNames, Stabilization1SettingsEnumOptions, this);
			fields.Add(Stabilization1Settings);

			List<String> Stabilization2SettingsElemNames = new List<String>();
			Stabilization2SettingsElemNames.Add("Roll");
			Stabilization2SettingsElemNames.Add("Pitch");
			Stabilization2SettingsElemNames.Add("Yaw");
			List<String> Stabilization2SettingsEnumOptions = new List<String>();
			Stabilization2SettingsEnumOptions.Add("None");
			Stabilization2SettingsEnumOptions.Add("Rate");
			Stabilization2SettingsEnumOptions.Add("Attitude");
			Stabilization2SettingsEnumOptions.Add("AxisLock");
			Stabilization2SettingsEnumOptions.Add("WeakLeveling");
			Stabilization2SettingsEnumOptions.Add("VirtualBar");
			Stabilization2SettingsEnumOptions.Add("RelayRate");
			Stabilization2SettingsEnumOptions.Add("RelayAttitude");
			Stabilization2SettingsEnumOptions.Add("POI");
			Stabilization2SettingsEnumOptions.Add("CoordinatedFlight");
			Stabilization2Settings=new UAVObjectField<Stabilization2SettingsUavEnum>("Stabilization2Settings", "", Stabilization2SettingsElemNames, Stabilization2SettingsEnumOptions, this);
			fields.Add(Stabilization2Settings);

			List<String> Stabilization3SettingsElemNames = new List<String>();
			Stabilization3SettingsElemNames.Add("Roll");
			Stabilization3SettingsElemNames.Add("Pitch");
			Stabilization3SettingsElemNames.Add("Yaw");
			List<String> Stabilization3SettingsEnumOptions = new List<String>();
			Stabilization3SettingsEnumOptions.Add("None");
			Stabilization3SettingsEnumOptions.Add("Rate");
			Stabilization3SettingsEnumOptions.Add("Attitude");
			Stabilization3SettingsEnumOptions.Add("AxisLock");
			Stabilization3SettingsEnumOptions.Add("WeakLeveling");
			Stabilization3SettingsEnumOptions.Add("VirtualBar");
			Stabilization3SettingsEnumOptions.Add("RelayRate");
			Stabilization3SettingsEnumOptions.Add("RelayAttitude");
			Stabilization3SettingsEnumOptions.Add("POI");
			Stabilization3SettingsEnumOptions.Add("CoordinatedFlight");
			Stabilization3Settings=new UAVObjectField<Stabilization3SettingsUavEnum>("Stabilization3Settings", "", Stabilization3SettingsElemNames, Stabilization3SettingsEnumOptions, this);
			fields.Add(Stabilization3Settings);

			List<String> FlightModeNumberElemNames = new List<String>();
			FlightModeNumberElemNames.Add("0");
			FlightModeNumber=new UAVObjectField<byte>("FlightModeNumber", "", FlightModeNumberElemNames, null, this);
			fields.Add(FlightModeNumber);

			List<String> FlightModePositionElemNames = new List<String>();
			FlightModePositionElemNames.Add("0");
			FlightModePositionElemNames.Add("1");
			FlightModePositionElemNames.Add("2");
			FlightModePositionElemNames.Add("3");
			FlightModePositionElemNames.Add("4");
			FlightModePositionElemNames.Add("5");
			List<String> FlightModePositionEnumOptions = new List<String>();
			FlightModePositionEnumOptions.Add("Manual");
			FlightModePositionEnumOptions.Add("Stabilized1");
			FlightModePositionEnumOptions.Add("Stabilized2");
			FlightModePositionEnumOptions.Add("Stabilized3");
			FlightModePositionEnumOptions.Add("Autotune");
			FlightModePositionEnumOptions.Add("AltitudeHold");
			FlightModePositionEnumOptions.Add("VelocityControl");
			FlightModePositionEnumOptions.Add("PositionHold");
			FlightModePositionEnumOptions.Add("ReturnToHome");
			FlightModePositionEnumOptions.Add("PathPlanner");
			FlightModePositionEnumOptions.Add("TabletControl");
			FlightModePosition=new UAVObjectField<FlightModePositionUavEnum>("FlightModePosition", "", FlightModePositionElemNames, FlightModePositionEnumOptions, this);
			fields.Add(FlightModePosition);

	

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
			Deadband.setValue((float)0);
			ChannelMin.setValue((Int16)1000,0);
			ChannelMin.setValue((Int16)1000,1);
			ChannelMin.setValue((Int16)1000,2);
			ChannelMin.setValue((Int16)1000,3);
			ChannelMin.setValue((Int16)1000,4);
			ChannelMin.setValue((Int16)1000,5);
			ChannelMin.setValue((Int16)1000,6);
			ChannelMin.setValue((Int16)1000,7);
			ChannelMin.setValue((Int16)1000,8);
			ChannelNeutral.setValue((Int16)1500,0);
			ChannelNeutral.setValue((Int16)1500,1);
			ChannelNeutral.setValue((Int16)1500,2);
			ChannelNeutral.setValue((Int16)1500,3);
			ChannelNeutral.setValue((Int16)1500,4);
			ChannelNeutral.setValue((Int16)1500,5);
			ChannelNeutral.setValue((Int16)1500,6);
			ChannelNeutral.setValue((Int16)1500,7);
			ChannelNeutral.setValue((Int16)1500,8);
			ChannelMax.setValue((Int16)2000,0);
			ChannelMax.setValue((Int16)2000,1);
			ChannelMax.setValue((Int16)2000,2);
			ChannelMax.setValue((Int16)2000,3);
			ChannelMax.setValue((Int16)2000,4);
			ChannelMax.setValue((Int16)2000,5);
			ChannelMax.setValue((Int16)2000,6);
			ChannelMax.setValue((Int16)2000,7);
			ChannelMax.setValue((Int16)2000,8);
			ArmedTimeout.setValue((UInt16)30000);
			ChannelGroups.setValue(ChannelGroupsUavEnum.None,0);
			ChannelGroups.setValue(ChannelGroupsUavEnum.None,1);
			ChannelGroups.setValue(ChannelGroupsUavEnum.None,2);
			ChannelGroups.setValue(ChannelGroupsUavEnum.None,3);
			ChannelGroups.setValue(ChannelGroupsUavEnum.None,4);
			ChannelGroups.setValue(ChannelGroupsUavEnum.None,5);
			ChannelGroups.setValue(ChannelGroupsUavEnum.None,6);
			ChannelGroups.setValue(ChannelGroupsUavEnum.None,7);
			ChannelGroups.setValue(ChannelGroupsUavEnum.None,8);
			ChannelNumber.setValue((byte)0,0);
			ChannelNumber.setValue((byte)0,1);
			ChannelNumber.setValue((byte)0,2);
			ChannelNumber.setValue((byte)0,3);
			ChannelNumber.setValue((byte)0,4);
			ChannelNumber.setValue((byte)0,5);
			ChannelNumber.setValue((byte)0,6);
			ChannelNumber.setValue((byte)0,7);
			ChannelNumber.setValue((byte)0,8);
			Arming.setValue(ArmingUavEnum.AlwaysDisarmed);
			Stabilization1Settings.setValue(Stabilization1SettingsUavEnum.Attitude,0);
			Stabilization1Settings.setValue(Stabilization1SettingsUavEnum.Attitude,1);
			Stabilization1Settings.setValue(Stabilization1SettingsUavEnum.Rate,2);
			Stabilization2Settings.setValue(Stabilization2SettingsUavEnum.Attitude,0);
			Stabilization2Settings.setValue(Stabilization2SettingsUavEnum.Attitude,1);
			Stabilization2Settings.setValue(Stabilization2SettingsUavEnum.Rate,2);
			Stabilization3Settings.setValue(Stabilization3SettingsUavEnum.Attitude,0);
			Stabilization3Settings.setValue(Stabilization3SettingsUavEnum.Attitude,1);
			Stabilization3Settings.setValue(Stabilization3SettingsUavEnum.Rate,2);
			FlightModeNumber.setValue((byte)3);
			FlightModePosition.setValue(FlightModePositionUavEnum.Manual,0);
			FlightModePosition.setValue(FlightModePositionUavEnum.Stabilized1,1);
			FlightModePosition.setValue(FlightModePositionUavEnum.Stabilized2,2);
			FlightModePosition.setValue(FlightModePositionUavEnum.Stabilized3,3);
			FlightModePosition.setValue(FlightModePositionUavEnum.ReturnToHome,4);
			FlightModePosition.setValue(FlightModePositionUavEnum.PositionHold,5);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				ManualControlSettings obj = new ManualControlSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public ManualControlSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (ManualControlSettings)(objMngr.getObject(ManualControlSettings.OBJID, instID));
		}
	}
}

// Object ID: 2333987988
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class OPLinkSettings : UAVDataObject
	{
		public const long OBJID = 2333987988;
		public int NUMBYTES { get; set; }
		protected const String NAME = "OPLinkSettings";
	    protected static String DESCRIPTION = @"OPLink configurations options.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<UInt32> CoordID;
		public enum CoordinatorUavEnum
		{
			[Description("FALSE")]
			FALSE = 0, 
			[Description("TRUE")]
			TRUE = 1, 
		}
		public UAVObjectField<CoordinatorUavEnum> Coordinator;
		public enum OneWayLinkUavEnum
		{
			[Description("FALSE")]
			FALSE = 0, 
			[Description("TRUE")]
			TRUE = 1, 
		}
		public UAVObjectField<OneWayLinkUavEnum> OneWayLink;
		public enum MainPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Telemetry")]
			Telemetry = 1, 
			[Description("Serial")]
			Serial = 2, 
			[Description("PPM")]
			PPM = 3, 
		}
		public UAVObjectField<MainPortUavEnum> MainPort;
		public enum FlexiPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Telemetry")]
			Telemetry = 1, 
			[Description("Serial")]
			Serial = 2, 
			[Description("PPM")]
			PPM = 3, 
		}
		public UAVObjectField<FlexiPortUavEnum> FlexiPort;
		public enum VCPPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Serial")]
			Serial = 1, 
		}
		public UAVObjectField<VCPPortUavEnum> VCPPort;
		public enum ComSpeedUavEnum
		{
			[Description("2400")]
			v2400 = 0, 
			[Description("4800")]
			v4800 = 1, 
			[Description("9600")]
			v9600 = 2, 
			[Description("19200")]
			v19200 = 3, 
			[Description("38400")]
			v38400 = 4, 
			[Description("57600")]
			v57600 = 5, 
			[Description("115200")]
			v115200 = 6, 
		}
		public UAVObjectField<ComSpeedUavEnum> ComSpeed;
		public enum MaxRFPowerUavEnum
		{
			[Description("1.25")]
			v125 = 0, 
			[Description("1.6")]
			v16 = 1, 
			[Description("3.16")]
			v316 = 2, 
			[Description("6.3")]
			v63 = 3, 
			[Description("12.6")]
			v126 = 4, 
			[Description("25")]
			v25 = 5, 
			[Description("50")]
			v50 = 6, 
			[Description("100")]
			v100 = 7, 
		}
		public UAVObjectField<MaxRFPowerUavEnum> MaxRFPower;
		public UAVObjectField<byte> MinChannel;
		public UAVObjectField<byte> MaxChannel;
		public UAVObjectField<byte> NumChannels;
		public UAVObjectField<byte> ChannelSet;
		public UAVObjectField<byte> PacketTime;

		public OPLinkSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> CoordIDElemNames = new List<String>();
			CoordIDElemNames.Add("0");
			CoordID=new UAVObjectField<UInt32>("CoordID", "hex", CoordIDElemNames, null, this);
			fields.Add(CoordID);

			List<String> CoordinatorElemNames = new List<String>();
			CoordinatorElemNames.Add("0");
			List<String> CoordinatorEnumOptions = new List<String>();
			CoordinatorEnumOptions.Add("FALSE");
			CoordinatorEnumOptions.Add("TRUE");
			Coordinator=new UAVObjectField<CoordinatorUavEnum>("Coordinator", "", CoordinatorElemNames, CoordinatorEnumOptions, this);
			fields.Add(Coordinator);

			List<String> OneWayLinkElemNames = new List<String>();
			OneWayLinkElemNames.Add("0");
			List<String> OneWayLinkEnumOptions = new List<String>();
			OneWayLinkEnumOptions.Add("FALSE");
			OneWayLinkEnumOptions.Add("TRUE");
			OneWayLink=new UAVObjectField<OneWayLinkUavEnum>("OneWayLink", "", OneWayLinkElemNames, OneWayLinkEnumOptions, this);
			fields.Add(OneWayLink);

			List<String> MainPortElemNames = new List<String>();
			MainPortElemNames.Add("0");
			List<String> MainPortEnumOptions = new List<String>();
			MainPortEnumOptions.Add("Disabled");
			MainPortEnumOptions.Add("Telemetry");
			MainPortEnumOptions.Add("Serial");
			MainPortEnumOptions.Add("PPM");
			MainPort=new UAVObjectField<MainPortUavEnum>("MainPort", "", MainPortElemNames, MainPortEnumOptions, this);
			fields.Add(MainPort);

			List<String> FlexiPortElemNames = new List<String>();
			FlexiPortElemNames.Add("0");
			List<String> FlexiPortEnumOptions = new List<String>();
			FlexiPortEnumOptions.Add("Disabled");
			FlexiPortEnumOptions.Add("Telemetry");
			FlexiPortEnumOptions.Add("Serial");
			FlexiPortEnumOptions.Add("PPM");
			FlexiPort=new UAVObjectField<FlexiPortUavEnum>("FlexiPort", "", FlexiPortElemNames, FlexiPortEnumOptions, this);
			fields.Add(FlexiPort);

			List<String> VCPPortElemNames = new List<String>();
			VCPPortElemNames.Add("0");
			List<String> VCPPortEnumOptions = new List<String>();
			VCPPortEnumOptions.Add("Disabled");
			VCPPortEnumOptions.Add("Serial");
			VCPPort=new UAVObjectField<VCPPortUavEnum>("VCPPort", "", VCPPortElemNames, VCPPortEnumOptions, this);
			fields.Add(VCPPort);

			List<String> ComSpeedElemNames = new List<String>();
			ComSpeedElemNames.Add("0");
			List<String> ComSpeedEnumOptions = new List<String>();
			ComSpeedEnumOptions.Add("2400");
			ComSpeedEnumOptions.Add("4800");
			ComSpeedEnumOptions.Add("9600");
			ComSpeedEnumOptions.Add("19200");
			ComSpeedEnumOptions.Add("38400");
			ComSpeedEnumOptions.Add("57600");
			ComSpeedEnumOptions.Add("115200");
			ComSpeed=new UAVObjectField<ComSpeedUavEnum>("ComSpeed", "bps", ComSpeedElemNames, ComSpeedEnumOptions, this);
			fields.Add(ComSpeed);

			List<String> MaxRFPowerElemNames = new List<String>();
			MaxRFPowerElemNames.Add("0");
			List<String> MaxRFPowerEnumOptions = new List<String>();
			MaxRFPowerEnumOptions.Add("1.25");
			MaxRFPowerEnumOptions.Add("1.6");
			MaxRFPowerEnumOptions.Add("3.16");
			MaxRFPowerEnumOptions.Add("6.3");
			MaxRFPowerEnumOptions.Add("12.6");
			MaxRFPowerEnumOptions.Add("25");
			MaxRFPowerEnumOptions.Add("50");
			MaxRFPowerEnumOptions.Add("100");
			MaxRFPower=new UAVObjectField<MaxRFPowerUavEnum>("MaxRFPower", "mW", MaxRFPowerElemNames, MaxRFPowerEnumOptions, this);
			fields.Add(MaxRFPower);

			List<String> MinChannelElemNames = new List<String>();
			MinChannelElemNames.Add("0");
			MinChannel=new UAVObjectField<byte>("MinChannel", "", MinChannelElemNames, null, this);
			fields.Add(MinChannel);

			List<String> MaxChannelElemNames = new List<String>();
			MaxChannelElemNames.Add("0");
			MaxChannel=new UAVObjectField<byte>("MaxChannel", "", MaxChannelElemNames, null, this);
			fields.Add(MaxChannel);

			List<String> NumChannelsElemNames = new List<String>();
			NumChannelsElemNames.Add("0");
			NumChannels=new UAVObjectField<byte>("NumChannels", "", NumChannelsElemNames, null, this);
			fields.Add(NumChannels);

			List<String> ChannelSetElemNames = new List<String>();
			ChannelSetElemNames.Add("0");
			ChannelSet=new UAVObjectField<byte>("ChannelSet", "", ChannelSetElemNames, null, this);
			fields.Add(ChannelSet);

			List<String> PacketTimeElemNames = new List<String>();
			PacketTimeElemNames.Add("0");
			PacketTime=new UAVObjectField<byte>("PacketTime", "ms", PacketTimeElemNames, null, this);
			fields.Add(PacketTime);

	

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
			CoordID.setValue((UInt32)0);
			Coordinator.setValue(CoordinatorUavEnum.FALSE);
			OneWayLink.setValue(OneWayLinkUavEnum.FALSE);
			MainPort.setValue(MainPortUavEnum.Telemetry);
			FlexiPort.setValue(FlexiPortUavEnum.Disabled);
			VCPPort.setValue(VCPPortUavEnum.Disabled);
			ComSpeed.setValue(ComSpeedUavEnum.v38400);
			MaxRFPower.setValue(MaxRFPowerUavEnum.v125);
			MinChannel.setValue((byte)0);
			MaxChannel.setValue((byte)250);
			NumChannels.setValue((byte)10);
			ChannelSet.setValue((byte)39);
			PacketTime.setValue((byte)15);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				OPLinkSettings obj = new OPLinkSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public OPLinkSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (OPLinkSettings)(objMngr.getObject(OPLinkSettings.OBJID, instID));
		}
	}
}

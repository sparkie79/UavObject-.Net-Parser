// Object ID: 3508971052
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
		public const long OBJID = 3508971052;
		public int NUMBYTES { get; set; }
		protected const String NAME = "OPLinkSettings";
	    protected static String DESCRIPTION = @"OPLink configurations options.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<UInt32> PairID;
		public UAVObjectField<UInt32> Bindings;
		public UAVObjectField<UInt32> MinFrequency;
		public UAVObjectField<UInt32> MaxFrequency;
		public UAVObjectField<UInt32> InitFrequency;
		public UAVObjectField<UInt32> ChannelSpacing;
		public enum RemoteMainPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Serial")]
			Serial = 1, 
			[Description("PPM")]
			PPM = 2, 
		}
		public UAVObjectField<RemoteMainPortUavEnum> RemoteMainPort;
		public enum RemoteFlexiPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Serial")]
			Serial = 1, 
			[Description("PPM")]
			PPM = 2, 
		}
		public UAVObjectField<RemoteFlexiPortUavEnum> RemoteFlexiPort;
		public enum RemoteVCPPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Serial")]
			Serial = 1, 
		}
		public UAVObjectField<RemoteVCPPortUavEnum> RemoteVCPPort;
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

		public OPLinkSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> PairIDElemNames = new List<String>();
			PairIDElemNames.Add("0");
			PairID=new UAVObjectField<UInt32>("PairID", "", PairIDElemNames, null, this);
			fields.Add(PairID);

			List<String> BindingsElemNames = new List<String>();
			BindingsElemNames.Add("0");
			BindingsElemNames.Add("1");
			BindingsElemNames.Add("2");
			BindingsElemNames.Add("3");
			BindingsElemNames.Add("4");
			BindingsElemNames.Add("5");
			BindingsElemNames.Add("6");
			BindingsElemNames.Add("7");
			Bindings=new UAVObjectField<UInt32>("Bindings", "hex", BindingsElemNames, null, this);
			fields.Add(Bindings);

			List<String> MinFrequencyElemNames = new List<String>();
			MinFrequencyElemNames.Add("0");
			MinFrequency=new UAVObjectField<UInt32>("MinFrequency", "Hz", MinFrequencyElemNames, null, this);
			fields.Add(MinFrequency);

			List<String> MaxFrequencyElemNames = new List<String>();
			MaxFrequencyElemNames.Add("0");
			MaxFrequency=new UAVObjectField<UInt32>("MaxFrequency", "Hz", MaxFrequencyElemNames, null, this);
			fields.Add(MaxFrequency);

			List<String> InitFrequencyElemNames = new List<String>();
			InitFrequencyElemNames.Add("0");
			InitFrequency=new UAVObjectField<UInt32>("InitFrequency", "Hz", InitFrequencyElemNames, null, this);
			fields.Add(InitFrequency);

			List<String> ChannelSpacingElemNames = new List<String>();
			ChannelSpacingElemNames.Add("0");
			ChannelSpacing=new UAVObjectField<UInt32>("ChannelSpacing", "Hz", ChannelSpacingElemNames, null, this);
			fields.Add(ChannelSpacing);

			List<String> RemoteMainPortElemNames = new List<String>();
			RemoteMainPortElemNames.Add("0");
			RemoteMainPortElemNames.Add("1");
			RemoteMainPortElemNames.Add("2");
			RemoteMainPortElemNames.Add("3");
			RemoteMainPortElemNames.Add("4");
			RemoteMainPortElemNames.Add("5");
			RemoteMainPortElemNames.Add("6");
			RemoteMainPortElemNames.Add("7");
			List<String> RemoteMainPortEnumOptions = new List<String>();
			RemoteMainPortEnumOptions.Add("Disabled");
			RemoteMainPortEnumOptions.Add("Serial");
			RemoteMainPortEnumOptions.Add("PPM");
			RemoteMainPort=new UAVObjectField<RemoteMainPortUavEnum>("RemoteMainPort", "", RemoteMainPortElemNames, RemoteMainPortEnumOptions, this);
			fields.Add(RemoteMainPort);

			List<String> RemoteFlexiPortElemNames = new List<String>();
			RemoteFlexiPortElemNames.Add("0");
			RemoteFlexiPortElemNames.Add("1");
			RemoteFlexiPortElemNames.Add("2");
			RemoteFlexiPortElemNames.Add("3");
			RemoteFlexiPortElemNames.Add("4");
			RemoteFlexiPortElemNames.Add("5");
			RemoteFlexiPortElemNames.Add("6");
			RemoteFlexiPortElemNames.Add("7");
			List<String> RemoteFlexiPortEnumOptions = new List<String>();
			RemoteFlexiPortEnumOptions.Add("Disabled");
			RemoteFlexiPortEnumOptions.Add("Serial");
			RemoteFlexiPortEnumOptions.Add("PPM");
			RemoteFlexiPort=new UAVObjectField<RemoteFlexiPortUavEnum>("RemoteFlexiPort", "", RemoteFlexiPortElemNames, RemoteFlexiPortEnumOptions, this);
			fields.Add(RemoteFlexiPort);

			List<String> RemoteVCPPortElemNames = new List<String>();
			RemoteVCPPortElemNames.Add("0");
			RemoteVCPPortElemNames.Add("1");
			RemoteVCPPortElemNames.Add("2");
			RemoteVCPPortElemNames.Add("3");
			RemoteVCPPortElemNames.Add("4");
			RemoteVCPPortElemNames.Add("5");
			RemoteVCPPortElemNames.Add("6");
			RemoteVCPPortElemNames.Add("7");
			List<String> RemoteVCPPortEnumOptions = new List<String>();
			RemoteVCPPortEnumOptions.Add("Disabled");
			RemoteVCPPortEnumOptions.Add("Serial");
			RemoteVCPPort=new UAVObjectField<RemoteVCPPortUavEnum>("RemoteVCPPort", "", RemoteVCPPortElemNames, RemoteVCPPortEnumOptions, this);
			fields.Add(RemoteVCPPort);

			List<String> ComSpeedElemNames = new List<String>();
			ComSpeedElemNames.Add("0");
			ComSpeedElemNames.Add("1");
			ComSpeedElemNames.Add("2");
			ComSpeedElemNames.Add("3");
			ComSpeedElemNames.Add("4");
			ComSpeedElemNames.Add("5");
			ComSpeedElemNames.Add("6");
			ComSpeedElemNames.Add("7");
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
			PairID.setValue((UInt32)0);
			Bindings.setValue((UInt32)0,0);
			Bindings.setValue((UInt32)0,1);
			Bindings.setValue((UInt32)0,2);
			Bindings.setValue((UInt32)0,3);
			Bindings.setValue((UInt32)0,4);
			Bindings.setValue((UInt32)0,5);
			Bindings.setValue((UInt32)0,6);
			Bindings.setValue((UInt32)0,7);
			MinFrequency.setValue((UInt32)430000000);
			MaxFrequency.setValue((UInt32)440000000);
			InitFrequency.setValue((UInt32)433000000);
			ChannelSpacing.setValue((UInt32)75000);
			RemoteMainPort.setValue(RemoteMainPortUavEnum.Disabled,0);
			RemoteMainPort.setValue(RemoteMainPortUavEnum.Disabled,1);
			RemoteMainPort.setValue(RemoteMainPortUavEnum.Disabled,2);
			RemoteMainPort.setValue(RemoteMainPortUavEnum.Disabled,3);
			RemoteMainPort.setValue(RemoteMainPortUavEnum.Disabled,4);
			RemoteMainPort.setValue(RemoteMainPortUavEnum.Disabled,5);
			RemoteMainPort.setValue(RemoteMainPortUavEnum.Disabled,6);
			RemoteMainPort.setValue(RemoteMainPortUavEnum.Disabled,7);
			RemoteFlexiPort.setValue(RemoteFlexiPortUavEnum.Disabled,0);
			RemoteFlexiPort.setValue(RemoteFlexiPortUavEnum.Disabled,1);
			RemoteFlexiPort.setValue(RemoteFlexiPortUavEnum.Disabled,2);
			RemoteFlexiPort.setValue(RemoteFlexiPortUavEnum.Disabled,3);
			RemoteFlexiPort.setValue(RemoteFlexiPortUavEnum.Disabled,4);
			RemoteFlexiPort.setValue(RemoteFlexiPortUavEnum.Disabled,5);
			RemoteFlexiPort.setValue(RemoteFlexiPortUavEnum.Disabled,6);
			RemoteFlexiPort.setValue(RemoteFlexiPortUavEnum.Disabled,7);
			RemoteVCPPort.setValue(RemoteVCPPortUavEnum.Disabled,0);
			RemoteVCPPort.setValue(RemoteVCPPortUavEnum.Disabled,1);
			RemoteVCPPort.setValue(RemoteVCPPortUavEnum.Disabled,2);
			RemoteVCPPort.setValue(RemoteVCPPortUavEnum.Disabled,3);
			RemoteVCPPort.setValue(RemoteVCPPortUavEnum.Disabled,4);
			RemoteVCPPort.setValue(RemoteVCPPortUavEnum.Disabled,5);
			RemoteVCPPort.setValue(RemoteVCPPortUavEnum.Disabled,6);
			RemoteVCPPort.setValue(RemoteVCPPortUavEnum.Disabled,7);
			ComSpeed.setValue(ComSpeedUavEnum.v38400,0);
			ComSpeed.setValue(ComSpeedUavEnum.v38400,1);
			ComSpeed.setValue(ComSpeedUavEnum.v38400,2);
			ComSpeed.setValue(ComSpeedUavEnum.v38400,3);
			ComSpeed.setValue(ComSpeedUavEnum.v38400,4);
			ComSpeed.setValue(ComSpeedUavEnum.v38400,5);
			ComSpeed.setValue(ComSpeedUavEnum.v38400,6);
			ComSpeed.setValue(ComSpeedUavEnum.v38400,7);
			MainPort.setValue(MainPortUavEnum.Telemetry);
			FlexiPort.setValue(FlexiPortUavEnum.Disabled);
			VCPPort.setValue(VCPPortUavEnum.Disabled);
			MaxRFPower.setValue(MaxRFPowerUavEnum.v125);
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

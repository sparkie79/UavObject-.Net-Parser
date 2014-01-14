// Object ID: 50493318
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class HwSettings : UAVDataObject
	{
		public const long OBJID = 50493318;
		public int NUMBYTES { get; set; }
		protected const String NAME = "HwSettings";
	    protected static String DESCRIPTION = @"Selection of optional hardware configurations.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public enum CC_RcvrPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("PWM")]
			PWM = 1, 
			[Description("PPM")]
			PPM = 2, 
			[Description("PPM+PWM")]
			PPMPWM = 3, 
			[Description("PPM+Outputs")]
			PPMOutputs = 4, 
			[Description("Outputs")]
			Outputs = 5, 
		}
		public UAVObjectField<CC_RcvrPortUavEnum> CC_RcvrPort;
		public enum CC_MainPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Telemetry")]
			Telemetry = 1, 
			[Description("GPS")]
			GPS = 2, 
			[Description("S.Bus")]
			SBus = 3, 
			[Description("DSM2")]
			DSM2 = 4, 
			[Description("DSMX (10bit)")]
			DSMX10bit = 5, 
			[Description("DSMX (11bit)")]
			DSMX11bit = 6, 
			[Description("DebugConsole")]
			DebugConsole = 7, 
			[Description("ComBridge")]
			ComBridge = 8, 
			[Description("OsdHk")]
			OsdHk = 9, 
		}
		public UAVObjectField<CC_MainPortUavEnum> CC_MainPort;
		public enum CC_FlexiPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Telemetry")]
			Telemetry = 1, 
			[Description("GPS")]
			GPS = 2, 
			[Description("I2C")]
			I2C = 3, 
			[Description("PPM")]
			PPM = 4, 
			[Description("DSM2")]
			DSM2 = 5, 
			[Description("DSMX (10bit)")]
			DSMX10bit = 6, 
			[Description("DSMX (11bit)")]
			DSMX11bit = 7, 
			[Description("DebugConsole")]
			DebugConsole = 8, 
			[Description("ComBridge")]
			ComBridge = 9, 
			[Description("OsdHk")]
			OsdHk = 10, 
		}
		public UAVObjectField<CC_FlexiPortUavEnum> CC_FlexiPort;
		public enum RV_RcvrPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("PWM")]
			PWM = 1, 
			[Description("PPM")]
			PPM = 2, 
			[Description("PPM+Outputs")]
			PPMOutputs = 3, 
			[Description("Outputs")]
			Outputs = 4, 
		}
		public UAVObjectField<RV_RcvrPortUavEnum> RV_RcvrPort;
		public enum RV_AuxPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Telemetry")]
			Telemetry = 1, 
			[Description("DSM2")]
			DSM2 = 2, 
			[Description("DSMX (10bit)")]
			DSMX10bit = 3, 
			[Description("DSMX (11bit)")]
			DSMX11bit = 4, 
			[Description("ComAux")]
			ComAux = 5, 
			[Description("ComBridge")]
			ComBridge = 6, 
			[Description("OsdHk")]
			OsdHk = 7, 
		}
		public UAVObjectField<RV_AuxPortUavEnum> RV_AuxPort;
		public enum RV_AuxSBusPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("S.Bus")]
			SBus = 1, 
			[Description("DSM2")]
			DSM2 = 2, 
			[Description("DSMX (10bit)")]
			DSMX10bit = 3, 
			[Description("DSMX (11bit)")]
			DSMX11bit = 4, 
			[Description("ComAux")]
			ComAux = 5, 
			[Description("ComBridge")]
			ComBridge = 6, 
			[Description("OsdHk")]
			OsdHk = 7, 
		}
		public UAVObjectField<RV_AuxSBusPortUavEnum> RV_AuxSBusPort;
		public enum RV_FlexiPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("I2C")]
			I2C = 1, 
			[Description("DSM2")]
			DSM2 = 2, 
			[Description("DSMX (10bit)")]
			DSMX10bit = 3, 
			[Description("DSMX (11bit)")]
			DSMX11bit = 4, 
			[Description("ComAux")]
			ComAux = 5, 
			[Description("ComBridge")]
			ComBridge = 6, 
		}
		public UAVObjectField<RV_FlexiPortUavEnum> RV_FlexiPort;
		public enum RV_TelemetryPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Telemetry")]
			Telemetry = 1, 
			[Description("ComAux")]
			ComAux = 2, 
			[Description("ComBridge")]
			ComBridge = 3, 
		}
		public UAVObjectField<RV_TelemetryPortUavEnum> RV_TelemetryPort;
		public enum RV_GPSPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Telemetry")]
			Telemetry = 1, 
			[Description("GPS")]
			GPS = 2, 
			[Description("ComAux")]
			ComAux = 3, 
			[Description("ComBridge")]
			ComBridge = 4, 
		}
		public UAVObjectField<RV_GPSPortUavEnum> RV_GPSPort;
		public enum RM_RcvrPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("PWM")]
			PWM = 1, 
			[Description("PPM")]
			PPM = 2, 
			[Description("PPM+PWM")]
			PPMPWM = 3, 
			[Description("PPM+Outputs")]
			PPMOutputs = 4, 
			[Description("Outputs")]
			Outputs = 5, 
		}
		public UAVObjectField<RM_RcvrPortUavEnum> RM_RcvrPort;
		public enum RM_MainPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Telemetry")]
			Telemetry = 1, 
			[Description("GPS")]
			GPS = 2, 
			[Description("S.Bus")]
			SBus = 3, 
			[Description("DSM2")]
			DSM2 = 4, 
			[Description("DSMX (10bit)")]
			DSMX10bit = 5, 
			[Description("DSMX (11bit)")]
			DSMX11bit = 6, 
			[Description("DebugConsole")]
			DebugConsole = 7, 
			[Description("ComBridge")]
			ComBridge = 8, 
			[Description("OsdHk")]
			OsdHk = 9, 
		}
		public UAVObjectField<RM_MainPortUavEnum> RM_MainPort;
		public enum RM_FlexiPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Telemetry")]
			Telemetry = 1, 
			[Description("GPS")]
			GPS = 2, 
			[Description("I2C")]
			I2C = 3, 
			[Description("DSM2")]
			DSM2 = 4, 
			[Description("DSMX (10bit)")]
			DSMX10bit = 5, 
			[Description("DSMX (11bit)")]
			DSMX11bit = 6, 
			[Description("DebugConsole")]
			DebugConsole = 7, 
			[Description("ComBridge")]
			ComBridge = 8, 
			[Description("OsdHk")]
			OsdHk = 9, 
		}
		public UAVObjectField<RM_FlexiPortUavEnum> RM_FlexiPort;
		public enum TelemetrySpeedUavEnum
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
		public UAVObjectField<TelemetrySpeedUavEnum> TelemetrySpeed;
		public enum GPSSpeedUavEnum
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
		public UAVObjectField<GPSSpeedUavEnum> GPSSpeed;
		public enum ComUsbBridgeSpeedUavEnum
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
		public UAVObjectField<ComUsbBridgeSpeedUavEnum> ComUsbBridgeSpeed;
		public enum USB_HIDPortUavEnum
		{
			[Description("USBTelemetry")]
			USBTelemetry = 0, 
			[Description("RCTransmitter")]
			RCTransmitter = 1, 
			[Description("Disabled")]
			Disabled = 2, 
		}
		public UAVObjectField<USB_HIDPortUavEnum> USB_HIDPort;
		public enum USB_VCPPortUavEnum
		{
			[Description("USBTelemetry")]
			USBTelemetry = 0, 
			[Description("ComBridge")]
			ComBridge = 1, 
			[Description("DebugConsole")]
			DebugConsole = 2, 
			[Description("Disabled")]
			Disabled = 3, 
		}
		public UAVObjectField<USB_VCPPortUavEnum> USB_VCPPort;
		public enum OptionalModulesUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Enabled")]
			Enabled = 1, 
		}
		public UAVObjectField<OptionalModulesUavEnum> OptionalModules;
		public enum ADCRoutingUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("BatteryVoltage")]
			BatteryVoltage = 1, 
			[Description("BatteryCurrent")]
			BatteryCurrent = 2, 
			[Description("AnalogAirspeed")]
			AnalogAirspeed = 3, 
			[Description("Generic")]
			Generic = 4, 
		}
		public UAVObjectField<ADCRoutingUavEnum> ADCRouting;
		public UAVObjectField<byte> DSMxBind;

		public HwSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> CC_RcvrPortElemNames = new List<String>();
			CC_RcvrPortElemNames.Add("0");
			List<String> CC_RcvrPortEnumOptions = new List<String>();
			CC_RcvrPortEnumOptions.Add("Disabled");
			CC_RcvrPortEnumOptions.Add("PWM");
			CC_RcvrPortEnumOptions.Add("PPM");
			CC_RcvrPortEnumOptions.Add("PPM+PWM");
			CC_RcvrPortEnumOptions.Add("PPM+Outputs");
			CC_RcvrPortEnumOptions.Add("Outputs");
			CC_RcvrPort=new UAVObjectField<CC_RcvrPortUavEnum>("CC_RcvrPort", "function", CC_RcvrPortElemNames, CC_RcvrPortEnumOptions, this);
			fields.Add(CC_RcvrPort);

			List<String> CC_MainPortElemNames = new List<String>();
			CC_MainPortElemNames.Add("0");
			List<String> CC_MainPortEnumOptions = new List<String>();
			CC_MainPortEnumOptions.Add("Disabled");
			CC_MainPortEnumOptions.Add("Telemetry");
			CC_MainPortEnumOptions.Add("GPS");
			CC_MainPortEnumOptions.Add("S.Bus");
			CC_MainPortEnumOptions.Add("DSM2");
			CC_MainPortEnumOptions.Add("DSMX (10bit)");
			CC_MainPortEnumOptions.Add("DSMX (11bit)");
			CC_MainPortEnumOptions.Add("DebugConsole");
			CC_MainPortEnumOptions.Add("ComBridge");
			CC_MainPortEnumOptions.Add("OsdHk");
			CC_MainPort=new UAVObjectField<CC_MainPortUavEnum>("CC_MainPort", "function", CC_MainPortElemNames, CC_MainPortEnumOptions, this);
			fields.Add(CC_MainPort);

			List<String> CC_FlexiPortElemNames = new List<String>();
			CC_FlexiPortElemNames.Add("0");
			List<String> CC_FlexiPortEnumOptions = new List<String>();
			CC_FlexiPortEnumOptions.Add("Disabled");
			CC_FlexiPortEnumOptions.Add("Telemetry");
			CC_FlexiPortEnumOptions.Add("GPS");
			CC_FlexiPortEnumOptions.Add("I2C");
			CC_FlexiPortEnumOptions.Add("PPM");
			CC_FlexiPortEnumOptions.Add("DSM2");
			CC_FlexiPortEnumOptions.Add("DSMX (10bit)");
			CC_FlexiPortEnumOptions.Add("DSMX (11bit)");
			CC_FlexiPortEnumOptions.Add("DebugConsole");
			CC_FlexiPortEnumOptions.Add("ComBridge");
			CC_FlexiPortEnumOptions.Add("OsdHk");
			CC_FlexiPort=new UAVObjectField<CC_FlexiPortUavEnum>("CC_FlexiPort", "function", CC_FlexiPortElemNames, CC_FlexiPortEnumOptions, this);
			fields.Add(CC_FlexiPort);

			List<String> RV_RcvrPortElemNames = new List<String>();
			RV_RcvrPortElemNames.Add("0");
			List<String> RV_RcvrPortEnumOptions = new List<String>();
			RV_RcvrPortEnumOptions.Add("Disabled");
			RV_RcvrPortEnumOptions.Add("PWM");
			RV_RcvrPortEnumOptions.Add("PPM");
			RV_RcvrPortEnumOptions.Add("PPM+Outputs");
			RV_RcvrPortEnumOptions.Add("Outputs");
			RV_RcvrPort=new UAVObjectField<RV_RcvrPortUavEnum>("RV_RcvrPort", "function", RV_RcvrPortElemNames, RV_RcvrPortEnumOptions, this);
			fields.Add(RV_RcvrPort);

			List<String> RV_AuxPortElemNames = new List<String>();
			RV_AuxPortElemNames.Add("0");
			List<String> RV_AuxPortEnumOptions = new List<String>();
			RV_AuxPortEnumOptions.Add("Disabled");
			RV_AuxPortEnumOptions.Add("Telemetry");
			RV_AuxPortEnumOptions.Add("DSM2");
			RV_AuxPortEnumOptions.Add("DSMX (10bit)");
			RV_AuxPortEnumOptions.Add("DSMX (11bit)");
			RV_AuxPortEnumOptions.Add("ComAux");
			RV_AuxPortEnumOptions.Add("ComBridge");
			RV_AuxPortEnumOptions.Add("OsdHk");
			RV_AuxPort=new UAVObjectField<RV_AuxPortUavEnum>("RV_AuxPort", "function", RV_AuxPortElemNames, RV_AuxPortEnumOptions, this);
			fields.Add(RV_AuxPort);

			List<String> RV_AuxSBusPortElemNames = new List<String>();
			RV_AuxSBusPortElemNames.Add("0");
			List<String> RV_AuxSBusPortEnumOptions = new List<String>();
			RV_AuxSBusPortEnumOptions.Add("Disabled");
			RV_AuxSBusPortEnumOptions.Add("S.Bus");
			RV_AuxSBusPortEnumOptions.Add("DSM2");
			RV_AuxSBusPortEnumOptions.Add("DSMX (10bit)");
			RV_AuxSBusPortEnumOptions.Add("DSMX (11bit)");
			RV_AuxSBusPortEnumOptions.Add("ComAux");
			RV_AuxSBusPortEnumOptions.Add("ComBridge");
			RV_AuxSBusPortEnumOptions.Add("OsdHk");
			RV_AuxSBusPort=new UAVObjectField<RV_AuxSBusPortUavEnum>("RV_AuxSBusPort", "function", RV_AuxSBusPortElemNames, RV_AuxSBusPortEnumOptions, this);
			fields.Add(RV_AuxSBusPort);

			List<String> RV_FlexiPortElemNames = new List<String>();
			RV_FlexiPortElemNames.Add("0");
			List<String> RV_FlexiPortEnumOptions = new List<String>();
			RV_FlexiPortEnumOptions.Add("Disabled");
			RV_FlexiPortEnumOptions.Add("I2C");
			RV_FlexiPortEnumOptions.Add("DSM2");
			RV_FlexiPortEnumOptions.Add("DSMX (10bit)");
			RV_FlexiPortEnumOptions.Add("DSMX (11bit)");
			RV_FlexiPortEnumOptions.Add("ComAux");
			RV_FlexiPortEnumOptions.Add("ComBridge");
			RV_FlexiPort=new UAVObjectField<RV_FlexiPortUavEnum>("RV_FlexiPort", "function", RV_FlexiPortElemNames, RV_FlexiPortEnumOptions, this);
			fields.Add(RV_FlexiPort);

			List<String> RV_TelemetryPortElemNames = new List<String>();
			RV_TelemetryPortElemNames.Add("0");
			List<String> RV_TelemetryPortEnumOptions = new List<String>();
			RV_TelemetryPortEnumOptions.Add("Disabled");
			RV_TelemetryPortEnumOptions.Add("Telemetry");
			RV_TelemetryPortEnumOptions.Add("ComAux");
			RV_TelemetryPortEnumOptions.Add("ComBridge");
			RV_TelemetryPort=new UAVObjectField<RV_TelemetryPortUavEnum>("RV_TelemetryPort", "function", RV_TelemetryPortElemNames, RV_TelemetryPortEnumOptions, this);
			fields.Add(RV_TelemetryPort);

			List<String> RV_GPSPortElemNames = new List<String>();
			RV_GPSPortElemNames.Add("0");
			List<String> RV_GPSPortEnumOptions = new List<String>();
			RV_GPSPortEnumOptions.Add("Disabled");
			RV_GPSPortEnumOptions.Add("Telemetry");
			RV_GPSPortEnumOptions.Add("GPS");
			RV_GPSPortEnumOptions.Add("ComAux");
			RV_GPSPortEnumOptions.Add("ComBridge");
			RV_GPSPort=new UAVObjectField<RV_GPSPortUavEnum>("RV_GPSPort", "function", RV_GPSPortElemNames, RV_GPSPortEnumOptions, this);
			fields.Add(RV_GPSPort);

			List<String> RM_RcvrPortElemNames = new List<String>();
			RM_RcvrPortElemNames.Add("0");
			List<String> RM_RcvrPortEnumOptions = new List<String>();
			RM_RcvrPortEnumOptions.Add("Disabled");
			RM_RcvrPortEnumOptions.Add("PWM");
			RM_RcvrPortEnumOptions.Add("PPM");
			RM_RcvrPortEnumOptions.Add("PPM+PWM");
			RM_RcvrPortEnumOptions.Add("PPM+Outputs");
			RM_RcvrPortEnumOptions.Add("Outputs");
			RM_RcvrPort=new UAVObjectField<RM_RcvrPortUavEnum>("RM_RcvrPort", "function", RM_RcvrPortElemNames, RM_RcvrPortEnumOptions, this);
			fields.Add(RM_RcvrPort);

			List<String> RM_MainPortElemNames = new List<String>();
			RM_MainPortElemNames.Add("0");
			List<String> RM_MainPortEnumOptions = new List<String>();
			RM_MainPortEnumOptions.Add("Disabled");
			RM_MainPortEnumOptions.Add("Telemetry");
			RM_MainPortEnumOptions.Add("GPS");
			RM_MainPortEnumOptions.Add("S.Bus");
			RM_MainPortEnumOptions.Add("DSM2");
			RM_MainPortEnumOptions.Add("DSMX (10bit)");
			RM_MainPortEnumOptions.Add("DSMX (11bit)");
			RM_MainPortEnumOptions.Add("DebugConsole");
			RM_MainPortEnumOptions.Add("ComBridge");
			RM_MainPortEnumOptions.Add("OsdHk");
			RM_MainPort=new UAVObjectField<RM_MainPortUavEnum>("RM_MainPort", "function", RM_MainPortElemNames, RM_MainPortEnumOptions, this);
			fields.Add(RM_MainPort);

			List<String> RM_FlexiPortElemNames = new List<String>();
			RM_FlexiPortElemNames.Add("0");
			List<String> RM_FlexiPortEnumOptions = new List<String>();
			RM_FlexiPortEnumOptions.Add("Disabled");
			RM_FlexiPortEnumOptions.Add("Telemetry");
			RM_FlexiPortEnumOptions.Add("GPS");
			RM_FlexiPortEnumOptions.Add("I2C");
			RM_FlexiPortEnumOptions.Add("DSM2");
			RM_FlexiPortEnumOptions.Add("DSMX (10bit)");
			RM_FlexiPortEnumOptions.Add("DSMX (11bit)");
			RM_FlexiPortEnumOptions.Add("DebugConsole");
			RM_FlexiPortEnumOptions.Add("ComBridge");
			RM_FlexiPortEnumOptions.Add("OsdHk");
			RM_FlexiPort=new UAVObjectField<RM_FlexiPortUavEnum>("RM_FlexiPort", "function", RM_FlexiPortElemNames, RM_FlexiPortEnumOptions, this);
			fields.Add(RM_FlexiPort);

			List<String> TelemetrySpeedElemNames = new List<String>();
			TelemetrySpeedElemNames.Add("0");
			List<String> TelemetrySpeedEnumOptions = new List<String>();
			TelemetrySpeedEnumOptions.Add("2400");
			TelemetrySpeedEnumOptions.Add("4800");
			TelemetrySpeedEnumOptions.Add("9600");
			TelemetrySpeedEnumOptions.Add("19200");
			TelemetrySpeedEnumOptions.Add("38400");
			TelemetrySpeedEnumOptions.Add("57600");
			TelemetrySpeedEnumOptions.Add("115200");
			TelemetrySpeed=new UAVObjectField<TelemetrySpeedUavEnum>("TelemetrySpeed", "bps", TelemetrySpeedElemNames, TelemetrySpeedEnumOptions, this);
			fields.Add(TelemetrySpeed);

			List<String> GPSSpeedElemNames = new List<String>();
			GPSSpeedElemNames.Add("0");
			List<String> GPSSpeedEnumOptions = new List<String>();
			GPSSpeedEnumOptions.Add("2400");
			GPSSpeedEnumOptions.Add("4800");
			GPSSpeedEnumOptions.Add("9600");
			GPSSpeedEnumOptions.Add("19200");
			GPSSpeedEnumOptions.Add("38400");
			GPSSpeedEnumOptions.Add("57600");
			GPSSpeedEnumOptions.Add("115200");
			GPSSpeed=new UAVObjectField<GPSSpeedUavEnum>("GPSSpeed", "bps", GPSSpeedElemNames, GPSSpeedEnumOptions, this);
			fields.Add(GPSSpeed);

			List<String> ComUsbBridgeSpeedElemNames = new List<String>();
			ComUsbBridgeSpeedElemNames.Add("0");
			List<String> ComUsbBridgeSpeedEnumOptions = new List<String>();
			ComUsbBridgeSpeedEnumOptions.Add("2400");
			ComUsbBridgeSpeedEnumOptions.Add("4800");
			ComUsbBridgeSpeedEnumOptions.Add("9600");
			ComUsbBridgeSpeedEnumOptions.Add("19200");
			ComUsbBridgeSpeedEnumOptions.Add("38400");
			ComUsbBridgeSpeedEnumOptions.Add("57600");
			ComUsbBridgeSpeedEnumOptions.Add("115200");
			ComUsbBridgeSpeed=new UAVObjectField<ComUsbBridgeSpeedUavEnum>("ComUsbBridgeSpeed", "bps", ComUsbBridgeSpeedElemNames, ComUsbBridgeSpeedEnumOptions, this);
			fields.Add(ComUsbBridgeSpeed);

			List<String> USB_HIDPortElemNames = new List<String>();
			USB_HIDPortElemNames.Add("0");
			List<String> USB_HIDPortEnumOptions = new List<String>();
			USB_HIDPortEnumOptions.Add("USBTelemetry");
			USB_HIDPortEnumOptions.Add("RCTransmitter");
			USB_HIDPortEnumOptions.Add("Disabled");
			USB_HIDPort=new UAVObjectField<USB_HIDPortUavEnum>("USB_HIDPort", "function", USB_HIDPortElemNames, USB_HIDPortEnumOptions, this);
			fields.Add(USB_HIDPort);

			List<String> USB_VCPPortElemNames = new List<String>();
			USB_VCPPortElemNames.Add("0");
			List<String> USB_VCPPortEnumOptions = new List<String>();
			USB_VCPPortEnumOptions.Add("USBTelemetry");
			USB_VCPPortEnumOptions.Add("ComBridge");
			USB_VCPPortEnumOptions.Add("DebugConsole");
			USB_VCPPortEnumOptions.Add("Disabled");
			USB_VCPPort=new UAVObjectField<USB_VCPPortUavEnum>("USB_VCPPort", "function", USB_VCPPortElemNames, USB_VCPPortEnumOptions, this);
			fields.Add(USB_VCPPort);

			List<String> OptionalModulesElemNames = new List<String>();
			OptionalModulesElemNames.Add("CameraStab");
			OptionalModulesElemNames.Add("GPS");
			OptionalModulesElemNames.Add("ComUsbBridge");
			OptionalModulesElemNames.Add("Fault");
			OptionalModulesElemNames.Add("Altitude");
			OptionalModulesElemNames.Add("Airspeed");
			OptionalModulesElemNames.Add("TxPID");
			OptionalModulesElemNames.Add("Autotune");
			OptionalModulesElemNames.Add("VtolPathFollower");
			OptionalModulesElemNames.Add("FixedWingPathFollower");
			OptionalModulesElemNames.Add("Battery");
			OptionalModulesElemNames.Add("Overo");
			OptionalModulesElemNames.Add("MagBaro");
			OptionalModulesElemNames.Add("OsdHk");
			List<String> OptionalModulesEnumOptions = new List<String>();
			OptionalModulesEnumOptions.Add("Disabled");
			OptionalModulesEnumOptions.Add("Enabled");
			OptionalModules=new UAVObjectField<OptionalModulesUavEnum>("OptionalModules", "", OptionalModulesElemNames, OptionalModulesEnumOptions, this);
			fields.Add(OptionalModules);

			List<String> ADCRoutingElemNames = new List<String>();
			ADCRoutingElemNames.Add("adc0");
			ADCRoutingElemNames.Add("adc1");
			ADCRoutingElemNames.Add("adc2");
			ADCRoutingElemNames.Add("adc3");
			List<String> ADCRoutingEnumOptions = new List<String>();
			ADCRoutingEnumOptions.Add("Disabled");
			ADCRoutingEnumOptions.Add("BatteryVoltage");
			ADCRoutingEnumOptions.Add("BatteryCurrent");
			ADCRoutingEnumOptions.Add("AnalogAirspeed");
			ADCRoutingEnumOptions.Add("Generic");
			ADCRouting=new UAVObjectField<ADCRoutingUavEnum>("ADCRouting", "", ADCRoutingElemNames, ADCRoutingEnumOptions, this);
			fields.Add(ADCRouting);

			List<String> DSMxBindElemNames = new List<String>();
			DSMxBindElemNames.Add("0");
			DSMxBind=new UAVObjectField<byte>("DSMxBind", "", DSMxBindElemNames, null, this);
			fields.Add(DSMxBind);

	

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
			CC_RcvrPort.setValue(CC_RcvrPortUavEnum.PWM);
			CC_MainPort.setValue(CC_MainPortUavEnum.Telemetry);
			CC_FlexiPort.setValue(CC_FlexiPortUavEnum.Disabled);
			RV_RcvrPort.setValue(RV_RcvrPortUavEnum.PWM);
			RV_AuxPort.setValue(RV_AuxPortUavEnum.Disabled);
			RV_AuxSBusPort.setValue(RV_AuxSBusPortUavEnum.Disabled);
			RV_FlexiPort.setValue(RV_FlexiPortUavEnum.Disabled);
			RV_TelemetryPort.setValue(RV_TelemetryPortUavEnum.Telemetry);
			RV_GPSPort.setValue(RV_GPSPortUavEnum.GPS);
			RM_RcvrPort.setValue(RM_RcvrPortUavEnum.PWM);
			RM_MainPort.setValue(RM_MainPortUavEnum.Telemetry);
			RM_FlexiPort.setValue(RM_FlexiPortUavEnum.Disabled);
			TelemetrySpeed.setValue(TelemetrySpeedUavEnum.v57600);
			GPSSpeed.setValue(GPSSpeedUavEnum.v57600);
			ComUsbBridgeSpeed.setValue(ComUsbBridgeSpeedUavEnum.v57600);
			USB_HIDPort.setValue(USB_HIDPortUavEnum.USBTelemetry);
			USB_VCPPort.setValue(USB_VCPPortUavEnum.Disabled);
			OptionalModules.setValue(OptionalModulesUavEnum.Disabled,0);
			OptionalModules.setValue(OptionalModulesUavEnum.Disabled,1);
			OptionalModules.setValue(OptionalModulesUavEnum.Disabled,2);
			OptionalModules.setValue(OptionalModulesUavEnum.Disabled,3);
			OptionalModules.setValue(OptionalModulesUavEnum.Disabled,4);
			OptionalModules.setValue(OptionalModulesUavEnum.Disabled,5);
			OptionalModules.setValue(OptionalModulesUavEnum.Disabled,6);
			OptionalModules.setValue(OptionalModulesUavEnum.Disabled,7);
			OptionalModules.setValue(OptionalModulesUavEnum.Disabled,8);
			OptionalModules.setValue(OptionalModulesUavEnum.Disabled,9);
			OptionalModules.setValue(OptionalModulesUavEnum.Disabled,10);
			OptionalModules.setValue(OptionalModulesUavEnum.Disabled,11);
			OptionalModules.setValue(OptionalModulesUavEnum.Disabled,12);
			OptionalModules.setValue(OptionalModulesUavEnum.Disabled,13);
			ADCRouting.setValue(ADCRoutingUavEnum.Disabled,0);
			ADCRouting.setValue(ADCRoutingUavEnum.Disabled,1);
			ADCRouting.setValue(ADCRoutingUavEnum.Disabled,2);
			ADCRouting.setValue(ADCRoutingUavEnum.Disabled,3);
			DSMxBind.setValue((byte)0);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				HwSettings obj = new HwSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public HwSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (HwSettings)(objMngr.getObject(HwSettings.OBJID, instID));
		}
	}
}

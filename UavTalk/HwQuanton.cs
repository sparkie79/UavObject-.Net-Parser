// Object ID: 3446240770
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class HwQuanton : UAVDataObject
	{
		public const long OBJID = 3446240770;
		public int NUMBYTES { get; set; }
		protected const String NAME = "HwQuanton";
	    protected static String DESCRIPTION = @"Selection of optional hardware configurations.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public enum RcvrPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("PWM")]
			PWM = 1, 
			[Description("PWM+ADC")]
			PWMADC = 2, 
			[Description("PPM")]
			PPM = 3, 
			[Description("PPM+ADC")]
			PPMADC = 4, 
			[Description("PPM+PWM")]
			PPMPWM = 5, 
			[Description("PPM+PWM+ADC")]
			PPMPWMADC = 6, 
			[Description("PPM+Outputs")]
			PPMOutputs = 7, 
			[Description("PPM+Outputs+ADC")]
			PPMOutputsADC = 8, 
			[Description("Outputs")]
			Outputs = 9, 
			[Description("Outputs+ADC")]
			OutputsADC = 10, 
		}
		public UAVObjectField<RcvrPortUavEnum> RcvrPort;
		public enum Uart1UavEnum
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
			[Description("MavLinkTX")]
			MavLinkTX = 9, 
			[Description("MavLinkTX_GPS_RX")]
			MavLinkTXGPSRX = 10, 
		}
		public UAVObjectField<Uart1UavEnum> Uart1;
		public enum Uart2UavEnum
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
			[Description("MavLinkTX")]
			MavLinkTX = 9, 
			[Description("MavLinkTX_GPS_RX")]
			MavLinkTXGPSRX = 10, 
		}
		public UAVObjectField<Uart2UavEnum> Uart2;
		public enum Uart3UavEnum
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
			[Description("MavLinkTX")]
			MavLinkTX = 9, 
			[Description("MavLinkTX_GPS_RX")]
			MavLinkTXGPSRX = 10, 
		}
		public UAVObjectField<Uart3UavEnum> Uart3;
		public enum Uart4UavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Telemetry")]
			Telemetry = 1, 
			[Description("GPS")]
			GPS = 2, 
			[Description("DSM2")]
			DSM2 = 3, 
			[Description("DSMX (10bit)")]
			DSMX10bit = 4, 
			[Description("DSMX (11bit)")]
			DSMX11bit = 5, 
			[Description("DebugConsole")]
			DebugConsole = 6, 
			[Description("ComBridge")]
			ComBridge = 7, 
			[Description("MavLinkTX")]
			MavLinkTX = 8, 
			[Description("MavLinkTX_GPS_RX")]
			MavLinkTXGPSRX = 9, 
		}
		public UAVObjectField<Uart4UavEnum> Uart4;
		public enum Uart5UavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Telemetry")]
			Telemetry = 1, 
			[Description("GPS")]
			GPS = 2, 
			[Description("DSM2")]
			DSM2 = 3, 
			[Description("DSMX (10bit)")]
			DSMX10bit = 4, 
			[Description("DSMX (11bit)")]
			DSMX11bit = 5, 
			[Description("DebugConsole")]
			DebugConsole = 6, 
			[Description("ComBridge")]
			ComBridge = 7, 
			[Description("MavLinkTX")]
			MavLinkTX = 8, 
			[Description("MavLinkTX_GPS_RX")]
			MavLinkTXGPSRX = 9, 
		}
		public UAVObjectField<Uart5UavEnum> Uart5;
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
		public UAVObjectField<byte> DSMxBind;
		public enum GyroRangeUavEnum
		{
			[Description("250")]
			v250 = 0, 
			[Description("500")]
			v500 = 1, 
			[Description("1000")]
			v1000 = 2, 
			[Description("2000")]
			v2000 = 3, 
		}
		public UAVObjectField<GyroRangeUavEnum> GyroRange;
		public enum AccelRangeUavEnum
		{
			[Description("2G")]
			v2G = 0, 
			[Description("4G")]
			v4G = 1, 
			[Description("8G")]
			v8G = 2, 
			[Description("16G")]
			v16G = 3, 
		}
		public UAVObjectField<AccelRangeUavEnum> AccelRange;
		public enum MPU6000RateUavEnum
		{
			[Description("200")]
			v200 = 0, 
			[Description("333")]
			v333 = 1, 
			[Description("500")]
			v500 = 2, 
			[Description("666")]
			v666 = 3, 
			[Description("1000")]
			v1000 = 4, 
			[Description("2000")]
			v2000 = 5, 
			[Description("4000")]
			v4000 = 6, 
			[Description("8000")]
			v8000 = 7, 
		}
		public UAVObjectField<MPU6000RateUavEnum> MPU6000Rate;
		public enum MPU6000DLPFUavEnum
		{
			[Description("256")]
			v256 = 0, 
			[Description("188")]
			v188 = 1, 
			[Description("98")]
			v98 = 2, 
			[Description("42")]
			v42 = 3, 
			[Description("20")]
			v20 = 4, 
			[Description("10")]
			v10 = 5, 
			[Description("5")]
			v5 = 6, 
		}
		public UAVObjectField<MPU6000DLPFUavEnum> MPU6000DLPF;

		public HwQuanton() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> RcvrPortElemNames = new List<String>();
			RcvrPortElemNames.Add("0");
			List<String> RcvrPortEnumOptions = new List<String>();
			RcvrPortEnumOptions.Add("Disabled");
			RcvrPortEnumOptions.Add("PWM");
			RcvrPortEnumOptions.Add("PWM+ADC");
			RcvrPortEnumOptions.Add("PPM");
			RcvrPortEnumOptions.Add("PPM+ADC");
			RcvrPortEnumOptions.Add("PPM+PWM");
			RcvrPortEnumOptions.Add("PPM+PWM+ADC");
			RcvrPortEnumOptions.Add("PPM+Outputs");
			RcvrPortEnumOptions.Add("PPM+Outputs+ADC");
			RcvrPortEnumOptions.Add("Outputs");
			RcvrPortEnumOptions.Add("Outputs+ADC");
			RcvrPort=new UAVObjectField<RcvrPortUavEnum>("RcvrPort", "function", RcvrPortElemNames, RcvrPortEnumOptions, this);
			fields.Add(RcvrPort);

			List<String> Uart1ElemNames = new List<String>();
			Uart1ElemNames.Add("0");
			List<String> Uart1EnumOptions = new List<String>();
			Uart1EnumOptions.Add("Disabled");
			Uart1EnumOptions.Add("Telemetry");
			Uart1EnumOptions.Add("GPS");
			Uart1EnumOptions.Add("I2C");
			Uart1EnumOptions.Add("DSM2");
			Uart1EnumOptions.Add("DSMX (10bit)");
			Uart1EnumOptions.Add("DSMX (11bit)");
			Uart1EnumOptions.Add("DebugConsole");
			Uart1EnumOptions.Add("ComBridge");
			Uart1EnumOptions.Add("MavLinkTX");
			Uart1EnumOptions.Add("MavLinkTX_GPS_RX");
			Uart1=new UAVObjectField<Uart1UavEnum>("Uart1", "function", Uart1ElemNames, Uart1EnumOptions, this);
			fields.Add(Uart1);

			List<String> Uart2ElemNames = new List<String>();
			Uart2ElemNames.Add("0");
			List<String> Uart2EnumOptions = new List<String>();
			Uart2EnumOptions.Add("Disabled");
			Uart2EnumOptions.Add("Telemetry");
			Uart2EnumOptions.Add("GPS");
			Uart2EnumOptions.Add("S.Bus");
			Uart2EnumOptions.Add("DSM2");
			Uart2EnumOptions.Add("DSMX (10bit)");
			Uart2EnumOptions.Add("DSMX (11bit)");
			Uart2EnumOptions.Add("DebugConsole");
			Uart2EnumOptions.Add("ComBridge");
			Uart2EnumOptions.Add("MavLinkTX");
			Uart2EnumOptions.Add("MavLinkTX_GPS_RX");
			Uart2=new UAVObjectField<Uart2UavEnum>("Uart2", "function", Uart2ElemNames, Uart2EnumOptions, this);
			fields.Add(Uart2);

			List<String> Uart3ElemNames = new List<String>();
			Uart3ElemNames.Add("0");
			List<String> Uart3EnumOptions = new List<String>();
			Uart3EnumOptions.Add("Disabled");
			Uart3EnumOptions.Add("Telemetry");
			Uart3EnumOptions.Add("GPS");
			Uart3EnumOptions.Add("I2C");
			Uart3EnumOptions.Add("DSM2");
			Uart3EnumOptions.Add("DSMX (10bit)");
			Uart3EnumOptions.Add("DSMX (11bit)");
			Uart3EnumOptions.Add("DebugConsole");
			Uart3EnumOptions.Add("ComBridge");
			Uart3EnumOptions.Add("MavLinkTX");
			Uart3EnumOptions.Add("MavLinkTX_GPS_RX");
			Uart3=new UAVObjectField<Uart3UavEnum>("Uart3", "function", Uart3ElemNames, Uart3EnumOptions, this);
			fields.Add(Uart3);

			List<String> Uart4ElemNames = new List<String>();
			Uart4ElemNames.Add("0");
			List<String> Uart4EnumOptions = new List<String>();
			Uart4EnumOptions.Add("Disabled");
			Uart4EnumOptions.Add("Telemetry");
			Uart4EnumOptions.Add("GPS");
			Uart4EnumOptions.Add("DSM2");
			Uart4EnumOptions.Add("DSMX (10bit)");
			Uart4EnumOptions.Add("DSMX (11bit)");
			Uart4EnumOptions.Add("DebugConsole");
			Uart4EnumOptions.Add("ComBridge");
			Uart4EnumOptions.Add("MavLinkTX");
			Uart4EnumOptions.Add("MavLinkTX_GPS_RX");
			Uart4=new UAVObjectField<Uart4UavEnum>("Uart4", "function", Uart4ElemNames, Uart4EnumOptions, this);
			fields.Add(Uart4);

			List<String> Uart5ElemNames = new List<String>();
			Uart5ElemNames.Add("0");
			List<String> Uart5EnumOptions = new List<String>();
			Uart5EnumOptions.Add("Disabled");
			Uart5EnumOptions.Add("Telemetry");
			Uart5EnumOptions.Add("GPS");
			Uart5EnumOptions.Add("DSM2");
			Uart5EnumOptions.Add("DSMX (10bit)");
			Uart5EnumOptions.Add("DSMX (11bit)");
			Uart5EnumOptions.Add("DebugConsole");
			Uart5EnumOptions.Add("ComBridge");
			Uart5EnumOptions.Add("MavLinkTX");
			Uart5EnumOptions.Add("MavLinkTX_GPS_RX");
			Uart5=new UAVObjectField<Uart5UavEnum>("Uart5", "function", Uart5ElemNames, Uart5EnumOptions, this);
			fields.Add(Uart5);

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

			List<String> DSMxBindElemNames = new List<String>();
			DSMxBindElemNames.Add("0");
			DSMxBind=new UAVObjectField<byte>("DSMxBind", "", DSMxBindElemNames, null, this);
			fields.Add(DSMxBind);

			List<String> GyroRangeElemNames = new List<String>();
			GyroRangeElemNames.Add("0");
			List<String> GyroRangeEnumOptions = new List<String>();
			GyroRangeEnumOptions.Add("250");
			GyroRangeEnumOptions.Add("500");
			GyroRangeEnumOptions.Add("1000");
			GyroRangeEnumOptions.Add("2000");
			GyroRange=new UAVObjectField<GyroRangeUavEnum>("GyroRange", "deg/s", GyroRangeElemNames, GyroRangeEnumOptions, this);
			fields.Add(GyroRange);

			List<String> AccelRangeElemNames = new List<String>();
			AccelRangeElemNames.Add("0");
			List<String> AccelRangeEnumOptions = new List<String>();
			AccelRangeEnumOptions.Add("2G");
			AccelRangeEnumOptions.Add("4G");
			AccelRangeEnumOptions.Add("8G");
			AccelRangeEnumOptions.Add("16G");
			AccelRange=new UAVObjectField<AccelRangeUavEnum>("AccelRange", "*gravity m/s^2", AccelRangeElemNames, AccelRangeEnumOptions, this);
			fields.Add(AccelRange);

			List<String> MPU6000RateElemNames = new List<String>();
			MPU6000RateElemNames.Add("0");
			List<String> MPU6000RateEnumOptions = new List<String>();
			MPU6000RateEnumOptions.Add("200");
			MPU6000RateEnumOptions.Add("333");
			MPU6000RateEnumOptions.Add("500");
			MPU6000RateEnumOptions.Add("666");
			MPU6000RateEnumOptions.Add("1000");
			MPU6000RateEnumOptions.Add("2000");
			MPU6000RateEnumOptions.Add("4000");
			MPU6000RateEnumOptions.Add("8000");
			MPU6000Rate=new UAVObjectField<MPU6000RateUavEnum>("MPU6000Rate", "", MPU6000RateElemNames, MPU6000RateEnumOptions, this);
			fields.Add(MPU6000Rate);

			List<String> MPU6000DLPFElemNames = new List<String>();
			MPU6000DLPFElemNames.Add("0");
			List<String> MPU6000DLPFEnumOptions = new List<String>();
			MPU6000DLPFEnumOptions.Add("256");
			MPU6000DLPFEnumOptions.Add("188");
			MPU6000DLPFEnumOptions.Add("98");
			MPU6000DLPFEnumOptions.Add("42");
			MPU6000DLPFEnumOptions.Add("20");
			MPU6000DLPFEnumOptions.Add("10");
			MPU6000DLPFEnumOptions.Add("5");
			MPU6000DLPF=new UAVObjectField<MPU6000DLPFUavEnum>("MPU6000DLPF", "", MPU6000DLPFElemNames, MPU6000DLPFEnumOptions, this);
			fields.Add(MPU6000DLPF);

	

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
			RcvrPort.setValue(RcvrPortUavEnum.PWM);
			Uart1.setValue(Uart1UavEnum.Disabled);
			Uart2.setValue(Uart2UavEnum.Disabled);
			Uart3.setValue(Uart3UavEnum.Disabled);
			Uart4.setValue(Uart4UavEnum.Telemetry);
			Uart5.setValue(Uart5UavEnum.GPS);
			USB_HIDPort.setValue(USB_HIDPortUavEnum.USBTelemetry);
			USB_VCPPort.setValue(USB_VCPPortUavEnum.Disabled);
			DSMxBind.setValue((byte)0);
			GyroRange.setValue(GyroRangeUavEnum.v500);
			AccelRange.setValue(AccelRangeUavEnum.v8G);
			MPU6000Rate.setValue(MPU6000RateUavEnum.v666);
			MPU6000DLPF.setValue(MPU6000DLPFUavEnum.v256);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				HwQuanton obj = new HwQuanton();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public HwQuanton GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (HwQuanton)(objMngr.getObject(HwQuanton.OBJID, instID));
		}
	}
}

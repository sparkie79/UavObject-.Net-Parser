﻿// Object ID: 467116534
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class HwRevolution : UAVDataObject
	{
		public const long OBJID = 467116534;
		public int NUMBYTES { get; set; }
		protected const String NAME = "HwRevolution";
	    protected static String DESCRIPTION = @"Selection of optional hardware configurations.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public enum RcvrPortUavEnum
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
		public UAVObjectField<RcvrPortUavEnum> RcvrPort;
		public enum AuxPortUavEnum
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
			[Description("DebugConsole")]
			DebugConsole = 5, 
			[Description("ComBridge")]
			ComBridge = 6, 
		}
		public UAVObjectField<AuxPortUavEnum> AuxPort;
		public enum AuxSBusPortUavEnum
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
			[Description("DebugConsole")]
			DebugConsole = 5, 
			[Description("ComBridge")]
			ComBridge = 6, 
		}
		public UAVObjectField<AuxSBusPortUavEnum> AuxSBusPort;
		public enum FlexiPortUavEnum
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
			[Description("DebugConsole")]
			DebugConsole = 5, 
			[Description("ComBridge")]
			ComBridge = 6, 
		}
		public UAVObjectField<FlexiPortUavEnum> FlexiPort;
		public enum TelemetryPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Telemetry")]
			Telemetry = 1, 
			[Description("DebugConsole")]
			DebugConsole = 2, 
			[Description("ComBridge")]
			ComBridge = 3, 
		}
		public UAVObjectField<TelemetryPortUavEnum> TelemetryPort;
		public enum GPSPortUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Telemetry")]
			Telemetry = 1, 
			[Description("GPS")]
			GPS = 2, 
			[Description("DebugConsole")]
			DebugConsole = 3, 
			[Description("ComBridge")]
			ComBridge = 4, 
		}
		public UAVObjectField<GPSPortUavEnum> GPSPort;
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

		public HwRevolution() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> RcvrPortElemNames = new List<String>();
			RcvrPortElemNames.Add("0");
			List<String> RcvrPortEnumOptions = new List<String>();
			RcvrPortEnumOptions.Add("Disabled");
			RcvrPortEnumOptions.Add("PWM");
			RcvrPortEnumOptions.Add("PPM");
			RcvrPortEnumOptions.Add("PPM+Outputs");
			RcvrPortEnumOptions.Add("Outputs");
			RcvrPort=new UAVObjectField<RcvrPortUavEnum>("RcvrPort", "function", RcvrPortElemNames, RcvrPortEnumOptions, this);
			fields.Add(RcvrPort);

			List<String> AuxPortElemNames = new List<String>();
			AuxPortElemNames.Add("0");
			List<String> AuxPortEnumOptions = new List<String>();
			AuxPortEnumOptions.Add("Disabled");
			AuxPortEnumOptions.Add("Telemetry");
			AuxPortEnumOptions.Add("DSM2");
			AuxPortEnumOptions.Add("DSMX (10bit)");
			AuxPortEnumOptions.Add("DSMX (11bit)");
			AuxPortEnumOptions.Add("DebugConsole");
			AuxPortEnumOptions.Add("ComBridge");
			AuxPort=new UAVObjectField<AuxPortUavEnum>("AuxPort", "function", AuxPortElemNames, AuxPortEnumOptions, this);
			fields.Add(AuxPort);

			List<String> AuxSBusPortElemNames = new List<String>();
			AuxSBusPortElemNames.Add("0");
			List<String> AuxSBusPortEnumOptions = new List<String>();
			AuxSBusPortEnumOptions.Add("Disabled");
			AuxSBusPortEnumOptions.Add("S.Bus");
			AuxSBusPortEnumOptions.Add("DSM2");
			AuxSBusPortEnumOptions.Add("DSMX (10bit)");
			AuxSBusPortEnumOptions.Add("DSMX (11bit)");
			AuxSBusPortEnumOptions.Add("DebugConsole");
			AuxSBusPortEnumOptions.Add("ComBridge");
			AuxSBusPort=new UAVObjectField<AuxSBusPortUavEnum>("AuxSBusPort", "function", AuxSBusPortElemNames, AuxSBusPortEnumOptions, this);
			fields.Add(AuxSBusPort);

			List<String> FlexiPortElemNames = new List<String>();
			FlexiPortElemNames.Add("0");
			List<String> FlexiPortEnumOptions = new List<String>();
			FlexiPortEnumOptions.Add("Disabled");
			FlexiPortEnumOptions.Add("I2C");
			FlexiPortEnumOptions.Add("DSM2");
			FlexiPortEnumOptions.Add("DSMX (10bit)");
			FlexiPortEnumOptions.Add("DSMX (11bit)");
			FlexiPortEnumOptions.Add("DebugConsole");
			FlexiPortEnumOptions.Add("ComBridge");
			FlexiPort=new UAVObjectField<FlexiPortUavEnum>("FlexiPort", "function", FlexiPortElemNames, FlexiPortEnumOptions, this);
			fields.Add(FlexiPort);

			List<String> TelemetryPortElemNames = new List<String>();
			TelemetryPortElemNames.Add("0");
			List<String> TelemetryPortEnumOptions = new List<String>();
			TelemetryPortEnumOptions.Add("Disabled");
			TelemetryPortEnumOptions.Add("Telemetry");
			TelemetryPortEnumOptions.Add("DebugConsole");
			TelemetryPortEnumOptions.Add("ComBridge");
			TelemetryPort=new UAVObjectField<TelemetryPortUavEnum>("TelemetryPort", "function", TelemetryPortElemNames, TelemetryPortEnumOptions, this);
			fields.Add(TelemetryPort);

			List<String> GPSPortElemNames = new List<String>();
			GPSPortElemNames.Add("0");
			List<String> GPSPortEnumOptions = new List<String>();
			GPSPortEnumOptions.Add("Disabled");
			GPSPortEnumOptions.Add("Telemetry");
			GPSPortEnumOptions.Add("GPS");
			GPSPortEnumOptions.Add("DebugConsole");
			GPSPortEnumOptions.Add("ComBridge");
			GPSPort=new UAVObjectField<GPSPortUavEnum>("GPSPort", "function", GPSPortElemNames, GPSPortEnumOptions, this);
			fields.Add(GPSPort);

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
			AuxPort.setValue(AuxPortUavEnum.Disabled);
			AuxSBusPort.setValue(AuxSBusPortUavEnum.Disabled);
			FlexiPort.setValue(FlexiPortUavEnum.Disabled);
			TelemetryPort.setValue(TelemetryPortUavEnum.Telemetry);
			GPSPort.setValue(GPSPortUavEnum.GPS);
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
				HwRevolution obj = new HwRevolution();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public HwRevolution GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (HwRevolution)(objMngr.getObject(HwRevolution.OBJID, instID));
		}
	}
}

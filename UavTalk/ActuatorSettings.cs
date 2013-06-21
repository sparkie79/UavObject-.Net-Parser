// Object ID: 2747679346
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class ActuatorSettings : UAVDataObject
	{
		public const long OBJID = 2747679346;
		public int NUMBYTES { get; set; }
		protected const String NAME = "ActuatorSettings";
	    protected static String DESCRIPTION = @"Settings for the @ref ActuatorModule that controls the channel assignments for the mixer based on AircraftType";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<UInt16> ChannelUpdateFreq;
		public UAVObjectField<Int16> ChannelMax;
		public UAVObjectField<Int16> ChannelNeutral;
		public UAVObjectField<Int16> ChannelMin;
		public enum ChannelTypeUavEnum
		{
			[Description("PWM")]
			PWM = 0, 
			[Description("MK")]
			MK = 1, 
			[Description("ASTEC4")]
			ASTEC4 = 2, 
			[Description("PWM Alarm Buzzer")]
			PWMAlarmBuzzer = 3, 
			[Description("Arming led")]
			Armingled = 4, 
			[Description("Info led")]
			Infoled = 5, 
		}
		public UAVObjectField<ChannelTypeUavEnum> ChannelType;
		public UAVObjectField<byte> ChannelAddr;
		public enum MotorsSpinWhileArmedUavEnum
		{
			[Description("FALSE")]
			FALSE = 0, 
			[Description("TRUE")]
			TRUE = 1, 
		}
		public UAVObjectField<MotorsSpinWhileArmedUavEnum> MotorsSpinWhileArmed;

		public ActuatorSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ChannelUpdateFreqElemNames = new List<String>();
			ChannelUpdateFreqElemNames.Add("0");
			ChannelUpdateFreqElemNames.Add("1");
			ChannelUpdateFreqElemNames.Add("2");
			ChannelUpdateFreqElemNames.Add("3");
			ChannelUpdateFreqElemNames.Add("4");
			ChannelUpdateFreqElemNames.Add("5");
			ChannelUpdateFreq=new UAVObjectField<UInt16>("ChannelUpdateFreq", "Hz", ChannelUpdateFreqElemNames, null, this);
			fields.Add(ChannelUpdateFreq);

			List<String> ChannelMaxElemNames = new List<String>();
			ChannelMaxElemNames.Add("0");
			ChannelMaxElemNames.Add("1");
			ChannelMaxElemNames.Add("2");
			ChannelMaxElemNames.Add("3");
			ChannelMaxElemNames.Add("4");
			ChannelMaxElemNames.Add("5");
			ChannelMaxElemNames.Add("6");
			ChannelMaxElemNames.Add("7");
			ChannelMaxElemNames.Add("8");
			ChannelMaxElemNames.Add("9");
			ChannelMax=new UAVObjectField<Int16>("ChannelMax", "us", ChannelMaxElemNames, null, this);
			fields.Add(ChannelMax);

			List<String> ChannelNeutralElemNames = new List<String>();
			ChannelNeutralElemNames.Add("0");
			ChannelNeutralElemNames.Add("1");
			ChannelNeutralElemNames.Add("2");
			ChannelNeutralElemNames.Add("3");
			ChannelNeutralElemNames.Add("4");
			ChannelNeutralElemNames.Add("5");
			ChannelNeutralElemNames.Add("6");
			ChannelNeutralElemNames.Add("7");
			ChannelNeutralElemNames.Add("8");
			ChannelNeutralElemNames.Add("9");
			ChannelNeutral=new UAVObjectField<Int16>("ChannelNeutral", "us", ChannelNeutralElemNames, null, this);
			fields.Add(ChannelNeutral);

			List<String> ChannelMinElemNames = new List<String>();
			ChannelMinElemNames.Add("0");
			ChannelMinElemNames.Add("1");
			ChannelMinElemNames.Add("2");
			ChannelMinElemNames.Add("3");
			ChannelMinElemNames.Add("4");
			ChannelMinElemNames.Add("5");
			ChannelMinElemNames.Add("6");
			ChannelMinElemNames.Add("7");
			ChannelMinElemNames.Add("8");
			ChannelMinElemNames.Add("9");
			ChannelMin=new UAVObjectField<Int16>("ChannelMin", "us", ChannelMinElemNames, null, this);
			fields.Add(ChannelMin);

			List<String> ChannelTypeElemNames = new List<String>();
			ChannelTypeElemNames.Add("0");
			ChannelTypeElemNames.Add("1");
			ChannelTypeElemNames.Add("2");
			ChannelTypeElemNames.Add("3");
			ChannelTypeElemNames.Add("4");
			ChannelTypeElemNames.Add("5");
			ChannelTypeElemNames.Add("6");
			ChannelTypeElemNames.Add("7");
			ChannelTypeElemNames.Add("8");
			ChannelTypeElemNames.Add("9");
			List<String> ChannelTypeEnumOptions = new List<String>();
			ChannelTypeEnumOptions.Add("PWM");
			ChannelTypeEnumOptions.Add("MK");
			ChannelTypeEnumOptions.Add("ASTEC4");
			ChannelTypeEnumOptions.Add("PWM Alarm Buzzer");
			ChannelTypeEnumOptions.Add("Arming led");
			ChannelTypeEnumOptions.Add("Info led");
			ChannelType=new UAVObjectField<ChannelTypeUavEnum>("ChannelType", "", ChannelTypeElemNames, ChannelTypeEnumOptions, this);
			fields.Add(ChannelType);

			List<String> ChannelAddrElemNames = new List<String>();
			ChannelAddrElemNames.Add("0");
			ChannelAddrElemNames.Add("1");
			ChannelAddrElemNames.Add("2");
			ChannelAddrElemNames.Add("3");
			ChannelAddrElemNames.Add("4");
			ChannelAddrElemNames.Add("5");
			ChannelAddrElemNames.Add("6");
			ChannelAddrElemNames.Add("7");
			ChannelAddrElemNames.Add("8");
			ChannelAddrElemNames.Add("9");
			ChannelAddr=new UAVObjectField<byte>("ChannelAddr", "", ChannelAddrElemNames, null, this);
			fields.Add(ChannelAddr);

			List<String> MotorsSpinWhileArmedElemNames = new List<String>();
			MotorsSpinWhileArmedElemNames.Add("0");
			List<String> MotorsSpinWhileArmedEnumOptions = new List<String>();
			MotorsSpinWhileArmedEnumOptions.Add("FALSE");
			MotorsSpinWhileArmedEnumOptions.Add("TRUE");
			MotorsSpinWhileArmed=new UAVObjectField<MotorsSpinWhileArmedUavEnum>("MotorsSpinWhileArmed", "", MotorsSpinWhileArmedElemNames, MotorsSpinWhileArmedEnumOptions, this);
			fields.Add(MotorsSpinWhileArmed);

	

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
			ChannelUpdateFreq.setValue((UInt16)50,0);
			ChannelUpdateFreq.setValue((UInt16)50,1);
			ChannelUpdateFreq.setValue((UInt16)50,2);
			ChannelUpdateFreq.setValue((UInt16)50,3);
			ChannelUpdateFreq.setValue((UInt16)50,4);
			ChannelUpdateFreq.setValue((UInt16)50,5);
			ChannelMax.setValue((Int16)1000,0);
			ChannelMax.setValue((Int16)1000,1);
			ChannelMax.setValue((Int16)1000,2);
			ChannelMax.setValue((Int16)1000,3);
			ChannelMax.setValue((Int16)1000,4);
			ChannelMax.setValue((Int16)1000,5);
			ChannelMax.setValue((Int16)1000,6);
			ChannelMax.setValue((Int16)1000,7);
			ChannelMax.setValue((Int16)1000,8);
			ChannelMax.setValue((Int16)1000,9);
			ChannelNeutral.setValue((Int16)1000,0);
			ChannelNeutral.setValue((Int16)1000,1);
			ChannelNeutral.setValue((Int16)1000,2);
			ChannelNeutral.setValue((Int16)1000,3);
			ChannelNeutral.setValue((Int16)1000,4);
			ChannelNeutral.setValue((Int16)1000,5);
			ChannelNeutral.setValue((Int16)1000,6);
			ChannelNeutral.setValue((Int16)1000,7);
			ChannelNeutral.setValue((Int16)1000,8);
			ChannelNeutral.setValue((Int16)1000,9);
			ChannelMin.setValue((Int16)1000,0);
			ChannelMin.setValue((Int16)1000,1);
			ChannelMin.setValue((Int16)1000,2);
			ChannelMin.setValue((Int16)1000,3);
			ChannelMin.setValue((Int16)1000,4);
			ChannelMin.setValue((Int16)1000,5);
			ChannelMin.setValue((Int16)1000,6);
			ChannelMin.setValue((Int16)1000,7);
			ChannelMin.setValue((Int16)1000,8);
			ChannelMin.setValue((Int16)1000,9);
			ChannelType.setValue(ChannelTypeUavEnum.PWM,0);
			ChannelType.setValue(ChannelTypeUavEnum.PWM,1);
			ChannelType.setValue(ChannelTypeUavEnum.PWM,2);
			ChannelType.setValue(ChannelTypeUavEnum.PWM,3);
			ChannelType.setValue(ChannelTypeUavEnum.PWM,4);
			ChannelType.setValue(ChannelTypeUavEnum.PWM,5);
			ChannelType.setValue(ChannelTypeUavEnum.PWM,6);
			ChannelType.setValue(ChannelTypeUavEnum.PWM,7);
			ChannelType.setValue(ChannelTypeUavEnum.PWM,8);
			ChannelType.setValue(ChannelTypeUavEnum.PWM,9);
			ChannelAddr.setValue((byte)0,0);
			ChannelAddr.setValue((byte)1,1);
			ChannelAddr.setValue((byte)2,2);
			ChannelAddr.setValue((byte)3,3);
			ChannelAddr.setValue((byte)4,4);
			ChannelAddr.setValue((byte)5,5);
			ChannelAddr.setValue((byte)6,6);
			ChannelAddr.setValue((byte)7,7);
			ChannelAddr.setValue((byte)8,8);
			ChannelAddr.setValue((byte)9,9);
			MotorsSpinWhileArmed.setValue(MotorsSpinWhileArmedUavEnum.FALSE);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				ActuatorSettings obj = new ActuatorSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public ActuatorSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (ActuatorSettings)(objMngr.getObject(ActuatorSettings.OBJID, instID));
		}
	}
}

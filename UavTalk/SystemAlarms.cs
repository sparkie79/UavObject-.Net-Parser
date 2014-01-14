// Object ID: 493935428
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class SystemAlarms : UAVDataObject
	{
		public const long OBJID = 493935428;
		public int NUMBYTES { get; set; }
		protected const String NAME = "SystemAlarms";
	    protected static String DESCRIPTION = @"Alarms from OpenPilot to indicate failure conditions or warnings.  Set by various modules.  Some modules may have a module defined Status and Substatus fields that details its condition.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public enum AlarmUavEnum
		{
			[Description("Uninitialised")]
			Uninitialised = 0, 
			[Description("OK")]
			OK = 1, 
			[Description("Warning")]
			Warning = 2, 
			[Description("Error")]
			Error = 3, 
			[Description("Critical")]
			Critical = 4, 
		}
		public UAVObjectField<AlarmUavEnum> Alarm;
		public enum ExtendedAlarmStatusUavEnum
		{
			[Description("None")]
			None = 0, 
			[Description("RebootRequired")]
			RebootRequired = 1, 
			[Description("FlightMode")]
			FlightMode = 2, 
		}
		public UAVObjectField<ExtendedAlarmStatusUavEnum> ExtendedAlarmStatus;
		public UAVObjectField<byte> ExtendedAlarmSubStatus;

		public SystemAlarms() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> AlarmElemNames = new List<String>();
			AlarmElemNames.Add("SystemConfiguration");
			AlarmElemNames.Add("BootFault");
			AlarmElemNames.Add("OutOfMemory");
			AlarmElemNames.Add("StackOverflow");
			AlarmElemNames.Add("CPUOverload");
			AlarmElemNames.Add("EventSystem");
			AlarmElemNames.Add("Telemetry");
			AlarmElemNames.Add("ManualControl");
			AlarmElemNames.Add("Actuator");
			AlarmElemNames.Add("Attitude");
			AlarmElemNames.Add("Sensors");
			AlarmElemNames.Add("Stabilization");
			AlarmElemNames.Add("Guidance");
			AlarmElemNames.Add("Battery");
			AlarmElemNames.Add("FlightTime");
			AlarmElemNames.Add("I2C");
			AlarmElemNames.Add("GPS");
			AlarmElemNames.Add("Power");
			List<String> AlarmEnumOptions = new List<String>();
			AlarmEnumOptions.Add("Uninitialised");
			AlarmEnumOptions.Add("OK");
			AlarmEnumOptions.Add("Warning");
			AlarmEnumOptions.Add("Error");
			AlarmEnumOptions.Add("Critical");
			Alarm=new UAVObjectField<AlarmUavEnum>("Alarm", "", AlarmElemNames, AlarmEnumOptions, this);
			fields.Add(Alarm);

			List<String> ExtendedAlarmStatusElemNames = new List<String>();
			ExtendedAlarmStatusElemNames.Add("SystemConfiguration");
			ExtendedAlarmStatusElemNames.Add("BootFault");
			List<String> ExtendedAlarmStatusEnumOptions = new List<String>();
			ExtendedAlarmStatusEnumOptions.Add("None");
			ExtendedAlarmStatusEnumOptions.Add("RebootRequired");
			ExtendedAlarmStatusEnumOptions.Add("FlightMode");
			ExtendedAlarmStatus=new UAVObjectField<ExtendedAlarmStatusUavEnum>("ExtendedAlarmStatus", "", ExtendedAlarmStatusElemNames, ExtendedAlarmStatusEnumOptions, this);
			fields.Add(ExtendedAlarmStatus);

			List<String> ExtendedAlarmSubStatusElemNames = new List<String>();
			ExtendedAlarmSubStatusElemNames.Add("SystemConfiguration");
			ExtendedAlarmSubStatusElemNames.Add("BootFault");
			ExtendedAlarmSubStatus=new UAVObjectField<byte>("ExtendedAlarmSubStatus", "", ExtendedAlarmSubStatusElemNames, null, this);
			fields.Add(ExtendedAlarmSubStatus);

	

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
    		metadata.loggingUpdatePeriod = 1000;
 
			return metadata;
		}

		/**
		 * Initialize object fields with the default values.
		 * If a default value is not specified the object fields
		 * will be initialized to zero.
		 */
		public void setDefaultFieldValues()
		{
			Alarm.setValue(AlarmUavEnum.Uninitialised,0);
			Alarm.setValue(AlarmUavEnum.Uninitialised,1);
			Alarm.setValue(AlarmUavEnum.Uninitialised,2);
			Alarm.setValue(AlarmUavEnum.Uninitialised,3);
			Alarm.setValue(AlarmUavEnum.Uninitialised,4);
			Alarm.setValue(AlarmUavEnum.Uninitialised,5);
			Alarm.setValue(AlarmUavEnum.Uninitialised,6);
			Alarm.setValue(AlarmUavEnum.Uninitialised,7);
			Alarm.setValue(AlarmUavEnum.Uninitialised,8);
			Alarm.setValue(AlarmUavEnum.Uninitialised,9);
			Alarm.setValue(AlarmUavEnum.Uninitialised,10);
			Alarm.setValue(AlarmUavEnum.Uninitialised,11);
			Alarm.setValue(AlarmUavEnum.Uninitialised,12);
			Alarm.setValue(AlarmUavEnum.Uninitialised,13);
			Alarm.setValue(AlarmUavEnum.Uninitialised,14);
			Alarm.setValue(AlarmUavEnum.Uninitialised,15);
			Alarm.setValue(AlarmUavEnum.Uninitialised,16);
			Alarm.setValue(AlarmUavEnum.Uninitialised,17);
			ExtendedAlarmStatus.setValue(ExtendedAlarmStatusUavEnum.None,0);
			ExtendedAlarmStatus.setValue(ExtendedAlarmStatusUavEnum.None,1);
			ExtendedAlarmSubStatus.setValue((byte)0,0);
			ExtendedAlarmSubStatus.setValue((byte)0,1);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				SystemAlarms obj = new SystemAlarms();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public SystemAlarms GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (SystemAlarms)(objMngr.getObject(SystemAlarms.OBJID, instID));
		}
	}
}

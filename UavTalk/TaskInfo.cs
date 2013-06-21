// Object ID: 2716312384
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class TaskInfo : UAVDataObject
	{
		public const long OBJID = 2716312384;
		public int NUMBYTES { get; set; }
		protected const String NAME = "TaskInfo";
	    protected static String DESCRIPTION = @"Task information";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<UInt16> StackRemaining;
		public enum RunningUavEnum
		{
			[Description("False")]
			False = 0, 
			[Description("True")]
			True = 1, 
		}
		public UAVObjectField<RunningUavEnum> Running;
		public UAVObjectField<byte> RunningTime;

		public TaskInfo() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> StackRemainingElemNames = new List<String>();
			StackRemainingElemNames.Add("System");
			StackRemainingElemNames.Add("Actuator");
			StackRemainingElemNames.Add("Attitude");
			StackRemainingElemNames.Add("Sensors");
			StackRemainingElemNames.Add("TelemetryTx");
			StackRemainingElemNames.Add("TelemetryTxPri");
			StackRemainingElemNames.Add("TelemetryRx");
			StackRemainingElemNames.Add("GPS");
			StackRemainingElemNames.Add("ManualControl");
			StackRemainingElemNames.Add("Altitude");
			StackRemainingElemNames.Add("Airspeed");
			StackRemainingElemNames.Add("Stabilization");
			StackRemainingElemNames.Add("AltitudeHold");
			StackRemainingElemNames.Add("PathPlanner");
			StackRemainingElemNames.Add("PathFollower");
			StackRemainingElemNames.Add("FlightPlan");
			StackRemainingElemNames.Add("Com2UsbBridge");
			StackRemainingElemNames.Add("Usb2ComBridge");
			StackRemainingElemNames.Add("OveroSync");
			StackRemainingElemNames.Add("ModemRx");
			StackRemainingElemNames.Add("ModemTx");
			StackRemainingElemNames.Add("ModemStat");
			StackRemainingElemNames.Add("Autotune");
			StackRemainingElemNames.Add("EventDispatcher");
			StackRemainingElemNames.Add("GenericI2CSensor");
			StackRemainingElemNames.Add("UAVOMavlinkBridge");
			StackRemainingElemNames.Add("VibrationAnalysis");
			StackRemainingElemNames.Add("Battery");
			StackRemaining=new UAVObjectField<UInt16>("StackRemaining", "bytes", StackRemainingElemNames, null, this);
			fields.Add(StackRemaining);

			List<String> RunningElemNames = new List<String>();
			RunningElemNames.Add("System");
			RunningElemNames.Add("Actuator");
			RunningElemNames.Add("Attitude");
			RunningElemNames.Add("Sensors");
			RunningElemNames.Add("TelemetryTx");
			RunningElemNames.Add("TelemetryTxPri");
			RunningElemNames.Add("TelemetryRx");
			RunningElemNames.Add("GPS");
			RunningElemNames.Add("ManualControl");
			RunningElemNames.Add("Altitude");
			RunningElemNames.Add("Airspeed");
			RunningElemNames.Add("Stabilization");
			RunningElemNames.Add("AltitudeHold");
			RunningElemNames.Add("PathPlanner");
			RunningElemNames.Add("PathFollower");
			RunningElemNames.Add("FlightPlan");
			RunningElemNames.Add("Com2UsbBridge");
			RunningElemNames.Add("Usb2ComBridge");
			RunningElemNames.Add("OveroSync");
			RunningElemNames.Add("ModemRx");
			RunningElemNames.Add("ModemTx");
			RunningElemNames.Add("ModemStat");
			RunningElemNames.Add("Autotune");
			RunningElemNames.Add("EventDispatcher");
			RunningElemNames.Add("GenericI2CSensor");
			RunningElemNames.Add("UAVOMavlinkBridge");
			RunningElemNames.Add("VibrationAnalysis");
			RunningElemNames.Add("Battery");
			List<String> RunningEnumOptions = new List<String>();
			RunningEnumOptions.Add("False");
			RunningEnumOptions.Add("True");
			Running=new UAVObjectField<RunningUavEnum>("Running", "bool", RunningElemNames, RunningEnumOptions, this);
			fields.Add(Running);

			List<String> RunningTimeElemNames = new List<String>();
			RunningTimeElemNames.Add("System");
			RunningTimeElemNames.Add("Actuator");
			RunningTimeElemNames.Add("Attitude");
			RunningTimeElemNames.Add("Sensors");
			RunningTimeElemNames.Add("TelemetryTx");
			RunningTimeElemNames.Add("TelemetryTxPri");
			RunningTimeElemNames.Add("TelemetryRx");
			RunningTimeElemNames.Add("GPS");
			RunningTimeElemNames.Add("ManualControl");
			RunningTimeElemNames.Add("Altitude");
			RunningTimeElemNames.Add("Airspeed");
			RunningTimeElemNames.Add("Stabilization");
			RunningTimeElemNames.Add("AltitudeHold");
			RunningTimeElemNames.Add("PathPlanner");
			RunningTimeElemNames.Add("PathFollower");
			RunningTimeElemNames.Add("FlightPlan");
			RunningTimeElemNames.Add("Com2UsbBridge");
			RunningTimeElemNames.Add("Usb2ComBridge");
			RunningTimeElemNames.Add("OveroSync");
			RunningTimeElemNames.Add("ModemRx");
			RunningTimeElemNames.Add("ModemTx");
			RunningTimeElemNames.Add("ModemStat");
			RunningTimeElemNames.Add("Autotune");
			RunningTimeElemNames.Add("EventDispatcher");
			RunningTimeElemNames.Add("GenericI2CSensor");
			RunningTimeElemNames.Add("UAVOMavlinkBridge");
			RunningTimeElemNames.Add("VibrationAnalysis");
			RunningTimeElemNames.Add("Battery");
			RunningTime=new UAVObjectField<byte>("RunningTime", "%", RunningTimeElemNames, null, this);
			fields.Add(RunningTime);

	

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
				(int)UPDATEMODE.UPDATEMODE_PERIODIC << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_ONCHANGE << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
    		metadata.flightTelemetryUpdatePeriod = 10000;
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
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				TaskInfo obj = new TaskInfo();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public TaskInfo GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (TaskInfo)(objMngr.getObject(TaskInfo.OBJID, instID));
		}
	}
}

// Object ID: 1732092470
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class SystemStats : UAVDataObject
	{
		public const long OBJID = 1732092470;
		public int NUMBYTES { get; set; }
		protected const String NAME = "SystemStats";
	    protected static String DESCRIPTION = @"CPU and memory usage from OpenPilot computer. ";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<UInt32> FlightTime;
		public UAVObjectField<UInt32> EventSystemWarningID;
		public UAVObjectField<UInt32> ObjectManagerCallbackID;
		public UAVObjectField<UInt32> ObjectManagerQueueID;
		public UAVObjectField<UInt16> HeapRemaining;
		public UAVObjectField<UInt16> IRQStackRemaining;
		public UAVObjectField<UInt16> SysSlotsFree;
		public UAVObjectField<UInt16> SysSlotsActive;
		public UAVObjectField<UInt16> UsrSlotsFree;
		public UAVObjectField<UInt16> UsrSlotsActive;
		public UAVObjectField<byte> CPULoad;
		public UAVObjectField<sbyte> CPUTemp;

		public SystemStats() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> FlightTimeElemNames = new List<String>();
			FlightTimeElemNames.Add("0");
			FlightTime=new UAVObjectField<UInt32>("FlightTime", "ms", FlightTimeElemNames, null, this);
			fields.Add(FlightTime);

			List<String> EventSystemWarningIDElemNames = new List<String>();
			EventSystemWarningIDElemNames.Add("0");
			EventSystemWarningID=new UAVObjectField<UInt32>("EventSystemWarningID", "uavoid", EventSystemWarningIDElemNames, null, this);
			fields.Add(EventSystemWarningID);

			List<String> ObjectManagerCallbackIDElemNames = new List<String>();
			ObjectManagerCallbackIDElemNames.Add("0");
			ObjectManagerCallbackID=new UAVObjectField<UInt32>("ObjectManagerCallbackID", "uavoid", ObjectManagerCallbackIDElemNames, null, this);
			fields.Add(ObjectManagerCallbackID);

			List<String> ObjectManagerQueueIDElemNames = new List<String>();
			ObjectManagerQueueIDElemNames.Add("0");
			ObjectManagerQueueID=new UAVObjectField<UInt32>("ObjectManagerQueueID", "uavoid", ObjectManagerQueueIDElemNames, null, this);
			fields.Add(ObjectManagerQueueID);

			List<String> HeapRemainingElemNames = new List<String>();
			HeapRemainingElemNames.Add("0");
			HeapRemaining=new UAVObjectField<UInt16>("HeapRemaining", "bytes", HeapRemainingElemNames, null, this);
			fields.Add(HeapRemaining);

			List<String> IRQStackRemainingElemNames = new List<String>();
			IRQStackRemainingElemNames.Add("0");
			IRQStackRemaining=new UAVObjectField<UInt16>("IRQStackRemaining", "bytes", IRQStackRemainingElemNames, null, this);
			fields.Add(IRQStackRemaining);

			List<String> SysSlotsFreeElemNames = new List<String>();
			SysSlotsFreeElemNames.Add("0");
			SysSlotsFree=new UAVObjectField<UInt16>("SysSlotsFree", "slots", SysSlotsFreeElemNames, null, this);
			fields.Add(SysSlotsFree);

			List<String> SysSlotsActiveElemNames = new List<String>();
			SysSlotsActiveElemNames.Add("0");
			SysSlotsActive=new UAVObjectField<UInt16>("SysSlotsActive", "slots", SysSlotsActiveElemNames, null, this);
			fields.Add(SysSlotsActive);

			List<String> UsrSlotsFreeElemNames = new List<String>();
			UsrSlotsFreeElemNames.Add("0");
			UsrSlotsFree=new UAVObjectField<UInt16>("UsrSlotsFree", "slots", UsrSlotsFreeElemNames, null, this);
			fields.Add(UsrSlotsFree);

			List<String> UsrSlotsActiveElemNames = new List<String>();
			UsrSlotsActiveElemNames.Add("0");
			UsrSlotsActive=new UAVObjectField<UInt16>("UsrSlotsActive", "slots", UsrSlotsActiveElemNames, null, this);
			fields.Add(UsrSlotsActive);

			List<String> CPULoadElemNames = new List<String>();
			CPULoadElemNames.Add("0");
			CPULoad=new UAVObjectField<byte>("CPULoad", "%", CPULoadElemNames, null, this);
			fields.Add(CPULoad);

			List<String> CPUTempElemNames = new List<String>();
			CPUTempElemNames.Add("0");
			CPUTemp=new UAVObjectField<sbyte>("CPUTemp", "C", CPUTempElemNames, null, this);
			fields.Add(CPUTemp);

	

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
				0 << Metadata.UAVOBJ_TELEMETRY_ACKED_SHIFT |
				0 << Metadata.UAVOBJ_GCS_TELEMETRY_ACKED_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_PERIODIC << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_MANUAL << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
    		metadata.flightTelemetryUpdatePeriod = 1000;
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
				SystemStats obj = new SystemStats();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public SystemStats GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (SystemStats)(objMngr.getObject(SystemStats.OBJID, instID));
		}
	}
}

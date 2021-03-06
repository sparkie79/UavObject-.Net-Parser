﻿// Object ID: 2718431868
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class WatchdogStatus : UAVDataObject
	{
		public const long OBJID = 2718431868;
		public int NUMBYTES { get; set; }
		protected const String NAME = "WatchdogStatus";
	    protected static String DESCRIPTION = @"For monitoring the flags in the watchdog and especially the bootup flags";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<UInt16> BootupFlags;
		public UAVObjectField<UInt16> ActiveFlags;

		public WatchdogStatus() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> BootupFlagsElemNames = new List<String>();
			BootupFlagsElemNames.Add("0");
			BootupFlags=new UAVObjectField<UInt16>("BootupFlags", "", BootupFlagsElemNames, null, this);
			fields.Add(BootupFlags);

			List<String> ActiveFlagsElemNames = new List<String>();
			ActiveFlagsElemNames.Add("0");
			ActiveFlags=new UAVObjectField<UInt16>("ActiveFlags", "", ActiveFlagsElemNames, null, this);
			fields.Add(ActiveFlags);

	

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
    		metadata.flightTelemetryUpdatePeriod = 5000;
    		metadata.gcsTelemetryUpdatePeriod = 0;
    		metadata.loggingUpdatePeriod = 5000;
 
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
				WatchdogStatus obj = new WatchdogStatus();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public WatchdogStatus GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (WatchdogStatus)(objMngr.getObject(WatchdogStatus.OBJID, instID));
		}
	}
}

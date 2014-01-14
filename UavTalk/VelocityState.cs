// Object ID: 3259197548
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class VelocityState : UAVDataObject
	{
		public const long OBJID = 3259197548;
		public int NUMBYTES { get; set; }
		protected const String NAME = "VelocityState";
	    protected static String DESCRIPTION = @"Updated by @ref StateEstimationModule, velocity relative to @ref HomeLocation.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> North;
		public UAVObjectField<float> East;
		public UAVObjectField<float> Down;

		public VelocityState() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> NorthElemNames = new List<String>();
			NorthElemNames.Add("0");
			North=new UAVObjectField<float>("North", "m/s", NorthElemNames, null, this);
			fields.Add(North);

			List<String> EastElemNames = new List<String>();
			EastElemNames.Add("0");
			East=new UAVObjectField<float>("East", "m/s", EastElemNames, null, this);
			fields.Add(East);

			List<String> DownElemNames = new List<String>();
			DownElemNames.Add("0");
			Down=new UAVObjectField<float>("Down", "m/s", DownElemNames, null, this);
			fields.Add(Down);

	

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
				VelocityState obj = new VelocityState();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public VelocityState GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (VelocityState)(objMngr.getObject(VelocityState.OBJID, instID));
		}
	}
}

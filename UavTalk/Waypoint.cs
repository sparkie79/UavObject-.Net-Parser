// Object ID: 3526906588
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class Waypoint : UAVDataObject
	{
		public const long OBJID = 3526906588;
		public int NUMBYTES { get; set; }
		protected const String NAME = "Waypoint";
	    protected static String DESCRIPTION = @"A waypoint the aircraft can try and hit.  Used by the @ref PathPlanner module";
		protected const bool ISSINGLEINST = false;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> Position;
		public UAVObjectField<float> Velocity;
		public UAVObjectField<byte> Action;

		public Waypoint() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> PositionElemNames = new List<String>();
			PositionElemNames.Add("North");
			PositionElemNames.Add("East");
			PositionElemNames.Add("Down");
			Position=new UAVObjectField<float>("Position", "m", PositionElemNames, null, this);
			fields.Add(Position);

			List<String> VelocityElemNames = new List<String>();
			VelocityElemNames.Add("0");
			Velocity=new UAVObjectField<float>("Velocity", "m/s", VelocityElemNames, null, this);
			fields.Add(Velocity);

			List<String> ActionElemNames = new List<String>();
			ActionElemNames.Add("0");
			Action=new UAVObjectField<byte>("Action", "", ActionElemNames, null, this);
			fields.Add(Action);

	

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
				1 << Metadata.UAVOBJ_GCS_TELEMETRY_ACKED_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_PERIODIC << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_MANUAL << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
    		metadata.flightTelemetryUpdatePeriod = 4000;
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
				Waypoint obj = new Waypoint();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public Waypoint GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (Waypoint)(objMngr.getObject(Waypoint.OBJID, instID));
		}
	}
}

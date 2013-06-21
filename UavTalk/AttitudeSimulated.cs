// Object ID: 2456211060
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class AttitudeSimulated : UAVDataObject
	{
		public const long OBJID = 2456211060;
		public int NUMBYTES { get; set; }
		protected const String NAME = "AttitudeSimulated";
	    protected static String DESCRIPTION = @"The simulated Attitude estimation from @ref Sensors.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> q1;
		public UAVObjectField<float> q2;
		public UAVObjectField<float> q3;
		public UAVObjectField<float> q4;
		public UAVObjectField<float> Roll;
		public UAVObjectField<float> Pitch;
		public UAVObjectField<float> Yaw;
		public UAVObjectField<float> Velocity;
		public UAVObjectField<float> Position;

		public AttitudeSimulated() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> q1ElemNames = new List<String>();
			q1ElemNames.Add("0");
			q1=new UAVObjectField<float>("q1", "", q1ElemNames, null, this);
			fields.Add(q1);

			List<String> q2ElemNames = new List<String>();
			q2ElemNames.Add("0");
			q2=new UAVObjectField<float>("q2", "", q2ElemNames, null, this);
			fields.Add(q2);

			List<String> q3ElemNames = new List<String>();
			q3ElemNames.Add("0");
			q3=new UAVObjectField<float>("q3", "", q3ElemNames, null, this);
			fields.Add(q3);

			List<String> q4ElemNames = new List<String>();
			q4ElemNames.Add("0");
			q4=new UAVObjectField<float>("q4", "", q4ElemNames, null, this);
			fields.Add(q4);

			List<String> RollElemNames = new List<String>();
			RollElemNames.Add("0");
			Roll=new UAVObjectField<float>("Roll", "degrees", RollElemNames, null, this);
			fields.Add(Roll);

			List<String> PitchElemNames = new List<String>();
			PitchElemNames.Add("0");
			Pitch=new UAVObjectField<float>("Pitch", "degrees", PitchElemNames, null, this);
			fields.Add(Pitch);

			List<String> YawElemNames = new List<String>();
			YawElemNames.Add("0");
			Yaw=new UAVObjectField<float>("Yaw", "degrees", YawElemNames, null, this);
			fields.Add(Yaw);

			List<String> VelocityElemNames = new List<String>();
			VelocityElemNames.Add("North");
			VelocityElemNames.Add("East");
			VelocityElemNames.Add("Down");
			Velocity=new UAVObjectField<float>("Velocity", "m/s", VelocityElemNames, null, this);
			fields.Add(Velocity);

			List<String> PositionElemNames = new List<String>();
			PositionElemNames.Add("North");
			PositionElemNames.Add("East");
			PositionElemNames.Add("Down");
			Position=new UAVObjectField<float>("Position", "m", PositionElemNames, null, this);
			fields.Add(Position);

	

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
    		metadata.flightTelemetryUpdatePeriod = 100;
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
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				AttitudeSimulated obj = new AttitudeSimulated();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public AttitudeSimulated GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (AttitudeSimulated)(objMngr.getObject(AttitudeSimulated.OBJID, instID));
		}
	}
}

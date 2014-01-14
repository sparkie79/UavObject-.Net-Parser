// Object ID: 3393963172
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class ActuatorDesired : UAVDataObject
	{
		public const long OBJID = 3393963172;
		public int NUMBYTES { get; set; }
		protected const String NAME = "ActuatorDesired";
	    protected static String DESCRIPTION = @"Desired raw, pitch and yaw actuator settings.  Comes from either @ref StabilizationModule or @ref ManualControlModule depending on FlightMode.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> Roll;
		public UAVObjectField<float> Pitch;
		public UAVObjectField<float> Yaw;
		public UAVObjectField<float> Throttle;
		public UAVObjectField<float> UpdateTime;
		public UAVObjectField<float> NumLongUpdates;

		public ActuatorDesired() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> RollElemNames = new List<String>();
			RollElemNames.Add("0");
			Roll=new UAVObjectField<float>("Roll", "%", RollElemNames, null, this);
			fields.Add(Roll);

			List<String> PitchElemNames = new List<String>();
			PitchElemNames.Add("0");
			Pitch=new UAVObjectField<float>("Pitch", "%", PitchElemNames, null, this);
			fields.Add(Pitch);

			List<String> YawElemNames = new List<String>();
			YawElemNames.Add("0");
			Yaw=new UAVObjectField<float>("Yaw", "%", YawElemNames, null, this);
			fields.Add(Yaw);

			List<String> ThrottleElemNames = new List<String>();
			ThrottleElemNames.Add("0");
			Throttle=new UAVObjectField<float>("Throttle", "%", ThrottleElemNames, null, this);
			fields.Add(Throttle);

			List<String> UpdateTimeElemNames = new List<String>();
			UpdateTimeElemNames.Add("0");
			UpdateTime=new UAVObjectField<float>("UpdateTime", "ms", UpdateTimeElemNames, null, this);
			fields.Add(UpdateTime);

			List<String> NumLongUpdatesElemNames = new List<String>();
			NumLongUpdatesElemNames.Add("0");
			NumLongUpdates=new UAVObjectField<float>("NumLongUpdates", "ms", NumLongUpdatesElemNames, null, this);
			fields.Add(NumLongUpdates);

	

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
				ActuatorDesired obj = new ActuatorDesired();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public ActuatorDesired GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (ActuatorDesired)(objMngr.getObject(ActuatorDesired.OBJID, instID));
		}
	}
}

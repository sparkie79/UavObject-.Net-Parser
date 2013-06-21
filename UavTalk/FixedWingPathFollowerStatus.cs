// Object ID: 2896693256
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class FixedWingPathFollowerStatus : UAVDataObject
	{
		public const long OBJID = 2896693256;
		public int NUMBYTES { get; set; }
		protected const String NAME = "FixedWingPathFollowerStatus";
	    protected static String DESCRIPTION = @"Object Storing Debugging Information on PID internals";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> Error;
		public UAVObjectField<float> ErrorInt;
		public UAVObjectField<float> Command;
		public UAVObjectField<byte> Errors;

		public FixedWingPathFollowerStatus() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ErrorElemNames = new List<String>();
			ErrorElemNames.Add("Bearing");
			ErrorElemNames.Add("Speed");
			ErrorElemNames.Add("Accel");
			ErrorElemNames.Add("Power");
			Error=new UAVObjectField<float>("Error", "", ErrorElemNames, null, this);
			fields.Add(Error);

			List<String> ErrorIntElemNames = new List<String>();
			ErrorIntElemNames.Add("Bearing");
			ErrorIntElemNames.Add("Speed");
			ErrorIntElemNames.Add("Accel");
			ErrorIntElemNames.Add("Power");
			ErrorInt=new UAVObjectField<float>("ErrorInt", "", ErrorIntElemNames, null, this);
			fields.Add(ErrorInt);

			List<String> CommandElemNames = new List<String>();
			CommandElemNames.Add("Bearing");
			CommandElemNames.Add("Speed");
			CommandElemNames.Add("Accel");
			CommandElemNames.Add("Power");
			Command=new UAVObjectField<float>("Command", "", CommandElemNames, null, this);
			fields.Add(Command);

			List<String> ErrorsElemNames = new List<String>();
			ErrorsElemNames.Add("Wind");
			ErrorsElemNames.Add("Stallspeed");
			ErrorsElemNames.Add("Lowspeed");
			ErrorsElemNames.Add("Highspeed");
			ErrorsElemNames.Add("Overspeed");
			ErrorsElemNames.Add("Lowpower");
			ErrorsElemNames.Add("Highpower");
			ErrorsElemNames.Add("Pitchcontrol");
			Errors=new UAVObjectField<byte>("Errors", "", ErrorsElemNames, null, this);
			fields.Add(Errors);

	

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
    		metadata.flightTelemetryUpdatePeriod = 50000;
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
				FixedWingPathFollowerStatus obj = new FixedWingPathFollowerStatus();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public FixedWingPathFollowerStatus GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (FixedWingPathFollowerStatus)(objMngr.getObject(FixedWingPathFollowerStatus.OBJID, instID));
		}
	}
}

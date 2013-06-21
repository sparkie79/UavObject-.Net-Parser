// Object ID: 734443986
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class AltHoldSmoothed : UAVDataObject
	{
		public const long OBJID = 734443986;
		public int NUMBYTES { get; set; }
		protected const String NAME = "AltHoldSmoothed";
	    protected static String DESCRIPTION = @"The output on the kalman filter on altitude.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> Altitude;
		public UAVObjectField<float> Velocity;
		public UAVObjectField<float> Accel;

		public AltHoldSmoothed() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> AltitudeElemNames = new List<String>();
			AltitudeElemNames.Add("0");
			Altitude=new UAVObjectField<float>("Altitude", "m", AltitudeElemNames, null, this);
			fields.Add(Altitude);

			List<String> VelocityElemNames = new List<String>();
			VelocityElemNames.Add("0");
			Velocity=new UAVObjectField<float>("Velocity", "m/s", VelocityElemNames, null, this);
			fields.Add(Velocity);

			List<String> AccelElemNames = new List<String>();
			AccelElemNames.Add("0");
			Accel=new UAVObjectField<float>("Accel", "m/s^2", AccelElemNames, null, this);
			fields.Add(Accel);

	

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
				AltHoldSmoothed obj = new AltHoldSmoothed();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public AltHoldSmoothed GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (AltHoldSmoothed)(objMngr.getObject(AltHoldSmoothed.OBJID, instID));
		}
	}
}

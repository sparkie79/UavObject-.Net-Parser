// Object ID: 1209142950
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class BaroSensor : UAVDataObject
	{
		public const long OBJID = 1209142950;
		public int NUMBYTES { get; set; }
		protected const String NAME = "BaroSensor";
	    protected static String DESCRIPTION = @"The raw data from the barometric sensor with pressure, temperature and altitude estimate.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> Altitude;
		public UAVObjectField<float> Temperature;
		public UAVObjectField<float> Pressure;

		public BaroSensor() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> AltitudeElemNames = new List<String>();
			AltitudeElemNames.Add("0");
			Altitude=new UAVObjectField<float>("Altitude", "m", AltitudeElemNames, null, this);
			fields.Add(Altitude);

			List<String> TemperatureElemNames = new List<String>();
			TemperatureElemNames.Add("0");
			Temperature=new UAVObjectField<float>("Temperature", "C", TemperatureElemNames, null, this);
			fields.Add(Temperature);

			List<String> PressureElemNames = new List<String>();
			PressureElemNames.Add("0");
			Pressure=new UAVObjectField<float>("Pressure", "kPa", PressureElemNames, null, this);
			fields.Add(Pressure);

	

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
				BaroSensor obj = new BaroSensor();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public BaroSensor GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (BaroSensor)(objMngr.getObject(BaroSensor.OBJID, instID));
		}
	}
}

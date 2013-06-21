// Object ID: 322581120
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class AirspeedActual : UAVDataObject
	{
		public const long OBJID = 322581120;
		public int NUMBYTES { get; set; }
		protected const String NAME = "AirspeedActual";
	    protected static String DESCRIPTION = @"UAVO for true airspeed, calibrated airspeed, angle of attack, and angle of slip";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> TrueAirspeed;
		public UAVObjectField<float> CalibratedAirspeed;
		public UAVObjectField<float> alpha;
		public UAVObjectField<float> beta;

		public AirspeedActual() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> TrueAirspeedElemNames = new List<String>();
			TrueAirspeedElemNames.Add("0");
			TrueAirspeed=new UAVObjectField<float>("TrueAirspeed", "m/s", TrueAirspeedElemNames, null, this);
			fields.Add(TrueAirspeed);

			List<String> CalibratedAirspeedElemNames = new List<String>();
			CalibratedAirspeedElemNames.Add("0");
			CalibratedAirspeed=new UAVObjectField<float>("CalibratedAirspeed", "m/s", CalibratedAirspeedElemNames, null, this);
			fields.Add(CalibratedAirspeed);

			List<String> alphaElemNames = new List<String>();
			alphaElemNames.Add("0");
			alpha=new UAVObjectField<float>("alpha", "deg", alphaElemNames, null, this);
			fields.Add(alpha);

			List<String> betaElemNames = new List<String>();
			betaElemNames.Add("0");
			beta=new UAVObjectField<float>("beta", "deg", betaElemNames, null, this);
			fields.Add(beta);

	

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
    		metadata.flightTelemetryUpdatePeriod = 500;
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
				AirspeedActual obj = new AirspeedActual();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public AirspeedActual GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (AirspeedActual)(objMngr.getObject(AirspeedActual.OBJID, instID));
		}
	}
}

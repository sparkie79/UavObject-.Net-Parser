// Object ID: 1402977786
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class AltitudeFilterSettings : UAVDataObject
	{
		public const long OBJID = 1402977786;
		public int NUMBYTES { get; set; }
		protected const String NAME = "AltitudeFilterSettings";
	    protected static String DESCRIPTION = @"Settings for the @ref State Estimator module plugin altitudeFilter";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> AccelLowPassKp;
		public UAVObjectField<float> AccelDriftKi;
		public UAVObjectField<float> BaroKp;

		public AltitudeFilterSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> AccelLowPassKpElemNames = new List<String>();
			AccelLowPassKpElemNames.Add("0");
			AccelLowPassKp=new UAVObjectField<float>("AccelLowPassKp", "m/s^2", AccelLowPassKpElemNames, null, this);
			fields.Add(AccelLowPassKp);

			List<String> AccelDriftKiElemNames = new List<String>();
			AccelDriftKiElemNames.Add("0");
			AccelDriftKi=new UAVObjectField<float>("AccelDriftKi", "m/s^2", AccelDriftKiElemNames, null, this);
			fields.Add(AccelDriftKi);

			List<String> BaroKpElemNames = new List<String>();
			BaroKpElemNames.Add("0");
			BaroKp=new UAVObjectField<float>("BaroKp", "m", BaroKpElemNames, null, this);
			fields.Add(BaroKp);

	

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
				1 << Metadata.UAVOBJ_TELEMETRY_ACKED_SHIFT |
				1 << Metadata.UAVOBJ_GCS_TELEMETRY_ACKED_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_ONCHANGE << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_ONCHANGE << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
    		metadata.flightTelemetryUpdatePeriod = 0;
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
			AccelLowPassKp.setValue((float)7);
			AccelDriftKi.setValue((float)5);
			BaroKp.setValue((float)2);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				AltitudeFilterSettings obj = new AltitudeFilterSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public AltitudeFilterSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (AltitudeFilterSettings)(objMngr.getObject(AltitudeFilterSettings.OBJID, instID));
		}
	}
}

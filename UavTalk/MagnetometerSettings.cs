// Object ID: 3032077636
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class MagnetometerSettings : UAVDataObject
	{
		public const long OBJID = 3032077636;
		public int NUMBYTES { get; set; }
		protected const String NAME = "MagnetometerSettings";
	    protected static String DESCRIPTION = @"Settings for the @ref Attitude module";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> MagBias;
		public UAVObjectField<float> MagScale;

		public MagnetometerSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> MagBiasElemNames = new List<String>();
			MagBiasElemNames.Add("X");
			MagBiasElemNames.Add("Y");
			MagBiasElemNames.Add("Z");
			MagBias=new UAVObjectField<float>("MagBias", "mGau", MagBiasElemNames, null, this);
			fields.Add(MagBias);

			List<String> MagScaleElemNames = new List<String>();
			MagScaleElemNames.Add("X");
			MagScaleElemNames.Add("Y");
			MagScaleElemNames.Add("Z");
			MagScale=new UAVObjectField<float>("MagScale", "gain", MagScaleElemNames, null, this);
			fields.Add(MagScale);

	

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
			MagBias.setValue((float)0,0);
			MagBias.setValue((float)0,1);
			MagBias.setValue((float)0,2);
			MagScale.setValue((float)1,0);
			MagScale.setValue((float)1,1);
			MagScale.setValue((float)1,2);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				MagnetometerSettings obj = new MagnetometerSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public MagnetometerSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (MagnetometerSettings)(objMngr.getObject(MagnetometerSettings.OBJID, instID));
		}
	}
}

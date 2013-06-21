// Object ID: 48708918
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class SensorSettings : UAVDataObject
	{
		public const long OBJID = 48708918;
		public int NUMBYTES { get; set; }
		protected const String NAME = "SensorSettings";
	    protected static String DESCRIPTION = @"Settings for the @ref Attitude module";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> AccelBias;
		public UAVObjectField<float> AccelScale;
		public UAVObjectField<float> GyroScale;
		public UAVObjectField<float> XGyroTempCoeff;
		public UAVObjectField<float> YGyroTempCoeff;
		public UAVObjectField<float> ZGyroTempCoeff;
		public UAVObjectField<float> MagBias;
		public UAVObjectField<float> MagScale;

		public SensorSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> AccelBiasElemNames = new List<String>();
			AccelBiasElemNames.Add("X");
			AccelBiasElemNames.Add("Y");
			AccelBiasElemNames.Add("Z");
			AccelBias=new UAVObjectField<float>("AccelBias", "m/s^2", AccelBiasElemNames, null, this);
			fields.Add(AccelBias);

			List<String> AccelScaleElemNames = new List<String>();
			AccelScaleElemNames.Add("X");
			AccelScaleElemNames.Add("Y");
			AccelScaleElemNames.Add("Z");
			AccelScale=new UAVObjectField<float>("AccelScale", "[-]", AccelScaleElemNames, null, this);
			fields.Add(AccelScale);

			List<String> GyroScaleElemNames = new List<String>();
			GyroScaleElemNames.Add("X");
			GyroScaleElemNames.Add("Y");
			GyroScaleElemNames.Add("Z");
			GyroScale=new UAVObjectField<float>("GyroScale", "-", GyroScaleElemNames, null, this);
			fields.Add(GyroScale);

			List<String> XGyroTempCoeffElemNames = new List<String>();
			XGyroTempCoeffElemNames.Add("1");
			XGyroTempCoeffElemNames.Add("T");
			XGyroTempCoeffElemNames.Add("T2");
			XGyroTempCoeffElemNames.Add("T3");
			XGyroTempCoeff=new UAVObjectField<float>("XGyroTempCoeff", "(deg/s)/deg", XGyroTempCoeffElemNames, null, this);
			fields.Add(XGyroTempCoeff);

			List<String> YGyroTempCoeffElemNames = new List<String>();
			YGyroTempCoeffElemNames.Add("1");
			YGyroTempCoeffElemNames.Add("T");
			YGyroTempCoeffElemNames.Add("T2");
			YGyroTempCoeffElemNames.Add("T3");
			YGyroTempCoeff=new UAVObjectField<float>("YGyroTempCoeff", "(deg/s)/deg", YGyroTempCoeffElemNames, null, this);
			fields.Add(YGyroTempCoeff);

			List<String> ZGyroTempCoeffElemNames = new List<String>();
			ZGyroTempCoeffElemNames.Add("1");
			ZGyroTempCoeffElemNames.Add("T");
			ZGyroTempCoeffElemNames.Add("T2");
			ZGyroTempCoeffElemNames.Add("T3");
			ZGyroTempCoeff=new UAVObjectField<float>("ZGyroTempCoeff", "(deg/s)/deg", ZGyroTempCoeffElemNames, null, this);
			fields.Add(ZGyroTempCoeff);

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
			AccelBias.setValue((float)0,0);
			AccelBias.setValue((float)0,1);
			AccelBias.setValue((float)0,2);
			AccelScale.setValue((float)1,0);
			AccelScale.setValue((float)1,1);
			AccelScale.setValue((float)1,2);
			GyroScale.setValue((float)1,0);
			GyroScale.setValue((float)1,1);
			GyroScale.setValue((float)1,2);
			XGyroTempCoeff.setValue((float)0,0);
			XGyroTempCoeff.setValue((float)0,1);
			XGyroTempCoeff.setValue((float)0,2);
			XGyroTempCoeff.setValue((float)0,3);
			YGyroTempCoeff.setValue((float)0,0);
			YGyroTempCoeff.setValue((float)0,1);
			YGyroTempCoeff.setValue((float)0,2);
			YGyroTempCoeff.setValue((float)0,3);
			ZGyroTempCoeff.setValue((float)0,0);
			ZGyroTempCoeff.setValue((float)0,1);
			ZGyroTempCoeff.setValue((float)0,2);
			ZGyroTempCoeff.setValue((float)0,3);
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
				SensorSettings obj = new SensorSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public SensorSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (SensorSettings)(objMngr.getObject(SensorSettings.OBJID, instID));
		}
	}
}

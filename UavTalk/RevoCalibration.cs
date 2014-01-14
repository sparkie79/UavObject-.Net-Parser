// Object ID: 3806208588
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class RevoCalibration : UAVDataObject
	{
		public const long OBJID = 3806208588;
		public int NUMBYTES { get; set; }
		protected const String NAME = "RevoCalibration";
	    protected static String DESCRIPTION = @"Settings for the INS to control the algorithm and what is updated";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> accel_bias;
		public UAVObjectField<float> accel_scale;
		public UAVObjectField<float> gyro_bias;
		public UAVObjectField<float> gyro_scale;
		public UAVObjectField<float> mag_bias;
		public UAVObjectField<float> mag_scale;
		public UAVObjectField<float> MagBiasNullingRate;
		public enum BiasCorrectedRawUavEnum
		{
			[Description("FALSE")]
			FALSE = 0, 
			[Description("TRUE")]
			TRUE = 1, 
		}
		public UAVObjectField<BiasCorrectedRawUavEnum> BiasCorrectedRaw;

		public RevoCalibration() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> accel_biasElemNames = new List<String>();
			accel_biasElemNames.Add("X");
			accel_biasElemNames.Add("Y");
			accel_biasElemNames.Add("Z");
			accel_bias=new UAVObjectField<float>("accel_bias", "m/s", accel_biasElemNames, null, this);
			fields.Add(accel_bias);

			List<String> accel_scaleElemNames = new List<String>();
			accel_scaleElemNames.Add("X");
			accel_scaleElemNames.Add("Y");
			accel_scaleElemNames.Add("Z");
			accel_scale=new UAVObjectField<float>("accel_scale", "gain", accel_scaleElemNames, null, this);
			fields.Add(accel_scale);

			List<String> gyro_biasElemNames = new List<String>();
			gyro_biasElemNames.Add("X");
			gyro_biasElemNames.Add("Y");
			gyro_biasElemNames.Add("Z");
			gyro_bias=new UAVObjectField<float>("gyro_bias", "deg/s", gyro_biasElemNames, null, this);
			fields.Add(gyro_bias);

			List<String> gyro_scaleElemNames = new List<String>();
			gyro_scaleElemNames.Add("X");
			gyro_scaleElemNames.Add("Y");
			gyro_scaleElemNames.Add("Z");
			gyro_scale=new UAVObjectField<float>("gyro_scale", "gain", gyro_scaleElemNames, null, this);
			fields.Add(gyro_scale);

			List<String> mag_biasElemNames = new List<String>();
			mag_biasElemNames.Add("X");
			mag_biasElemNames.Add("Y");
			mag_biasElemNames.Add("Z");
			mag_bias=new UAVObjectField<float>("mag_bias", "mGau", mag_biasElemNames, null, this);
			fields.Add(mag_bias);

			List<String> mag_scaleElemNames = new List<String>();
			mag_scaleElemNames.Add("X");
			mag_scaleElemNames.Add("Y");
			mag_scaleElemNames.Add("Z");
			mag_scale=new UAVObjectField<float>("mag_scale", "gain", mag_scaleElemNames, null, this);
			fields.Add(mag_scale);

			List<String> MagBiasNullingRateElemNames = new List<String>();
			MagBiasNullingRateElemNames.Add("0");
			MagBiasNullingRate=new UAVObjectField<float>("MagBiasNullingRate", "", MagBiasNullingRateElemNames, null, this);
			fields.Add(MagBiasNullingRate);

			List<String> BiasCorrectedRawElemNames = new List<String>();
			BiasCorrectedRawElemNames.Add("0");
			List<String> BiasCorrectedRawEnumOptions = new List<String>();
			BiasCorrectedRawEnumOptions.Add("FALSE");
			BiasCorrectedRawEnumOptions.Add("TRUE");
			BiasCorrectedRaw=new UAVObjectField<BiasCorrectedRawUavEnum>("BiasCorrectedRaw", "", BiasCorrectedRawElemNames, BiasCorrectedRawEnumOptions, this);
			fields.Add(BiasCorrectedRaw);

	

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
			accel_bias.setValue((float)0,0);
			accel_bias.setValue((float)0,1);
			accel_bias.setValue((float)0,2);
			accel_scale.setValue((float)1,0);
			accel_scale.setValue((float)1,1);
			accel_scale.setValue((float)1,2);
			gyro_bias.setValue((float)0,0);
			gyro_bias.setValue((float)0,1);
			gyro_bias.setValue((float)0,2);
			gyro_scale.setValue((float)1,0);
			gyro_scale.setValue((float)1,1);
			gyro_scale.setValue((float)1,2);
			mag_bias.setValue((float)0,0);
			mag_bias.setValue((float)0,1);
			mag_bias.setValue((float)0,2);
			mag_scale.setValue((float)1,0);
			mag_scale.setValue((float)1,1);
			mag_scale.setValue((float)1,2);
			MagBiasNullingRate.setValue((float)0);
			BiasCorrectedRaw.setValue(BiasCorrectedRawUavEnum.TRUE);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				RevoCalibration obj = new RevoCalibration();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public RevoCalibration GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (RevoCalibration)(objMngr.getObject(RevoCalibration.OBJID, instID));
		}
	}
}

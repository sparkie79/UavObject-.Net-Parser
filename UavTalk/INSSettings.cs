// Object ID: 2362439506
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class INSSettings : UAVDataObject
	{
		public const long OBJID = 2362439506;
		public int NUMBYTES { get; set; }
		protected const String NAME = "INSSettings";
	    protected static String DESCRIPTION = @"Settings for the INS to control the algorithm and what is updated";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> accel_var;
		public UAVObjectField<float> gyro_var;
		public UAVObjectField<float> mag_var;
		public UAVObjectField<float> gps_var;
		public UAVObjectField<float> baro_var;
		public UAVObjectField<float> MagBiasNullingRate;
		public enum ComputeGyroBiasUavEnum
		{
			[Description("FALSE")]
			FALSE = 0, 
			[Description("TRUE")]
			TRUE = 1, 
		}
		public UAVObjectField<ComputeGyroBiasUavEnum> ComputeGyroBias;

		public INSSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> accel_varElemNames = new List<String>();
			accel_varElemNames.Add("X");
			accel_varElemNames.Add("Y");
			accel_varElemNames.Add("Z");
			accel_var=new UAVObjectField<float>("accel_var", "(m/s)^2", accel_varElemNames, null, this);
			fields.Add(accel_var);

			List<String> gyro_varElemNames = new List<String>();
			gyro_varElemNames.Add("X");
			gyro_varElemNames.Add("Y");
			gyro_varElemNames.Add("Z");
			gyro_var=new UAVObjectField<float>("gyro_var", "(deg/s)^2", gyro_varElemNames, null, this);
			fields.Add(gyro_var);

			List<String> mag_varElemNames = new List<String>();
			mag_varElemNames.Add("X");
			mag_varElemNames.Add("Y");
			mag_varElemNames.Add("Z");
			mag_var=new UAVObjectField<float>("mag_var", "mGau^2", mag_varElemNames, null, this);
			fields.Add(mag_var);

			List<String> gps_varElemNames = new List<String>();
			gps_varElemNames.Add("Pos");
			gps_varElemNames.Add("Vel");
			gps_varElemNames.Add("VertPos");
			gps_var=new UAVObjectField<float>("gps_var", "m^2", gps_varElemNames, null, this);
			fields.Add(gps_var);

			List<String> baro_varElemNames = new List<String>();
			baro_varElemNames.Add("0");
			baro_var=new UAVObjectField<float>("baro_var", "m^2", baro_varElemNames, null, this);
			fields.Add(baro_var);

			List<String> MagBiasNullingRateElemNames = new List<String>();
			MagBiasNullingRateElemNames.Add("0");
			MagBiasNullingRate=new UAVObjectField<float>("MagBiasNullingRate", "", MagBiasNullingRateElemNames, null, this);
			fields.Add(MagBiasNullingRate);

			List<String> ComputeGyroBiasElemNames = new List<String>();
			ComputeGyroBiasElemNames.Add("0");
			List<String> ComputeGyroBiasEnumOptions = new List<String>();
			ComputeGyroBiasEnumOptions.Add("FALSE");
			ComputeGyroBiasEnumOptions.Add("TRUE");
			ComputeGyroBias=new UAVObjectField<ComputeGyroBiasUavEnum>("ComputeGyroBias", "", ComputeGyroBiasElemNames, ComputeGyroBiasEnumOptions, this);
			fields.Add(ComputeGyroBias);

	

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
			accel_var.setValue((float)0.01,0);
			accel_var.setValue((float)0.01,1);
			accel_var.setValue((float)0.01,2);
			gyro_var.setValue((float)1E-05,0);
			gyro_var.setValue((float)1E-05,1);
			gyro_var.setValue((float)0.0001,2);
			mag_var.setValue((float)0.005,0);
			mag_var.setValue((float)0.005,1);
			mag_var.setValue((float)10,2);
			gps_var.setValue((float)0.001,0);
			gps_var.setValue((float)0.01,1);
			gps_var.setValue((float)10,2);
			baro_var.setValue((float)1);
			MagBiasNullingRate.setValue((float)0);
			ComputeGyroBias.setValue(ComputeGyroBiasUavEnum.FALSE);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				INSSettings obj = new INSSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public INSSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (INSSettings)(objMngr.getObject(INSSettings.OBJID, instID));
		}
	}
}

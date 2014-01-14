// Object ID: 2642197224
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class AirspeedSettings : UAVDataObject
	{
		public const long OBJID = 2642197224;
		public int NUMBYTES { get; set; }
		protected const String NAME = "AirspeedSettings";
	    protected static String DESCRIPTION = @"Settings for the @ref BaroAirspeed module used on CopterControl or Revolution";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> Scale;
		public UAVObjectField<float> GroundSpeedBasedEstimationLowPassAlpha;
		public UAVObjectField<UInt16> ZeroPoint;
		public UAVObjectField<byte> SamplePeriod;
		public enum AirspeedSensorTypeUavEnum
		{
			[Description("EagleTreeAirspeedV3")]
			EagleTreeAirspeedV3 = 0, 
			[Description("DIYDronesMPXV5004")]
			DIYDronesMPXV5004 = 1, 
			[Description("DIYDronesMPXV7002")]
			DIYDronesMPXV7002 = 2, 
			[Description("GroundSpeedBasedWindEstimation")]
			GroundSpeedBasedWindEstimation = 3, 
		}
		public UAVObjectField<AirspeedSensorTypeUavEnum> AirspeedSensorType;

		public AirspeedSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ScaleElemNames = new List<String>();
			ScaleElemNames.Add("0");
			Scale=new UAVObjectField<float>("Scale", "raw", ScaleElemNames, null, this);
			fields.Add(Scale);

			List<String> GroundSpeedBasedEstimationLowPassAlphaElemNames = new List<String>();
			GroundSpeedBasedEstimationLowPassAlphaElemNames.Add("0");
			GroundSpeedBasedEstimationLowPassAlpha=new UAVObjectField<float>("GroundSpeedBasedEstimationLowPassAlpha", "", GroundSpeedBasedEstimationLowPassAlphaElemNames, null, this);
			fields.Add(GroundSpeedBasedEstimationLowPassAlpha);

			List<String> ZeroPointElemNames = new List<String>();
			ZeroPointElemNames.Add("0");
			ZeroPoint=new UAVObjectField<UInt16>("ZeroPoint", "raw", ZeroPointElemNames, null, this);
			fields.Add(ZeroPoint);

			List<String> SamplePeriodElemNames = new List<String>();
			SamplePeriodElemNames.Add("0");
			SamplePeriod=new UAVObjectField<byte>("SamplePeriod", "ms", SamplePeriodElemNames, null, this);
			fields.Add(SamplePeriod);

			List<String> AirspeedSensorTypeElemNames = new List<String>();
			AirspeedSensorTypeElemNames.Add("0");
			List<String> AirspeedSensorTypeEnumOptions = new List<String>();
			AirspeedSensorTypeEnumOptions.Add("EagleTreeAirspeedV3");
			AirspeedSensorTypeEnumOptions.Add("DIYDronesMPXV5004");
			AirspeedSensorTypeEnumOptions.Add("DIYDronesMPXV7002");
			AirspeedSensorTypeEnumOptions.Add("GroundSpeedBasedWindEstimation");
			AirspeedSensorType=new UAVObjectField<AirspeedSensorTypeUavEnum>("AirspeedSensorType", "", AirspeedSensorTypeElemNames, AirspeedSensorTypeEnumOptions, this);
			fields.Add(AirspeedSensorType);

	

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
			Scale.setValue((float)10);
			GroundSpeedBasedEstimationLowPassAlpha.setValue((float)8);
			ZeroPoint.setValue((UInt16)0);
			SamplePeriod.setValue((byte)100);
			AirspeedSensorType.setValue(AirspeedSensorTypeUavEnum.DIYDronesMPXV7002);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				AirspeedSettings obj = new AirspeedSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public AirspeedSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (AirspeedSettings)(objMngr.getObject(AirspeedSettings.OBJID, instID));
		}
	}
}

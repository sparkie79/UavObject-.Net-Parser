// Object ID: 1407435012
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class RevoSettings : UAVDataObject
	{
		public const long OBJID = 1407435012;
		public int NUMBYTES { get; set; }
		protected const String NAME = "RevoSettings";
	    protected static String DESCRIPTION = @"Settings for the revo to control the algorithm and what is updated";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> BaroGPSOffsetCorrectionAlpha;
		public enum FusionAlgorithmUavEnum
		{
			[Description("None")]
			None = 0, 
			[Description("Complementary")]
			Complementary = 1, 
			[Description("Complementary+Mag")]
			ComplementaryMag = 2, 
			[Description("INS13Indoor")]
			INS13Indoor = 3, 
			[Description("INS13Outdoor")]
			INS13Outdoor = 4, 
		}
		public UAVObjectField<FusionAlgorithmUavEnum> FusionAlgorithm;

		public RevoSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> BaroGPSOffsetCorrectionAlphaElemNames = new List<String>();
			BaroGPSOffsetCorrectionAlphaElemNames.Add("0");
			BaroGPSOffsetCorrectionAlpha=new UAVObjectField<float>("BaroGPSOffsetCorrectionAlpha", "", BaroGPSOffsetCorrectionAlphaElemNames, null, this);
			fields.Add(BaroGPSOffsetCorrectionAlpha);

			List<String> FusionAlgorithmElemNames = new List<String>();
			FusionAlgorithmElemNames.Add("0");
			List<String> FusionAlgorithmEnumOptions = new List<String>();
			FusionAlgorithmEnumOptions.Add("None");
			FusionAlgorithmEnumOptions.Add("Complementary");
			FusionAlgorithmEnumOptions.Add("Complementary+Mag");
			FusionAlgorithmEnumOptions.Add("INS13Indoor");
			FusionAlgorithmEnumOptions.Add("INS13Outdoor");
			FusionAlgorithm=new UAVObjectField<FusionAlgorithmUavEnum>("FusionAlgorithm", "", FusionAlgorithmElemNames, FusionAlgorithmEnumOptions, this);
			fields.Add(FusionAlgorithm);

	

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
			BaroGPSOffsetCorrectionAlpha.setValue((float)9.993335E+12);
			FusionAlgorithm.setValue(FusionAlgorithmUavEnum.Complementary);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				RevoSettings obj = new RevoSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public RevoSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (RevoSettings)(objMngr.getObject(RevoSettings.OBJID, instID));
		}
	}
}

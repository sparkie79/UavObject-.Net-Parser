// Object ID: 1549571766
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class VibrationAnalysisSettings : UAVDataObject
	{
		public const long OBJID = 1549571766;
		public int NUMBYTES { get; set; }
		protected const String NAME = "VibrationAnalysisSettings";
	    protected static String DESCRIPTION = @"Settings for the @ref VibrationTest Module";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<UInt16> SampleRate;
		public enum FFTWindowSizeUavEnum
		{
			[Description("16")]
			v16 = 0, 
			[Description("64")]
			v64 = 1, 
			[Description("256")]
			v256 = 2, 
			[Description("1024")]
			v1024 = 3, 
		}
		public UAVObjectField<FFTWindowSizeUavEnum> FFTWindowSize;
		public enum TestingStatusUavEnum
		{
			[Description("Off")]
			Off = 0, 
			[Description("On")]
			On = 1, 
		}
		public UAVObjectField<TestingStatusUavEnum> TestingStatus;

		public VibrationAnalysisSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> SampleRateElemNames = new List<String>();
			SampleRateElemNames.Add("0");
			SampleRate=new UAVObjectField<UInt16>("SampleRate", "ms", SampleRateElemNames, null, this);
			fields.Add(SampleRate);

			List<String> FFTWindowSizeElemNames = new List<String>();
			FFTWindowSizeElemNames.Add("0");
			List<String> FFTWindowSizeEnumOptions = new List<String>();
			FFTWindowSizeEnumOptions.Add("16");
			FFTWindowSizeEnumOptions.Add("64");
			FFTWindowSizeEnumOptions.Add("256");
			FFTWindowSizeEnumOptions.Add("1024");
			FFTWindowSize=new UAVObjectField<FFTWindowSizeUavEnum>("FFTWindowSize", "", FFTWindowSizeElemNames, FFTWindowSizeEnumOptions, this);
			fields.Add(FFTWindowSize);

			List<String> TestingStatusElemNames = new List<String>();
			TestingStatusElemNames.Add("0");
			List<String> TestingStatusEnumOptions = new List<String>();
			TestingStatusEnumOptions.Add("Off");
			TestingStatusEnumOptions.Add("On");
			TestingStatus=new UAVObjectField<TestingStatusUavEnum>("TestingStatus", "", TestingStatusElemNames, TestingStatusEnumOptions, this);
			fields.Add(TestingStatus);

	

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
			SampleRate.setValue((UInt16)20);
			FFTWindowSize.setValue(FFTWindowSizeUavEnum.v16);
			TestingStatus.setValue(TestingStatusUavEnum.Off);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				VibrationAnalysisSettings obj = new VibrationAnalysisSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public VibrationAnalysisSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (VibrationAnalysisSettings)(objMngr.getObject(VibrationAnalysisSettings.OBJID, instID));
		}
	}
}

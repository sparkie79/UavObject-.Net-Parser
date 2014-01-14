// Object ID: 2835983996
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class Mpu6000Settings : UAVDataObject
	{
		public const long OBJID = 2835983996;
		public int NUMBYTES { get; set; }
		protected const String NAME = "Mpu6000Settings";
	    protected static String DESCRIPTION = @"Settings for the @ref MPU6000 sensor used on CC3D and Revolution. Reboot the board for this to takes effect";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public enum GyroScaleUavEnum
		{
			[Description("Scale_250")]
			Scale250 = 0, 
			[Description("Scale_500")]
			Scale500 = 1, 
			[Description("Scale_1000")]
			Scale1000 = 2, 
			[Description("Scale_2000")]
			Scale2000 = 3, 
		}
		public UAVObjectField<GyroScaleUavEnum> GyroScale;
		public enum AccelScaleUavEnum
		{
			[Description("Scale_2g")]
			Scale2g = 0, 
			[Description("Scale_4g")]
			Scale4g = 1, 
			[Description("Scale_8g")]
			Scale8g = 2, 
			[Description("Scale_16g")]
			Scale16g = 3, 
		}
		public UAVObjectField<AccelScaleUavEnum> AccelScale;
		public enum FilterSettingUavEnum
		{
			[Description("Lowpass_256_Hz")]
			Lowpass256Hz = 0, 
			[Description("Lowpass_188_Hz")]
			Lowpass188Hz = 1, 
			[Description("Lowpass_98_Hz")]
			Lowpass98Hz = 2, 
			[Description("Lowpass_42_Hz")]
			Lowpass42Hz = 3, 
			[Description("Lowpass_20_Hz")]
			Lowpass20Hz = 4, 
			[Description("Lowpass_10_Hz")]
			Lowpass10Hz = 5, 
			[Description("Lowpass_5_Hz")]
			Lowpass5Hz = 6, 
		}
		public UAVObjectField<FilterSettingUavEnum> FilterSetting;

		public Mpu6000Settings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> GyroScaleElemNames = new List<String>();
			GyroScaleElemNames.Add("0");
			List<String> GyroScaleEnumOptions = new List<String>();
			GyroScaleEnumOptions.Add("Scale_250");
			GyroScaleEnumOptions.Add("Scale_500");
			GyroScaleEnumOptions.Add("Scale_1000");
			GyroScaleEnumOptions.Add("Scale_2000");
			GyroScale=new UAVObjectField<GyroScaleUavEnum>("GyroScale", "deg/s", GyroScaleElemNames, GyroScaleEnumOptions, this);
			fields.Add(GyroScale);

			List<String> AccelScaleElemNames = new List<String>();
			AccelScaleElemNames.Add("0");
			List<String> AccelScaleEnumOptions = new List<String>();
			AccelScaleEnumOptions.Add("Scale_2g");
			AccelScaleEnumOptions.Add("Scale_4g");
			AccelScaleEnumOptions.Add("Scale_8g");
			AccelScaleEnumOptions.Add("Scale_16g");
			AccelScale=new UAVObjectField<AccelScaleUavEnum>("AccelScale", "g", AccelScaleElemNames, AccelScaleEnumOptions, this);
			fields.Add(AccelScale);

			List<String> FilterSettingElemNames = new List<String>();
			FilterSettingElemNames.Add("0");
			List<String> FilterSettingEnumOptions = new List<String>();
			FilterSettingEnumOptions.Add("Lowpass_256_Hz");
			FilterSettingEnumOptions.Add("Lowpass_188_Hz");
			FilterSettingEnumOptions.Add("Lowpass_98_Hz");
			FilterSettingEnumOptions.Add("Lowpass_42_Hz");
			FilterSettingEnumOptions.Add("Lowpass_20_Hz");
			FilterSettingEnumOptions.Add("Lowpass_10_Hz");
			FilterSettingEnumOptions.Add("Lowpass_5_Hz");
			FilterSetting=new UAVObjectField<FilterSettingUavEnum>("FilterSetting", "Hz", FilterSettingElemNames, FilterSettingEnumOptions, this);
			fields.Add(FilterSetting);

	

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
			GyroScale.setValue(GyroScaleUavEnum.Scale2000);
			AccelScale.setValue(AccelScaleUavEnum.Scale8g);
			FilterSetting.setValue(FilterSettingUavEnum.Lowpass256Hz);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				Mpu6000Settings obj = new Mpu6000Settings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public Mpu6000Settings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (Mpu6000Settings)(objMngr.getObject(Mpu6000Settings.OBJID, instID));
		}
	}
}

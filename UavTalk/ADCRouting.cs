// Object ID: 2677050632
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class ADCRouting : UAVDataObject
	{
		public const long OBJID = 2677050632;
		public int NUMBYTES { get; set; }
		protected const String NAME = "ADCRouting";
	    protected static String DESCRIPTION = @"Selection of optional hardware configurations.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public enum ChannelMapUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("BatteryVoltage")]
			BatteryVoltage = 1, 
			[Description("BatteryCurrent")]
			BatteryCurrent = 2, 
			[Description("AnalogAirspeed")]
			AnalogAirspeed = 3, 
			[Description("Generic")]
			Generic = 4, 
		}
		public UAVObjectField<ChannelMapUavEnum> ChannelMap;

		public ADCRouting() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ChannelMapElemNames = new List<String>();
			ChannelMapElemNames.Add("ADC0");
			ChannelMapElemNames.Add("ADC1");
			ChannelMapElemNames.Add("ADC2");
			ChannelMapElemNames.Add("ADC3");
			ChannelMapElemNames.Add("ADC4");
			ChannelMapElemNames.Add("ADC5");
			ChannelMapElemNames.Add("ADC6");
			ChannelMapElemNames.Add("ADC7");
			ChannelMapElemNames.Add("ADC8");
			List<String> ChannelMapEnumOptions = new List<String>();
			ChannelMapEnumOptions.Add("Disabled");
			ChannelMapEnumOptions.Add("BatteryVoltage");
			ChannelMapEnumOptions.Add("BatteryCurrent");
			ChannelMapEnumOptions.Add("AnalogAirspeed");
			ChannelMapEnumOptions.Add("Generic");
			ChannelMap=new UAVObjectField<ChannelMapUavEnum>("ChannelMap", "", ChannelMapElemNames, ChannelMapEnumOptions, this);
			fields.Add(ChannelMap);

	

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
			ChannelMap.setValue(ChannelMapUavEnum.Disabled,0);
			ChannelMap.setValue(ChannelMapUavEnum.Disabled,1);
			ChannelMap.setValue(ChannelMapUavEnum.Disabled,2);
			ChannelMap.setValue(ChannelMapUavEnum.Disabled,3);
			ChannelMap.setValue(ChannelMapUavEnum.Disabled,4);
			ChannelMap.setValue(ChannelMapUavEnum.Disabled,5);
			ChannelMap.setValue(ChannelMapUavEnum.Disabled,6);
			ChannelMap.setValue(ChannelMapUavEnum.Disabled,7);
			ChannelMap.setValue(ChannelMapUavEnum.Disabled,8);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				ADCRouting obj = new ADCRouting();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public ADCRouting GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (ADCRouting)(objMngr.getObject(ADCRouting.OBJID, instID));
		}
	}
}

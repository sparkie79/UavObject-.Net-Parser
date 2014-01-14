// Object ID: 2653087776
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class PoiLearnSettings : UAVDataObject
	{
		public const long OBJID = 2653087776;
		public int NUMBYTES { get; set; }
		protected const String NAME = "PoiLearnSettings";
	    protected static String DESCRIPTION = @"Settings for the @ref Point of Interest feature";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public enum InputUavEnum
		{
			[Description("Accessory0")]
			Accessory0 = 0, 
			[Description("Accessory1")]
			Accessory1 = 1, 
			[Description("Accessory2")]
			Accessory2 = 2, 
			[Description("Accessory3")]
			Accessory3 = 3, 
			[Description("Accessory4")]
			Accessory4 = 4, 
			[Description("Accessory5")]
			Accessory5 = 5, 
			[Description("None")]
			None = 6, 
		}
		public UAVObjectField<InputUavEnum> Input;

		public PoiLearnSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> InputElemNames = new List<String>();
			InputElemNames.Add("0");
			List<String> InputEnumOptions = new List<String>();
			InputEnumOptions.Add("Accessory0");
			InputEnumOptions.Add("Accessory1");
			InputEnumOptions.Add("Accessory2");
			InputEnumOptions.Add("Accessory3");
			InputEnumOptions.Add("Accessory4");
			InputEnumOptions.Add("Accessory5");
			InputEnumOptions.Add("None");
			Input=new UAVObjectField<InputUavEnum>("Input", "channel", InputElemNames, InputEnumOptions, this);
			fields.Add(Input);

	

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
			Input.setValue(InputUavEnum.None);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				PoiLearnSettings obj = new PoiLearnSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public PoiLearnSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (PoiLearnSettings)(objMngr.getObject(PoiLearnSettings.OBJID, instID));
		}
	}
}

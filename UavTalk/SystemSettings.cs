// Object ID: 1866184368
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class SystemSettings : UAVDataObject
	{
		public const long OBJID = 1866184368;
		public int NUMBYTES { get; set; }
		protected const String NAME = "SystemSettings";
	    protected static String DESCRIPTION = @"Select airframe type.  Currently used by @ref ActuatorModule to choose mixing from @ref ActuatorDesired to @ref ActuatorCommand";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<UInt32> AirframeCategorySpecificConfiguration;
		public enum AirframeTypeUavEnum
		{
			[Description("FixedWing")]
			FixedWing = 0, 
			[Description("FixedWingElevon")]
			FixedWingElevon = 1, 
			[Description("FixedWingVtail")]
			FixedWingVtail = 2, 
			[Description("VTOL")]
			VTOL = 3, 
			[Description("HeliCP")]
			HeliCP = 4, 
			[Description("QuadX")]
			QuadX = 5, 
			[Description("QuadP")]
			QuadP = 6, 
			[Description("Hexa")]
			Hexa = 7, 
			[Description("Octo")]
			Octo = 8, 
			[Description("Custom")]
			Custom = 9, 
			[Description("HexaX")]
			HexaX = 10, 
			[Description("OctoV")]
			OctoV = 11, 
			[Description("OctoCoaxP")]
			OctoCoaxP = 12, 
			[Description("OctoCoaxX")]
			OctoCoaxX = 13, 
			[Description("HexaCoax")]
			HexaCoax = 14, 
			[Description("Tri")]
			Tri = 15, 
			[Description("GroundVehicleCar")]
			GroundVehicleCar = 16, 
			[Description("GroundVehicleDifferential")]
			GroundVehicleDifferential = 17, 
			[Description("GroundVehicleMotorcycle")]
			GroundVehicleMotorcycle = 18, 
		}
		public UAVObjectField<AirframeTypeUavEnum> AirframeType;

		public SystemSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> AirframeCategorySpecificConfigurationElemNames = new List<String>();
			AirframeCategorySpecificConfigurationElemNames.Add("0");
			AirframeCategorySpecificConfigurationElemNames.Add("1");
			AirframeCategorySpecificConfigurationElemNames.Add("2");
			AirframeCategorySpecificConfigurationElemNames.Add("3");
			AirframeCategorySpecificConfiguration=new UAVObjectField<UInt32>("AirframeCategorySpecificConfiguration", "bits", AirframeCategorySpecificConfigurationElemNames, null, this);
			fields.Add(AirframeCategorySpecificConfiguration);

			List<String> AirframeTypeElemNames = new List<String>();
			AirframeTypeElemNames.Add("0");
			List<String> AirframeTypeEnumOptions = new List<String>();
			AirframeTypeEnumOptions.Add("FixedWing");
			AirframeTypeEnumOptions.Add("FixedWingElevon");
			AirframeTypeEnumOptions.Add("FixedWingVtail");
			AirframeTypeEnumOptions.Add("VTOL");
			AirframeTypeEnumOptions.Add("HeliCP");
			AirframeTypeEnumOptions.Add("QuadX");
			AirframeTypeEnumOptions.Add("QuadP");
			AirframeTypeEnumOptions.Add("Hexa");
			AirframeTypeEnumOptions.Add("Octo");
			AirframeTypeEnumOptions.Add("Custom");
			AirframeTypeEnumOptions.Add("HexaX");
			AirframeTypeEnumOptions.Add("OctoV");
			AirframeTypeEnumOptions.Add("OctoCoaxP");
			AirframeTypeEnumOptions.Add("OctoCoaxX");
			AirframeTypeEnumOptions.Add("HexaCoax");
			AirframeTypeEnumOptions.Add("Tri");
			AirframeTypeEnumOptions.Add("GroundVehicleCar");
			AirframeTypeEnumOptions.Add("GroundVehicleDifferential");
			AirframeTypeEnumOptions.Add("GroundVehicleMotorcycle");
			AirframeType=new UAVObjectField<AirframeTypeUavEnum>("AirframeType", "", AirframeTypeElemNames, AirframeTypeEnumOptions, this);
			fields.Add(AirframeType);

	

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
			AirframeCategorySpecificConfiguration.setValue((UInt32)0,0);
			AirframeCategorySpecificConfiguration.setValue((UInt32)0,1);
			AirframeCategorySpecificConfiguration.setValue((UInt32)0,2);
			AirframeCategorySpecificConfiguration.setValue((UInt32)0,3);
			AirframeType.setValue(AirframeTypeUavEnum.QuadX);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				SystemSettings obj = new SystemSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public SystemSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (SystemSettings)(objMngr.getObject(SystemSettings.OBJID, instID));
		}
	}
}

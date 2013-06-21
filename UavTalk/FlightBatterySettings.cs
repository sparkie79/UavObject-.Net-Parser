// Object ID: 2635022286
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class FlightBatterySettings : UAVDataObject
	{
		public const long OBJID = 2635022286;
		public int NUMBYTES { get; set; }
		protected const String NAME = "FlightBatterySettings";
	    protected static String DESCRIPTION = @"Flight Battery configuration.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<UInt32> Capacity;
		public UAVObjectField<float> VoltageThresholds;
		public UAVObjectField<float> SensorCalibrations;
		public enum TypeUavEnum
		{
			[Description("LiPo")]
			LiPo = 0, 
			[Description("A123")]
			A123 = 1, 
			[Description("LiCo")]
			LiCo = 2, 
			[Description("LiFeSO4")]
			LiFeSO4 = 3, 
			[Description("None")]
			None = 4, 
		}
		public UAVObjectField<TypeUavEnum> Type;
		public UAVObjectField<byte> NbCells;
		public enum SensorTypeUavEnum
		{
			[Description("Disabled")]
			Disabled = 0, 
			[Description("Enabled")]
			Enabled = 1, 
		}
		public UAVObjectField<SensorTypeUavEnum> SensorType;

		public FlightBatterySettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> CapacityElemNames = new List<String>();
			CapacityElemNames.Add("0");
			Capacity=new UAVObjectField<UInt32>("Capacity", "mAh", CapacityElemNames, null, this);
			fields.Add(Capacity);

			List<String> VoltageThresholdsElemNames = new List<String>();
			VoltageThresholdsElemNames.Add("Warning");
			VoltageThresholdsElemNames.Add("Alarm");
			VoltageThresholds=new UAVObjectField<float>("VoltageThresholds", "V", VoltageThresholdsElemNames, null, this);
			fields.Add(VoltageThresholds);

			List<String> SensorCalibrationsElemNames = new List<String>();
			SensorCalibrationsElemNames.Add("VoltageFactor");
			SensorCalibrationsElemNames.Add("CurrentFactor");
			SensorCalibrations=new UAVObjectField<float>("SensorCalibrations", "", SensorCalibrationsElemNames, null, this);
			fields.Add(SensorCalibrations);

			List<String> TypeElemNames = new List<String>();
			TypeElemNames.Add("0");
			List<String> TypeEnumOptions = new List<String>();
			TypeEnumOptions.Add("LiPo");
			TypeEnumOptions.Add("A123");
			TypeEnumOptions.Add("LiCo");
			TypeEnumOptions.Add("LiFeSO4");
			TypeEnumOptions.Add("None");
			Type=new UAVObjectField<TypeUavEnum>("Type", "", TypeElemNames, TypeEnumOptions, this);
			fields.Add(Type);

			List<String> NbCellsElemNames = new List<String>();
			NbCellsElemNames.Add("0");
			NbCells=new UAVObjectField<byte>("NbCells", "", NbCellsElemNames, null, this);
			fields.Add(NbCells);

			List<String> SensorTypeElemNames = new List<String>();
			SensorTypeElemNames.Add("BatteryCurrent");
			SensorTypeElemNames.Add("BatteryVoltage");
			List<String> SensorTypeEnumOptions = new List<String>();
			SensorTypeEnumOptions.Add("Disabled");
			SensorTypeEnumOptions.Add("Enabled");
			SensorType=new UAVObjectField<SensorTypeUavEnum>("SensorType", "", SensorTypeElemNames, SensorTypeEnumOptions, this);
			fields.Add(SensorType);

	

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
			Capacity.setValue((UInt32)2200);
			VoltageThresholds.setValue((float)9.8,0);
			VoltageThresholds.setValue((float)9.2,1);
			SensorCalibrations.setValue((float)1,0);
			SensorCalibrations.setValue((float)1,1);
			Type.setValue(TypeUavEnum.LiPo);
			NbCells.setValue((byte)3);
			SensorType.setValue(SensorTypeUavEnum.Enabled,0);
			SensorType.setValue(SensorTypeUavEnum.Enabled,1);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				FlightBatterySettings obj = new FlightBatterySettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public FlightBatterySettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (FlightBatterySettings)(objMngr.getObject(FlightBatterySettings.OBJID, instID));
		}
	}
}

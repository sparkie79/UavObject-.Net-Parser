// Object ID: 3285829802
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
		public const long OBJID = 3285829802;
		public int NUMBYTES { get; set; }
		protected const String NAME = "FlightBatterySettings";
	    protected static String DESCRIPTION = @"Flight Battery configuration.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<UInt32> Capacity;
		public UAVObjectField<float> CellVoltageThresholds;
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

		public FlightBatterySettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> CapacityElemNames = new List<String>();
			CapacityElemNames.Add("0");
			Capacity=new UAVObjectField<UInt32>("Capacity", "mAh", CapacityElemNames, null, this);
			fields.Add(Capacity);

			List<String> CellVoltageThresholdsElemNames = new List<String>();
			CellVoltageThresholdsElemNames.Add("Warning");
			CellVoltageThresholdsElemNames.Add("Alarm");
			CellVoltageThresholds=new UAVObjectField<float>("CellVoltageThresholds", "V", CellVoltageThresholdsElemNames, null, this);
			fields.Add(CellVoltageThresholds);

			List<String> SensorCalibrationsElemNames = new List<String>();
			SensorCalibrationsElemNames.Add("VoltageFactor");
			SensorCalibrationsElemNames.Add("CurrentFactor");
			SensorCalibrationsElemNames.Add("VoltageZero");
			SensorCalibrationsElemNames.Add("CurrentZero");
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
			CellVoltageThresholds.setValue((float)3.4,0);
			CellVoltageThresholds.setValue((float)3.1,1);
			SensorCalibrations.setValue((float)1,0);
			SensorCalibrations.setValue((float)1,1);
			SensorCalibrations.setValue((float)0,2);
			SensorCalibrations.setValue((float)0,3);
			Type.setValue(TypeUavEnum.LiPo);
			NbCells.setValue((byte)3);
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

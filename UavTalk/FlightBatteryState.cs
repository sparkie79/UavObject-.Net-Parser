// Object ID: 3523753366
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class FlightBatteryState : UAVDataObject
	{
		public const long OBJID = 3523753366;
		public int NUMBYTES { get; set; }
		protected const String NAME = "FlightBatteryState";
	    protected static String DESCRIPTION = @"Battery status information.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> Voltage;
		public UAVObjectField<float> Current;
		public UAVObjectField<float> BoardSupplyVoltage;
		public UAVObjectField<float> PeakCurrent;
		public UAVObjectField<float> AvgCurrent;
		public UAVObjectField<float> ConsumedEnergy;
		public UAVObjectField<float> EstimatedFlightTime;

		public FlightBatteryState() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> VoltageElemNames = new List<String>();
			VoltageElemNames.Add("0");
			Voltage=new UAVObjectField<float>("Voltage", "V", VoltageElemNames, null, this);
			fields.Add(Voltage);

			List<String> CurrentElemNames = new List<String>();
			CurrentElemNames.Add("0");
			Current=new UAVObjectField<float>("Current", "A", CurrentElemNames, null, this);
			fields.Add(Current);

			List<String> BoardSupplyVoltageElemNames = new List<String>();
			BoardSupplyVoltageElemNames.Add("0");
			BoardSupplyVoltage=new UAVObjectField<float>("BoardSupplyVoltage", "V", BoardSupplyVoltageElemNames, null, this);
			fields.Add(BoardSupplyVoltage);

			List<String> PeakCurrentElemNames = new List<String>();
			PeakCurrentElemNames.Add("0");
			PeakCurrent=new UAVObjectField<float>("PeakCurrent", "A", PeakCurrentElemNames, null, this);
			fields.Add(PeakCurrent);

			List<String> AvgCurrentElemNames = new List<String>();
			AvgCurrentElemNames.Add("0");
			AvgCurrent=new UAVObjectField<float>("AvgCurrent", "A", AvgCurrentElemNames, null, this);
			fields.Add(AvgCurrent);

			List<String> ConsumedEnergyElemNames = new List<String>();
			ConsumedEnergyElemNames.Add("0");
			ConsumedEnergy=new UAVObjectField<float>("ConsumedEnergy", "mAh", ConsumedEnergyElemNames, null, this);
			fields.Add(ConsumedEnergy);

			List<String> EstimatedFlightTimeElemNames = new List<String>();
			EstimatedFlightTimeElemNames.Add("0");
			EstimatedFlightTime=new UAVObjectField<float>("EstimatedFlightTime", "sec", EstimatedFlightTimeElemNames, null, this);
			fields.Add(EstimatedFlightTime);

	

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
				(int)AccessMode.ACCESS_READONLY << Metadata.UAVOBJ_ACCESS_SHIFT |
				(int)AccessMode.ACCESS_READONLY << Metadata.UAVOBJ_GCS_ACCESS_SHIFT |
				0 << Metadata.UAVOBJ_TELEMETRY_ACKED_SHIFT |
				0 << Metadata.UAVOBJ_GCS_TELEMETRY_ACKED_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_PERIODIC << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_MANUAL << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
    		metadata.flightTelemetryUpdatePeriod = 50000;
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
			Voltage.setValue((float)0);
			Current.setValue((float)0);
			BoardSupplyVoltage.setValue((float)0);
			PeakCurrent.setValue((float)0);
			AvgCurrent.setValue((float)0);
			ConsumedEnergy.setValue((float)0);
			EstimatedFlightTime.setValue((float)0);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				FlightBatteryState obj = new FlightBatteryState();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public FlightBatteryState GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (FlightBatteryState)(objMngr.getObject(FlightBatteryState.OBJID, instID));
		}
	}
}

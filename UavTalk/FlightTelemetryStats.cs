// Object ID: 796797186
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class FlightTelemetryStats : UAVDataObject
	{
		public const long OBJID = 796797186;
		public int NUMBYTES { get; set; }
		protected const String NAME = "FlightTelemetryStats";
	    protected static String DESCRIPTION = @"Maintains the telemetry statistics from the OpenPilot flight computer.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> TxDataRate;
		public UAVObjectField<float> RxDataRate;
		public UAVObjectField<UInt32> TxFailures;
		public UAVObjectField<UInt32> RxFailures;
		public UAVObjectField<UInt32> TxRetries;
		public enum StatusUavEnum
		{
			[Description("Disconnected")]
			Disconnected = 0, 
			[Description("HandshakeReq")]
			HandshakeReq = 1, 
			[Description("HandshakeAck")]
			HandshakeAck = 2, 
			[Description("Connected")]
			Connected = 3, 
		}
		public UAVObjectField<StatusUavEnum> Status;

		public FlightTelemetryStats() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> TxDataRateElemNames = new List<String>();
			TxDataRateElemNames.Add("0");
			TxDataRate=new UAVObjectField<float>("TxDataRate", "bytes/sec", TxDataRateElemNames, null, this);
			fields.Add(TxDataRate);

			List<String> RxDataRateElemNames = new List<String>();
			RxDataRateElemNames.Add("0");
			RxDataRate=new UAVObjectField<float>("RxDataRate", "bytes/sec", RxDataRateElemNames, null, this);
			fields.Add(RxDataRate);

			List<String> TxFailuresElemNames = new List<String>();
			TxFailuresElemNames.Add("0");
			TxFailures=new UAVObjectField<UInt32>("TxFailures", "count", TxFailuresElemNames, null, this);
			fields.Add(TxFailures);

			List<String> RxFailuresElemNames = new List<String>();
			RxFailuresElemNames.Add("0");
			RxFailures=new UAVObjectField<UInt32>("RxFailures", "count", RxFailuresElemNames, null, this);
			fields.Add(RxFailures);

			List<String> TxRetriesElemNames = new List<String>();
			TxRetriesElemNames.Add("0");
			TxRetries=new UAVObjectField<UInt32>("TxRetries", "count", TxRetriesElemNames, null, this);
			fields.Add(TxRetries);

			List<String> StatusElemNames = new List<String>();
			StatusElemNames.Add("0");
			List<String> StatusEnumOptions = new List<String>();
			StatusEnumOptions.Add("Disconnected");
			StatusEnumOptions.Add("HandshakeReq");
			StatusEnumOptions.Add("HandshakeAck");
			StatusEnumOptions.Add("Connected");
			Status=new UAVObjectField<StatusUavEnum>("Status", "", StatusElemNames, StatusEnumOptions, this);
			fields.Add(Status);

	

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
				0 << Metadata.UAVOBJ_TELEMETRY_ACKED_SHIFT |
				0 << Metadata.UAVOBJ_GCS_TELEMETRY_ACKED_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_PERIODIC << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_MANUAL << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
    		metadata.flightTelemetryUpdatePeriod = 5000;
    		metadata.gcsTelemetryUpdatePeriod = 0;
    		metadata.loggingUpdatePeriod = 5000;
 
			return metadata;
		}

		/**
		 * Initialize object fields with the default values.
		 * If a default value is not specified the object fields
		 * will be initialized to zero.
		 */
		public void setDefaultFieldValues()
		{
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				FlightTelemetryStats obj = new FlightTelemetryStats();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public FlightTelemetryStats GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (FlightTelemetryStats)(objMngr.getObject(FlightTelemetryStats.OBJID, instID));
		}
	}
}

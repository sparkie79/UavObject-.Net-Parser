// Object ID: 3523764140
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class OveroSyncStats : UAVDataObject
	{
		public const long OBJID = 3523764140;
		public int NUMBYTES { get; set; }
		protected const String NAME = "OveroSyncStats";
	    protected static String DESCRIPTION = @"Maintains statistics on transfer rate to and from over";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<UInt32> Send;
		public UAVObjectField<UInt32> Received;
		public UAVObjectField<UInt32> FramesyncErrors;
		public UAVObjectField<UInt32> UnderrunErrors;
		public UAVObjectField<UInt32> DroppedUpdates;
		public UAVObjectField<UInt32> Packets;
		public enum ConnectedUavEnum
		{
			[Description("False")]
			False = 0, 
			[Description("True")]
			True = 1, 
		}
		public UAVObjectField<ConnectedUavEnum> Connected;

		public OveroSyncStats() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> SendElemNames = new List<String>();
			SendElemNames.Add("0");
			Send=new UAVObjectField<UInt32>("Send", "B/s", SendElemNames, null, this);
			fields.Add(Send);

			List<String> ReceivedElemNames = new List<String>();
			ReceivedElemNames.Add("0");
			Received=new UAVObjectField<UInt32>("Received", "B/s", ReceivedElemNames, null, this);
			fields.Add(Received);

			List<String> FramesyncErrorsElemNames = new List<String>();
			FramesyncErrorsElemNames.Add("0");
			FramesyncErrors=new UAVObjectField<UInt32>("FramesyncErrors", "count", FramesyncErrorsElemNames, null, this);
			fields.Add(FramesyncErrors);

			List<String> UnderrunErrorsElemNames = new List<String>();
			UnderrunErrorsElemNames.Add("0");
			UnderrunErrors=new UAVObjectField<UInt32>("UnderrunErrors", "count", UnderrunErrorsElemNames, null, this);
			fields.Add(UnderrunErrors);

			List<String> DroppedUpdatesElemNames = new List<String>();
			DroppedUpdatesElemNames.Add("0");
			DroppedUpdates=new UAVObjectField<UInt32>("DroppedUpdates", "", DroppedUpdatesElemNames, null, this);
			fields.Add(DroppedUpdates);

			List<String> PacketsElemNames = new List<String>();
			PacketsElemNames.Add("0");
			Packets=new UAVObjectField<UInt32>("Packets", "", PacketsElemNames, null, this);
			fields.Add(Packets);

			List<String> ConnectedElemNames = new List<String>();
			ConnectedElemNames.Add("0");
			List<String> ConnectedEnumOptions = new List<String>();
			ConnectedEnumOptions.Add("False");
			ConnectedEnumOptions.Add("True");
			Connected=new UAVObjectField<ConnectedUavEnum>("Connected", "", ConnectedElemNames, ConnectedEnumOptions, this);
			fields.Add(Connected);

	

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
    		metadata.flightTelemetryUpdatePeriod = 1000;
    		metadata.gcsTelemetryUpdatePeriod = 0;
    		metadata.loggingUpdatePeriod = 1000;
 
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
				OveroSyncStats obj = new OveroSyncStats();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public OveroSyncStats GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (OveroSyncStats)(objMngr.getObject(OveroSyncStats.OBJID, instID));
		}
	}
}

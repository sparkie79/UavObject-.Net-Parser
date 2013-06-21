// Object ID: 87182520
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class ActuatorCommand : UAVDataObject
	{
		public const long OBJID = 87182520;
		public int NUMBYTES { get; set; }
		protected const String NAME = "ActuatorCommand";
	    protected static String DESCRIPTION = @"Contains the pulse duration sent to each of the channels.  Set by @ref ActuatorModule";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<Int16> Channel;
		public UAVObjectField<UInt16> MaxUpdateTime;
		public UAVObjectField<byte> UpdateTime;
		public UAVObjectField<byte> NumFailedUpdates;

		public ActuatorCommand() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ChannelElemNames = new List<String>();
			ChannelElemNames.Add("0");
			ChannelElemNames.Add("1");
			ChannelElemNames.Add("2");
			ChannelElemNames.Add("3");
			ChannelElemNames.Add("4");
			ChannelElemNames.Add("5");
			ChannelElemNames.Add("6");
			ChannelElemNames.Add("7");
			ChannelElemNames.Add("8");
			ChannelElemNames.Add("9");
			Channel=new UAVObjectField<Int16>("Channel", "us", ChannelElemNames, null, this);
			fields.Add(Channel);

			List<String> MaxUpdateTimeElemNames = new List<String>();
			MaxUpdateTimeElemNames.Add("0");
			MaxUpdateTime=new UAVObjectField<UInt16>("MaxUpdateTime", "ms", MaxUpdateTimeElemNames, null, this);
			fields.Add(MaxUpdateTime);

			List<String> UpdateTimeElemNames = new List<String>();
			UpdateTimeElemNames.Add("0");
			UpdateTime=new UAVObjectField<byte>("UpdateTime", "ms", UpdateTimeElemNames, null, this);
			fields.Add(UpdateTime);

			List<String> NumFailedUpdatesElemNames = new List<String>();
			NumFailedUpdatesElemNames.Add("0");
			NumFailedUpdates=new UAVObjectField<byte>("NumFailedUpdates", "", NumFailedUpdatesElemNames, null, this);
			fields.Add(NumFailedUpdates);

	

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
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				ActuatorCommand obj = new ActuatorCommand();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public ActuatorCommand GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (ActuatorCommand)(objMngr.getObject(ActuatorCommand.OBJID, instID));
		}
	}
}

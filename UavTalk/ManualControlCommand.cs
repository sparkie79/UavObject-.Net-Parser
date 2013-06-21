// Object ID: 511886034
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class ManualControlCommand : UAVDataObject
	{
		public const long OBJID = 511886034;
		public int NUMBYTES { get; set; }
		protected const String NAME = "ManualControlCommand";
	    protected static String DESCRIPTION = @"The output from the @ref ManualControlModule which descodes the receiver inputs.  Overriden by GCS for fly-by-wire control.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> Throttle;
		public UAVObjectField<float> Roll;
		public UAVObjectField<float> Pitch;
		public UAVObjectField<float> Yaw;
		public UAVObjectField<float> Collective;
		public UAVObjectField<UInt16> Channel;
		public enum ConnectedUavEnum
		{
			[Description("False")]
			False = 0, 
			[Description("True")]
			True = 1, 
		}
		public UAVObjectField<ConnectedUavEnum> Connected;

		public ManualControlCommand() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ThrottleElemNames = new List<String>();
			ThrottleElemNames.Add("0");
			Throttle=new UAVObjectField<float>("Throttle", "%", ThrottleElemNames, null, this);
			fields.Add(Throttle);

			List<String> RollElemNames = new List<String>();
			RollElemNames.Add("0");
			Roll=new UAVObjectField<float>("Roll", "%", RollElemNames, null, this);
			fields.Add(Roll);

			List<String> PitchElemNames = new List<String>();
			PitchElemNames.Add("0");
			Pitch=new UAVObjectField<float>("Pitch", "%", PitchElemNames, null, this);
			fields.Add(Pitch);

			List<String> YawElemNames = new List<String>();
			YawElemNames.Add("0");
			Yaw=new UAVObjectField<float>("Yaw", "%", YawElemNames, null, this);
			fields.Add(Yaw);

			List<String> CollectiveElemNames = new List<String>();
			CollectiveElemNames.Add("0");
			Collective=new UAVObjectField<float>("Collective", "%", CollectiveElemNames, null, this);
			fields.Add(Collective);

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
			Channel=new UAVObjectField<UInt16>("Channel", "us", ChannelElemNames, null, this);
			fields.Add(Channel);

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
    		metadata.flightTelemetryUpdatePeriod = 2000;
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
				ManualControlCommand obj = new ManualControlCommand();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public ManualControlCommand GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (ManualControlCommand)(objMngr.getObject(ManualControlCommand.OBJID, instID));
		}
	}
}

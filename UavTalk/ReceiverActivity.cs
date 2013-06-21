// Object ID: 511464410
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class ReceiverActivity : UAVDataObject
	{
		public const long OBJID = 511464410;
		public int NUMBYTES { get; set; }
		protected const String NAME = "ReceiverActivity";
	    protected static String DESCRIPTION = @"Monitors which receiver channels have been active within the last second.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public enum ActiveGroupUavEnum
		{
			[Description("PWM")]
			PWM = 0, 
			[Description("PPM")]
			PPM = 1, 
			[Description("DSM (MainPort)")]
			DSMMainPort = 2, 
			[Description("DSM (FlexiPort)")]
			DSMFlexiPort = 3, 
			[Description("S.Bus")]
			SBus = 4, 
			[Description("GCS")]
			GCS = 5, 
			[Description("None")]
			None = 6, 
		}
		public UAVObjectField<ActiveGroupUavEnum> ActiveGroup;
		public UAVObjectField<byte> ActiveChannel;

		public ReceiverActivity() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ActiveGroupElemNames = new List<String>();
			ActiveGroupElemNames.Add("0");
			List<String> ActiveGroupEnumOptions = new List<String>();
			ActiveGroupEnumOptions.Add("PWM");
			ActiveGroupEnumOptions.Add("PPM");
			ActiveGroupEnumOptions.Add("DSM (MainPort)");
			ActiveGroupEnumOptions.Add("DSM (FlexiPort)");
			ActiveGroupEnumOptions.Add("S.Bus");
			ActiveGroupEnumOptions.Add("GCS");
			ActiveGroupEnumOptions.Add("None");
			ActiveGroup=new UAVObjectField<ActiveGroupUavEnum>("ActiveGroup", "Channel Group", ActiveGroupElemNames, ActiveGroupEnumOptions, this);
			fields.Add(ActiveGroup);

			List<String> ActiveChannelElemNames = new List<String>();
			ActiveChannelElemNames.Add("0");
			ActiveChannel=new UAVObjectField<byte>("ActiveChannel", "channel", ActiveChannelElemNames, null, this);
			fields.Add(ActiveChannel);

	

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
				(int)UPDATEMODE.UPDATEMODE_ONCHANGE << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_MANUAL << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
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
			ActiveGroup.setValue(ActiveGroupUavEnum.None);
			ActiveChannel.setValue((byte)255);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				ReceiverActivity obj = new ReceiverActivity();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public ReceiverActivity GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (ReceiverActivity)(objMngr.getObject(ReceiverActivity.OBJID, instID));
		}
	}
}

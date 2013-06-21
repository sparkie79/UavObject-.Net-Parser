// Object ID: 1407447424
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class FlightPlanControl : UAVDataObject
	{
		public const long OBJID = 1407447424;
		public int NUMBYTES { get; set; }
		protected const String NAME = "FlightPlanControl";
	    protected static String DESCRIPTION = @"Control the flight plan script";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public enum CommandUavEnum
		{
			[Description("Start")]
			Start = 0, 
			[Description("Stop")]
			Stop = 1, 
			[Description("Kill")]
			Kill = 2, 
		}
		public UAVObjectField<CommandUavEnum> Command;

		public FlightPlanControl() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> CommandElemNames = new List<String>();
			CommandElemNames.Add("0");
			List<String> CommandEnumOptions = new List<String>();
			CommandEnumOptions.Add("Start");
			CommandEnumOptions.Add("Stop");
			CommandEnumOptions.Add("Kill");
			Command=new UAVObjectField<CommandUavEnum>("Command", "", CommandElemNames, CommandEnumOptions, this);
			fields.Add(Command);

	

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
				(int)UPDATEMODE.UPDATEMODE_MANUAL << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
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
			Command.setValue(CommandUavEnum.Start);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				FlightPlanControl obj = new FlightPlanControl();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public FlightPlanControl GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (FlightPlanControl)(objMngr.getObject(FlightPlanControl.OBJID, instID));
		}
	}
}

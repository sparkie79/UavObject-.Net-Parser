// Object ID: 4142817726
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class RelayTuning : UAVDataObject
	{
		public const long OBJID = 4142817726;
		public int NUMBYTES { get; set; }
		protected const String NAME = "RelayTuning";
	    protected static String DESCRIPTION = @"The input to the relay tuning.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> Period;
		public UAVObjectField<float> Gain;

		public RelayTuning() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> PeriodElemNames = new List<String>();
			PeriodElemNames.Add("Roll");
			PeriodElemNames.Add("Pitch");
			PeriodElemNames.Add("Yaw");
			Period=new UAVObjectField<float>("Period", "ms", PeriodElemNames, null, this);
			fields.Add(Period);

			List<String> GainElemNames = new List<String>();
			GainElemNames.Add("Roll");
			GainElemNames.Add("Pitch");
			GainElemNames.Add("Yaw");
			Gain=new UAVObjectField<float>("Gain", "(deg/s)/output", GainElemNames, null, this);
			fields.Add(Gain);

	

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
				RelayTuning obj = new RelayTuning();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public RelayTuning GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (RelayTuning)(objMngr.getObject(RelayTuning.OBJID, instID));
		}
	}
}

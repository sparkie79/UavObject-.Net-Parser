// Object ID: 19194506
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class MixerStatus : UAVDataObject
	{
		public const long OBJID = 19194506;
		public int NUMBYTES { get; set; }
		protected const String NAME = "MixerStatus";
	    protected static String DESCRIPTION = @"Status for the matrix mixer showing the output of each mixer after all scaling";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> Mixer1;
		public UAVObjectField<float> Mixer2;
		public UAVObjectField<float> Mixer3;
		public UAVObjectField<float> Mixer4;
		public UAVObjectField<float> Mixer5;
		public UAVObjectField<float> Mixer6;
		public UAVObjectField<float> Mixer7;
		public UAVObjectField<float> Mixer8;
		public UAVObjectField<float> Mixer9;
		public UAVObjectField<float> Mixer10;

		public MixerStatus() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> Mixer1ElemNames = new List<String>();
			Mixer1ElemNames.Add("0");
			Mixer1=new UAVObjectField<float>("Mixer1", "", Mixer1ElemNames, null, this);
			fields.Add(Mixer1);

			List<String> Mixer2ElemNames = new List<String>();
			Mixer2ElemNames.Add("0");
			Mixer2=new UAVObjectField<float>("Mixer2", "", Mixer2ElemNames, null, this);
			fields.Add(Mixer2);

			List<String> Mixer3ElemNames = new List<String>();
			Mixer3ElemNames.Add("0");
			Mixer3=new UAVObjectField<float>("Mixer3", "", Mixer3ElemNames, null, this);
			fields.Add(Mixer3);

			List<String> Mixer4ElemNames = new List<String>();
			Mixer4ElemNames.Add("0");
			Mixer4=new UAVObjectField<float>("Mixer4", "", Mixer4ElemNames, null, this);
			fields.Add(Mixer4);

			List<String> Mixer5ElemNames = new List<String>();
			Mixer5ElemNames.Add("0");
			Mixer5=new UAVObjectField<float>("Mixer5", "", Mixer5ElemNames, null, this);
			fields.Add(Mixer5);

			List<String> Mixer6ElemNames = new List<String>();
			Mixer6ElemNames.Add("0");
			Mixer6=new UAVObjectField<float>("Mixer6", "", Mixer6ElemNames, null, this);
			fields.Add(Mixer6);

			List<String> Mixer7ElemNames = new List<String>();
			Mixer7ElemNames.Add("0");
			Mixer7=new UAVObjectField<float>("Mixer7", "", Mixer7ElemNames, null, this);
			fields.Add(Mixer7);

			List<String> Mixer8ElemNames = new List<String>();
			Mixer8ElemNames.Add("0");
			Mixer8=new UAVObjectField<float>("Mixer8", "", Mixer8ElemNames, null, this);
			fields.Add(Mixer8);

			List<String> Mixer9ElemNames = new List<String>();
			Mixer9ElemNames.Add("0");
			Mixer9=new UAVObjectField<float>("Mixer9", "", Mixer9ElemNames, null, this);
			fields.Add(Mixer9);

			List<String> Mixer10ElemNames = new List<String>();
			Mixer10ElemNames.Add("0");
			Mixer10=new UAVObjectField<float>("Mixer10", "", Mixer10ElemNames, null, this);
			fields.Add(Mixer10);

	

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
				MixerStatus obj = new MixerStatus();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public MixerStatus GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (MixerStatus)(objMngr.getObject(MixerStatus.OBJID, instID));
		}
	}
}

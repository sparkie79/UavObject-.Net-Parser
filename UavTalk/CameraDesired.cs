// Object ID: 1681920078
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class CameraDesired : UAVDataObject
	{
		public const long OBJID = 1681920078;
		public int NUMBYTES { get; set; }
		protected const String NAME = "CameraDesired";
	    protected static String DESCRIPTION = @"Desired camera outputs.  Comes from @ref CameraStabilization module.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> RollOrServo1;
		public UAVObjectField<float> PitchOrServo2;
		public UAVObjectField<float> Yaw;

		public CameraDesired() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> RollOrServo1ElemNames = new List<String>();
			RollOrServo1ElemNames.Add("0");
			RollOrServo1=new UAVObjectField<float>("RollOrServo1", "", RollOrServo1ElemNames, null, this);
			fields.Add(RollOrServo1);

			List<String> PitchOrServo2ElemNames = new List<String>();
			PitchOrServo2ElemNames.Add("0");
			PitchOrServo2=new UAVObjectField<float>("PitchOrServo2", "", PitchOrServo2ElemNames, null, this);
			fields.Add(PitchOrServo2);

			List<String> YawElemNames = new List<String>();
			YawElemNames.Add("0");
			Yaw=new UAVObjectField<float>("Yaw", "", YawElemNames, null, this);
			fields.Add(Yaw);

	

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
				CameraDesired obj = new CameraDesired();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public CameraDesired GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (CameraDesired)(objMngr.getObject(CameraDesired.OBJID, instID));
		}
	}
}

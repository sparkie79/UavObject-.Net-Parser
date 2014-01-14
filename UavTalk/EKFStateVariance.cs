// Object ID: 515081700
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class EKFStateVariance : UAVDataObject
	{
		public const long OBJID = 515081700;
		public int NUMBYTES { get; set; }
		protected const String NAME = "EKFStateVariance";
	    protected static String DESCRIPTION = @"Extended Kalman Filter state covariance";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> P;

		public EKFStateVariance() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> PElemNames = new List<String>();
			PElemNames.Add("PositionNorth");
			PElemNames.Add("PositionEast");
			PElemNames.Add("PositionDown");
			PElemNames.Add("VelocityNorth");
			PElemNames.Add("VelocityEast");
			PElemNames.Add("VelocityDown");
			PElemNames.Add("AttitudeQ1");
			PElemNames.Add("AttitudeQ2");
			PElemNames.Add("AttitudeQ3");
			PElemNames.Add("AttitudeQ4");
			PElemNames.Add("GyroDriftX");
			PElemNames.Add("GyroDriftY");
			PElemNames.Add("GyroDriftZ");
			P=new UAVObjectField<float>("P", "1^2", PElemNames, null, this);
			fields.Add(P);

	

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
    		metadata.flightTelemetryUpdatePeriod = 10000;
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
				EKFStateVariance obj = new EKFStateVariance();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public EKFStateVariance GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (EKFStateVariance)(objMngr.getObject(EKFStateVariance.OBJID, instID));
		}
	}
}

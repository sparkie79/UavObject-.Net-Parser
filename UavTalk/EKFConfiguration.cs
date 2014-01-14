// Object ID: 1586569532
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class EKFConfiguration : UAVDataObject
	{
		public const long OBJID = 1586569532;
		public int NUMBYTES { get; set; }
		protected const String NAME = "EKFConfiguration";
	    protected static String DESCRIPTION = @"Extended Kalman Filter initialisation";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> P;
		public UAVObjectField<float> Q;
		public UAVObjectField<float> R;
		public UAVObjectField<float> FakeR;

		public EKFConfiguration() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
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

			List<String> QElemNames = new List<String>();
			QElemNames.Add("GyroX");
			QElemNames.Add("GyroY");
			QElemNames.Add("GyroZ");
			QElemNames.Add("AccelX");
			QElemNames.Add("AccelY");
			QElemNames.Add("AccelZ");
			QElemNames.Add("GyroDriftX");
			QElemNames.Add("GyroDriftY");
			QElemNames.Add("GyroDriftZ");
			Q=new UAVObjectField<float>("Q", "1^2", QElemNames, null, this);
			fields.Add(Q);

			List<String> RElemNames = new List<String>();
			RElemNames.Add("GPSPosNorth");
			RElemNames.Add("GPSPosEast");
			RElemNames.Add("GPSPosDown");
			RElemNames.Add("GPSVelNorth");
			RElemNames.Add("GPSVelEast");
			RElemNames.Add("GPSVelDown");
			RElemNames.Add("MagX");
			RElemNames.Add("MagY");
			RElemNames.Add("MagZ");
			RElemNames.Add("BaroZ");
			R=new UAVObjectField<float>("R", "1^2", RElemNames, null, this);
			fields.Add(R);

			List<String> FakeRElemNames = new List<String>();
			FakeRElemNames.Add("FakeGPSPosIndoor");
			FakeRElemNames.Add("FakeGPSVelIndoor");
			FakeRElemNames.Add("FakeGPSVelAirspeed");
			FakeR=new UAVObjectField<float>("FakeR", "1^2", FakeRElemNames, null, this);
			fields.Add(FakeR);

	

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
				(int)UPDATEMODE.UPDATEMODE_ONCHANGE << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_ONCHANGE << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
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
			P.setValue((float)10,0);
			P.setValue((float)10,1);
			P.setValue((float)10,2);
			P.setValue((float)1,3);
			P.setValue((float)1,4);
			P.setValue((float)1,5);
			P.setValue((float)0.007,6);
			P.setValue((float)0.007,7);
			P.setValue((float)0.007,8);
			P.setValue((float)0.007,9);
			P.setValue((float)0.0001,10);
			P.setValue((float)0.0001,11);
			P.setValue((float)0.0001,12);
			Q.setValue((float)0.01,0);
			Q.setValue((float)0.01,1);
			Q.setValue((float)0.01,2);
			Q.setValue((float)0.1,3);
			Q.setValue((float)0.1,4);
			Q.setValue((float)0.1,5);
			Q.setValue((float)1E-07,6);
			Q.setValue((float)1E-07,7);
			Q.setValue((float)1E-07,8);
			R.setValue((float)10,0);
			R.setValue((float)10,1);
			R.setValue((float)1000,2);
			R.setValue((float)1,3);
			R.setValue((float)1,4);
			R.setValue((float)1,5);
			R.setValue((float)5000,6);
			R.setValue((float)5000,7);
			R.setValue((float)5000,8);
			R.setValue((float)1,9);
			FakeR.setValue((float)10,0);
			FakeR.setValue((float)1,1);
			FakeR.setValue((float)1000,2);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				EKFConfiguration obj = new EKFConfiguration();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public EKFConfiguration GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (EKFConfiguration)(objMngr.getObject(EKFConfiguration.OBJID, instID));
		}
	}
}

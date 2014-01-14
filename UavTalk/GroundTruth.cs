// Object ID: 4051229864
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class GroundTruth : UAVDataObject
	{
		public const long OBJID = 4051229864;
		public int NUMBYTES { get; set; }
		protected const String NAME = "GroundTruth";
	    protected static String DESCRIPTION = @"Ground truth data output by a simulator.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> AccelerationXYZ;
		public UAVObjectField<float> PositionNED;
		public UAVObjectField<float> VelocityNED;
		public UAVObjectField<float> RPY;
		public UAVObjectField<float> AngularRates;
		public UAVObjectField<float> TrueAirspeed;
		public UAVObjectField<float> CalibratedAirspeed;
		public UAVObjectField<float> AngleOfAttack;
		public UAVObjectField<float> AngleOfSlip;

		public GroundTruth() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> AccelerationXYZElemNames = new List<String>();
			AccelerationXYZElemNames.Add("0");
			AccelerationXYZElemNames.Add("1");
			AccelerationXYZElemNames.Add("2");
			AccelerationXYZ=new UAVObjectField<float>("AccelerationXYZ", "m/s^2", AccelerationXYZElemNames, null, this);
			fields.Add(AccelerationXYZ);

			List<String> PositionNEDElemNames = new List<String>();
			PositionNEDElemNames.Add("0");
			PositionNEDElemNames.Add("1");
			PositionNEDElemNames.Add("2");
			PositionNED=new UAVObjectField<float>("PositionNED", "m", PositionNEDElemNames, null, this);
			fields.Add(PositionNED);

			List<String> VelocityNEDElemNames = new List<String>();
			VelocityNEDElemNames.Add("0");
			VelocityNEDElemNames.Add("1");
			VelocityNEDElemNames.Add("2");
			VelocityNED=new UAVObjectField<float>("VelocityNED", "m/s", VelocityNEDElemNames, null, this);
			fields.Add(VelocityNED);

			List<String> RPYElemNames = new List<String>();
			RPYElemNames.Add("0");
			RPYElemNames.Add("1");
			RPYElemNames.Add("2");
			RPY=new UAVObjectField<float>("RPY", "deg", RPYElemNames, null, this);
			fields.Add(RPY);

			List<String> AngularRatesElemNames = new List<String>();
			AngularRatesElemNames.Add("0");
			AngularRatesElemNames.Add("1");
			AngularRatesElemNames.Add("2");
			AngularRates=new UAVObjectField<float>("AngularRates", "deg/s", AngularRatesElemNames, null, this);
			fields.Add(AngularRates);

			List<String> TrueAirspeedElemNames = new List<String>();
			TrueAirspeedElemNames.Add("0");
			TrueAirspeed=new UAVObjectField<float>("TrueAirspeed", "m/s", TrueAirspeedElemNames, null, this);
			fields.Add(TrueAirspeed);

			List<String> CalibratedAirspeedElemNames = new List<String>();
			CalibratedAirspeedElemNames.Add("0");
			CalibratedAirspeed=new UAVObjectField<float>("CalibratedAirspeed", "m/s", CalibratedAirspeedElemNames, null, this);
			fields.Add(CalibratedAirspeed);

			List<String> AngleOfAttackElemNames = new List<String>();
			AngleOfAttackElemNames.Add("0");
			AngleOfAttack=new UAVObjectField<float>("AngleOfAttack", "deg", AngleOfAttackElemNames, null, this);
			fields.Add(AngleOfAttack);

			List<String> AngleOfSlipElemNames = new List<String>();
			AngleOfSlipElemNames.Add("0");
			AngleOfSlip=new UAVObjectField<float>("AngleOfSlip", "deg", AngleOfSlipElemNames, null, this);
			fields.Add(AngleOfSlip);

	

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
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				GroundTruth obj = new GroundTruth();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public GroundTruth GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (GroundTruth)(objMngr.getObject(GroundTruth.OBJID, instID));
		}
	}
}

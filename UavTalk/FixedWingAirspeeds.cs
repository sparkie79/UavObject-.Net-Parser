// Object ID: 66910198
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class FixedWingAirspeeds : UAVDataObject
	{
		public const long OBJID = 66910198;
		public int NUMBYTES { get; set; }
		protected const String NAME = "FixedWingAirspeeds";
	    protected static String DESCRIPTION = @"Settings for the @ref FixedWingPathFollowerModule";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> AirSpeedMax;
		public UAVObjectField<float> CruiseSpeed;
		public UAVObjectField<float> BestClimbRateSpeed;
		public UAVObjectField<float> StallSpeedClean;
		public UAVObjectField<float> StallSpeedDirty;
		public UAVObjectField<float> VerticalVelMax;

		public FixedWingAirspeeds() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> AirSpeedMaxElemNames = new List<String>();
			AirSpeedMaxElemNames.Add("0");
			AirSpeedMax=new UAVObjectField<float>("AirSpeedMax", "m/s", AirSpeedMaxElemNames, null, this);
			fields.Add(AirSpeedMax);

			List<String> CruiseSpeedElemNames = new List<String>();
			CruiseSpeedElemNames.Add("0");
			CruiseSpeed=new UAVObjectField<float>("CruiseSpeed", "m/s", CruiseSpeedElemNames, null, this);
			fields.Add(CruiseSpeed);

			List<String> BestClimbRateSpeedElemNames = new List<String>();
			BestClimbRateSpeedElemNames.Add("0");
			BestClimbRateSpeed=new UAVObjectField<float>("BestClimbRateSpeed", "m/s", BestClimbRateSpeedElemNames, null, this);
			fields.Add(BestClimbRateSpeed);

			List<String> StallSpeedCleanElemNames = new List<String>();
			StallSpeedCleanElemNames.Add("0");
			StallSpeedClean=new UAVObjectField<float>("StallSpeedClean", "m/s", StallSpeedCleanElemNames, null, this);
			fields.Add(StallSpeedClean);

			List<String> StallSpeedDirtyElemNames = new List<String>();
			StallSpeedDirtyElemNames.Add("0");
			StallSpeedDirty=new UAVObjectField<float>("StallSpeedDirty", "m/s", StallSpeedDirtyElemNames, null, this);
			fields.Add(StallSpeedDirty);

			List<String> VerticalVelMaxElemNames = new List<String>();
			VerticalVelMaxElemNames.Add("0");
			VerticalVelMax=new UAVObjectField<float>("VerticalVelMax", "m/s", VerticalVelMaxElemNames, null, this);
			fields.Add(VerticalVelMax);

	

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
			AirSpeedMax.setValue((float)20);
			CruiseSpeed.setValue((float)15);
			BestClimbRateSpeed.setValue((float)11);
			StallSpeedClean.setValue((float)8);
			StallSpeedDirty.setValue((float)8);
			VerticalVelMax.setValue((float)10);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				FixedWingAirspeeds obj = new FixedWingAirspeeds();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public FixedWingAirspeeds GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (FixedWingAirspeeds)(objMngr.getObject(FixedWingAirspeeds.OBJID, instID));
		}
	}
}

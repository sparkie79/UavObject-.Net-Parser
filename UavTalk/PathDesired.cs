// Object ID: 3515296630
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class PathDesired : UAVDataObject
	{
		public const long OBJID = 3515296630;
		public int NUMBYTES { get; set; }
		protected const String NAME = "PathDesired";
	    protected static String DESCRIPTION = @"The endpoint or path the craft is trying to achieve.  Can come from @ref ManualControl or @ref PathPlanner ";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> Start;
		public UAVObjectField<float> End;
		public UAVObjectField<float> StartingVelocity;
		public UAVObjectField<float> EndingVelocity;
		public UAVObjectField<float> ModeParameters;
		public UAVObjectField<Int16> UID;
		public enum ModeUavEnum
		{
			[Description("FlyEndpoint")]
			FlyEndpoint = 0, 
			[Description("FlyVector")]
			FlyVector = 1, 
			[Description("FlyCircleRight")]
			FlyCircleRight = 2, 
			[Description("FlyCircleLeft")]
			FlyCircleLeft = 3, 
			[Description("DriveEndpoint")]
			DriveEndpoint = 4, 
			[Description("DriveVector")]
			DriveVector = 5, 
			[Description("DriveCircleLeft")]
			DriveCircleLeft = 6, 
			[Description("DriveCircleRight")]
			DriveCircleRight = 7, 
			[Description("FixedAttitude")]
			FixedAttitude = 8, 
			[Description("SetAccessory")]
			SetAccessory = 9, 
			[Description("Land")]
			Land = 10, 
			[Description("DisarmAlarm")]
			DisarmAlarm = 11, 
		}
		public UAVObjectField<ModeUavEnum> Mode;

		public PathDesired() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> StartElemNames = new List<String>();
			StartElemNames.Add("North");
			StartElemNames.Add("East");
			StartElemNames.Add("Down");
			Start=new UAVObjectField<float>("Start", "m", StartElemNames, null, this);
			fields.Add(Start);

			List<String> EndElemNames = new List<String>();
			EndElemNames.Add("North");
			EndElemNames.Add("East");
			EndElemNames.Add("Down");
			End=new UAVObjectField<float>("End", "m", EndElemNames, null, this);
			fields.Add(End);

			List<String> StartingVelocityElemNames = new List<String>();
			StartingVelocityElemNames.Add("0");
			StartingVelocity=new UAVObjectField<float>("StartingVelocity", "m/s", StartingVelocityElemNames, null, this);
			fields.Add(StartingVelocity);

			List<String> EndingVelocityElemNames = new List<String>();
			EndingVelocityElemNames.Add("0");
			EndingVelocity=new UAVObjectField<float>("EndingVelocity", "m/s", EndingVelocityElemNames, null, this);
			fields.Add(EndingVelocity);

			List<String> ModeParametersElemNames = new List<String>();
			ModeParametersElemNames.Add("0");
			ModeParametersElemNames.Add("1");
			ModeParametersElemNames.Add("2");
			ModeParametersElemNames.Add("3");
			ModeParameters=new UAVObjectField<float>("ModeParameters", "", ModeParametersElemNames, null, this);
			fields.Add(ModeParameters);

			List<String> UIDElemNames = new List<String>();
			UIDElemNames.Add("0");
			UID=new UAVObjectField<Int16>("UID", "", UIDElemNames, null, this);
			fields.Add(UID);

			List<String> ModeElemNames = new List<String>();
			ModeElemNames.Add("0");
			List<String> ModeEnumOptions = new List<String>();
			ModeEnumOptions.Add("FlyEndpoint");
			ModeEnumOptions.Add("FlyVector");
			ModeEnumOptions.Add("FlyCircleRight");
			ModeEnumOptions.Add("FlyCircleLeft");
			ModeEnumOptions.Add("DriveEndpoint");
			ModeEnumOptions.Add("DriveVector");
			ModeEnumOptions.Add("DriveCircleLeft");
			ModeEnumOptions.Add("DriveCircleRight");
			ModeEnumOptions.Add("FixedAttitude");
			ModeEnumOptions.Add("SetAccessory");
			ModeEnumOptions.Add("Land");
			ModeEnumOptions.Add("DisarmAlarm");
			Mode=new UAVObjectField<ModeUavEnum>("Mode", "", ModeElemNames, ModeEnumOptions, this);
			fields.Add(Mode);

	

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
				(int)UPDATEMODE.UPDATEMODE_ONCHANGE << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
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
				PathDesired obj = new PathDesired();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public PathDesired GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (PathDesired)(objMngr.getObject(PathDesired.OBJID, instID));
		}
	}
}

// Object ID: 611492014
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class PathAction : UAVDataObject
	{
		public const long OBJID = 611492014;
		public int NUMBYTES { get; set; }
		protected const String NAME = "PathAction";
	    protected static String DESCRIPTION = @"A waypoint command the pathplanner is to use at a certain waypoint";
		protected const bool ISSINGLEINST = false;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> ModeParameters;
		public UAVObjectField<float> ConditionParameters;
		public UAVObjectField<Int16> JumpDestination;
		public UAVObjectField<Int16> ErrorDestination;
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
			[Description("DisarmAlarm")]
			DisarmAlarm = 10, 
		}
		public UAVObjectField<ModeUavEnum> Mode;
		public enum EndConditionUavEnum
		{
			[Description("None")]
			None = 0, 
			[Description("TimeOut")]
			TimeOut = 1, 
			[Description("DistanceToTarget")]
			DistanceToTarget = 2, 
			[Description("LegRemaining")]
			LegRemaining = 3, 
			[Description("BelowError")]
			BelowError = 4, 
			[Description("AboveAltitude")]
			AboveAltitude = 5, 
			[Description("AboveSpeed")]
			AboveSpeed = 6, 
			[Description("PointingTowardsNext")]
			PointingTowardsNext = 7, 
			[Description("PythonScript")]
			PythonScript = 8, 
			[Description("Immediate")]
			Immediate = 9, 
		}
		public UAVObjectField<EndConditionUavEnum> EndCondition;
		public enum CommandUavEnum
		{
			[Description("OnConditionNextWaypoint")]
			OnConditionNextWaypoint = 0, 
			[Description("OnNotConditionNextWaypoint")]
			OnNotConditionNextWaypoint = 1, 
			[Description("OnConditionJumpWaypoint")]
			OnConditionJumpWaypoint = 2, 
			[Description("OnNotConditionJumpWaypoint")]
			OnNotConditionJumpWaypoint = 3, 
			[Description("IfConditionJumpWaypointElseNextWaypoint")]
			IfConditionJumpWaypointElseNextWaypoint = 4, 
		}
		public UAVObjectField<CommandUavEnum> Command;

		public PathAction() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ModeParametersElemNames = new List<String>();
			ModeParametersElemNames.Add("0");
			ModeParametersElemNames.Add("1");
			ModeParametersElemNames.Add("2");
			ModeParametersElemNames.Add("3");
			ModeParameters=new UAVObjectField<float>("ModeParameters", "", ModeParametersElemNames, null, this);
			fields.Add(ModeParameters);

			List<String> ConditionParametersElemNames = new List<String>();
			ConditionParametersElemNames.Add("0");
			ConditionParametersElemNames.Add("1");
			ConditionParametersElemNames.Add("2");
			ConditionParametersElemNames.Add("3");
			ConditionParameters=new UAVObjectField<float>("ConditionParameters", "", ConditionParametersElemNames, null, this);
			fields.Add(ConditionParameters);

			List<String> JumpDestinationElemNames = new List<String>();
			JumpDestinationElemNames.Add("0");
			JumpDestination=new UAVObjectField<Int16>("JumpDestination", "waypoint", JumpDestinationElemNames, null, this);
			fields.Add(JumpDestination);

			List<String> ErrorDestinationElemNames = new List<String>();
			ErrorDestinationElemNames.Add("0");
			ErrorDestination=new UAVObjectField<Int16>("ErrorDestination", "waypoint", ErrorDestinationElemNames, null, this);
			fields.Add(ErrorDestination);

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
			ModeEnumOptions.Add("DisarmAlarm");
			Mode=new UAVObjectField<ModeUavEnum>("Mode", "", ModeElemNames, ModeEnumOptions, this);
			fields.Add(Mode);

			List<String> EndConditionElemNames = new List<String>();
			EndConditionElemNames.Add("0");
			List<String> EndConditionEnumOptions = new List<String>();
			EndConditionEnumOptions.Add("None");
			EndConditionEnumOptions.Add("TimeOut");
			EndConditionEnumOptions.Add("DistanceToTarget");
			EndConditionEnumOptions.Add("LegRemaining");
			EndConditionEnumOptions.Add("BelowError");
			EndConditionEnumOptions.Add("AboveAltitude");
			EndConditionEnumOptions.Add("AboveSpeed");
			EndConditionEnumOptions.Add("PointingTowardsNext");
			EndConditionEnumOptions.Add("PythonScript");
			EndConditionEnumOptions.Add("Immediate");
			EndCondition=new UAVObjectField<EndConditionUavEnum>("EndCondition", "", EndConditionElemNames, EndConditionEnumOptions, this);
			fields.Add(EndCondition);

			List<String> CommandElemNames = new List<String>();
			CommandElemNames.Add("0");
			List<String> CommandEnumOptions = new List<String>();
			CommandEnumOptions.Add("OnConditionNextWaypoint");
			CommandEnumOptions.Add("OnNotConditionNextWaypoint");
			CommandEnumOptions.Add("OnConditionJumpWaypoint");
			CommandEnumOptions.Add("OnNotConditionJumpWaypoint");
			CommandEnumOptions.Add("IfConditionJumpWaypointElseNextWaypoint");
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
				0 << Metadata.UAVOBJ_TELEMETRY_ACKED_SHIFT |
				1 << Metadata.UAVOBJ_GCS_TELEMETRY_ACKED_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_PERIODIC << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_MANUAL << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
    		metadata.flightTelemetryUpdatePeriod = 4000;
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
				PathAction obj = new PathAction();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public PathAction GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (PathAction)(objMngr.getObject(PathAction.OBJID, instID));
		}
	}
}

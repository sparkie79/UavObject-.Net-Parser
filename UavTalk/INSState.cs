// Object ID: 2922806822
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class INSState : UAVDataObject
	{
		public const long OBJID = 2922806822;
		public int NUMBYTES { get; set; }
		protected const String NAME = "INSState";
	    protected static String DESCRIPTION = @"Contains the INS state estimate";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> State;
		public UAVObjectField<float> Var;

		public INSState() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> StateElemNames = new List<String>();
			StateElemNames.Add("0");
			StateElemNames.Add("1");
			StateElemNames.Add("2");
			StateElemNames.Add("3");
			StateElemNames.Add("4");
			StateElemNames.Add("5");
			StateElemNames.Add("6");
			StateElemNames.Add("7");
			StateElemNames.Add("8");
			StateElemNames.Add("9");
			StateElemNames.Add("10");
			StateElemNames.Add("11");
			StateElemNames.Add("12");
			State=new UAVObjectField<float>("State", "", StateElemNames, null, this);
			fields.Add(State);

			List<String> VarElemNames = new List<String>();
			VarElemNames.Add("0");
			VarElemNames.Add("1");
			VarElemNames.Add("2");
			VarElemNames.Add("3");
			VarElemNames.Add("4");
			VarElemNames.Add("5");
			VarElemNames.Add("6");
			VarElemNames.Add("7");
			VarElemNames.Add("8");
			VarElemNames.Add("9");
			VarElemNames.Add("10");
			VarElemNames.Add("11");
			VarElemNames.Add("12");
			Var=new UAVObjectField<float>("Var", "", VarElemNames, null, this);
			fields.Add(Var);

	

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
				INSState obj = new INSState();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public INSState GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (INSState)(objMngr.getObject(INSState.OBJID, instID));
		}
	}
}

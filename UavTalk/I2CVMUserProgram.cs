// Object ID: 3986473388
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class I2CVMUserProgram : UAVDataObject
	{
		public const long OBJID = 3986473388;
		public int NUMBYTES { get; set; }
		protected const String NAME = "I2CVMUserProgram";
	    protected static String DESCRIPTION = @"Allows GCS to provide a user-defined program to the I2C Virtual Machine";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<UInt32> Program;

		public I2CVMUserProgram() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ProgramElemNames = new List<String>();
			ProgramElemNames.Add("0");
			ProgramElemNames.Add("1");
			ProgramElemNames.Add("2");
			ProgramElemNames.Add("3");
			ProgramElemNames.Add("4");
			ProgramElemNames.Add("5");
			ProgramElemNames.Add("6");
			ProgramElemNames.Add("7");
			ProgramElemNames.Add("8");
			ProgramElemNames.Add("9");
			ProgramElemNames.Add("10");
			ProgramElemNames.Add("11");
			ProgramElemNames.Add("12");
			ProgramElemNames.Add("13");
			ProgramElemNames.Add("14");
			ProgramElemNames.Add("15");
			ProgramElemNames.Add("16");
			ProgramElemNames.Add("17");
			ProgramElemNames.Add("18");
			ProgramElemNames.Add("19");
			Program=new UAVObjectField<UInt32>("Program", "", ProgramElemNames, null, this);
			fields.Add(Program);

	

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
			Program.setValue((UInt32)134676490,0);
			Program.setValue((UInt32)84541440,1);
			Program.setValue((UInt32)84607232,2);
			Program.setValue((UInt32)84673024,3);
			Program.setValue((UInt32)84738816,4);
			Program.setValue((UInt32)117441025,5);
			Program.setValue((UInt32)117441282,6);
			Program.setValue((UInt32)117441539,7);
			Program.setValue((UInt32)100663812,8);
			Program.setValue((UInt32)100664069,9);
			Program.setValue((UInt32)100664326,10);
			Program.setValue((UInt32)385875968,11);
			Program.setValue((UInt32)168296447,12);
			Program.setValue((UInt32)33554452,13);
			Program.setValue((UInt32)50855927,14);
			Program.setValue((UInt32)0,15);
			Program.setValue((UInt32)0,16);
			Program.setValue((UInt32)0,17);
			Program.setValue((UInt32)0,18);
			Program.setValue((UInt32)0,19);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				I2CVMUserProgram obj = new I2CVMUserProgram();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public I2CVMUserProgram GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (I2CVMUserProgram)(objMngr.getObject(I2CVMUserProgram.OBJID, instID));
		}
	}
}

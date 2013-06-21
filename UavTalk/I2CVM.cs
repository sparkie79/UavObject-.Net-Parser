// Object ID: 711610694
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class I2CVM : UAVDataObject
	{
		public const long OBJID = 711610694;
		public int NUMBYTES { get; set; }
		protected const String NAME = "I2CVM";
	    protected static String DESCRIPTION = @"Snapshot of the register and RAM state of the I2C Virtual Machine";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<Int32> r0;
		public UAVObjectField<Int32> r1;
		public UAVObjectField<Int32> r2;
		public UAVObjectField<Int32> r3;
		public UAVObjectField<Int32> r4;
		public UAVObjectField<Int32> r5;
		public UAVObjectField<Int32> r6;
		public UAVObjectField<UInt16> pc;
		public UAVObjectField<byte> ram;

		public I2CVM() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> r0ElemNames = new List<String>();
			r0ElemNames.Add("0");
			r0=new UAVObjectField<Int32>("r0", "", r0ElemNames, null, this);
			fields.Add(r0);

			List<String> r1ElemNames = new List<String>();
			r1ElemNames.Add("0");
			r1=new UAVObjectField<Int32>("r1", "", r1ElemNames, null, this);
			fields.Add(r1);

			List<String> r2ElemNames = new List<String>();
			r2ElemNames.Add("0");
			r2=new UAVObjectField<Int32>("r2", "", r2ElemNames, null, this);
			fields.Add(r2);

			List<String> r3ElemNames = new List<String>();
			r3ElemNames.Add("0");
			r3=new UAVObjectField<Int32>("r3", "", r3ElemNames, null, this);
			fields.Add(r3);

			List<String> r4ElemNames = new List<String>();
			r4ElemNames.Add("0");
			r4=new UAVObjectField<Int32>("r4", "", r4ElemNames, null, this);
			fields.Add(r4);

			List<String> r5ElemNames = new List<String>();
			r5ElemNames.Add("0");
			r5=new UAVObjectField<Int32>("r5", "", r5ElemNames, null, this);
			fields.Add(r5);

			List<String> r6ElemNames = new List<String>();
			r6ElemNames.Add("0");
			r6=new UAVObjectField<Int32>("r6", "", r6ElemNames, null, this);
			fields.Add(r6);

			List<String> pcElemNames = new List<String>();
			pcElemNames.Add("0");
			pc=new UAVObjectField<UInt16>("pc", "", pcElemNames, null, this);
			fields.Add(pc);

			List<String> ramElemNames = new List<String>();
			ramElemNames.Add("0");
			ramElemNames.Add("1");
			ramElemNames.Add("2");
			ramElemNames.Add("3");
			ramElemNames.Add("4");
			ramElemNames.Add("5");
			ramElemNames.Add("6");
			ramElemNames.Add("7");
			ram=new UAVObjectField<byte>("ram", "", ramElemNames, null, this);
			fields.Add(ram);

	

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
				(int)AccessMode.ACCESS_READONLY << Metadata.UAVOBJ_ACCESS_SHIFT |
				(int)AccessMode.ACCESS_READONLY << Metadata.UAVOBJ_GCS_ACCESS_SHIFT |
				0 << Metadata.UAVOBJ_TELEMETRY_ACKED_SHIFT |
				0 << Metadata.UAVOBJ_GCS_TELEMETRY_ACKED_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_ONCHANGE << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_MANUAL << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
    		metadata.flightTelemetryUpdatePeriod = 100;
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
				I2CVM obj = new I2CVM();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public I2CVM GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (I2CVM)(objMngr.getObject(I2CVM.OBJID, instID));
		}
	}
}

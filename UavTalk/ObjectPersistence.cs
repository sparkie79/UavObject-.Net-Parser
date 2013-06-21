// Object ID: 2579903122
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class ObjectPersistence : UAVDataObject
	{
		public const long OBJID = 2579903122;
		public int NUMBYTES { get; set; }
		protected const String NAME = "ObjectPersistence";
	    protected static String DESCRIPTION = @"Someone who knows please enter this";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<UInt32> ObjectID;
		public UAVObjectField<UInt32> InstanceID;
		public enum OperationUavEnum
		{
			[Description("NOP")]
			NOP = 0, 
			[Description("Load")]
			Load = 1, 
			[Description("Save")]
			Save = 2, 
			[Description("Delete")]
			Delete = 3, 
			[Description("FullErase")]
			FullErase = 4, 
			[Description("Completed")]
			Completed = 5, 
			[Description("Error")]
			Error = 6, 
		}
		public UAVObjectField<OperationUavEnum> Operation;
		public enum SelectionUavEnum
		{
			[Description("SingleObject")]
			SingleObject = 0, 
			[Description("AllSettings")]
			AllSettings = 1, 
			[Description("AllMetaObjects")]
			AllMetaObjects = 2, 
			[Description("AllObjects")]
			AllObjects = 3, 
		}
		public UAVObjectField<SelectionUavEnum> Selection;

		public ObjectPersistence() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ObjectIDElemNames = new List<String>();
			ObjectIDElemNames.Add("0");
			ObjectID=new UAVObjectField<UInt32>("ObjectID", "", ObjectIDElemNames, null, this);
			fields.Add(ObjectID);

			List<String> InstanceIDElemNames = new List<String>();
			InstanceIDElemNames.Add("0");
			InstanceID=new UAVObjectField<UInt32>("InstanceID", "", InstanceIDElemNames, null, this);
			fields.Add(InstanceID);

			List<String> OperationElemNames = new List<String>();
			OperationElemNames.Add("0");
			List<String> OperationEnumOptions = new List<String>();
			OperationEnumOptions.Add("NOP");
			OperationEnumOptions.Add("Load");
			OperationEnumOptions.Add("Save");
			OperationEnumOptions.Add("Delete");
			OperationEnumOptions.Add("FullErase");
			OperationEnumOptions.Add("Completed");
			OperationEnumOptions.Add("Error");
			Operation=new UAVObjectField<OperationUavEnum>("Operation", "", OperationElemNames, OperationEnumOptions, this);
			fields.Add(Operation);

			List<String> SelectionElemNames = new List<String>();
			SelectionElemNames.Add("0");
			List<String> SelectionEnumOptions = new List<String>();
			SelectionEnumOptions.Add("SingleObject");
			SelectionEnumOptions.Add("AllSettings");
			SelectionEnumOptions.Add("AllMetaObjects");
			SelectionEnumOptions.Add("AllObjects");
			Selection=new UAVObjectField<SelectionUavEnum>("Selection", "", SelectionElemNames, SelectionEnumOptions, this);
			fields.Add(Selection);

	

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
				ObjectPersistence obj = new ObjectPersistence();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public ObjectPersistence GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (ObjectPersistence)(objMngr.getObject(ObjectPersistence.OBJID, instID));
		}
	}
}

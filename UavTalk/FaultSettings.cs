// Object ID: 662223420
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class FaultSettings : UAVDataObject
	{
		public const long OBJID = 662223420;
		public int NUMBYTES { get; set; }
		protected const String NAME = "FaultSettings";
	    protected static String DESCRIPTION = @"Allows testers to simulate various fault scenarios.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public enum ActivateFaultUavEnum
		{
			[Description("NoFault")]
			NoFault = 0, 
			[Description("ModuleInitAssert")]
			ModuleInitAssert = 1, 
			[Description("InitOutOfMemory")]
			InitOutOfMemory = 2, 
			[Description("InitBusError")]
			InitBusError = 3, 
			[Description("RunawayTask")]
			RunawayTask = 4, 
			[Description("TaskOutOfMemory")]
			TaskOutOfMemory = 5, 
		}
		public UAVObjectField<ActivateFaultUavEnum> ActivateFault;

		public FaultSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ActivateFaultElemNames = new List<String>();
			ActivateFaultElemNames.Add("0");
			List<String> ActivateFaultEnumOptions = new List<String>();
			ActivateFaultEnumOptions.Add("NoFault");
			ActivateFaultEnumOptions.Add("ModuleInitAssert");
			ActivateFaultEnumOptions.Add("InitOutOfMemory");
			ActivateFaultEnumOptions.Add("InitBusError");
			ActivateFaultEnumOptions.Add("RunawayTask");
			ActivateFaultEnumOptions.Add("TaskOutOfMemory");
			ActivateFault=new UAVObjectField<ActivateFaultUavEnum>("ActivateFault", "fault", ActivateFaultElemNames, ActivateFaultEnumOptions, this);
			fields.Add(ActivateFault);

	

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
			ActivateFault.setValue(ActivateFaultUavEnum.NoFault);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				FaultSettings obj = new FaultSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public FaultSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (FaultSettings)(objMngr.getObject(FaultSettings.OBJID, instID));
		}
	}
}

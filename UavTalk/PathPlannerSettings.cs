// Object ID: 2007623920
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class PathPlannerSettings : UAVDataObject
	{
		public const long OBJID = 2007623920;
		public int NUMBYTES { get; set; }
		protected const String NAME = "PathPlannerSettings";
	    protected static String DESCRIPTION = @"Settings for the @ref PathPlanner Module";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public enum PreprogrammedPathUavEnum
		{
			[Description("NONE")]
			NONE = 0, 
			[Description("10M_BOX")]
			v10MBOX = 1, 
			[Description("LOGO")]
			LOGO = 2, 
		}
		public UAVObjectField<PreprogrammedPathUavEnum> PreprogrammedPath;
		public enum FlashOperationUavEnum
		{
			[Description("NONE")]
			NONE = 0, 
			[Description("FAILED")]
			FAILED = 1, 
			[Description("COMPLETED")]
			COMPLETED = 2, 
			[Description("SAVE1")]
			SAVE1 = 3, 
			[Description("SAVE2")]
			SAVE2 = 4, 
			[Description("SAVE3")]
			SAVE3 = 5, 
			[Description("SAVE4")]
			SAVE4 = 6, 
			[Description("SAVE5")]
			SAVE5 = 7, 
			[Description("LOAD1")]
			LOAD1 = 8, 
			[Description("LOAD2")]
			LOAD2 = 9, 
			[Description("LOAD3")]
			LOAD3 = 10, 
			[Description("LOAD4")]
			LOAD4 = 11, 
			[Description("LOAD5")]
			LOAD5 = 12, 
		}
		public UAVObjectField<FlashOperationUavEnum> FlashOperation;

		public PathPlannerSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> PreprogrammedPathElemNames = new List<String>();
			PreprogrammedPathElemNames.Add("0");
			List<String> PreprogrammedPathEnumOptions = new List<String>();
			PreprogrammedPathEnumOptions.Add("NONE");
			PreprogrammedPathEnumOptions.Add("10M_BOX");
			PreprogrammedPathEnumOptions.Add("LOGO");
			PreprogrammedPath=new UAVObjectField<PreprogrammedPathUavEnum>("PreprogrammedPath", "", PreprogrammedPathElemNames, PreprogrammedPathEnumOptions, this);
			fields.Add(PreprogrammedPath);

			List<String> FlashOperationElemNames = new List<String>();
			FlashOperationElemNames.Add("0");
			List<String> FlashOperationEnumOptions = new List<String>();
			FlashOperationEnumOptions.Add("NONE");
			FlashOperationEnumOptions.Add("FAILED");
			FlashOperationEnumOptions.Add("COMPLETED");
			FlashOperationEnumOptions.Add("SAVE1");
			FlashOperationEnumOptions.Add("SAVE2");
			FlashOperationEnumOptions.Add("SAVE3");
			FlashOperationEnumOptions.Add("SAVE4");
			FlashOperationEnumOptions.Add("SAVE5");
			FlashOperationEnumOptions.Add("LOAD1");
			FlashOperationEnumOptions.Add("LOAD2");
			FlashOperationEnumOptions.Add("LOAD3");
			FlashOperationEnumOptions.Add("LOAD4");
			FlashOperationEnumOptions.Add("LOAD5");
			FlashOperation=new UAVObjectField<FlashOperationUavEnum>("FlashOperation", "", FlashOperationElemNames, FlashOperationEnumOptions, this);
			fields.Add(FlashOperation);

	

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
			PreprogrammedPath.setValue(PreprogrammedPathUavEnum.NONE);
			FlashOperation.setValue(FlashOperationUavEnum.NONE);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				PathPlannerSettings obj = new PathPlannerSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public PathPlannerSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (PathPlannerSettings)(objMngr.getObject(PathPlannerSettings.OBJID, instID));
		}
	}
}

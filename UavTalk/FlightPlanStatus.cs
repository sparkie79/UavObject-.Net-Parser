// Object ID: 570879558
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class FlightPlanStatus : UAVDataObject
	{
		public const long OBJID = 570879558;
		public int NUMBYTES { get; set; }
		protected const String NAME = "FlightPlanStatus";
	    protected static String DESCRIPTION = @"Status of the flight plan script";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<UInt32> ErrorFileID;
		public UAVObjectField<UInt32> ErrorLineNum;
		public UAVObjectField<float> Debug;
		public enum StatusUavEnum
		{
			[Description("Stopped")]
			Stopped = 0, 
			[Description("Running")]
			Running = 1, 
			[Description("Error")]
			Error = 2, 
		}
		public UAVObjectField<StatusUavEnum> Status;
		public enum ErrorTypeUavEnum
		{
			[Description("None")]
			None = 0, 
			[Description("VMInitError")]
			VMInitError = 1, 
			[Description("Exception")]
			Exception = 2, 
			[Description("IOError")]
			IOError = 3, 
			[Description("DivByZero")]
			DivByZero = 4, 
			[Description("AssertError")]
			AssertError = 5, 
			[Description("AttributeError")]
			AttributeError = 6, 
			[Description("ImportError")]
			ImportError = 7, 
			[Description("IndexError")]
			IndexError = 8, 
			[Description("KeyError")]
			KeyError = 9, 
			[Description("MemoryError")]
			MemoryError = 10, 
			[Description("NameError")]
			NameError = 11, 
			[Description("SyntaxError")]
			SyntaxError = 12, 
			[Description("SystemError")]
			SystemError = 13, 
			[Description("TypeError")]
			TypeError = 14, 
			[Description("ValueError")]
			ValueError = 15, 
			[Description("StopIteration")]
			StopIteration = 16, 
			[Description("Warning")]
			Warning = 17, 
			[Description("UnknownError")]
			UnknownError = 18, 
		}
		public UAVObjectField<ErrorTypeUavEnum> ErrorType;

		public FlightPlanStatus() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ErrorFileIDElemNames = new List<String>();
			ErrorFileIDElemNames.Add("0");
			ErrorFileID=new UAVObjectField<UInt32>("ErrorFileID", "", ErrorFileIDElemNames, null, this);
			fields.Add(ErrorFileID);

			List<String> ErrorLineNumElemNames = new List<String>();
			ErrorLineNumElemNames.Add("0");
			ErrorLineNum=new UAVObjectField<UInt32>("ErrorLineNum", "", ErrorLineNumElemNames, null, this);
			fields.Add(ErrorLineNum);

			List<String> DebugElemNames = new List<String>();
			DebugElemNames.Add("0");
			DebugElemNames.Add("1");
			Debug=new UAVObjectField<float>("Debug", "", DebugElemNames, null, this);
			fields.Add(Debug);

			List<String> StatusElemNames = new List<String>();
			StatusElemNames.Add("0");
			List<String> StatusEnumOptions = new List<String>();
			StatusEnumOptions.Add("Stopped");
			StatusEnumOptions.Add("Running");
			StatusEnumOptions.Add("Error");
			Status=new UAVObjectField<StatusUavEnum>("Status", "", StatusElemNames, StatusEnumOptions, this);
			fields.Add(Status);

			List<String> ErrorTypeElemNames = new List<String>();
			ErrorTypeElemNames.Add("0");
			List<String> ErrorTypeEnumOptions = new List<String>();
			ErrorTypeEnumOptions.Add("None");
			ErrorTypeEnumOptions.Add("VMInitError");
			ErrorTypeEnumOptions.Add("Exception");
			ErrorTypeEnumOptions.Add("IOError");
			ErrorTypeEnumOptions.Add("DivByZero");
			ErrorTypeEnumOptions.Add("AssertError");
			ErrorTypeEnumOptions.Add("AttributeError");
			ErrorTypeEnumOptions.Add("ImportError");
			ErrorTypeEnumOptions.Add("IndexError");
			ErrorTypeEnumOptions.Add("KeyError");
			ErrorTypeEnumOptions.Add("MemoryError");
			ErrorTypeEnumOptions.Add("NameError");
			ErrorTypeEnumOptions.Add("SyntaxError");
			ErrorTypeEnumOptions.Add("SystemError");
			ErrorTypeEnumOptions.Add("TypeError");
			ErrorTypeEnumOptions.Add("ValueError");
			ErrorTypeEnumOptions.Add("StopIteration");
			ErrorTypeEnumOptions.Add("Warning");
			ErrorTypeEnumOptions.Add("UnknownError");
			ErrorType=new UAVObjectField<ErrorTypeUavEnum>("ErrorType", "", ErrorTypeElemNames, ErrorTypeEnumOptions, this);
			fields.Add(ErrorType);

	

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
    		metadata.flightTelemetryUpdatePeriod = 2000;
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
			Debug.setValue((float)0,0);
			Debug.setValue((float)0,1);
			Status.setValue(StatusUavEnum.Stopped);
			ErrorType.setValue(ErrorTypeUavEnum.None);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				FlightPlanStatus obj = new FlightPlanStatus();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public FlightPlanStatus GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (FlightPlanStatus)(objMngr.getObject(FlightPlanStatus.OBJID, instID));
		}
	}
}

﻿// Object ID: 188197398
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class FlightStatus : UAVDataObject
	{
		public const long OBJID = 188197398;
		public int NUMBYTES { get; set; }
		protected const String NAME = "FlightStatus";
	    protected static String DESCRIPTION = @"Contains major flight status information for other modules.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public enum ArmedUavEnum
		{
			[Description("Disarmed")]
			Disarmed = 0, 
			[Description("Arming")]
			Arming = 1, 
			[Description("Armed")]
			Armed = 2, 
		}
		public UAVObjectField<ArmedUavEnum> Armed;
		public enum FlightModeUavEnum
		{
			[Description("Manual")]
			Manual = 0, 
			[Description("Stabilized1")]
			Stabilized1 = 1, 
			[Description("Stabilized2")]
			Stabilized2 = 2, 
			[Description("Stabilized3")]
			Stabilized3 = 3, 
			[Description("Autotune")]
			Autotune = 4, 
			[Description("AltitudeHold")]
			AltitudeHold = 5, 
			[Description("AltitudeVario")]
			AltitudeVario = 6, 
			[Description("VelocityControl")]
			VelocityControl = 7, 
			[Description("PositionHold")]
			PositionHold = 8, 
			[Description("ReturnToBase")]
			ReturnToBase = 9, 
			[Description("Land")]
			Land = 10, 
			[Description("PathPlanner")]
			PathPlanner = 11, 
			[Description("POI")]
			POI = 12, 
		}
		public UAVObjectField<FlightModeUavEnum> FlightMode;

		public FlightStatus() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ArmedElemNames = new List<String>();
			ArmedElemNames.Add("0");
			List<String> ArmedEnumOptions = new List<String>();
			ArmedEnumOptions.Add("Disarmed");
			ArmedEnumOptions.Add("Arming");
			ArmedEnumOptions.Add("Armed");
			Armed=new UAVObjectField<ArmedUavEnum>("Armed", "", ArmedElemNames, ArmedEnumOptions, this);
			fields.Add(Armed);

			List<String> FlightModeElemNames = new List<String>();
			FlightModeElemNames.Add("0");
			List<String> FlightModeEnumOptions = new List<String>();
			FlightModeEnumOptions.Add("Manual");
			FlightModeEnumOptions.Add("Stabilized1");
			FlightModeEnumOptions.Add("Stabilized2");
			FlightModeEnumOptions.Add("Stabilized3");
			FlightModeEnumOptions.Add("Autotune");
			FlightModeEnumOptions.Add("AltitudeHold");
			FlightModeEnumOptions.Add("AltitudeVario");
			FlightModeEnumOptions.Add("VelocityControl");
			FlightModeEnumOptions.Add("PositionHold");
			FlightModeEnumOptions.Add("ReturnToBase");
			FlightModeEnumOptions.Add("Land");
			FlightModeEnumOptions.Add("PathPlanner");
			FlightModeEnumOptions.Add("POI");
			FlightMode=new UAVObjectField<FlightModeUavEnum>("FlightMode", "", FlightModeElemNames, FlightModeEnumOptions, this);
			fields.Add(FlightMode);

	

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
    		metadata.flightTelemetryUpdatePeriod = 5000;
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
			Armed.setValue(ArmedUavEnum.Disarmed);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				FlightStatus obj = new FlightStatus();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public FlightStatus GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (FlightStatus)(objMngr.getObject(FlightStatus.OBJID, instID));
		}
	}
}

// Object ID: 3561455748
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class GPSTime : UAVDataObject
	{
		public const long OBJID = 3561455748;
		public int NUMBYTES { get; set; }
		protected const String NAME = "GPSTime";
	    protected static String DESCRIPTION = @"Contains the GPS time from @ref GPSModule.  Required to compute the world magnetic model correctly when setting the home location.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<Int16> Year;
		public UAVObjectField<sbyte> Month;
		public UAVObjectField<sbyte> Day;
		public UAVObjectField<sbyte> Hour;
		public UAVObjectField<sbyte> Minute;
		public UAVObjectField<sbyte> Second;

		public GPSTime() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> YearElemNames = new List<String>();
			YearElemNames.Add("0");
			Year=new UAVObjectField<Int16>("Year", "", YearElemNames, null, this);
			fields.Add(Year);

			List<String> MonthElemNames = new List<String>();
			MonthElemNames.Add("0");
			Month=new UAVObjectField<sbyte>("Month", "", MonthElemNames, null, this);
			fields.Add(Month);

			List<String> DayElemNames = new List<String>();
			DayElemNames.Add("0");
			Day=new UAVObjectField<sbyte>("Day", "", DayElemNames, null, this);
			fields.Add(Day);

			List<String> HourElemNames = new List<String>();
			HourElemNames.Add("0");
			Hour=new UAVObjectField<sbyte>("Hour", "", HourElemNames, null, this);
			fields.Add(Hour);

			List<String> MinuteElemNames = new List<String>();
			MinuteElemNames.Add("0");
			Minute=new UAVObjectField<sbyte>("Minute", "", MinuteElemNames, null, this);
			fields.Add(Minute);

			List<String> SecondElemNames = new List<String>();
			SecondElemNames.Add("0");
			Second=new UAVObjectField<sbyte>("Second", "", SecondElemNames, null, this);
			fields.Add(Second);

	

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
    		metadata.flightTelemetryUpdatePeriod = 10000;
    		metadata.gcsTelemetryUpdatePeriod = 0;
    		metadata.loggingUpdatePeriod = 30000;
 
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
				GPSTime obj = new GPSTime();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public GPSTime GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (GPSTime)(objMngr.getObject(GPSTime.OBJID, instID));
		}
	}
}

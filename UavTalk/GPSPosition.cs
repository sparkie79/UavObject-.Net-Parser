// Object ID: 3802342326
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class GPSPosition : UAVDataObject
	{
		public const long OBJID = 3802342326;
		public int NUMBYTES { get; set; }
		protected const String NAME = "GPSPosition";
	    protected static String DESCRIPTION = @"Raw GPS data from @ref GPSModule.  Should only be used by @ref AHRSCommsModule.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<Int32> Latitude;
		public UAVObjectField<Int32> Longitude;
		public UAVObjectField<float> Altitude;
		public UAVObjectField<float> GeoidSeparation;
		public UAVObjectField<float> Heading;
		public UAVObjectField<float> Groundspeed;
		public UAVObjectField<float> PDOP;
		public UAVObjectField<float> HDOP;
		public UAVObjectField<float> VDOP;
		public enum StatusUavEnum
		{
			[Description("NoGPS")]
			NoGPS = 0, 
			[Description("NoFix")]
			NoFix = 1, 
			[Description("Fix2D")]
			Fix2D = 2, 
			[Description("Fix3D")]
			Fix3D = 3, 
		}
		public UAVObjectField<StatusUavEnum> Status;
		public UAVObjectField<sbyte> Satellites;

		public GPSPosition() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> LatitudeElemNames = new List<String>();
			LatitudeElemNames.Add("0");
			Latitude=new UAVObjectField<Int32>("Latitude", "degrees x 10^-7", LatitudeElemNames, null, this);
			fields.Add(Latitude);

			List<String> LongitudeElemNames = new List<String>();
			LongitudeElemNames.Add("0");
			Longitude=new UAVObjectField<Int32>("Longitude", "degrees x 10^-7", LongitudeElemNames, null, this);
			fields.Add(Longitude);

			List<String> AltitudeElemNames = new List<String>();
			AltitudeElemNames.Add("0");
			Altitude=new UAVObjectField<float>("Altitude", "meters", AltitudeElemNames, null, this);
			fields.Add(Altitude);

			List<String> GeoidSeparationElemNames = new List<String>();
			GeoidSeparationElemNames.Add("0");
			GeoidSeparation=new UAVObjectField<float>("GeoidSeparation", "meters", GeoidSeparationElemNames, null, this);
			fields.Add(GeoidSeparation);

			List<String> HeadingElemNames = new List<String>();
			HeadingElemNames.Add("0");
			Heading=new UAVObjectField<float>("Heading", "degrees", HeadingElemNames, null, this);
			fields.Add(Heading);

			List<String> GroundspeedElemNames = new List<String>();
			GroundspeedElemNames.Add("0");
			Groundspeed=new UAVObjectField<float>("Groundspeed", "m/s", GroundspeedElemNames, null, this);
			fields.Add(Groundspeed);

			List<String> PDOPElemNames = new List<String>();
			PDOPElemNames.Add("0");
			PDOP=new UAVObjectField<float>("PDOP", "", PDOPElemNames, null, this);
			fields.Add(PDOP);

			List<String> HDOPElemNames = new List<String>();
			HDOPElemNames.Add("0");
			HDOP=new UAVObjectField<float>("HDOP", "", HDOPElemNames, null, this);
			fields.Add(HDOP);

			List<String> VDOPElemNames = new List<String>();
			VDOPElemNames.Add("0");
			VDOP=new UAVObjectField<float>("VDOP", "", VDOPElemNames, null, this);
			fields.Add(VDOP);

			List<String> StatusElemNames = new List<String>();
			StatusElemNames.Add("0");
			List<String> StatusEnumOptions = new List<String>();
			StatusEnumOptions.Add("NoGPS");
			StatusEnumOptions.Add("NoFix");
			StatusEnumOptions.Add("Fix2D");
			StatusEnumOptions.Add("Fix3D");
			Status=new UAVObjectField<StatusUavEnum>("Status", "", StatusElemNames, StatusEnumOptions, this);
			fields.Add(Status);

			List<String> SatellitesElemNames = new List<String>();
			SatellitesElemNames.Add("0");
			Satellites=new UAVObjectField<sbyte>("Satellites", "", SatellitesElemNames, null, this);
			fields.Add(Satellites);

	

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
				GPSPosition obj = new GPSPosition();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public GPSPosition GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (GPSPosition)(objMngr.getObject(GPSPosition.OBJID, instID));
		}
	}
}

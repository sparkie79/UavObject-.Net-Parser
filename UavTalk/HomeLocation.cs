// Object ID: 283879042
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class HomeLocation : UAVDataObject
	{
		public const long OBJID = 283879042;
		public int NUMBYTES { get; set; }
		protected const String NAME = "HomeLocation";
	    protected static String DESCRIPTION = @"HomeLocation setting which contains the constants to tranlate from longitutde and latitude to NED reference frame.  Automatically set by @ref GPSModule after acquiring a 3D lock.  Used by @ref AHRSCommsModule.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<Int32> Latitude;
		public UAVObjectField<Int32> Longitude;
		public UAVObjectField<float> Altitude;
		public UAVObjectField<float> Be;
		public UAVObjectField<UInt16> SeaLevelPressure;
		public enum SetUavEnum
		{
			[Description("FALSE")]
			FALSE = 0, 
			[Description("TRUE")]
			TRUE = 1, 
		}
		public UAVObjectField<SetUavEnum> Set;
		public UAVObjectField<sbyte> GroundTemperature;

		public HomeLocation() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> LatitudeElemNames = new List<String>();
			LatitudeElemNames.Add("0");
			Latitude=new UAVObjectField<Int32>("Latitude", "deg * 10e6", LatitudeElemNames, null, this);
			fields.Add(Latitude);

			List<String> LongitudeElemNames = new List<String>();
			LongitudeElemNames.Add("0");
			Longitude=new UAVObjectField<Int32>("Longitude", "deg * 10e6", LongitudeElemNames, null, this);
			fields.Add(Longitude);

			List<String> AltitudeElemNames = new List<String>();
			AltitudeElemNames.Add("0");
			Altitude=new UAVObjectField<float>("Altitude", "m over geoid", AltitudeElemNames, null, this);
			fields.Add(Altitude);

			List<String> BeElemNames = new List<String>();
			BeElemNames.Add("0");
			BeElemNames.Add("1");
			BeElemNames.Add("2");
			Be=new UAVObjectField<float>("Be", "", BeElemNames, null, this);
			fields.Add(Be);

			List<String> SeaLevelPressureElemNames = new List<String>();
			SeaLevelPressureElemNames.Add("0");
			SeaLevelPressure=new UAVObjectField<UInt16>("SeaLevelPressure", "millibar", SeaLevelPressureElemNames, null, this);
			fields.Add(SeaLevelPressure);

			List<String> SetElemNames = new List<String>();
			SetElemNames.Add("0");
			List<String> SetEnumOptions = new List<String>();
			SetEnumOptions.Add("FALSE");
			SetEnumOptions.Add("TRUE");
			Set=new UAVObjectField<SetUavEnum>("Set", "", SetElemNames, SetEnumOptions, this);
			fields.Add(Set);

			List<String> GroundTemperatureElemNames = new List<String>();
			GroundTemperatureElemNames.Add("0");
			GroundTemperature=new UAVObjectField<sbyte>("GroundTemperature", "deg C", GroundTemperatureElemNames, null, this);
			fields.Add(GroundTemperature);

	

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
			Latitude.setValue((Int32)0);
			Longitude.setValue((Int32)0);
			Altitude.setValue((float)0);
			Be.setValue((float)0,0);
			Be.setValue((float)0,1);
			Be.setValue((float)0,2);
			SeaLevelPressure.setValue((UInt16)1013);
			Set.setValue(SetUavEnum.FALSE);
			GroundTemperature.setValue((sbyte)15);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				HomeLocation obj = new HomeLocation();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public HomeLocation GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (HomeLocation)(objMngr.getObject(HomeLocation.OBJID, instID));
		}
	}
}

// Object ID: 153147800
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class GPSSatellites : UAVDataObject
	{
		public const long OBJID = 153147800;
		public int NUMBYTES { get; set; }
		protected const String NAME = "GPSSatellites";
	    protected static String DESCRIPTION = @"Contains information about the GPS satellites in view from @ref GPSModule.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> Elevation;
		public UAVObjectField<float> Azimuth;
		public UAVObjectField<sbyte> SatsInView;
		public UAVObjectField<sbyte> PRN;
		public UAVObjectField<sbyte> SNR;

		public GPSSatellites() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> ElevationElemNames = new List<String>();
			ElevationElemNames.Add("0");
			ElevationElemNames.Add("1");
			ElevationElemNames.Add("2");
			ElevationElemNames.Add("3");
			ElevationElemNames.Add("4");
			ElevationElemNames.Add("5");
			ElevationElemNames.Add("6");
			ElevationElemNames.Add("7");
			ElevationElemNames.Add("8");
			ElevationElemNames.Add("9");
			ElevationElemNames.Add("10");
			ElevationElemNames.Add("11");
			ElevationElemNames.Add("12");
			ElevationElemNames.Add("13");
			ElevationElemNames.Add("14");
			ElevationElemNames.Add("15");
			Elevation=new UAVObjectField<float>("Elevation", "degrees", ElevationElemNames, null, this);
			fields.Add(Elevation);

			List<String> AzimuthElemNames = new List<String>();
			AzimuthElemNames.Add("0");
			AzimuthElemNames.Add("1");
			AzimuthElemNames.Add("2");
			AzimuthElemNames.Add("3");
			AzimuthElemNames.Add("4");
			AzimuthElemNames.Add("5");
			AzimuthElemNames.Add("6");
			AzimuthElemNames.Add("7");
			AzimuthElemNames.Add("8");
			AzimuthElemNames.Add("9");
			AzimuthElemNames.Add("10");
			AzimuthElemNames.Add("11");
			AzimuthElemNames.Add("12");
			AzimuthElemNames.Add("13");
			AzimuthElemNames.Add("14");
			AzimuthElemNames.Add("15");
			Azimuth=new UAVObjectField<float>("Azimuth", "degrees", AzimuthElemNames, null, this);
			fields.Add(Azimuth);

			List<String> SatsInViewElemNames = new List<String>();
			SatsInViewElemNames.Add("0");
			SatsInView=new UAVObjectField<sbyte>("SatsInView", "", SatsInViewElemNames, null, this);
			fields.Add(SatsInView);

			List<String> PRNElemNames = new List<String>();
			PRNElemNames.Add("0");
			PRNElemNames.Add("1");
			PRNElemNames.Add("2");
			PRNElemNames.Add("3");
			PRNElemNames.Add("4");
			PRNElemNames.Add("5");
			PRNElemNames.Add("6");
			PRNElemNames.Add("7");
			PRNElemNames.Add("8");
			PRNElemNames.Add("9");
			PRNElemNames.Add("10");
			PRNElemNames.Add("11");
			PRNElemNames.Add("12");
			PRNElemNames.Add("13");
			PRNElemNames.Add("14");
			PRNElemNames.Add("15");
			PRN=new UAVObjectField<sbyte>("PRN", "", PRNElemNames, null, this);
			fields.Add(PRN);

			List<String> SNRElemNames = new List<String>();
			SNRElemNames.Add("0");
			SNRElemNames.Add("1");
			SNRElemNames.Add("2");
			SNRElemNames.Add("3");
			SNRElemNames.Add("4");
			SNRElemNames.Add("5");
			SNRElemNames.Add("6");
			SNRElemNames.Add("7");
			SNRElemNames.Add("8");
			SNRElemNames.Add("9");
			SNRElemNames.Add("10");
			SNRElemNames.Add("11");
			SNRElemNames.Add("12");
			SNRElemNames.Add("13");
			SNRElemNames.Add("14");
			SNRElemNames.Add("15");
			SNR=new UAVObjectField<sbyte>("SNR", "", SNRElemNames, null, this);
			fields.Add(SNR);

	

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
				GPSSatellites obj = new GPSSatellites();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public GPSSatellites GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (GPSSatellites)(objMngr.getObject(GPSSatellites.OBJID, instID));
		}
	}
}

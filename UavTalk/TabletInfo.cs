// Object ID: 1456166740
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class TabletInfo : UAVDataObject
	{
		public const long OBJID = 1456166740;
		public int NUMBYTES { get; set; }
		protected const String NAME = "TabletInfo";
	    protected static String DESCRIPTION = @"The information from the tablet to the UAVO.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<Int32> Latitude;
		public UAVObjectField<Int32> Longitude;
		public UAVObjectField<float> Altitude;
		public enum ConnectedUavEnum
		{
			[Description("False")]
			False = 0, 
			[Description("True")]
			True = 1, 
		}
		public UAVObjectField<ConnectedUavEnum> Connected;
		public enum TabletModeDesiredUavEnum
		{
			[Description("PositionHold")]
			PositionHold = 0, 
			[Description("ReturnToHome")]
			ReturnToHome = 1, 
			[Description("ReturnToTablet")]
			ReturnToTablet = 2, 
			[Description("PathPlanner")]
			PathPlanner = 3, 
			[Description("FollowMe")]
			FollowMe = 4, 
			[Description("Land")]
			Land = 5, 
			[Description("CameraPOI")]
			CameraPOI = 6, 
		}
		public UAVObjectField<TabletModeDesiredUavEnum> TabletModeDesired;

		public TabletInfo() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> LatitudeElemNames = new List<String>();
			LatitudeElemNames.Add("0");
			Latitude=new UAVObjectField<Int32>("Latitude", "deg*10e6", LatitudeElemNames, null, this);
			fields.Add(Latitude);

			List<String> LongitudeElemNames = new List<String>();
			LongitudeElemNames.Add("0");
			Longitude=new UAVObjectField<Int32>("Longitude", "deg*10e6", LongitudeElemNames, null, this);
			fields.Add(Longitude);

			List<String> AltitudeElemNames = new List<String>();
			AltitudeElemNames.Add("0");
			Altitude=new UAVObjectField<float>("Altitude", "m", AltitudeElemNames, null, this);
			fields.Add(Altitude);

			List<String> ConnectedElemNames = new List<String>();
			ConnectedElemNames.Add("0");
			List<String> ConnectedEnumOptions = new List<String>();
			ConnectedEnumOptions.Add("False");
			ConnectedEnumOptions.Add("True");
			Connected=new UAVObjectField<ConnectedUavEnum>("Connected", "", ConnectedElemNames, ConnectedEnumOptions, this);
			fields.Add(Connected);

			List<String> TabletModeDesiredElemNames = new List<String>();
			TabletModeDesiredElemNames.Add("0");
			List<String> TabletModeDesiredEnumOptions = new List<String>();
			TabletModeDesiredEnumOptions.Add("PositionHold");
			TabletModeDesiredEnumOptions.Add("ReturnToHome");
			TabletModeDesiredEnumOptions.Add("ReturnToTablet");
			TabletModeDesiredEnumOptions.Add("PathPlanner");
			TabletModeDesiredEnumOptions.Add("FollowMe");
			TabletModeDesiredEnumOptions.Add("Land");
			TabletModeDesiredEnumOptions.Add("CameraPOI");
			TabletModeDesired=new UAVObjectField<TabletModeDesiredUavEnum>("TabletModeDesired", "", TabletModeDesiredElemNames, TabletModeDesiredEnumOptions, this);
			fields.Add(TabletModeDesired);

	

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
				TabletInfo obj = new TabletInfo();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public TabletInfo GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (TabletInfo)(objMngr.getObject(TabletInfo.OBJID, instID));
		}
	}
}

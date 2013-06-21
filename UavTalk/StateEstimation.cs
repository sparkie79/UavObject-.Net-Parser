// Object ID: 2650829874
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class StateEstimation : UAVDataObject
	{
		public const long OBJID = 2650829874;
		public int NUMBYTES { get; set; }
		protected const String NAME = "StateEstimation";
	    protected static String DESCRIPTION = @"Settings for how to estimate the state";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public enum AttitudeFilterUavEnum
		{
			[Description("Complementary")]
			Complementary = 0, 
			[Description("INSIndoor")]
			INSIndoor = 1, 
			[Description("INSOutdoor")]
			INSOutdoor = 2, 
		}
		public UAVObjectField<AttitudeFilterUavEnum> AttitudeFilter;
		public enum NavigationFilterUavEnum
		{
			[Description("Raw")]
			Raw = 0, 
			[Description("INS")]
			INS = 1, 
		}
		public UAVObjectField<NavigationFilterUavEnum> NavigationFilter;

		public StateEstimation() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> AttitudeFilterElemNames = new List<String>();
			AttitudeFilterElemNames.Add("0");
			List<String> AttitudeFilterEnumOptions = new List<String>();
			AttitudeFilterEnumOptions.Add("Complementary");
			AttitudeFilterEnumOptions.Add("INSIndoor");
			AttitudeFilterEnumOptions.Add("INSOutdoor");
			AttitudeFilter=new UAVObjectField<AttitudeFilterUavEnum>("AttitudeFilter", "", AttitudeFilterElemNames, AttitudeFilterEnumOptions, this);
			fields.Add(AttitudeFilter);

			List<String> NavigationFilterElemNames = new List<String>();
			NavigationFilterElemNames.Add("0");
			List<String> NavigationFilterEnumOptions = new List<String>();
			NavigationFilterEnumOptions.Add("Raw");
			NavigationFilterEnumOptions.Add("INS");
			NavigationFilter=new UAVObjectField<NavigationFilterUavEnum>("NavigationFilter", "", NavigationFilterElemNames, NavigationFilterEnumOptions, this);
			fields.Add(NavigationFilter);

	

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
			AttitudeFilter.setValue(AttitudeFilterUavEnum.Complementary);
			NavigationFilter.setValue(NavigationFilterUavEnum.Raw);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				StateEstimation obj = new StateEstimation();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public StateEstimation GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (StateEstimation)(objMngr.getObject(StateEstimation.OBJID, instID));
		}
	}
}

﻿// Object ID: 3492481604
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class VibrationAnalysisOutput : UAVDataObject
	{
		public const long OBJID = 3492481604;
		public int NUMBYTES { get; set; }
		protected const String NAME = "VibrationAnalysisOutput";
	    protected static String DESCRIPTION = @"FFT output from @VibrationTest module.";
		protected const bool ISSINGLEINST = false;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<float> x;
		public UAVObjectField<float> y;
		public UAVObjectField<float> z;

		public VibrationAnalysisOutput() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> xElemNames = new List<String>();
			xElemNames.Add("0");
			x=new UAVObjectField<float>("x", "m/s^2", xElemNames, null, this);
			fields.Add(x);

			List<String> yElemNames = new List<String>();
			yElemNames.Add("0");
			y=new UAVObjectField<float>("y", "m/s^2", yElemNames, null, this);
			fields.Add(y);

			List<String> zElemNames = new List<String>();
			zElemNames.Add("0");
			z=new UAVObjectField<float>("z", "m/s^2", zElemNames, null, this);
			fields.Add(z);

	

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
				(int)UPDATEMODE.UPDATEMODE_MANUAL << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_MANUAL << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
    		metadata.flightTelemetryUpdatePeriod = 1000;
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
				VibrationAnalysisOutput obj = new VibrationAnalysisOutput();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public VibrationAnalysisOutput GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (VibrationAnalysisOutput)(objMngr.getObject(VibrationAnalysisOutput.OBJID, instID));
		}
	}
}

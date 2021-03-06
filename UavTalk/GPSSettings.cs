﻿// Object ID: 3883100782
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class GPSSettings : UAVDataObject
	{
		public const long OBJID = 3883100782;
		public int NUMBYTES { get; set; }
		protected const String NAME = "GPSSettings";
	    protected static String DESCRIPTION = @"GPS Module specific settings";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = true;

		public UAVObjectField<float> MaxPDOP;
		public enum DataProtocolUavEnum
		{
			[Description("NMEA")]
			NMEA = 0, 
			[Description("UBX")]
			UBX = 1, 
		}
		public UAVObjectField<DataProtocolUavEnum> DataProtocol;
		public UAVObjectField<byte> MinSattelites;

		public GPSSettings() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> MaxPDOPElemNames = new List<String>();
			MaxPDOPElemNames.Add("0");
			MaxPDOP=new UAVObjectField<float>("MaxPDOP", "", MaxPDOPElemNames, null, this);
			fields.Add(MaxPDOP);

			List<String> DataProtocolElemNames = new List<String>();
			DataProtocolElemNames.Add("0");
			List<String> DataProtocolEnumOptions = new List<String>();
			DataProtocolEnumOptions.Add("NMEA");
			DataProtocolEnumOptions.Add("UBX");
			DataProtocol=new UAVObjectField<DataProtocolUavEnum>("DataProtocol", "", DataProtocolElemNames, DataProtocolEnumOptions, this);
			fields.Add(DataProtocol);

			List<String> MinSattelitesElemNames = new List<String>();
			MinSattelitesElemNames.Add("0");
			MinSattelites=new UAVObjectField<byte>("MinSattelites", "", MinSattelitesElemNames, null, this);
			fields.Add(MinSattelites);

	

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
			MaxPDOP.setValue((float)35);
			DataProtocol.setValue(DataProtocolUavEnum.UBX);
			MinSattelites.setValue((byte)7);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				GPSSettings obj = new GPSSettings();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public GPSSettings GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (GPSSettings)(objMngr.getObject(GPSSettings.OBJID, instID));
		}
	}
}

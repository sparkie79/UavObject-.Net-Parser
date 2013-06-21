// Object ID: 1584304092
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class FirmwareIAPObj : UAVDataObject
	{
		public const long OBJID = 1584304092;
		public int NUMBYTES { get; set; }
		protected const String NAME = "FirmwareIAPObj";
	    protected static String DESCRIPTION = @"Queries board for SN, model, revision, and sends reset command";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<UInt32> crc;
		public UAVObjectField<UInt16> Command;
		public UAVObjectField<UInt16> BoardRevision;
		public UAVObjectField<byte> Description;
		public UAVObjectField<byte> CPUSerial;
		public UAVObjectField<byte> BoardType;
		public UAVObjectField<byte> ArmReset;

		public FirmwareIAPObj() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> crcElemNames = new List<String>();
			crcElemNames.Add("0");
			crc=new UAVObjectField<UInt32>("crc", "", crcElemNames, null, this);
			fields.Add(crc);

			List<String> CommandElemNames = new List<String>();
			CommandElemNames.Add("0");
			Command=new UAVObjectField<UInt16>("Command", "", CommandElemNames, null, this);
			fields.Add(Command);

			List<String> BoardRevisionElemNames = new List<String>();
			BoardRevisionElemNames.Add("0");
			BoardRevision=new UAVObjectField<UInt16>("BoardRevision", "", BoardRevisionElemNames, null, this);
			fields.Add(BoardRevision);

			List<String> DescriptionElemNames = new List<String>();
			DescriptionElemNames.Add("0");
			DescriptionElemNames.Add("1");
			DescriptionElemNames.Add("2");
			DescriptionElemNames.Add("3");
			DescriptionElemNames.Add("4");
			DescriptionElemNames.Add("5");
			DescriptionElemNames.Add("6");
			DescriptionElemNames.Add("7");
			DescriptionElemNames.Add("8");
			DescriptionElemNames.Add("9");
			DescriptionElemNames.Add("10");
			DescriptionElemNames.Add("11");
			DescriptionElemNames.Add("12");
			DescriptionElemNames.Add("13");
			DescriptionElemNames.Add("14");
			DescriptionElemNames.Add("15");
			DescriptionElemNames.Add("16");
			DescriptionElemNames.Add("17");
			DescriptionElemNames.Add("18");
			DescriptionElemNames.Add("19");
			DescriptionElemNames.Add("20");
			DescriptionElemNames.Add("21");
			DescriptionElemNames.Add("22");
			DescriptionElemNames.Add("23");
			DescriptionElemNames.Add("24");
			DescriptionElemNames.Add("25");
			DescriptionElemNames.Add("26");
			DescriptionElemNames.Add("27");
			DescriptionElemNames.Add("28");
			DescriptionElemNames.Add("29");
			DescriptionElemNames.Add("30");
			DescriptionElemNames.Add("31");
			DescriptionElemNames.Add("32");
			DescriptionElemNames.Add("33");
			DescriptionElemNames.Add("34");
			DescriptionElemNames.Add("35");
			DescriptionElemNames.Add("36");
			DescriptionElemNames.Add("37");
			DescriptionElemNames.Add("38");
			DescriptionElemNames.Add("39");
			DescriptionElemNames.Add("40");
			DescriptionElemNames.Add("41");
			DescriptionElemNames.Add("42");
			DescriptionElemNames.Add("43");
			DescriptionElemNames.Add("44");
			DescriptionElemNames.Add("45");
			DescriptionElemNames.Add("46");
			DescriptionElemNames.Add("47");
			DescriptionElemNames.Add("48");
			DescriptionElemNames.Add("49");
			DescriptionElemNames.Add("50");
			DescriptionElemNames.Add("51");
			DescriptionElemNames.Add("52");
			DescriptionElemNames.Add("53");
			DescriptionElemNames.Add("54");
			DescriptionElemNames.Add("55");
			DescriptionElemNames.Add("56");
			DescriptionElemNames.Add("57");
			DescriptionElemNames.Add("58");
			DescriptionElemNames.Add("59");
			DescriptionElemNames.Add("60");
			DescriptionElemNames.Add("61");
			DescriptionElemNames.Add("62");
			DescriptionElemNames.Add("63");
			DescriptionElemNames.Add("64");
			DescriptionElemNames.Add("65");
			DescriptionElemNames.Add("66");
			DescriptionElemNames.Add("67");
			DescriptionElemNames.Add("68");
			DescriptionElemNames.Add("69");
			DescriptionElemNames.Add("70");
			DescriptionElemNames.Add("71");
			DescriptionElemNames.Add("72");
			DescriptionElemNames.Add("73");
			DescriptionElemNames.Add("74");
			DescriptionElemNames.Add("75");
			DescriptionElemNames.Add("76");
			DescriptionElemNames.Add("77");
			DescriptionElemNames.Add("78");
			DescriptionElemNames.Add("79");
			DescriptionElemNames.Add("80");
			DescriptionElemNames.Add("81");
			DescriptionElemNames.Add("82");
			DescriptionElemNames.Add("83");
			DescriptionElemNames.Add("84");
			DescriptionElemNames.Add("85");
			DescriptionElemNames.Add("86");
			DescriptionElemNames.Add("87");
			DescriptionElemNames.Add("88");
			DescriptionElemNames.Add("89");
			DescriptionElemNames.Add("90");
			DescriptionElemNames.Add("91");
			DescriptionElemNames.Add("92");
			DescriptionElemNames.Add("93");
			DescriptionElemNames.Add("94");
			DescriptionElemNames.Add("95");
			DescriptionElemNames.Add("96");
			DescriptionElemNames.Add("97");
			DescriptionElemNames.Add("98");
			DescriptionElemNames.Add("99");
			Description=new UAVObjectField<byte>("Description", "", DescriptionElemNames, null, this);
			fields.Add(Description);

			List<String> CPUSerialElemNames = new List<String>();
			CPUSerialElemNames.Add("0");
			CPUSerialElemNames.Add("1");
			CPUSerialElemNames.Add("2");
			CPUSerialElemNames.Add("3");
			CPUSerialElemNames.Add("4");
			CPUSerialElemNames.Add("5");
			CPUSerialElemNames.Add("6");
			CPUSerialElemNames.Add("7");
			CPUSerialElemNames.Add("8");
			CPUSerialElemNames.Add("9");
			CPUSerialElemNames.Add("10");
			CPUSerialElemNames.Add("11");
			CPUSerial=new UAVObjectField<byte>("CPUSerial", "", CPUSerialElemNames, null, this);
			fields.Add(CPUSerial);

			List<String> BoardTypeElemNames = new List<String>();
			BoardTypeElemNames.Add("0");
			BoardType=new UAVObjectField<byte>("BoardType", "", BoardTypeElemNames, null, this);
			fields.Add(BoardType);

			List<String> ArmResetElemNames = new List<String>();
			ArmResetElemNames.Add("0");
			ArmReset=new UAVObjectField<byte>("ArmReset", "", ArmResetElemNames, null, this);
			fields.Add(ArmReset);

	

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
				FirmwareIAPObj obj = new FirmwareIAPObj();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public FirmwareIAPObj GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (FirmwareIAPObj)(objMngr.getObject(FirmwareIAPObj.OBJID, instID));
		}
	}
}

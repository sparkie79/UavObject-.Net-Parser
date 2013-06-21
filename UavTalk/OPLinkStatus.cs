// Object ID: 635577328
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class OPLinkStatus : UAVDataObject
	{
		public const long OBJID = 635577328;
		public int NUMBYTES { get; set; }
		protected const String NAME = "OPLinkStatus";
	    protected static String DESCRIPTION = @"OPLink device status.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<UInt32> DeviceID;
		public UAVObjectField<UInt32> PairIDs;
		public UAVObjectField<UInt16> BoardRevision;
		public UAVObjectField<UInt16> UAVTalkErrors;
		public UAVObjectField<UInt16> TXRate;
		public UAVObjectField<UInt16> RXRate;
		public UAVObjectField<UInt16> TXSeq;
		public UAVObjectField<UInt16> RXSeq;
		public UAVObjectField<byte> Description;
		public UAVObjectField<byte> CPUSerial;
		public UAVObjectField<byte> BoardType;
		public UAVObjectField<byte> RxGood;
		public UAVObjectField<byte> RxCorrected;
		public UAVObjectField<byte> RxErrors;
		public UAVObjectField<byte> RxMissed;
		public UAVObjectField<byte> RxFailure;
		public UAVObjectField<byte> TxResent;
		public UAVObjectField<byte> TxDropped;
		public UAVObjectField<byte> TxFailure;
		public UAVObjectField<byte> Resets;
		public UAVObjectField<byte> Timeouts;
		public UAVObjectField<sbyte> RSSI;
		public UAVObjectField<sbyte> AFCCorrection;
		public UAVObjectField<byte> LinkQuality;
		public enum LinkStateUavEnum
		{
			[Description("Disconnected")]
			Disconnected = 0, 
			[Description("Connecting")]
			Connecting = 1, 
			[Description("Connected")]
			Connected = 2, 
		}
		public UAVObjectField<LinkStateUavEnum> LinkState;
		public UAVObjectField<sbyte> PairSignalStrengths;

		public OPLinkStatus() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> DeviceIDElemNames = new List<String>();
			DeviceIDElemNames.Add("0");
			DeviceID=new UAVObjectField<UInt32>("DeviceID", "", DeviceIDElemNames, null, this);
			fields.Add(DeviceID);

			List<String> PairIDsElemNames = new List<String>();
			PairIDsElemNames.Add("0");
			PairIDsElemNames.Add("1");
			PairIDsElemNames.Add("2");
			PairIDsElemNames.Add("3");
			PairIDs=new UAVObjectField<UInt32>("PairIDs", "", PairIDsElemNames, null, this);
			fields.Add(PairIDs);

			List<String> BoardRevisionElemNames = new List<String>();
			BoardRevisionElemNames.Add("0");
			BoardRevision=new UAVObjectField<UInt16>("BoardRevision", "", BoardRevisionElemNames, null, this);
			fields.Add(BoardRevision);

			List<String> UAVTalkErrorsElemNames = new List<String>();
			UAVTalkErrorsElemNames.Add("0");
			UAVTalkErrors=new UAVObjectField<UInt16>("UAVTalkErrors", "", UAVTalkErrorsElemNames, null, this);
			fields.Add(UAVTalkErrors);

			List<String> TXRateElemNames = new List<String>();
			TXRateElemNames.Add("0");
			TXRate=new UAVObjectField<UInt16>("TXRate", "Bps", TXRateElemNames, null, this);
			fields.Add(TXRate);

			List<String> RXRateElemNames = new List<String>();
			RXRateElemNames.Add("0");
			RXRate=new UAVObjectField<UInt16>("RXRate", "Bps", RXRateElemNames, null, this);
			fields.Add(RXRate);

			List<String> TXSeqElemNames = new List<String>();
			TXSeqElemNames.Add("0");
			TXSeq=new UAVObjectField<UInt16>("TXSeq", "", TXSeqElemNames, null, this);
			fields.Add(TXSeq);

			List<String> RXSeqElemNames = new List<String>();
			RXSeqElemNames.Add("0");
			RXSeq=new UAVObjectField<UInt16>("RXSeq", "", RXSeqElemNames, null, this);
			fields.Add(RXSeq);

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

			List<String> RxGoodElemNames = new List<String>();
			RxGoodElemNames.Add("0");
			RxGood=new UAVObjectField<byte>("RxGood", "%", RxGoodElemNames, null, this);
			fields.Add(RxGood);

			List<String> RxCorrectedElemNames = new List<String>();
			RxCorrectedElemNames.Add("0");
			RxCorrected=new UAVObjectField<byte>("RxCorrected", "%", RxCorrectedElemNames, null, this);
			fields.Add(RxCorrected);

			List<String> RxErrorsElemNames = new List<String>();
			RxErrorsElemNames.Add("0");
			RxErrors=new UAVObjectField<byte>("RxErrors", "%", RxErrorsElemNames, null, this);
			fields.Add(RxErrors);

			List<String> RxMissedElemNames = new List<String>();
			RxMissedElemNames.Add("0");
			RxMissed=new UAVObjectField<byte>("RxMissed", "%", RxMissedElemNames, null, this);
			fields.Add(RxMissed);

			List<String> RxFailureElemNames = new List<String>();
			RxFailureElemNames.Add("0");
			RxFailure=new UAVObjectField<byte>("RxFailure", "%", RxFailureElemNames, null, this);
			fields.Add(RxFailure);

			List<String> TxResentElemNames = new List<String>();
			TxResentElemNames.Add("0");
			TxResent=new UAVObjectField<byte>("TxResent", "%", TxResentElemNames, null, this);
			fields.Add(TxResent);

			List<String> TxDroppedElemNames = new List<String>();
			TxDroppedElemNames.Add("0");
			TxDropped=new UAVObjectField<byte>("TxDropped", "%", TxDroppedElemNames, null, this);
			fields.Add(TxDropped);

			List<String> TxFailureElemNames = new List<String>();
			TxFailureElemNames.Add("0");
			TxFailure=new UAVObjectField<byte>("TxFailure", "%", TxFailureElemNames, null, this);
			fields.Add(TxFailure);

			List<String> ResetsElemNames = new List<String>();
			ResetsElemNames.Add("0");
			Resets=new UAVObjectField<byte>("Resets", "", ResetsElemNames, null, this);
			fields.Add(Resets);

			List<String> TimeoutsElemNames = new List<String>();
			TimeoutsElemNames.Add("0");
			Timeouts=new UAVObjectField<byte>("Timeouts", "", TimeoutsElemNames, null, this);
			fields.Add(Timeouts);

			List<String> RSSIElemNames = new List<String>();
			RSSIElemNames.Add("0");
			RSSI=new UAVObjectField<sbyte>("RSSI", "dBm", RSSIElemNames, null, this);
			fields.Add(RSSI);

			List<String> AFCCorrectionElemNames = new List<String>();
			AFCCorrectionElemNames.Add("0");
			AFCCorrection=new UAVObjectField<sbyte>("AFCCorrection", "Hz", AFCCorrectionElemNames, null, this);
			fields.Add(AFCCorrection);

			List<String> LinkQualityElemNames = new List<String>();
			LinkQualityElemNames.Add("0");
			LinkQuality=new UAVObjectField<byte>("LinkQuality", "", LinkQualityElemNames, null, this);
			fields.Add(LinkQuality);

			List<String> LinkStateElemNames = new List<String>();
			LinkStateElemNames.Add("0");
			List<String> LinkStateEnumOptions = new List<String>();
			LinkStateEnumOptions.Add("Disconnected");
			LinkStateEnumOptions.Add("Connecting");
			LinkStateEnumOptions.Add("Connected");
			LinkState=new UAVObjectField<LinkStateUavEnum>("LinkState", "function", LinkStateElemNames, LinkStateEnumOptions, this);
			fields.Add(LinkState);

			List<String> PairSignalStrengthsElemNames = new List<String>();
			PairSignalStrengthsElemNames.Add("0");
			PairSignalStrengthsElemNames.Add("1");
			PairSignalStrengthsElemNames.Add("2");
			PairSignalStrengthsElemNames.Add("3");
			PairSignalStrengths=new UAVObjectField<sbyte>("PairSignalStrengths", "dBm", PairSignalStrengthsElemNames, null, this);
			fields.Add(PairSignalStrengths);

	

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
				(int)AccessMode.ACCESS_READONLY << Metadata.UAVOBJ_ACCESS_SHIFT |
				(int)AccessMode.ACCESS_READONLY << Metadata.UAVOBJ_GCS_ACCESS_SHIFT |
				0 << Metadata.UAVOBJ_TELEMETRY_ACKED_SHIFT |
				0 << Metadata.UAVOBJ_GCS_TELEMETRY_ACKED_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_PERIODIC << Metadata.UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT |
				(int)UPDATEMODE.UPDATEMODE_MANUAL << Metadata.UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT;
    		metadata.flightTelemetryUpdatePeriod = 1000;
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
			DeviceID.setValue((UInt32)0);
			PairIDs.setValue((UInt32)0,0);
			PairIDs.setValue((UInt32)0,1);
			PairIDs.setValue((UInt32)0,2);
			PairIDs.setValue((UInt32)0,3);
			UAVTalkErrors.setValue((UInt16)0);
			TXRate.setValue((UInt16)0);
			RXRate.setValue((UInt16)0);
			TXSeq.setValue((UInt16)0);
			RXSeq.setValue((UInt16)0);
			RxGood.setValue((byte)0);
			RxCorrected.setValue((byte)0);
			RxErrors.setValue((byte)0);
			RxMissed.setValue((byte)0);
			RxFailure.setValue((byte)0);
			TxResent.setValue((byte)0);
			TxDropped.setValue((byte)0);
			TxFailure.setValue((byte)0);
			Resets.setValue((byte)0);
			Timeouts.setValue((byte)0);
			RSSI.setValue((sbyte)0);
			AFCCorrection.setValue((sbyte)0);
			LinkQuality.setValue((byte)0);
			LinkState.setValue(LinkStateUavEnum.Disconnected);
			PairSignalStrengths.setValue((sbyte)-127,0);
			PairSignalStrengths.setValue((sbyte)-127,1);
			PairSignalStrengths.setValue((sbyte)-127,2);
			PairSignalStrengths.setValue((sbyte)-127,3);
		}

		/**
		 * Create a clone of this object, a new instance ID must be specified.
		 * Do not use this function directly to create new instances, the
		 * UAVObjectManager should be used instead.
		 */
		public override UAVDataObject clone(long instID) {
			// TODO: Need to get specific instance to clone
			try {
				OPLinkStatus obj = new OPLinkStatus();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public OPLinkStatus GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (OPLinkStatus)(objMngr.getObject(OPLinkStatus.OBJID, instID));
		}
	}
}

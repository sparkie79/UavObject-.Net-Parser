// Object ID: 3071574590
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System;
using System.ComponentModel;
 
namespace UavTalk
{
	public class I2CStats : UAVDataObject
	{
		public const long OBJID = 3071574590;
		public int NUMBYTES { get; set; }
		protected const String NAME = "I2CStats";
	    protected static String DESCRIPTION = @"Tracks statistics on the I2C bus.";
		protected const bool ISSINGLEINST = true;
		protected const bool ISSETTINGS = false;

		public UAVObjectField<UInt32> evirq_log;
		public UAVObjectField<UInt32> erirq_log;
		public UAVObjectField<byte> event_errors;
		public UAVObjectField<byte> fsm_errors;
		public UAVObjectField<byte> irq_errors;
		public UAVObjectField<byte> nacks;
		public UAVObjectField<byte> timeouts;
		public enum last_error_typeUavEnum
		{
			[Description("EVENT")]
			EVENT = 0, 
			[Description("FSM")]
			FSM = 1, 
			[Description("INTERRUPT")]
			INTERRUPT = 2, 
		}
		public UAVObjectField<last_error_typeUavEnum> last_error_type;
		public enum event_logUavEnum
		{
			[Description("I2C_EVENT_BUS_ERROR")]
			I2CEVENTBUSERROR = 0, 
			[Description("I2C_EVENT_START")]
			I2CEVENTSTART = 1, 
			[Description("I2C_EVENT_STARTED_MORE_TXN_READ")]
			I2CEVENTSTARTEDMORETXNREAD = 2, 
			[Description("I2C_EVENT_STARTED_MORE_TXN_WRITE")]
			I2CEVENTSTARTEDMORETXNWRITE = 3, 
			[Description("I2C_EVENT_STARTED_LAST_TXN_READ")]
			I2CEVENTSTARTEDLASTTXNREAD = 4, 
			[Description("I2C_EVENT_STARTED_LAST_TXN_WRITE")]
			I2CEVENTSTARTEDLASTTXNWRITE = 5, 
			[Description("I2C_EVENT_ADDR_SENT_LEN_EQ_0")]
			I2CEVENTADDRSENTLENEQ0 = 6, 
			[Description("I2C_EVENT_ADDR_SENT_LEN_EQ_1")]
			I2CEVENTADDRSENTLENEQ1 = 7, 
			[Description("I2C_EVENT_ADDR_SENT_LEN_EQ_2")]
			I2CEVENTADDRSENTLENEQ2 = 8, 
			[Description("I2C_EVENT_ADDR_SENT_LEN_GT_2")]
			I2CEVENTADDRSENTLENGT2 = 9, 
			[Description("I2C_EVENT_TRANSFER_DONE_LEN_EQ_0")]
			I2CEVENTTRANSFERDONELENEQ0 = 10, 
			[Description("I2C_EVENT_TRANSFER_DONE_LEN_EQ_1")]
			I2CEVENTTRANSFERDONELENEQ1 = 11, 
			[Description("I2C_EVENT_TRANSFER_DONE_LEN_EQ_2")]
			I2CEVENTTRANSFERDONELENEQ2 = 12, 
			[Description("I2C_EVENT_TRANSFER_DONE_LEN_GT_2")]
			I2CEVENTTRANSFERDONELENGT2 = 13, 
			[Description("I2C_EVENT_NACK")]
			I2CEVENTNACK = 14, 
			[Description("I2C_EVENT_STOPPED")]
			I2CEVENTSTOPPED = 15, 
			[Description("I2C_EVENT_AUTO")]
			I2CEVENTAUTO = 16, 
		}
		public UAVObjectField<event_logUavEnum> event_log;
		public enum state_logUavEnum
		{
			[Description("I2C_STATE_FSM_FAULT")]
			I2CSTATEFSMFAULT = 0, 
			[Description("I2C_STATE_BUS_ERROR")]
			I2CSTATEBUSERROR = 1, 
			[Description("I2C_STATE_STOPPED")]
			I2CSTATESTOPPED = 2, 
			[Description("I2C_STATE_STOPPING")]
			I2CSTATESTOPPING = 3, 
			[Description("I2C_STATE_STARTING")]
			I2CSTATESTARTING = 4, 
			[Description("I2C_STATE_R_MORE_TXN_ADDR")]
			I2CSTATERMORETXNADDR = 5, 
			[Description("I2C_STATE_R_MORE_TXN_PRE_ONE")]
			I2CSTATERMORETXNPREONE = 6, 
			[Description("I2C_STATE_R_MORE_TXN_PRE_FIRST")]
			I2CSTATERMORETXNPREFIRST = 7, 
			[Description("I2C_STATE_R_MORE_TXN_PRE_MIDDLE")]
			I2CSTATERMORETXNPREMIDDLE = 8, 
			[Description("I2C_STATE_R_MORE_TXN_LAST")]
			I2CSTATERMORETXNLAST = 9, 
			[Description("I2C_STATE_R_MORE_TXN_POST_LAST")]
			I2CSTATERMORETXNPOSTLAST = 10, 
			[Description("R_LAST_TXN_ADDR")]
			RLASTTXNADDR = 11, 
			[Description("I2C_STATE_R_LAST_TXN_PRE_ONE")]
			I2CSTATERLASTTXNPREONE = 12, 
			[Description("I2C_STATE_R_LAST_TXN_PRE_FIRST")]
			I2CSTATERLASTTXNPREFIRST = 13, 
			[Description("I2C_STATE_R_LAST_TXN_PRE_MIDDLE")]
			I2CSTATERLASTTXNPREMIDDLE = 14, 
			[Description("I2C_STATE_R_LAST_TXN_PRE_LAST")]
			I2CSTATERLASTTXNPRELAST = 15, 
			[Description("I2C_STATE_R_LAST_TXN_POST_LAST")]
			I2CSTATERLASTTXNPOSTLAST = 16, 
			[Description("I2C_STATE_W_MORE_TXN_ADDR")]
			I2CSTATEWMORETXNADDR = 17, 
			[Description("I2C_STATE_W_MORE_TXN_MIDDLE")]
			I2CSTATEWMORETXNMIDDLE = 18, 
			[Description("I2C_STATE_W_MORE_TXN_LAST")]
			I2CSTATEWMORETXNLAST = 19, 
			[Description("I2C_STATE_W_LAST_TXN_ADDR")]
			I2CSTATEWLASTTXNADDR = 20, 
			[Description("I2C_STATE_W_LAST_TXN_MIDDLE")]
			I2CSTATEWLASTTXNMIDDLE = 21, 
			[Description("I2C_STATE_W_LAST_TXN_LAST")]
			I2CSTATEWLASTTXNLAST = 22, 
			[Description("I2C_STATE_NACK")]
			I2CSTATENACK = 23, 
		}
		public UAVObjectField<state_logUavEnum> state_log;

		public I2CStats() : base (OBJID, ISSINGLEINST, ISSETTINGS, NAME)
		{
			List<UAVObjectField> fields = new List<UAVObjectField>();

			List<String> evirq_logElemNames = new List<String>();
			evirq_logElemNames.Add("0");
			evirq_logElemNames.Add("1");
			evirq_logElemNames.Add("2");
			evirq_logElemNames.Add("3");
			evirq_logElemNames.Add("4");
			evirq_log=new UAVObjectField<UInt32>("evirq_log", "", evirq_logElemNames, null, this);
			fields.Add(evirq_log);

			List<String> erirq_logElemNames = new List<String>();
			erirq_logElemNames.Add("0");
			erirq_logElemNames.Add("1");
			erirq_logElemNames.Add("2");
			erirq_logElemNames.Add("3");
			erirq_logElemNames.Add("4");
			erirq_log=new UAVObjectField<UInt32>("erirq_log", "", erirq_logElemNames, null, this);
			fields.Add(erirq_log);

			List<String> event_errorsElemNames = new List<String>();
			event_errorsElemNames.Add("0");
			event_errors=new UAVObjectField<byte>("event_errors", "", event_errorsElemNames, null, this);
			fields.Add(event_errors);

			List<String> fsm_errorsElemNames = new List<String>();
			fsm_errorsElemNames.Add("0");
			fsm_errors=new UAVObjectField<byte>("fsm_errors", "", fsm_errorsElemNames, null, this);
			fields.Add(fsm_errors);

			List<String> irq_errorsElemNames = new List<String>();
			irq_errorsElemNames.Add("0");
			irq_errors=new UAVObjectField<byte>("irq_errors", "", irq_errorsElemNames, null, this);
			fields.Add(irq_errors);

			List<String> nacksElemNames = new List<String>();
			nacksElemNames.Add("0");
			nacks=new UAVObjectField<byte>("nacks", "", nacksElemNames, null, this);
			fields.Add(nacks);

			List<String> timeoutsElemNames = new List<String>();
			timeoutsElemNames.Add("0");
			timeouts=new UAVObjectField<byte>("timeouts", "", timeoutsElemNames, null, this);
			fields.Add(timeouts);

			List<String> last_error_typeElemNames = new List<String>();
			last_error_typeElemNames.Add("0");
			List<String> last_error_typeEnumOptions = new List<String>();
			last_error_typeEnumOptions.Add("EVENT");
			last_error_typeEnumOptions.Add("FSM");
			last_error_typeEnumOptions.Add("INTERRUPT");
			last_error_type=new UAVObjectField<last_error_typeUavEnum>("last_error_type", "", last_error_typeElemNames, last_error_typeEnumOptions, this);
			fields.Add(last_error_type);

			List<String> event_logElemNames = new List<String>();
			event_logElemNames.Add("0");
			event_logElemNames.Add("1");
			event_logElemNames.Add("2");
			event_logElemNames.Add("3");
			event_logElemNames.Add("4");
			List<String> event_logEnumOptions = new List<String>();
			event_logEnumOptions.Add("I2C_EVENT_BUS_ERROR");
			event_logEnumOptions.Add("I2C_EVENT_START");
			event_logEnumOptions.Add("I2C_EVENT_STARTED_MORE_TXN_READ");
			event_logEnumOptions.Add("I2C_EVENT_STARTED_MORE_TXN_WRITE");
			event_logEnumOptions.Add("I2C_EVENT_STARTED_LAST_TXN_READ");
			event_logEnumOptions.Add("I2C_EVENT_STARTED_LAST_TXN_WRITE");
			event_logEnumOptions.Add("I2C_EVENT_ADDR_SENT_LEN_EQ_0");
			event_logEnumOptions.Add("I2C_EVENT_ADDR_SENT_LEN_EQ_1");
			event_logEnumOptions.Add("I2C_EVENT_ADDR_SENT_LEN_EQ_2");
			event_logEnumOptions.Add("I2C_EVENT_ADDR_SENT_LEN_GT_2");
			event_logEnumOptions.Add("I2C_EVENT_TRANSFER_DONE_LEN_EQ_0");
			event_logEnumOptions.Add("I2C_EVENT_TRANSFER_DONE_LEN_EQ_1");
			event_logEnumOptions.Add("I2C_EVENT_TRANSFER_DONE_LEN_EQ_2");
			event_logEnumOptions.Add("I2C_EVENT_TRANSFER_DONE_LEN_GT_2");
			event_logEnumOptions.Add("I2C_EVENT_NACK");
			event_logEnumOptions.Add("I2C_EVENT_STOPPED");
			event_logEnumOptions.Add("I2C_EVENT_AUTO");
			event_log=new UAVObjectField<event_logUavEnum>("event_log", "", event_logElemNames, event_logEnumOptions, this);
			fields.Add(event_log);

			List<String> state_logElemNames = new List<String>();
			state_logElemNames.Add("0");
			state_logElemNames.Add("1");
			state_logElemNames.Add("2");
			state_logElemNames.Add("3");
			state_logElemNames.Add("4");
			List<String> state_logEnumOptions = new List<String>();
			state_logEnumOptions.Add("I2C_STATE_FSM_FAULT");
			state_logEnumOptions.Add("I2C_STATE_BUS_ERROR");
			state_logEnumOptions.Add("I2C_STATE_STOPPED");
			state_logEnumOptions.Add("I2C_STATE_STOPPING");
			state_logEnumOptions.Add("I2C_STATE_STARTING");
			state_logEnumOptions.Add("I2C_STATE_R_MORE_TXN_ADDR");
			state_logEnumOptions.Add("I2C_STATE_R_MORE_TXN_PRE_ONE");
			state_logEnumOptions.Add("I2C_STATE_R_MORE_TXN_PRE_FIRST");
			state_logEnumOptions.Add("I2C_STATE_R_MORE_TXN_PRE_MIDDLE");
			state_logEnumOptions.Add("I2C_STATE_R_MORE_TXN_LAST");
			state_logEnumOptions.Add("I2C_STATE_R_MORE_TXN_POST_LAST");
			state_logEnumOptions.Add("R_LAST_TXN_ADDR");
			state_logEnumOptions.Add("I2C_STATE_R_LAST_TXN_PRE_ONE");
			state_logEnumOptions.Add("I2C_STATE_R_LAST_TXN_PRE_FIRST");
			state_logEnumOptions.Add("I2C_STATE_R_LAST_TXN_PRE_MIDDLE");
			state_logEnumOptions.Add("I2C_STATE_R_LAST_TXN_PRE_LAST");
			state_logEnumOptions.Add("I2C_STATE_R_LAST_TXN_POST_LAST");
			state_logEnumOptions.Add("I2C_STATE_W_MORE_TXN_ADDR");
			state_logEnumOptions.Add("I2C_STATE_W_MORE_TXN_MIDDLE");
			state_logEnumOptions.Add("I2C_STATE_W_MORE_TXN_LAST");
			state_logEnumOptions.Add("I2C_STATE_W_LAST_TXN_ADDR");
			state_logEnumOptions.Add("I2C_STATE_W_LAST_TXN_MIDDLE");
			state_logEnumOptions.Add("I2C_STATE_W_LAST_TXN_LAST");
			state_logEnumOptions.Add("I2C_STATE_NACK");
			state_log=new UAVObjectField<state_logUavEnum>("state_log", "", state_logElemNames, state_logEnumOptions, this);
			fields.Add(state_log);

	

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
				I2CStats obj = new I2CStats();
				obj.initialize(instID, this.getMetaObject());
				return obj;
			} catch  (Exception) {
				return null;
			}
		}

		/**
		 * Static function to retrieve an instance of the object.
		 */
		public I2CStats GetInstance(UAVObjectManager objMngr, long instID)
		{
			return (I2CStats)(objMngr.getObject(I2CStats.OBJID, instID));
		}
	}
}

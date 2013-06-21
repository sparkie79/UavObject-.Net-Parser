using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UavTalk.enums;

namespace UavTalk
{
    public class Metadata
    {
        public const int UAVOBJ_ACCESS_SHIFT = 0;
        public const int UAVOBJ_GCS_ACCESS_SHIFT = 1;
        public const int UAVOBJ_TELEMETRY_ACKED_SHIFT = 2;
        public const int UAVOBJ_GCS_TELEMETRY_ACKED_SHIFT = 3;
        public const int UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT = 4;
        public const int UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT = 6;
        public const int UAVOBJ_UPDATE_MODE_MASK = 0x3;

        /**
         * Object metadata, each object has a meta object that holds its metadata. The metadata define
         * properties for each object and can be used by multiple modules (e.g. telemetry and logger)
         *
         * The object metadata flags are packed into a single 16 bit integer.
         * The bits in the flag field are defined as:
         *
         *   Bit(s)  Name                       Meaning
         *   ------  ----                       -------
         *      0    access                     Defines the access level for the local transactions (readonly=0 and readwrite=1)
         *      1    gcsAccess                  Defines the access level for the local GCS transactions (readonly=0 and readwrite=1), not used in the flight s/w
         *      2    telemetryAcked             Defines if an ack is required for the transactions of this object (1:acked, 0:not acked)
         *      3    gcsTelemetryAcked          Defines if an ack is required for the transactions of this object (1:acked, 0:not acked)
         *    4-5    telemetryUpdateMode        Update mode used by the telemetry module (UAVObjUpdateMode)
         *    6-7    gcsTelemetryUpdateMode     Update mode used by the GCS (UAVObjUpdateMode)
         */
        public int flags; /** Defines flags for update and logging modes and whether an update should be ACK'd (bits defined above) */

        /** Update period used by the telemetry module (only if telemetry mode is PERIODIC) */
        public int flightTelemetryUpdatePeriod;

        /** Update period used by the GCS (only if telemetry mode is PERIODIC) */
        public int gcsTelemetryUpdatePeriod;

        /** Update period used by the GCS (only if telemetry mode is PERIODIC) */
        public int loggingUpdatePeriod;
        /**
         * Update period used by the logging module (only if logging mode is
         * PERIODIC)
         */

        /**
         * @brief Helper method for metadata accessors
         * @param var The starting value
         * @param shift The offset of these bits
         * @param value The new value
         * @param mask The mask of these bits
         * @return
         */
        private void SET_BITS(int shift, int value, int mask)
        {
            flags = (flags & ~(mask << shift)) | (value << shift);
        }

        /**
         * Get the UAVObject metadata access member
         * \return the access type
         */
        public AccessMode GetFlightAccess()
        {
            return AccessModeEnum((flags >> UAVOBJ_ACCESS_SHIFT) & 1);
        }

        /**
         * Set the UAVObject metadata access member
         * \param[in] mode The access mode
         */
        public void SetFlightAccess(Metadata metadata, AccessMode mode)
        {
            // Need to convert java enums which have no numeric value to bits
            SET_BITS(UAVOBJ_ACCESS_SHIFT, AccessModeNum(mode), 1);
        }

        /**
         * Get the UAVObject metadata GCS access member
         * \return the GCS access type
         */
        public AccessMode GetGcsAccess()
        {
            return AccessModeEnum((flags >> UAVOBJ_GCS_ACCESS_SHIFT) & 1);
        }

        /**
         * Set the UAVObject metadata GCS access member
         * \param[in] mode The access mode
         */
        public void SetGcsAccess(Metadata metadata, AccessMode mode)
        {
            // Need to convert java enums which have no numeric value to bits
            SET_BITS(UAVOBJ_GCS_ACCESS_SHIFT, AccessModeNum(mode), 1);
        }

        /**
         * Get the UAVObject metadata telemetry acked member
         * \return the telemetry acked bool
         */
        public bool GetFlightTelemetryAcked()
        {
            return (((flags >> UAVOBJ_TELEMETRY_ACKED_SHIFT) & 1) == 1);
        }

        /**
         * Set the UAVObject metadata telemetry acked member
         * \param[in] val The telemetry acked bool
         */
        public void SetFlightTelemetryAcked(bool val)
        {
            SET_BITS(UAVOBJ_TELEMETRY_ACKED_SHIFT, val ? 1 : 0, 1);
        }

        /**
         * Get the UAVObject metadata GCS telemetry acked member
         * \return the telemetry acked bool
         */
        public bool GetGcsTelemetryAcked()
        {
            return ((flags >> UAVOBJ_GCS_TELEMETRY_ACKED_SHIFT) & 1) == 1;
        }

        /**
         * Set the UAVObject metadata GCS telemetry acked member
         * \param[in] val The GCS telemetry acked bool
         */
        public void SetGcsTelemetryAcked(bool val)
        {
            SET_BITS(UAVOBJ_GCS_TELEMETRY_ACKED_SHIFT, val ? 1 : 0, 1);
        }

        /**
         * Maps from the bitfield number to the symbolic java enumeration
         * @param num The value in the bitfield after shifting
         * @return The update mode
         */
        public AccessMode AccessModeEnum(int num)
        {
            switch (num)
            {
                case 0:
                    return AccessMode.ACCESS_READONLY;
                case 1:
                    return AccessMode.ACCESS_READWRITE;
            }
            return AccessMode.ACCESS_READONLY;
        }

        /**
         * Maps from the java symbolic enumeration of update mode to the bitfield value
         * @param e The update mode
         * @return The numeric value to use on the wire
         */
        public int AccessModeNum(AccessMode e)
        {
            switch (e)
            {
                case AccessMode.ACCESS_READONLY:
                    return 0;
                case AccessMode.ACCESS_READWRITE:
                    return 1;
            }
            return 0;
        }

        /**
         * Maps from the bitfield number to the symbolic java enumeration
         * @param num The value in the bitfield after shifting
         * @return The update mode
         */
        public UpdateMode UpdateModeEnum(int num)
        {
            switch (num)
            {
                case 0:
                    return UpdateMode.UPDATEMODE_MANUAL;
                case 1:
                    return UpdateMode.UPDATEMODE_PERIODIC;
                case 2:
                    return UpdateMode.UPDATEMODE_ONCHANGE;
                default:
                    return UpdateMode.UPDATEMODE_THROTTLED;
            }
        }

        /**
         * Maps from the java symbolic enumeration of update mode to the bitfield value
         * @param e The update mode
         * @return The numeric value to use on the wire
         */
        public int UpdateModeNum(UpdateMode e)
        {
            switch (e)
            {
                case UpdateMode.UPDATEMODE_MANUAL:
                    return 0;
                case UpdateMode.UPDATEMODE_PERIODIC:
                    return 1;
                case UpdateMode.UPDATEMODE_ONCHANGE:
                    return 2;
                case UpdateMode.UPDATEMODE_THROTTLED:
                    return 3;
            }
            return 0;
        }

        /**
         * Get the UAVObject metadata telemetry update mode
         * \return the telemetry update mode
         */
        public UpdateMode GetFlightTelemetryUpdateMode()
        {
            return UpdateModeEnum((flags >> UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT) & UAVOBJ_UPDATE_MODE_MASK);
        }

        /**
         * Set the UAVObject metadata telemetry update mode member
         * \param[in] metadata The metadata object
         * \param[in] val The telemetry update mode
         */
        public void SetFlightTelemetryUpdateMode(UpdateMode val)
        {
            SET_BITS(UAVOBJ_TELEMETRY_UPDATE_MODE_SHIFT, UpdateModeNum(val), UAVOBJ_UPDATE_MODE_MASK);
        }

        /**
         * Get the UAVObject metadata GCS telemetry update mode
         * \param[in] metadata The metadata object
         * \return the GCS telemetry update mode
         */
        public UpdateMode GetGcsTelemetryUpdateMode()
        {
            return UpdateModeEnum((flags >> UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT) & UAVOBJ_UPDATE_MODE_MASK);
        }

        /**
         * Set the UAVObject metadata GCS telemetry update mode member
         * \param[in] metadata The metadata object
         * \param[in] val The GCS telemetry update mode
         */
        public void SetGcsTelemetryUpdateMode(UpdateMode val)
        {
            SET_BITS(UAVOBJ_GCS_TELEMETRY_UPDATE_MODE_SHIFT, UpdateModeNum(val), UAVOBJ_UPDATE_MODE_MASK);
        }

    };
}

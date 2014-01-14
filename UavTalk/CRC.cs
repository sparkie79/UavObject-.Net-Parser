using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UavTalk
{
    public static class CRC
    {
        public static int updateCRC(int crc, int data)
        {
            return uavConsts.crc_table[crc ^ (data & 0xff)];
        }

        public static int updateCRC(int crc, byte[] data, int length)
        {
            for (int i = 0; i < length; i++)
                crc = updateCRC(crc, data[i]);
            return crc;
        }
    }
}

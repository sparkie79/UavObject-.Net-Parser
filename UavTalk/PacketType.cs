using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UavTalk
{
    public enum PacketType
    {
        OBJ = 0x20,
        OBJ_REQ = 0x21,
        OBJ_ACK = 0x22,
        ACK = 0x23,
        NACK = 0x24
    }
}

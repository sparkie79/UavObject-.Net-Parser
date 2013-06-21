using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UavTalk
{
    public class UavPacket
    {
        public PacketType MessageType { get; set; }
        public byte protocolVersion { get; set; }
        public ushort length { get; set; }
        public UInt32 ObjId { get; set; }
        public ushort InstanceID { get; set; }
        public byte[] data;
        public byte checkSum { get; set; }
    }
}

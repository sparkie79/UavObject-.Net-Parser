using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UavTalk
{
    public class ByteBuffer
    {
        MemoryStream stream = new MemoryStream();
        BinaryReader rd;
        BinaryWriter wr;
        byte[] buf;

        public ByteBuffer(int size)
        {
            buf = new byte[size];
            stream = new MemoryStream(buf);
            wr = new BinaryWriter(stream);
            rd = new BinaryReader(stream);
        }

        public void write(byte data)
        {
            wr.Write(data);
        }

        public void write(byte[] data)
        {
            wr.Write(data);
        }

        public void position(int position)
        {
            wr.Seek(position, SeekOrigin.Begin);
        }

        public void put(int position, byte data)
        {
            wr.Seek(position, SeekOrigin.Begin);
            wr.Write(data);
        }

        internal UInt32 getInt(int position)
        {
            stream.Seek(position, SeekOrigin.Begin);
            return rd.ReadUInt32();
        }

        internal UInt16 getShort(int position)
        {
            stream.Seek(position, SeekOrigin.Begin);
            return rd.ReadUInt16();
        }

        internal void put(byte p)
        {
            wr.Write(p);
        }

        internal void putShort(UInt16 p)
        {
            wr.Write(p);
        }

        internal void putUint32(UInt32 p)
        {
            wr.Write(p);
        }

        internal byte[] array()
        {
            return buf;
        }

        internal int position()
        {
            return (int)stream.Position;
        }

        internal void get(byte[] dst, int p, int packlen)
        {
            int count = 0;
            for (int i = p; count < packlen; i++)
                dst[count++] = buf[i];
        }

        internal void put<T>(Object value)
        {
            if (value.GetType() == typeof(byte))
                wr.Write((byte)value);
            else if (value.GetType() == typeof(UInt16))
                wr.Write((UInt16)value);
            else if (value.GetType() == typeof(UInt32))
                wr.Write((UInt32)value);
            else if (value.GetType() == typeof(UInt32))
                wr.Write((UInt32)value);
            else if (value.GetType() == typeof(sbyte))
                wr.Write((byte)value);
            else if (value.GetType() == typeof(Int16))
                wr.Write((Int16)value);
            else if (value.GetType() == typeof(Int32))
                wr.Write((Int32)value);
            else if (value.GetType() == typeof(float))
                wr.Write((float)value);
            else if (value.GetType().Name.EndsWith("UavEnum"))
            {
                byte val = (byte)((int)value);
                wr.Write((byte)val);
            }
            else throw new ArgumentOutOfRangeException();
        }

        internal T get<T>()
        {
            if (typeof(T) == typeof(byte))
                return (dynamic)rd.ReadByte();
            if (typeof(T) == typeof(UInt16))
                return (dynamic)rd.ReadUInt16();
            if (typeof(T) == typeof(UInt32))
                return (dynamic)rd.ReadUInt32();
            if (typeof(T) == typeof(sbyte))
                return (dynamic)rd.ReadSByte();
            if (typeof(T) == typeof(UInt32))
                return (dynamic)rd.ReadUInt32();
            if (typeof(T) == typeof(Int16))
                return (dynamic)rd.ReadInt16();
            if (typeof(T) == typeof(Int32))
                return (dynamic)rd.ReadInt32();
            if (typeof(T) == typeof(float))
                return (dynamic)rd.ReadSingle();
            if (typeof(T) == typeof(bool))
                return (dynamic)(rd.ReadByte() > 0);
            if (typeof(T).Name.EndsWith("UavEnum"))
                return (dynamic)Enum.Parse(typeof(T),rd.ReadByte().ToString());
            return (dynamic)0;
        }
    }
}

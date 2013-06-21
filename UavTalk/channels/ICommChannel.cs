using System;
namespace UavTalk
{
    public interface ICommChannel
    {
        bool close();
        event SerialChannel.onDataReceivedDelegate onDataReceived;
        bool open();
        bool write(byte[] data);
    }
}

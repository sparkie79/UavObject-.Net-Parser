using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UavTalk
{
    public class SerialChannel : ICommChannel
    {
        public delegate void onDataReceivedDelegate(byte[] data);
        public event onDataReceivedDelegate onDataReceived;

        private SerialPort _port;

        public SerialChannel(string port, int baudRate)
        {
            _port = new SerialPort(port, baudRate);
            _port.ReceivedBytesThreshold = 1;
            _port.DataReceived += _port_DataReceived;
        }

        void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType == SerialData.Chars)
            {
                int count = _port.BytesToRead;
                byte[] data = new byte[count];
                _port.Read(data, 0, count);
                if (onDataReceived != null)
                {
                    onDataReceived(data);
                }
            }
        }

        public bool open()
        {
            try
            {
                _port.Open();
            }
            catch { return false; }
            return true;
        }

        public bool close()
        {
            if (!_port.IsOpen)
                return true;
            try
            {
                _port.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool write(byte[] data)
        {
            try
            {
                _port.Write(data,0, data.Length);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}

using HidLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UavTalk
{
    class HidChannel : ICommChannel
    {
        private int _isReading;

        HidLibrary.HidDevice dev;
        public HidChannel(int vid, int pid)
        {
            dev = HidDevices.Enumerate(vid, pid).FirstOrDefault();
                                    
            //usb.OnSpecifiedDeviceArrived += usb_OnSpecifiedDeviceArrived;
            //usb.OnDataRecieved += usb_OnDataRecieved;
        }

        void usb_OnDataRecieved(object sender, UsbLibrary.DataRecievedEventArgs args)
        {
            if (onDataReceived != null)
                onDataReceived(args.data);
        }

        void usb_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            
        }

        public bool close()
        {
            throw new NotImplementedException();
        }

        public event SerialChannel.onDataReceivedDelegate onDataReceived;

        private void BeginReadReport()
        {
            if (Interlocked.CompareExchange(ref _isReading, 1, 0) == 1) return;
            dev.ReadReport(ReadReport);
        }

        private void ReadReport(HidReport report)
        {
            if (onDataReceived != null && report.ReadStatus == HidDeviceData.ReadStatus.Success)
            {
                int length = report.Data[0];
                byte[] data = new byte[length];
                Array.Copy(report.Data, 1, data, 0, length);
                onDataReceived(data);
            }
            dev.ReadReport(ReadReport);
        }

        public bool open()
        {
            dev.OpenDevice(HidDevice.DeviceMode.NonOverlapped, HidDevice.DeviceMode.NonOverlapped);
            BeginReadReport();
            return true;
        }

        const int maxSize = 64;
        public bool write(byte[] data)
        {
            int count = 0; int size = data.Length;
            if (!dev.IsConnected)
                return false;

            while (size > 0)
            {
                int byteToWrite = Math.Min(maxSize - 2, size); 
                HidReport rp = new HidReport(byteToWrite + 2);
                rp.ReportId = 2;
                Array.Copy(data, count, rp.Data, 1, byteToWrite);
                rp.Data[0] = (byte)byteToWrite;
                size -= byteToWrite;
                count += byteToWrite;
                bool rv;
                rv = dev.WriteReport(rp);
            }
            
            return true;
        }
    }
}

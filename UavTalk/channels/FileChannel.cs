using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UavTalk.channels
{
    public class FileChannel : ICommChannel
    {
        private Thread readThread;
        private FileStream reader;
        private string filename;
        public EventHandler fileclosed;

        public FileChannel(string file)
        {
            filename = file;
        }

        public bool close()
        {
            reader.Close();
            if (fileclosed != null)
                fileclosed(this, null);

            return true;
        }

        public event SerialChannel.onDataReceivedDelegate onDataReceived;

        public bool open()
        {
            //reader = File.OpenRead(@"C:\Users\spark_000\Google Drive\Mimmo\cc3d\TauLabs-2013-05-12_14-22-58.tll");
            reader = File.OpenRead(filename);
            
            readThread = new Thread(new ThreadStart(readTask));
            readThread.Start();
            return true;
        }

        private void readTask()
        {
            byte[] data = new byte[10];
            int count;
            while ((count = reader.Read(data, 0, 10)) > 0)
            {
                if (onDataReceived != null)
                    onDataReceived(data);
            }
            close();
        }

        public bool write(byte[] data)
        {
            return true;
        }

        public bool isRunning { get { return readThread.IsAlive; } }
    }
}

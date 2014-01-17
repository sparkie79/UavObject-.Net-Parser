using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UavTalk;
using System.Threading;
using UavTalk.channels;
using SharpKml.Dom;
using SharpKml.Base;

using csmatio.types;
using csmatio.io;

namespace ConsoleTest
{
    class Program
    {
        static TextWriter wr;
        static Dictionary<UAVObjectField, object> fields = new Dictionary<UAVObjectField, object>();
     
        static CoordinateCollection coords = new CoordinateCollection();

        static MLStructure getStructure(IEnumerable<UAVObject> data, Type type)
        {
            int rowCount = data.Count();
            MLStructure structure = new MLStructure(type.Name, new int[] { 1, 1 });
            var timestamp = data.Select(k => k.timestamp).ToArray();
            structure["timestamp"] = new MLUInt32("", timestamp, rowCount);

            foreach (var prop in type.GetFields().Where(j => j.FieldType.BaseType == typeof(UAVObjectField)))
            {
                string name = prop.Name;
                double[] fieldata = data.Select( k=> Convert.ToDouble(((UAVObjectField)prop.GetValue(k)).getValue(0))).ToArray();
                structure[name] = new MLDouble("", fieldata, rowCount);
            }
            return structure;
        }

        static void Main(string[] args)
        {
            /*exportKml(
                @"C:\Users\mimmo\Downloads\taulabs_next_20130622_124410_7c6e38b8d5_win32\gcs\bin\TauLabs-2013-09-12_18-56-07.tll",
                @"C:\Users\mimmo\Downloads\taulabs_next_20130622_124410_7c6e38b8d5_win32\gcs\bin\TauLabs-2013-09-12_18-56-07.tll.kml"
            );*/
            //analyzeMagData();
            exportMagData();
        }

        static void exportMatlabTest()
        {
            UAVObjectManager mgr = new UAVObjectManager();
            UAVObjectsInitialize.register(mgr);
            UavLogReader rd = new UavLogReader(mgr);
            var data = rd.parseFile(@"C:\Users\mimmo\Desktop\xports\OP-2014-01-13_22-17-14.opl");

            IEnumerable<AccelSensor> mags = data.OfType<AccelSensor>().Where(k => k.temperature.value < 37);
            var gyro = data.OfType<GyroSensor>().Where(k => k.temperature.value < 37);

            List<MLArray> data1 = new List<MLArray>();
            foreach (var type in data.Select(k => k.GetType()).Distinct().OrderBy(k => k.Name))
            {
                IEnumerable<UAVObject> qq = data.Where(k => k.GetType() == type);
                data1.Add(getStructure(qq, type));
            }

            MatFileWriter mfw = new MatFileWriter(@"C:\Users\mimmo\Desktop\xports\test2.mat", data1, true);
        }

        static void exportKml(string filename, string outputFile)
        {
            Document kml = new Document();


            FileChannel ch = new FileChannel(filename);
            UAVObjectManager mgr = new UAVObjectManager();
            UAVObjectsInitialize.register(mgr);
            UavTalk.UavTalkProto tlk = new UavTalkProto(ch, mgr);
            mgr.getObject<GPSPositionSensor>().onUpdated += new EventHandler(GpsPositionReceived);
            mgr.getObject<PositionState>().onUpdated += new EventHandler(GpsPositionReceived);

            ch.open();
            while (ch.isRunning)
                Thread.Sleep(50);


            LineString ls = new LineString();

            ls.AltitudeMode = SharpKml.Dom.AltitudeMode.Absolute;
            ls.Extrude = true;
            ls.Coordinates = coords;

            Placemark pm = new Placemark();

            pm.Name = "Flight Path ";
            //pm.StyleUrl = new Uri("#yellowLineGreenPoly", UriKind.Relative);
            pm.Geometry = ls;

            kml.AddFeature(pm);
            
            Serializer serializer = new Serializer();
            serializer.Serialize(kml);

            StreamWriter sw = new StreamWriter(outputFile);
            sw.Write(serializer.Xml);
            sw.Close();
        }

        static GPSPositionSensor refPosition = null;
        static void GpsPositionReceived(object sender, EventArgs e)
        {
            if (sender is GPSPositionSensor && refPosition == null)
            {
                if ((int)((GPSPositionSensor)sender).Latitude.value != 0)
                    refPosition = (GPSPositionSensor)sender;
            }
            else if (sender is PositionState && refPosition != null)
            {
                PositionState pos = (PositionState)sender;

                coords.Add(new SharpKml.Base.Vector(
                    Convert.ToDouble((int)refPosition.Latitude.value + (float)pos.East.value) / 10000000f,
                    Convert.ToDouble((int)refPosition.Longitude.value + (float)pos.North.value) / 10000000f,
                    Convert.ToDouble(140f - Convert.ToDouble(pos.Down.value)))
                );

            }

            
            
            
        }

        static void test3()
        {

        }


        static void registerData(IEnumerable<UAVObjectField> field_items)
        {
            foreach (var item in field_items)
                fields.Add(item, null);
        }

        static void exportMagData()
        {
            UAVObjectManager mgr = new UAVObjectManager();
            UAVObjectsInitialize.register(mgr);
            UavLogReader reader = new UavLogReader(mgr);
            var objects = reader.parseFile(@"C:\OpenPilot\build\openpilotgcs_release\bin\OP-2013-12-31_15-54-42.opl");
            //var objects = reader.parseFile(@"C:\Users\mimmo\Desktop\xports\OP-2014-01-09_23-43-28.opl");
            wr = File.CreateText(@"..\..\output\magdata.csv");
            wr.WriteLine("timestamp;x;y;z;");
            foreach (MagState item in objects.OfType<MagState>().OrderBy(l=>l.timestamp))
            {
                wr.WriteLine("{0};{1};{2};{3};", item.timestamp, item.x.value, item.y.value, item.z.value);
            }
            wr.Close();    
            
        }

        static void test1()
        {
            HidChannel ch = new HidChannel(0x20A0, 0x415C);
            UAVObjectManager mgr = new UAVObjectManager();
            UAVObjectsInitialize.register(mgr);
            UavTalk.UavTalkProto tlk = new UavTalkProto(ch, mgr);
            ch.open();
            tlk.sendObjectRequest(mgr.getObject<OPLinkSettings>(), false);
            while (true)
            {
                var obj = mgr.getObject<OPLinkSettings>();
                obj.CoordID.setValue((uint)0xE4C1B293);
                tlk.sendObject(obj, false, false);
                //tlk.sendObjectRequest(mgr.getObject<SystemStats>(),false);
                Thread.Sleep(2000);
            }

        }
        
        static List<UAVObject> receivedItems = new List<UAVObject>();
        static void uo_onUpdated1(object sender, EventArgs e)
        {
            UAVObject uav = (UAVObject)sender;
            receivedItems.Add(uav);
        }
    }
}

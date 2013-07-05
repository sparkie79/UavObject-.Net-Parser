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

namespace ConsoleTest
{
    class Program
    {
        static TextWriter wr;
        static Dictionary<UAVObjectField, object> fields = new Dictionary<UAVObjectField, object>();
        
        static CoordinateCollection coords = new CoordinateCollection();

        static void Main(string[] args)
        {
            exportKml(@"C:\Users\mimmo\Google Drive\TauLabs-2013-07-04_19-02-10.tll", @"C:\Users\mimmo\Google Drive\TauLabs-2013-07-04_19-02-10.tll.xml");
        }

        static void exportKml(string filename, string outputFile)
        {
            Document kml = new Document();


            FileChannel ch = new FileChannel(filename);
            UAVObjectManager mgr = new UAVObjectManager();
            UAVObjectsInitialize.register(mgr);
            UavTalk.UavTalkProto tlk = new UavTalkProto(ch, mgr);
            mgr.getObject<GPSPosition>().onUpdated += new EventHandler(GpsPositionReceived);
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

        static void GpsPositionReceived(object sender, EventArgs e)
        {
            GPSPosition pos = (GPSPosition)sender;
            
            coords.Add(new Vector(
                Convert.ToDouble(pos.Latitude.getValue()) / 10000000f,
                Convert.ToDouble(pos.Longitude.getValue()) / 10000000f,
                Convert.ToDouble(pos.Altitude.getValue())
                ));
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
        // open a log file and export desired objects to csv
        static void test()
        {
            //SerialChannel ch = new SerialChannel("com11", 57600);
            //idChannel1 ch = new HidChannel1(0x20A0,0x415B);
            //HidChannel1 ch = new HidChannel1(0x20A0, 0x415C);

            FileChannel ch = new FileChannel(@"C:\Users\mimmo\Google Drive\TauLabs-2013-06-18_18-44-06.tll");
            UAVObjectManager mgr = new UAVObjectManager();
            UAVObjectsInitialize.register(mgr);
            UavTalkProto tlk = new UavTalkProto(ch, mgr);

            // export altitude data
            /*fields.Add(mgr.getObject<BaroAltitude>().Pressure, null);
            fields.Add(mgr.getObject<BaroAltitude>().Temperature, null);
            fields.Add(mgr.getObject<BaroAltitude>().Altitude, null);
            fields.Add(mgr.getObject<AltitudeHoldDesired>().Altitude, null);
            fields.Add(mgr.getObject<AltitudeHoldDesired>().Pitch, null);
            fields.Add(mgr.getObject<AltHoldSmoothed>().Altitude, null);
            fields.Add(mgr.getObject<AltHoldSmoothed>().Velocity, null);
            fields.Add(mgr.getObject<AltHoldSmoothed>().Accel, null);*/

            // export magnetometer data
            fields.Add(mgr.getObject<Magnetometer>().x, null);
            fields.Add(mgr.getObject<Magnetometer>().y, null);
            fields.Add(mgr.getObject<Magnetometer>().z, null);
            fields.Add(mgr.getObject<AttitudeActual>().Yaw, null);

            // export attitude data
            /*fields.Add(mgr.getObject<AttitudeActual>().Pitch, null);
            fields.Add(mgr.getObject<AttitudeActual>().Roll, null);
            fields.Add(mgr.getObject<ActuatorDesired>().Pitch, null);
            fields.Add(mgr.getObject<ActuatorDesired>().Roll, null);*/

            // export battery data
            /*fields.Add(mgr.getObject<FlightBatteryState>().Current,null);
            fields.Add(mgr.getObject<FlightBatteryState>().Voltage, null);
            fields.Add(mgr.getObject<FlightBatteryState>().ConsumedEnergy, null);
            fields.Add(mgr.getObject<FlightBatteryState>().EstimatedFlightTime, null);
            fields.Add(mgr.getObject<OPLinkStatus>().PairSignalStrengths, null);*/

            foreach (UAVObject uo in fields.Select(j => j.Key.parent).Distinct())
                uo.onUpdated += uo_onUpdated;

            wr = File.CreateText(@"..\..\output\magnitude3.csv");
            foreach (var item in fields)
                wr.Write(item.Key.getName() + ";");
            wr.WriteLine();

            if (!ch.open())
                return;

            while (ch.isRunning)
            {
                //tlk.sendObjectRequest(mgr.getObject<SystemStats>(),false);
                Thread.Sleep(2000);
            }
        }

        static void uo_onUpdated(object sender, EventArgs e)
        {
            UAVObject uav = (UAVObject)sender;
            foreach (var prop in uav.GetType().GetFields().Where(j => j.FieldType.BaseType == typeof(UAVObjectField)))
            {
                UAVObjectField f = (UAVObjectField)prop.GetValue(uav);
                if (fields.ContainsKey(f))
                {
                    int n = f.getNumElements();
                    if (n == 1)
                        fields[f] = f.getValue();
                    else
                    {
                        object[] vals = new object[n];
                        for (int i = 0; i < n; i++)
                            vals[i] = f.getValue(i);
                        fields[f] = vals;
                    }
                }
            }
            writeLine();
        }

        static void writeLine()
        {
            foreach (var item in fields)
            {
                if (item.Value != null)
                {
                    if (item.Value.GetType() == typeof(object[]))
                    {
                        foreach (object sitem in (object[])item.Value)
                        {
                            wr.Write(sitem.ToString() + ";");
                        }
                    }
                    else
                        wr.Write(item.Value.ToString());
                }
                wr.Write(";");
            }
            wr.WriteLine();
        }
    }
}

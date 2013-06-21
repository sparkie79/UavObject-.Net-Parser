using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using UavTalk.channels;
using System.Windows.Forms;

namespace UavTalk
{
    class Program
    {
        static TextWriter wr;
        static Dictionary<UAVObjectField, object> fields = new Dictionary<UAVObjectField, object>();
        static void Main(string[] args)
        {
            test();
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
            UavTalk tlk = new UavTalk(ch, mgr);

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
                    } else
                        wr.Write(item.Value.ToString());
                }
                wr.Write(";");
            }
            wr.WriteLine();
        }
    }
}

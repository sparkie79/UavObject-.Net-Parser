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
using Meta.Numerics.Matrices;
using Meta.Numerics;

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

            UAVObjectManager mgr = new UAVObjectManager();
            UAVObjectsInitialize.register(mgr);
            UavLogReader rd = new UavLogReader(mgr);
            var data = rd.parseFile(@"C:\Users\mimmo\Desktop\xports\OP-2014-01-13_22-17-14.opl");

            IEnumerable<AccelSensor> mags = data.OfType<AccelSensor>().Where(k => k.temperature.value < 37);
            var gyro = data.OfType<GyroSensor>().Where(k => k.temperature.value < 37);

            List<MLArray> data1 = new List<MLArray>();
            foreach (var type in data.Select(k => k.GetType()).Distinct().OrderBy(k=>k.Name))
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
                if ((int)((GPSPositionSensor)sender).Latitude.getValue() != 0)
                    refPosition = (GPSPositionSensor)sender;
            }
            else if (sender is PositionState && refPosition != null)
            {
                PositionState pos = (PositionState)sender;

                coords.Add(new SharpKml.Base.Vector(
                    Convert.ToDouble((int)refPosition.Latitude.getValue() + (float)pos.East.getValue()) / 10000000f,
                    Convert.ToDouble((int)refPosition.Longitude.getValue() + (float)pos.North.getValue()) / 10000000f,
                    Convert.ToDouble(140f - Convert.ToDouble(pos.Down.getValue())))
                );

            }

            
            
            
        }

        static void test3()
        {

        }

        static void analyzeMagData()
        {
             FileChannel ch = new FileChannel(
                @"C:\OpenPilot\build\openpilotgcs_release\bin\OP-2013-12-31_15-54-42.opl"
            );
            UAVObjectManager mgr = new UAVObjectManager();
            UAVObjectsInitialize.register(mgr);
            UavTalkProto tlk = new UavTalkProto(ch, mgr);
            mgr.getObject<MagState>().onUpdated += uo_onUpdated1;

            if (!ch.open())
                return;

            while (ch.isRunning)
            {
                //tlk.sendObjectRequest(mgr.getObject<SystemStats>(),false);
                Thread.Sleep(2000);
            }

            var magItems = getItems<MagState>();
            var points = magItems.Select(j => new Point { X = (float)j.x.getValue(), Y = (float)j.y.getValue() }).ToList();
            var ellipse = Fit(points);

            double a = ellipse[0, 0];
            double b = ellipse[1, 0];
            double c = ellipse[2, 0];
            double d = ellipse[3, 0];
            double e = ellipse[4, 0];
            double f = ellipse[5, 0];
            double h = (2 * c * d - e * b) / (b * b - 4 * a * c);
            double k = (-2 * a * h - d) / (b);

            Console.WriteLine("\nCenter Detected at ({0:0.000},{0:0.000})", h, k);
        }

        

        static void registerData(IEnumerable<UAVObjectField> field_items)
        {
            foreach (var item in field_items)
                fields.Add(item, null);
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

            FileChannel ch = new FileChannel(
                @"C:\OpenPilot\build\openpilotgcs_release\bin\OP-2013-12-31_15-54-42.opl"
            );
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
            fields.Add(mgr.getObject<MagState>().x, null);
            fields.Add(mgr.getObject<MagState>().y, null);
            fields.Add(mgr.getObject<MagState>().z, null);
            

            // export attitude data
            fields.Add(mgr.getObject<AttitudeState>().Yaw, null);
            /*fields.Add(mgr.getObject<AttitudeActual>().Roll, null);
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

            wr = File.CreateText(@"..\..\output\magdata.csv");
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

        public class Point
        {
            public double X { get; set; }
            public double Y {get; set;  }
        }

        // A x2 + Bxy + Cy2 + Dx + Ey + F = 0
        static RectangularMatrix Fit(List<Point> points)
        {
            int numPoints = points.Count;
            Meta.Numerics.Matrices.
            RectangularMatrix D1 = new RectangularMatrix(numPoints, 3);
            RectangularMatrix D2 = new RectangularMatrix(numPoints, 3);
            SquareMatrix S1 = new SquareMatrix(3);
            SquareMatrix S2 = new SquareMatrix(3);
            SquareMatrix S3 = new SquareMatrix(3);
            SquareMatrix T = new SquareMatrix(3);
            SquareMatrix M = new SquareMatrix(3);
            SquareMatrix C1 = new SquareMatrix(3);
            RectangularMatrix a1 = new RectangularMatrix(3, 1);
            RectangularMatrix a2 = new RectangularMatrix(3, 1);
            RectangularMatrix result = new RectangularMatrix(6, 1);
            RectangularMatrix temp;
 
            C1[0, 0] = 0;
            C1[0, 1] = 0;
            C1[0, 2] = 0.5;
            C1[1, 0] = 0;
            C1[1, 1] = -1;
            C1[1, 2] = 0;
            C1[2, 0] = 0.5;
            C1[2, 1] = 0;
            C1[2, 2] = 0;
 
            //2 D1 = [x .ˆ 2, x .* y, y .ˆ 2]; % quadratic part of the design matrix
            //3 D2 = [x, y, ones(size(x))]; % linear part of the design matrix
            for (int xx = 0; xx < points.Count; xx++)
            {
                Point p = points[xx];
                D1[xx, 0] = p.X * p.X;
                D1[xx, 1] = p.X * p.Y;
                D1[xx, 2] = p.Y * p.Y;
 
                D2[xx, 0] = p.X;
                D2[xx, 1] = p.Y;
                D2[xx, 2] = 1;
            }
 
            //4 S1 = D1’ * D1; % quadratic part of the scatter matrix
            temp = D1.Transpose() * D1;
            for (int xx = 0; xx < 3; xx++)
                for (int yy = 0; yy < 3; yy++)
                    S1[xx, yy] = temp[xx, yy];
 
            //5 S2 = D1’ * D2; % combined part of the scatter matrix
            temp = D1.Transpose() * D2;
            for (int xx = 0; xx < 3; xx++)
                for (int yy = 0; yy < 3; yy++)
                    S2[xx, yy] = temp[xx, yy];
 
            //6 S3 = D2’ * D2; % linear part of the scatter matrix
            temp = D2.Transpose() * D2;
            for (int xx = 0; xx < 3; xx++)
                for (int yy = 0; yy < 3; yy++)
                    S3[xx, yy] = temp[xx, yy];
 
            //7 T = - inv(S3) * S2’; % for getting a2 from a1
            T = -1 * S3.Inverse() * S2.Transpose();
             
            //8 M = S1 + S2 * T; % reduced scatter matrix
            M = S1 + S2 * T;
             
            //9 M = [M(3, <img src="http://s0.wp.com/wp-includes/images/smilies/icon_smile.gif?m=1129645325g" alt=":)" class="wp-smiley">  ./ 2; - M(2, :); M(1, <img src="http://s0.wp.com/wp-includes/images/smilies/icon_smile.gif?m=1129645325g" alt=":)" class="wp-smiley">  ./ 2]; % premultiply by inv(C1)
            M = C1 * M;
             
            //10 [evec, eval] = eig(M); % solve eigensystem
            ComplexEigensystem eigenSystem = M.Eigensystem();
 
            //11 cond = 4 * evec(1, <img src="http://s0.wp.com/wp-includes/images/smilies/icon_smile.gif?m=1129645325g" alt=":)" class="wp-smiley">  .* evec(3, <img src="http://s0.wp.com/wp-includes/images/smilies/icon_smile.gif?m=1129645325g" alt=":)" class="wp-smiley">  - evec(2, <img src="http://s0.wp.com/wp-includes/images/smilies/icon_smile.gif?m=1129645325g" alt=":)" class="wp-smiley">  .ˆ 2; % evaluate a’Ca
            //12 a1 = evec(:, find(cond > 0)); % eigenvector for min. pos. eigenvalue
            
            for (int xx = 0; xx < eigenSystem.Dimension; xx++)
            {
               Complex[] vector =  eigenSystem.Eigenvector(xx);
               Complex condition = 4 * vector[0] * vector[2] - vector[1] * vector[1];
               if (condition.Im == 0 && condition.Re > 0)
               {
                   // Solution is found
                   Console.WriteLine("\nSolution Found!");
                   for (int yy = 0; yy < vector.Count(); yy++)
                   {
                       Console.Write("{0}, ", vector[yy]);
                       a1[yy, 0] = vector[yy].Re;
                   }
               }
            }
            //13 a2 = T * a1; % ellipse coefficients
            a2 = T * a1;
 
            //14 a = [a1; a2]; % ellipse coefficients
            result[0, 0] = a1[0, 0];
            result[1, 0] = a1[1, 0];
            result[2, 0] = a1[2, 0];
            result[3, 0] = a2[0, 0];
            result[4, 0] = a2[1, 0];
            result[5, 0] = a2[2, 0];
 
            return result;
        }

        static List<UAVObject> receivedItems = new List<UAVObject>();
        static void uo_onUpdated1(object sender, EventArgs e)
        {
            UAVObject uav = (UAVObject)sender;
            receivedItems.Add(uav);
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
            writeItems();
        }

        static IEnumerable<T> getItems<T>() where T : UAVObject
        {
            foreach (var item in receivedItems)
            {
                if (item.GetType() == typeof(T))
                {
                    yield return (T)item;
                }
            }
        }

        static void writeItems()
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

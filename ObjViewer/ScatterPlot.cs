using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ILNumerics;
using ILNumerics.Drawing;
using ILNumerics.Drawing.Plotting;
using UavTalk;
using Meta.Numerics.Matrices;
using System.Diagnostics;

namespace ObjViewer
{
    public partial class ScatterPlot : Form
    {
        double[] _x, _y, _z;
        public ScatterPlot(double[] x, double[] y, double[] z)
        {
            InitializeComponent();
            _x = x; _y = y; _z = z;
            test();

        }
        ILPlotCube plot;

        public void test()
        {
            ILArray<float> data = ILMath.zeros<float>(3, _x.Length);

            for (int index = 0; index < _x.Length; index++)
            {
                data[0, index] = (float)_x[index];
                data[1, index] = (float)_y[index];
                data[2, index] = (float)_z[index];
            }

            var points = new ILPoints()
            {
                Positions = data
            };

            points.Color = null;

            plot = new ILPlotCube(twoDMode: false)
            {
                Rotation = Matrix4.Rotation(new Vector3(1, 1, 0.1f), 0.4f),
                Projection = Projection.Orthographic,
                Children = { points }
            };

            plot.Axes[0].Label.Text = "X";
            plot.Axes[1].Label.Text = "Y";
            plot.Axes[2].Label.Text = "Z";

            this.ilPanel1.Scene = new ILScene { plot };
            outputCalibration();
        }

        void outputCalibration()
        {
    
            int magnetomIndex = _x.Length;
            /* ELLIPSOID FITTING CODE */
            // Adaption of 'ellipsoid_fit' matlab code by Yury Petrov (See 'Matlab' folder
            // that came with the archive containing this file).

            // Seperate xyz magnetometer values and make column vectors
            ILArray<double> x = ILMath.array(_x);
            ILArray<double> y = _y;
            ILArray<double> z = _z;

            /*
            % fit ellipsoid in the form Ax^2 + By^2 + Cz^2 + 2Dxy + 2Exz + 2Fyz + 2Gx + 2Hy + 2Iz = 1
            D = [ x .* x, ...
                  y .* y, ...
                  z .* z, ...
              2 * x .* y, ...
              2 * x .* z, ...
              2 * y .* z, ...
              2 * x, ...
              2 * y, ... 
               2 * z ];  % ndatapoints x 9 ellipsoid parameters
            */
            /*ILArray<double> D = ILMath.zeros(_x.Length, 9);

            D[ILMath.full, 0] = x * x;
            D[ILMath.full, 1] = y * y;
            D[ILMath.full, 2] = z * z;
            D[ILMath.full, 3] = x * y * 2;
            D[ILMath.full, 4] = x * z * 2;
            D[ILMath.full, 5] = y * z * 2;
            D[ILMath.full, 6] = x * 2;
            D[ILMath.full, 7] = y * 2;
            D[ILMath.full, 8] = z * 2;*/
            ILArray<double> D = ILMath.zeros(_x.Length, 6);

            D[ILMath.full, 0] = x * x;
            D[ILMath.full, 1] = y * y;
            D[ILMath.full, 2] = z * z;
            D[ILMath.full, 3] = x  * 2;
            D[ILMath.full, 4] = y  * 2;
            D[ILMath.full, 5] = z  * 2;

            ILArray<double> tempA = ILMath.multiply(D.T, D);
            ILArray<double> ones = ILMath.ones(x.Length);
            ILArray<double> tempB = ILMath.multiply(D.T, ones);
            ILArray<double> v1 = ILMath.linsolve(tempA, tempB);
            var v = v1.GetArrayForRead();
            //ILArray<double> A = ILMath.array( new double[] { v[0], v[3], v[4], v[6], v[3], v[1], v[5], v[7], v[4], v[5], v[2], v[8], v[6], v[7], v[8], -1}, 4, 4);
            ILArray<double> A = ILMath.array(new double[] { v[0], v[1], v[2], 0, 0, 0, v[3], v[4], v[5]}, 1, 9);
            
            var a1 = A["6:8"];
            var a2 = A["0:2"];
            var sphere = new ILSphere();
            sphere.Fill.Color = Color.FromArgb(70, Color.LightGreen);
            sphere.Wireframe.Visible = false;
            var center = ILMath.divide(-a1, a2).T;

            var gam = 1 + ((A[6] * A[6]) / A[0] + (A[7] * A[7]) / A[1] + (A[8] * A[8]) / A[2]);
            var radii = ILMath.sqrt(gam / A["0:2"]).T;

            using (ILScope.Enter())
            {
                // take the vertex positions from the Fill.Positions buffer
                ILArray<float> pos = sphere.Fill.Positions.Storage;
                // set all vertices with a Y coordinate larger than 0.3 to 0.3
                pos = pos * ILMath.tosingle(radii).T + ILMath.tosingle(center).T;
                // write all values back to the buffer
                sphere.Fill.Positions.Update(pos);
            }
            
            plot.Add(sphere);

            
            
            //radii = ( sqrt( gam ./ v( 1:3 ) ) )';

            /*ILArray<double> tmp = A["0:2", "0:2"] * -1;
            ILArray<double> tmp1 = v1["6:8", ":"];
            ILArray<double> center = ILMath.linsolve(tmp, tmp1);

            ILArray<double> T = ILMath.eye(4,4);
            T[3, "0:2"] = center.T;

            ILArray<double> R = ILMath.multiply(T, A, T.T);
            ILArray<double> tmpx = R["0:2", "0:2"] / (-R[3, 3]);

            ILArray<complex> EigenVectors = ILMath.zeros<complex>(3, 3);
            var xx = ILMath.eig(tmpx, EigenVectors);

            ILArray <double> evecs = ILMath.array(EigenVectors.Select(k => k.real).ToArray(), 3, 3);

            var eigValues = xx.GetArrayForRead();
            ILArray<double> radii = ILMath.array( new double[] { Math.Sqrt(1.0 / eigValues[0].real), Math.Sqrt(1.0 / eigValues[4].real), Math.Sqrt(1.0 / eigValues[8].real) }, 3,1);

            double max, min; 
            radii.GetLimits(out min, out max);

            ILArray<double> scale = ILMath.zeros(3, 3);
            scale[0, 0] = radii[0];
            scale[1, 1] = radii[1];
            scale[2, 2] = radii[2];

                       
            scale = ILMath.pinv(scale) * 300;*/
            
            //ILArray<double> comp = ILMath.multiply(evecs, scale, evecs.T);            
        }
    }
}

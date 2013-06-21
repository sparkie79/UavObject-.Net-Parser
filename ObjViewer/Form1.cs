using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UavTalk;
using UavTalk.channels;
using ZedGraph;

namespace ObjViewer
{
    public partial class Form1 : Form
    {
        UAVObjectManager mgr;
        Dictionary<TreeNode, UAVObject> nodes = new Dictionary<TreeNode,UAVObject>();
        List<fieldData> uavobjectData = new List<fieldData>();
        int timestamp = 0;

        public Form1()
        {
            InitializeComponent();
            mgr = new UAVObjectManager();
            
            UAVObjectsInitialize.register(mgr);
            foreach (var item in mgr.getObjects())
            {
                item[0].onUpdated += new EventHandler(obj_updated);
            }

            /*FileChannel ch = new FileChannel(@"C:\Users\mimmo\Google Drive\Mimmo\cc3d\TauLabs-2013-05-19_11-13-29.tll");
            UavTalk.UavTalk tlk = new UavTalk.UavTalk(ch, mgr);
            timestamp = 0;
            ch.open();*/
        }

        private delegate TreeNode addnodeDelegate(UAVObject obj);
        TreeNode addNode(UAVObject b)
        {
            if (InvokeRequired)
                return (TreeNode)this.Invoke(new addnodeDelegate(addNode), b);
            else
            {
                TreeNode n = treeView1.Nodes.Add(b.name);
                foreach (var prop in b.GetType().GetFields().Where(j => j.FieldType.BaseType == typeof(UAVObjectField)))
                {
                    UAVObjectField f = (UAVObjectField)prop.GetValue(b);
                    TreeNode newnode = n.Nodes.Add(f.getName());
                    if (f.getNumElements() > 1)
                    {
                        for (int i = 0; i < f.getNumElements(); i++)
                        {
                            newnode.Nodes.Add(i.ToString());
                        }
                    }
                    /*if (fields.ContainsKey(f))
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
                    }*/
                }
                return n;
            }
        }

        void obj_updated(object sender, EventArgs e)
        {
            UAVObject b = (UAVObject)sender;
            {
                if(!b.isMetadata() && !((UAVDataObject)b).isSettings())
                {
                    timestamp++;
                    foreach (var prop in b.GetType().GetFields().Where(j => j.FieldType.BaseType == typeof(UAVObjectField)))
                    {
                        UAVObjectField f = (UAVObjectField)prop.GetValue(b);

                        for (int i = 0; i < f.getNumElements(); i++)
                        {
                            fieldData data = new fieldData()
                            {
                                fieldName = f.getName(),
                                timestamp = timestamp,
                                type = b.GetType(),
                                value = Convert.ToDouble(f.getValue(i)),
                                channel = i
                            };

                            lock (uavobjectData)
                            {
                                uavobjectData.Add(data);
                            }
                        }
                    }

                    if (!nodes.ContainsValue(b))
                        nodes.Add(addNode(b), b);
                }
            }
            
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Parent != null && e.Node.Nodes.Count == 0)
                {
                    TreeNode node = e.Node;
                    int levels = 0;
                    while (!nodes.ContainsKey(node))
                    {
                        node = node.Parent;
                        levels++;
                    }

                    int channel;
                    string fieldname;
                    if (levels == 1)
                    {
                        channel = 0;
                        fieldname = e.Node.Text;
                    }
                    else
                    {
                        channel = int.Parse(e.Node.Text);
                        fieldname = e.Node.Parent.Text;
                    }

                    if(e.Node.Checked)
                        addGraph(nodes[node].GetType(), fieldname, channel);
                    else
                        removeGraph(nodes[node].GetType(), fieldname, channel);
                }
                else
                {
                    
                }
            }
        }

        private class GrapCurve
        {
            public CurveItem curve { get; set; }
            public Type objType { get; set; }
            public string field { get; set; }
            public int channelNumber { get; set; }
        }

        private class fieldData
        {
            public Type type { get; set; }
            public string fieldName { get; set; }
            public int timestamp { get; set; }
            public double value { get; set; }
            public int channel { get; set; }
        }

        List<GrapCurve> curves = new List<GrapCurve>();

        private void removeGraph(Type t, string field, int channel)
        {
            var curve = curves.FirstOrDefault(j => j.objType == t && j.field == field && j.channelNumber == channel);
            if (curve != null)
            {
                curve.curve.IsVisible = false;
                if (curve.curve.IsY2Axis)
                {
                    zedGraphControl1.GraphPane.Y2AxisList[curve.curve.YAxisIndex].IsVisible = false;
                }
                zedGraphControl1.GraphPane.CurveList.Remove(curve.curve);
                curves.Remove(curve);
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void addGraph(Type t, string field, int channel)
        {
            var curve = curves.FirstOrDefault(j => j.objType == t && j.field == field && j.channelNumber == channel);
            if (curve != null)
            {
                curve.curve.IsVisible = true;
            } else
            {
                ZedGraph.CurveItem cv = zedGraphControl1.GraphPane.AddCurve(field, getPoints(t,field,channel), Color.Red,SymbolType.None);
                if (zedGraphControl1.GraphPane.CurveList.Count() > 1)
                {
                    zedGraphControl1.GraphPane.Y2Axis.IsVisible = true;
                    
                    cv.IsY2Axis = true;
                    cv.YAxisIndex = zedGraphControl1.GraphPane.CurveList.Count() - 2;
                    if (cv.YAxisIndex > 0)
                        zedGraphControl1.GraphPane.AddY2Axis("");    
                }

                cv.MakeUnique();
                //((LineItem)cv).Symbol.Type = SymbolType.None;
                ((LineItem)cv).Symbol.Size = 1.5f;
                ((LineItem)cv).Line.Width = 1;
                ((LineItem)cv).Line.SmoothTension = 0.5F;
                ((LineItem)cv).Line.IsAntiAlias = true;

                GrapCurve gc = new GrapCurve() { objType = t, curve = cv, field = field, channelNumber = channel };
                curves.Add(gc);
                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();
            }
        }
        
        private PointPairList getPoints(Type t, string field, int channel)
        {
            PointPairList p = new PointPairList();
            lock (uavobjectData)
            {
                p.AddRange(
                    uavobjectData.Where(j => j.type == t && j.fieldName == field && j.channel == channel)
                    .Select(h =>
                        new PointPair(
                            (double)h.timestamp,
                            h.value
                            )
                        ));
            }
            return p;
        }

        private void apriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Log Files *.tll|*.tll";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                uavobjectData.Clear();
                treeView1.Nodes.Clear();
                zedGraphControl1.GraphPane.CurveList.Clear();
                nodes.Clear();
                curves.Clear();
                FileChannel ch = new FileChannel(dlg.FileName);
                ch.fileclosed += new EventHandler(fileclosed);
                UavTalk.UavTalk tlk = new UavTalk.UavTalk(ch, mgr);
                timestamp = 0;
                treeView1.Enabled = false;
                ch.open();
            }
        }

        private void fileclosed(object sender, EventArgs e)
        {
            if (InvokeRequired)
                this.Invoke(new EventHandler(fileclosed));
            else
            {
                treeView1.Sort();
                treeView1.Enabled = true;
            }
        }
    }
}

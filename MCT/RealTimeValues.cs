using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace MCT
{
    public partial class RealTimeValues : Form
    {
        public RealTimeValues()
        {
            InitializeComponent();
        }

        public RealTimeValues(int _n_sensors, double[] _current_Values)
        {
            if (_n_sensors == 0)
                return;

            InitializeComponent();

            Number_of_sensors = _n_sensors;
            InitGraphPane();
            InitBarItem(_n_sensors,_current_Values);
            
        }

        private protected int _number_of_sensors;
        private protected GraphPane z;
        private protected List<BarItem> _bar;

        private int Number_of_sensors { get => _number_of_sensors; set => _number_of_sensors = value; }
        private List<BarItem> Bar { get => _bar; set => _bar = value; }

        private void InitGraphPane()
        {
            z = zedGraphControl1.GraphPane;
            //z.Rect = new RectangleF(new PointF(2, 2), new SizeF(Width, Height));

            //z.XAxis.Scale.MinorStep = 1;
            //z.XAxis.Scale.Max = 5; //values range on X axis
            //z.YAxis.Scale.Max = 100; //values range on Y axis
            z.YAxis.Scale.MaxAuto = true;
            z.YAxis.Scale.MinAuto = true;

            z.XAxis.MajorGrid.DashOff = 0;
            z.YAxis.MajorGrid.DashOff = 0;

            z.XAxis.MajorGrid.Color = Color.DarkSlateGray;
            z.XAxis.MinorGrid.IsVisible = true;
            z.XAxis.MinorGrid.Color = Color.Gray;
            z.XAxis.MajorGrid.IsVisible = true;

            z.YAxis.MajorGrid.Color = Color.DarkSlateGray;
            z.YAxis.MajorGrid.IsVisible = true;
            z.YAxis.MinorGrid.Color = Color.Gray;
            z.YAxis.MinorGrid.IsVisible = true;

            z.XAxis.IsAxisSegmentVisible = false;
            z.XAxis.IsVisible = false;

            z.Title.Text = "Realtime Values";

            z.XAxis.Title.Text = "Sensors";
            z.XAxis.IsVisible = true;

            z.YAxis.Title.Text = "Temperature";
            z.YAxis.IsVisible = true;
        }
        private void InitBarItem(int _nSensors, double[] _curValues)
        {
            List<Color> Colors = new List<Color>() {
                Color.Green,
                Color.Red,
                Color.Black,
                Color.Yellow,
                Color.Blue,
                Color.Brown,
                Color.Purple,
                Color.Orange,
                Color.Gray,
                Color.Gold,
                Color.DarkGreen,
                Color.Olive
                };
            Bar = new List<BarItem>();
            for (int i = 0; i < _nSensors; i++)
            {
                double[] x_value = new double[1] { i + 1 };
                double[] y_value = new double[1] { _curValues[i] };
                Bar.Add(zedGraphControl1.GraphPane.AddBar(("Sensor" + (i + 1)), x_value, y_value, Colors[i]));
            }
            
            z.XAxis.Scale.Max = Bar[Bar.Count - 1].Points[0].X + 1;
            z.AxisChange();
        }

        private void RealTimeValues_Load(object sender, EventArgs e)
        {
            CenterToScreen();

            
        }
    }
}

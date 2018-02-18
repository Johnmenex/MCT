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

        public RealTimeValues(int _n_sensors, double[] _current_Values, int _sampling_rate)
        {
            if (_n_sensors == 0)
                return;

            InitializeComponent();
            Sampling_rate = _sampling_rate;
            NumberOfSensors = _n_sensors;
            InitGraphPane();
            InitBar(NumberOfSensors,_current_Values);
            
        }
        private bool graphPaneInitialized;
        private bool barInitialized;
        private protected int sampling_rate;
        private protected int _number_of_sensors;
        private protected GraphPane z;
        private protected List<BarItem> _bar;
        private protected double[] _sensorValues;

        private protected int NumberOfSensors { get => _number_of_sensors; set => _number_of_sensors = value; }
        private protected List<BarItem> Bar { get => _bar; set => _bar = value; }
        private protected int Sampling_rate { get => sampling_rate; set => sampling_rate = value; }
        private protected bool GraphPaneInitialized { get => graphPaneInitialized; set => graphPaneInitialized = value; }
        private protected bool BarInitialized { get => barInitialized; set => barInitialized = value; }
        private protected double[] SensorValues { get => _sensorValues; set => _sensorValues = value; }

        private protected void InitGraphPane()
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

            GraphPaneInitialized = true;
        }
        private protected void InitBar(int _nSensors, double[] _curValues)
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
                Color.LightBlue,
                Color.DarkGreen,
                Color.Olive
                };
            Bar = new List<BarItem>();
            for (int i = 0; i < _nSensors; i++)
            {
                double[] x_value = new double[1] { i + 1};
                double[] y_value = new double[1] { _curValues[i] };
                Bar.Add(zedGraphControl1.GraphPane.AddBar(("Sensor" + (i+1)), x_value, y_value, Colors[i]));
            }
            z.XAxis.Scale.Min = Bar[0].Points[0].X - 1;
            z.XAxis.Scale.Max = Bar[Bar.Count - 1].Points[0].X + 1;
            z.AxisChange();

            BarInitialized = true;
        }
        public void ReceiveData(double[] _sensor_values)
        {
            SensorValues = _sensor_values;
        }
        private protected void RefreshBars()
        {
            double[] _sensor_values = SensorValues;

            int _index = 0;
            foreach (BarItem _b in Bar)
            {
                _b.Clear();
                _b.AddPoint(_index + 1, _sensor_values[_index]);
                _index++;
            }
           
            zedGraphControl1.Refresh();
        }

        private protected void RealTimeValues_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            timer_visualiser.Interval = Sampling_rate;

            timer_visualiser.Start();

            
        }

        private void timer_visualiser_Tick(object sender, EventArgs e)
        {
            if(BarInitialized)
                RefreshBars();
        }
    }
}

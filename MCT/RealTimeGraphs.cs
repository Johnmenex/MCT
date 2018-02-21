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

namespace MCT {
    public partial class RealTimeGraphs : Form {
        public RealTimeGraphs() {
            InitializeComponent();
        }


        public RealTimeGraphs(int _n_sensors, double[] _current_Values, int _sampling_rate) {
            if (_n_sensors == 0)
                return;

            InitializeComponent();
            NumberOfSensors = _n_sensors;
            InitCurve(NumberOfSensors, _current_Values);
        }

        public void ReceiveData(double[] _sensor_values) {
            SensorValues = _sensor_values;
        }

        private protected GraphPane z;
        private protected List<CurveItem> _curve;
        private protected double[] _sensorValues;
        private protected int _number_of_sensors;

        private protected List<CurveItem> Curve { get => _curve; set => _curve = value; }
        private protected double[] SensorValues { get => _sensorValues; set => _sensorValues = value; }
        private protected int NumberOfSensors { get => _number_of_sensors; set => _number_of_sensors = value; }

        //bool _allow_scroll = false;
        private protected void InitGraphPane() {
            //_allow_scroll = true;

            
            z = zedGraphControl1.GraphPane;
            z.XAxis.Scale.MinorStep = 1;

            z.XAxis.Scale.Max = 20; //values range on X axis
            //z.YAxis.Scale.Max = 100; //values range on Y axis
            z.YAxis.Scale.MaxAuto = true;
            z.YAxis.Scale.MinAuto = true;


            zedGraphControl1.ScrollMaxX = 21;

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

            z.XAxis.Title.Text = "Samples";
            z.YAxis.Title.Text = "Temperature";
            z.Title.Text = "Realtime monitoring";



            z.AxisChange();
            zedGraphControl1.IsAntiAlias = true;
            zedGraphControl1.Refresh();
        }

        private protected void InitCurve(int _nSensors, double[] _curValues) {
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
            _curve = new List<CurveItem>();
            for (int i = 0; i < NumberOfSensors; i++) {
                double[] x_value = new double[1] { i + 1 };
                double[] y_value = new double[1] { _curValues[i] };
                //Bar.Add(zedGraphControl1.GraphPane.AddBar(("Sensor" + (i + 1)), x_value, y_value, Colors[i]));
                Curve.Add(zedGraphControl1.GraphPane.AddCurve("Sensor" + (i + 1), x_value, y_value, Colors[i]));
            }


        }

        private void RealTimeGraphs_Load(object sender, EventArgs e) {
            InitGraphPane();
        }
    }
}
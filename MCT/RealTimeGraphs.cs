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
            SamplingTime = _sampling_rate;
            NumberOfSensors = _n_sensors;
            InitGraphPane();
            InitCurve(NumberOfSensors, _current_Values);
        }

        public void ReceiveData(double[] _sensor_values) {
            SensorValues = _sensor_values;
        }

        private protected GraphPane z;
        private protected List<CurveItem> _curve;
        private protected double[] _sensorValues;
        private protected int _number_of_sensors;
        private protected int samplenumber = 1;
        private protected int samplingTime;
        private protected List<GroupBox> gb_threshold;

        private protected bool graphPaneInitialized;
        private protected bool curveInitialized;

        private protected List<CurveItem> Curve { get => _curve; set => _curve = value; }
        private protected double[] SensorValues { get => _sensorValues; set => _sensorValues = value; }
        private protected int NumberOfSensors { get => _number_of_sensors; set => _number_of_sensors = value; }
        private protected bool GraphPaneInitialized { get => graphPaneInitialized; set => graphPaneInitialized = value; }
        private protected bool CurveInitialized { get => curveInitialized; set => curveInitialized = value; }
        private protected int SampleNumber { get => samplenumber; set => samplenumber = value; }
        private protected int SamplingTime { get => samplingTime; set => samplingTime = value; }
        private protected List<GroupBox> Gb_threshold { get => gb_threshold; set => gb_threshold = value; }

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

            GraphPaneInitialized = true;
        }
        private protected void initUI() {
            int column = 0;
            int row = 0;
            Gb_threshold = new List<GroupBox>();
            for (int i = 0; i < _number_of_sensors; i++) {
                //create each groupbox
                Gb_threshold.Add(new GroupBox());
                Gb_threshold[i].Text = "Sensor " + (i + 1);
                //
                //create cb_display
                CheckBox cb_display = new CheckBox();
                cb_display.Location = new Point(4, 15);
                cb_display.AutoSize = true;
                cb_display.Name = "cb_display" + (i + 1);
                cb_display.Text = "Show";
                cb_display.Checked = true;
                cb_display.Show();
                cb_display.CheckedChanged += Cb_display_CheckedChanged;
                Gb_threshold[i].Controls.Add(cb_display);
                //
                //create cb_sensor
                CheckBox cb_threshold = new CheckBox();
                cb_threshold.Location = new Point(4, cb_display.Location.Y + cb_display.Height + 5);
                cb_threshold.AutoSize = true;
                cb_threshold.Name = "cb_sensor" + (i + 1);
                cb_threshold.Text = "Threshold";
                cb_threshold.Checked = false;
                cb_threshold.Show();
                Gb_threshold[i].Controls.Add(cb_threshold);
                //
                //create min_label
                System.Windows.Forms.Label lb_min = new System.Windows.Forms.Label();
                lb_min.AutoSize = true;
                lb_min.Name = "lb_min";
                lb_min.Text = "Min:";
                lb_min.Location = new Point(2, cb_threshold.Location.Y + cb_threshold.Height + 5);
                lb_min.Show();
                Gb_threshold[i].Controls.Add(lb_min);
                //
                //create min_nuD
                NumericUpDown nUD_min = new NumericUpDown();
                nUD_min.Minimum = -999;
                nUD_min.Maximum = 999;
                nUD_min.Width = 40;
                nUD_min.Location = new Point(lb_min.Location.X + lb_min.Width + 3, lb_min.Location.Y - 5);
                nUD_min.Show();
                Gb_threshold[i].Controls.Add(nUD_min);
                //
                //create max_label
                System.Windows.Forms.Label lb_max = new System.Windows.Forms.Label();
                lb_max.AutoSize = true;
                lb_max.Name = "lb_max";
                lb_max.Text = "Max:";
                lb_max.Location = new Point(2, lb_min.Location.Y + lb_min.Height + 10);
                lb_max.Show();
                Gb_threshold[i].Controls.Add(lb_max);
                //
                //create max_nUD
                NumericUpDown nUD_max = new NumericUpDown();
                nUD_max.Minimum = -999;
                nUD_max.Maximum = 999;
                nUD_max.Width = 40;
                nUD_max.Location = new Point(lb_max.Location.X + lb_max.Width, lb_max.Location.Y - 5);
                nUD_max.Show();
                Gb_threshold[i].Controls.Add(nUD_max);
                //
                //Set the dynamic location of each groupbox
                Gb_threshold[i].AutoSize = true;
                Gb_threshold[i].Width = cb_threshold.Width;

                if(row<=0)
                Gb_threshold[i].Location = new Point(
                    5 + (column * (Gb_threshold[i].Width + 30)),
                    15 + (row * Gb_threshold[i].Height)
                    );
                else {
                    Gb_threshold[i].Location = new Point(
                    5 + (column * (Gb_threshold[i].Width + 30)),
                    15 + (row * Gb_threshold[i].Height+15)
                    );
                }
                column++;
                if ((5 + (column * (Gb_threshold[i].Width + 30))) > gb_parent.Width) {
                    if (column != _number_of_sensors) {
                        gb_parent.Height += Gb_threshold[i].Height + 10;
                        Height += Gb_threshold[i].Height + 5;
                    }
                    column = 0;
                    row++;
                }
                //
                Gb_threshold[i].Show();
                gb_parent.Controls.Add(Gb_threshold[i]);
            }
        }

        private void Cb_display_CheckedChanged(object sender, EventArgs e) {
            Curve.Find(x => x.Label.Text.Remove(0, 6)[0].ToString() == (((CheckBox)sender).Name.Remove(0, 10))).IsVisible = ((CheckBox)sender).Checked;
            Curve.Find(x => x.Label.Text.Remove(0, 6)[0].ToString() == (((CheckBox)sender).Name.Remove(0, 10))).Label.IsVisible = ((CheckBox)sender).Checked;
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
                double[] x_value = new double[1] { 1 };
                double[] y_value = new double[1] { _curValues[i] };
                Curve.Add(zedGraphControl1.GraphPane.AddCurve("Sensor" + (i + 1), x_value, y_value, Colors[i]));
            }

            CurveInitialized = true;
        }
        private protected void DrawNextSpot() {

            int i = 0;
            SampleNumber++;
            foreach (CurveItem _c in Curve) {
                _c.AddPoint(SampleNumber, _sensorValues[i]);
                i++;
            }
            z.AxisChange();
            zedGraphControl1.Refresh();
        }

        private void RealTimeGraphs_Load(object sender, EventArgs e) {
            CenterToScreen();
            timer_visualizer.Interval = SamplingTime;
            initUI();
            timer_visualizer.Start();
        }

        private void timer_visualizer_Tick(object sender, EventArgs e) {
            if (CurveInitialized) {
                timer_visualizer.Stop();
                DrawNextSpot();
                timer_visualizer.Start();
            }
        }
    }
}
/*!
Apache License
Version 2.0, January 2004

Copyright (c) 2018 Yiannis Menexes <johnmenex@gmail.com>, Dimitris Katikaridis <dkatikaridis@gmail.com>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace MCT {
    public partial class RealTimeGraphs : Form {
        public RealTimeGraphs() {
            InitializeComponent();
        }

        public RealTimeGraphs(List<int> _active_sensors, double[] _current_Values, int _sampling_rate) {
            if (_active_sensors == null || _active_sensors.Count == 0)
                return;

            InitializeComponent();
            SamplingTime = _sampling_rate;
            ActiveSensors = _active_sensors;
            NumberOfSensors = _active_sensors.Count;
            
            InitGraphs(_current_Values);
            InitUI();
            
            timer_visualizer.Start();
        }

        public void ReceiveData(double[] _sensor_values) {
            SensorValues = _sensor_values;
        }

        private CheckBox cb_Allow_Scroll;
        private protected GraphPane z;
        private protected List<CurveItem> _curve;
        private protected List<string> labelNames;
        private protected double[] _sensorValues;
        private List<int> _activeSensors;
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
        private List<int> ActiveSensors { get => _activeSensors; set => _activeSensors = value; }
        private protected List<string> LabelNames { get => labelNames; set => labelNames = value; }

        
        private protected void InitUI() {
            CenterToScreen();
            int column = 0;
            int row = 0;
            Gb_threshold = new List<GroupBox>();
            for (int i = 0; i < NumberOfSensors; i++) {

                #region create each groupbox
                Gb_threshold.Add(new GroupBox());
                Gb_threshold[i].Text = "Sensor " + ActiveSensors[i];
                #endregion

                #region create cb_display -> Gb_threshold.Controls[0]
                CheckBox cb_display = new CheckBox();
                cb_display.Location = new Point(4, 15);
                cb_display.AutoSize = true;
                cb_display.Name = "cb_display" + (i + 1);
                cb_display.Text = "Show";
                cb_display.Checked = true;
                cb_display.Show();
                cb_display.CheckedChanged += Cb_display_CheckedChanged;
                Gb_threshold[i].Controls.Add(cb_display);
                #endregion

                #region create cb_sensor -> Gb_threshold.Controls[1]
                CheckBox cb_threshold = new CheckBox();
                cb_threshold.Location = new Point(4, cb_display.Location.Y + cb_display.Height + 5);
                cb_threshold.AutoSize = true;
                cb_threshold.Name = "cb_sensor" + ActiveSensors[i];
                cb_threshold.Text = "Threshold";
                cb_threshold.Checked = false;
                cb_threshold.Show();
                Gb_threshold[i].Controls.Add(cb_threshold);
                #endregion

                #region create min_label -> Gb_threshold.Controls[2]
                System.Windows.Forms.Label lb_min = new System.Windows.Forms.Label();
                lb_min.AutoSize = true;
                lb_min.Name = "lb_min";
                lb_min.Text = "Min:";
                lb_min.Location = new Point(2, cb_threshold.Location.Y + cb_threshold.Height + 5);
                lb_min.Show();
                Gb_threshold[i].Controls.Add(lb_min);
                #endregion

                #region create min_nuD -> Gb_threshold.Controls[3]
                NumericUpDown nUD_min = new NumericUpDown();
                nUD_min.Minimum = -999;
                nUD_min.Maximum = 999;
                nUD_min.Width = 40;
                nUD_min.Location = new Point(lb_min.Location.X + lb_min.Width + 3, lb_min.Location.Y - 5);
                nUD_min.BackColor = Color.FromKnownColor(KnownColor.Control);
                nUD_min.Show();
                Gb_threshold[i].Controls.Add(nUD_min);
                #endregion

                #region create max_label -> Gb_threshold.Controls[4]
                System.Windows.Forms.Label lb_max = new System.Windows.Forms.Label();
                lb_max.AutoSize = true;
                lb_max.Name = "lb_max";
                lb_max.Text = "Max:";
                lb_max.Location = new Point(2, lb_min.Location.Y + lb_min.Height + 10);
                lb_max.Show();
                Gb_threshold[i].Controls.Add(lb_max);
                #endregion

                #region create max_nUD -> Gb_threshold.Controls[5]
                NumericUpDown nUD_max = new NumericUpDown();
                nUD_max.Minimum = -999;
                nUD_max.Maximum = 999;
                nUD_max.Width = 40;
                nUD_max.Location = new Point(lb_max.Location.X + lb_max.Width, lb_max.Location.Y - 5);
                nUD_max.BackColor = Color.FromKnownColor(KnownColor.Control);
                nUD_max.Show();
                Gb_threshold[i].Controls.Add(nUD_max);
                #endregion

                #region Set the dynamic location of each groupbox
                Gb_threshold[i].AutoSize = true;
                Gb_threshold[i].Width = cb_threshold.Width;

                if (row <= 0)
                    Gb_threshold[i].Location = new Point(
                        5 + (column * (Gb_threshold[i].Width + 30)),
                        15 + (row * Gb_threshold[i].Height)
                        );
                else {
                    Gb_threshold[i].Location = new Point(
                    5 + (column * (Gb_threshold[i].Width + 30)),
                    15 + (row * Gb_threshold[i].Height + 15)
                    );
                }
                column++;
                if ((5 + (column * (Gb_threshold[i].Width + 30))) > gb_parent.Width) {
                    if (column != NumberOfSensors) {
                        gb_parent.Height += Gb_threshold[i].Height + 10;
                        Height += Gb_threshold[i].Height + 5;
                    }
                    column = 0;
                    row++;
                }
                #endregion

                Gb_threshold[i].Show();
                gb_parent.Controls.Add(Gb_threshold[i]);
            }
        }
        private protected void InitGraphs(double[] _current_Values) {
            InitGraphPane();
            InitCurve(NumberOfSensors, _current_Values);

            timer_visualizer.Interval = SamplingTime;
        }
        private protected void InitGraphPane() {

            z = zedGraphControl1.GraphPane;
            z.XAxis.Scale.MinorStep = 1;

            z.XAxis.Scale.Max = 20; //values range on X axis

            zedGraphControl1.IsShowHScrollBar = true;

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
            cb_Allow_Scroll = new CheckBox {
                Checked = true,
                BackColor = Color.FromKnownColor(KnownColor.White),
                Location = new Point(zedGraphControl1.Location.X + 5,
                                     zedGraphControl1.Location.Y + zedGraphControl1.Controls[0].Location.Y - zedGraphControl1.Controls[0].Height * 2
                                     ),
                Visible = true,
                Enabled = true,
                AutoSize = true,
                Text = "Keep - track of incoming values"
            };
            Controls.Add(cb_Allow_Scroll);
            cb_Allow_Scroll.Show();
            cb_Allow_Scroll.BringToFront();
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
            LabelNames = new List<string>();

            for (int i = 0; i < NumberOfSensors; i++) {
                double[] x_value = new double[1] { 1 };
                double[] y_value = new double[1] { _curValues[i] };
                Curve.Add(zedGraphControl1.GraphPane.AddCurve("Sensor" + ActiveSensors[i], x_value, y_value, Colors[i]));
                LabelNames.Add(Curve[i].Label.Text);
            }

            CurveInitialized = true;
        }

        private void Cb_display_CheckedChanged(object sender, EventArgs e) {
            Curve[Convert.ToInt32(((CheckBox)sender).Name.Remove(0, 10)) - 1].IsVisible = ((CheckBox)sender).Checked;
            Curve[Convert.ToInt32(((CheckBox)sender).Name.Remove(0, 10)) - 1].Label.IsVisible = ((CheckBox)sender).Checked;
        }
        private void AutoFollowGraphLine() {
            if (!cb_Allow_Scroll.Checked)
                return;

            if (SampleNumber >= 15 && samplenumber <= 20) {
                z.XAxis.Scale.Max = samplenumber + 5;
                z.XAxis.Scale.Min = samplenumber > 15 ? samplenumber - 15 : 0;
                zedGraphControl1.ScrollMaxX = z.XAxis.Scale.Max;
            }
            else {
                if (samplenumber >= 20) {
                    z.XAxis.Scale.Max = SampleNumber + 5;
                    z.XAxis.Scale.Min = samplenumber - 20;
                    zedGraphControl1.ScrollMaxX = z.XAxis.Scale.Max - z.XAxis.Scale.Min;
                }
            }
        }
        
        private protected void DrawNextSpot() {

            int i = 0;
            SampleNumber++;
            foreach (CurveItem _c in Curve) {
                _c.AddPoint(SampleNumber, SensorValues[i]);
                _c.Label.Text = LabelNames[i] + " - " + SensorValues[i];

                i++;
            }
            AutoFollowGraphLine();
            z.AxisChange();
            zedGraphControl1.Refresh();
        }
        private protected void CheckThresholds() {
            int _index = 0;
            foreach (GroupBox _gb in gb_parent.Controls) {
                if (((CheckBox)_gb.Controls[0]).Checked)
                    if (((CheckBox)_gb.Controls[1]).Checked) {
                        if ((double)((NumericUpDown)_gb.Controls[3]).Value > _sensorValues[_index])
                            ((NumericUpDown)_gb.Controls[3]).BackColor = Color.Red;
                        else
                            ((NumericUpDown)_gb.Controls[3]).BackColor = Color.FromKnownColor((KnownColor.Control));

                        if ((double)((NumericUpDown)_gb.Controls[5]).Value < _sensorValues[_index])
                            ((NumericUpDown)_gb.Controls[5]).BackColor = Color.Red;
                        else
                            ((NumericUpDown)_gb.Controls[5]).BackColor = Color.FromKnownColor((KnownColor.Control));
                    }
                    else {
                        ((NumericUpDown)_gb.Controls[3]).BackColor = Color.FromKnownColor((KnownColor.Control));
                        ((NumericUpDown)_gb.Controls[5]).BackColor = Color.FromKnownColor((KnownColor.Control));
                    }
                else {
                    ((NumericUpDown)_gb.Controls[3]).BackColor = Color.FromKnownColor((KnownColor.Control));
                    ((NumericUpDown)_gb.Controls[5]).BackColor = Color.FromKnownColor((KnownColor.Control));
                }
                _index++;
            }
        }

        private void timer_visualizer_Tick(object sender, EventArgs e) {
            if (CurveInitialized) {
                timer_visualizer.Stop();
                DrawNextSpot();
                timer_visualizer.Start();
                CheckThresholds();
            }
        }
    }
}
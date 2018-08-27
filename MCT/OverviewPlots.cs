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
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ZedGraph;

namespace MCT {
    public partial class OverviewPlots : Form {
        public OverviewPlots(List<string> LogFilePaths, List<List<string>> _ActiveSensors) {

            InitializeComponent();

            SetInterface();


            List<List<string>> _RawData = ParseFiles(LogFilePaths);
            List<List<List<string>>> _Values = SeperateValues(_RawData, _ActiveSensors);
            InitCurve(_Values);
            Plot(_Values);
        }

        private Point _reference_ipt = new Point(-1, -1);
        private protected GraphPane z;
        private bool curveInitialized;
        private List<List<CurveItem>> curve;

        private ListBox _listbox;

        private protected bool CurveInitialized { get => curveInitialized; set => curveInitialized = value; }
        private protected List<List<CurveItem>> Curve { get => curve; set => curve = value; }


        private void SetInterface() {

            MaximizeBox = false;
            Location = new Point(0, 0);
            Bounds = Screen.PrimaryScreen.Bounds;
            z_Graph.Height = Height - 50;
            z_Graph.Width = Width - (Width / 4);

            _listbox = new ListBox {
                Location = new Point(z_Graph.Location.X + z_Graph.Width + 10, z_Graph.Location.Y),
                Height = z_Graph.Height,
            };
            Controls.Add(_listbox);

            InitGraphPane();
        }

        private List<List<string>> ParseFiles(List<string> FilesToParse) {
            List<List<string>> FileContents = new List<List<string>>();

            int _sessionIndex = 0;
            foreach (string _file in FilesToParse) {
                StreamReader _rdr = new StreamReader(_file);
                FileContents.Add(new List<string>());
                do {
                    string _line = _rdr.ReadLine();
                    if (_line != "")
                        FileContents[_sessionIndex].Add(_line);
                } while (!_rdr.EndOfStream);
                _sessionIndex++;
            }

            return FileContents;
        }

        private void InitGraphPane() {
            z = z_Graph.GraphPane;
            z_Graph.IsShowHScrollBar = true;

            z.XAxis.Scale.MinorStep = 1;
            z.XAxis.Scale.Max = 20;
            z.XAxis.MajorGrid.DashOff = 0;

            z.XAxis.MajorGrid.Color = Color.DarkSlateGray;
            z.XAxis.MinorGrid.IsVisible = true;
            z.XAxis.MinorGrid.Color = Color.Gray;
            z.XAxis.MajorGrid.IsVisible = true;

            z.XAxis.Title.Text = "Samples";
            z.XAxis.Title.FontSpec.Size = 7;
            z.XAxis.Scale.FontSpec.Size = 7;

            z.YAxis.MajorGrid.DashOff = 0;
            z.YAxis.MajorGrid.Color = Color.DarkSlateGray;
            z.YAxis.MajorGrid.IsVisible = true;
            z.YAxis.MinorGrid.Color = Color.Gray;
            z.YAxis.MinorGrid.IsVisible = true;

            z.YAxis.Title.Text = "Temperature";
            z.YAxis.Title.FontSpec.Size = 7;
            z.YAxis.Scale.FontSpec.Size = 7;


            z.Title.Text = "Logs Overview";
            z.Title.FontSpec.Size = 10;
            z.Legend.Position = LegendPos.BottomFlushLeft;
            z.Legend.FontSpec.Size = 6;

            z_Graph.IsShowPointValues = true;

            z.AxisChange();
            z_Graph.IsAntiAlias = true;
            z_Graph.Refresh();

            z_Graph.PointValueEvent += (ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt) => FindSample(sender, pane, curve, iPt);
        }

        private string FindSample(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt) {
            List<List<string>> _found_samples = new List<List<string>>();
            foreach (List<CurveItem> _session in Curve) {
                _found_samples.Add(new List<string>());
                foreach (CurveItem _ci in _session) {
                    #region convert CurveItem iPoints to List<Point>
                    List<Point> _points = new List<Point>();
                    for (int i = 1; i < _ci.Points.Count; i++)
                        _points.Add(new Point((int)_ci[i].X, (int)_ci[i].Y));
                    #endregion

                    foreach (Point _p in _points)
                        if (_p.X == (int)curve[iPt].X && _p.Y == (int)curve[iPt].Y)
                            _found_samples[_found_samples.Count - 1].Add(
                                _ci.Label.Text.Split('-')[0] + "|" +
                                _ci.Label.Text.Split('-')[1] + "|" +
                                curve[iPt].X + "|" +
                                curve[iPt].Y
                                );
                }
            }

            List<List<string>> _found_indexes = new List<List<string>>();
            bool multi_valued_samples = false;
            int multi_valued_samples_counter = 0;
            int _session_specifier = 0;
            foreach (List<string> _session in _found_samples) {
                _found_indexes.Add(new List<string>());
                int _sample_counter = 0;
                foreach (string _sample in _session) {
                    _sample_counter++;
                    multi_valued_samples_counter++;
                    int _session_index = _listbox.FindString("============" + _sample.Split('|')[0].Split(':')[0] + " " + _sample.Split('|')[0].Split(' ')[1]);
                    int _sample_index = _listbox.FindString("============Sample " + _sample.Split('|')[2], _session_index);

                    string _search_string =
                        Convert.ToInt32(_sample.Split('|')[1].Split(' ')[1]) > 9 ?
                            "Sensor: " + _sample.Split('|')[1].Split(' ')[1] + " | Value= " + _sample.Split('|')[3] :
                            "Sensor:  " + _sample.Split('|')[1].Split(' ')[1] + " | Value = " + _sample.Split('|')[3];

                    _found_indexes[_found_indexes.Count - 1].Add(_listbox.FindString(_search_string, _sample_index) + "|" + _sample.Split('|')[2]);

                    multi_valued_samples = multi_valued_samples_counter > 1 ? true : false;
                    _session_specifier = Convert.ToInt32(_sample.Split('|')[0].Split(' ')[1]) -1;
                }
            }

            if (_reference_ipt.X != curve[iPt].X || _reference_ipt.Y != curve[iPt].Y) {
                _reference_ipt = new Point((int)curve[iPt].X, (int)curve[iPt].Y);
                if (!multi_valued_samples) {
                    Controls.RemoveByKey("Secondary_listbox");
                    _listbox.Height = z_Graph.Height;
                    _listbox.SelectedIndex = Convert.ToInt32(_found_indexes[_session_specifier][0].Split('|')[0]);

                }
                else {
                    Controls.RemoveByKey("Secondary_listbox");
                    _listbox.Height = z_Graph.Height;
                    _listbox.ClearSelected();
                    Controls.Add(Secondary_Listbox(_found_indexes));
                    object _tmp_lb = ((ListBox)(Controls.Find("Secondary_listbox", true)[0]));
                    ((ListBox)_tmp_lb).SelectedItem = ((ListBox)_tmp_lb).Items[0];
                }
            }
            return "";
        }

        private ListBox Secondary_Listbox(List<List<string>> found_samples) {
            _listbox.Height = _listbox.Height - 100;
            ListBox second_listbox = new ListBox {
                Name = "Secondary_listbox",
                Location = new Point(_listbox.Location.X, _listbox.Location.Y + _listbox.Height + 25),
                Width = _listbox.Width,
                ScrollAlwaysVisible = true
            };
            second_listbox.Height = Height - second_listbox.Location.Y - 50;
            int _session_counter = 0;
            foreach (List<string> _session in found_samples) {
                _session_counter++;
                if(_session.Count!=0)
                    second_listbox.Items.Add("============Session " + _session_counter + "============");
                foreach (string _item in _session) {
                    second_listbox.Items.Add("============Sample " + _item.Split('|')[1] + "============");
                    second_listbox.Items.Add(_listbox.Items[Convert.ToInt32(_item.Split('|')[0])]);
                }
                second_listbox.Items.Add("");
            }
            return second_listbox;
        }

        private void InitCurve(List<List<List<string>>> _Values) {

            Random _rnd = new Random();

            List<List<string>> _colors = new List<List<string>>();
            List<string> _already_asigned_colors = new List<string>();
            int _number_of_sensors = 0;

            List<List<int>> _init_values = new List<List<int>>();
            List<List<int>> _init_labels = new List<List<int>>();

            foreach (List<List<string>> _session in _Values) {

                string[] _tmp = new string[_session[0].Count];
                int _c = 0;
                foreach (string _s in _session[0]) {
                    _tmp[_c] = _s;
                    _c++;
                }
                _colors.Add(new List<string>());

                _init_values.Add(new List<int>());
                _init_labels.Add(new List<int>());
                for (int i = 1; i < _tmp.Length; i++) {
                    _init_values[_init_values.Count - 1].Add(Convert.ToInt32(_tmp[i].Split('-')[1]));
                    _init_labels[_init_labels.Count - 1].Add(Convert.ToInt32(_tmp[i].Split('-')[0]));
                    int _r, _g, _b;
                    _r = _g = _b = 0;
                    do {
                        _r = _rnd.Next(0, 255);
                        _g = _rnd.Next(0, 255);
                        _b = _rnd.Next(0, 255);
                    } while (_already_asigned_colors.Exists(element => element == (_r + "," + _g + "," + _b)));
                    _already_asigned_colors.Add(_r + "," + _g + "," + _b);
                    _colors[_colors.Count - 1].Add(_r + "," + _g + "," + _b);
                    _number_of_sensors++;
                }
            }

            Curve = new List<List<CurveItem>>();
            int _session_index = 0;

            foreach (List<int> _session in _init_values) {
                Curve.Add(new List<CurveItem>());

                int _cc = 0;
                foreach (int _sensor_value in _session) {
                    Curve[_session_index].Add(z_Graph.GraphPane.AddCurve(
                        "Session: " + (_session_index + 1) + "-Sensor: " + (_init_labels[_session_index][_cc]),
                        new double[1] { 1 },
                        new double[1] { _sensor_value },
                        Color.FromArgb(
                            Convert.ToInt32(_colors[_session_index][_cc].Split(',')[0]),
                            Convert.ToInt32(_colors[_session_index][_cc].Split(',')[1]),
                            Convert.ToInt32(_colors[_session_index][_cc].Split(',')[2])
                        )));
                    _cc++;
                }
                _session_index++;
            }

            z.AxisChange();
            z_Graph.Refresh();
            CurveInitialized = true;
        }
        
        private List<List<List<string>>> SeperateValues(List<List<string>> RawData, List<List<string>> _ActiveSensors) {
            List<List<List<string>>> _List = new List<List<List<string>>>();
            ///
            /// List looks like this
            /// [ Session [ sample [ sensor_values ] ]
            ///
            int _Session_index = 0;

            foreach (List<string> _session in RawData) {
                _List.Add(new List<List<string>>());

                foreach (string _sample in _session) {
                    if (!_sample.StartsWith("MCT|")) {

                        _List[_List.Count - 1].Add(new List<string>());
                        string[] _tmp = _sample.Split('|');
                        _List[_List.Count - 1][_List[_List.Count - 1].Count - 1].Add(_tmp[1].Split('=')[1]); //add timestamp

                        int _sensor_index = 2;
                        foreach (string _sensor in _ActiveSensors[_Session_index]) {
                            if (_sensor == "True") {
                                string[] _tmp_sensor = _tmp[_sensor_index].Split('-');
                                //add sensorID-value
                                _List[_List.Count - 1]
                                    [_List[_List.Count - 1].Count - 1].Add
                                    (
                                        _tmp_sensor[0].Split('=')[1] + "-" + _tmp_sensor[1].Split('=')[1]
                                    );
                            }
                            _sensor_index++;
                        }
                    }
                }
                _Session_index++;
            }
            return _List;
        }

        private void Plot(List<List<List<string>>> _values) {
            int _session_index = 0;
            foreach (List<List<string>> _session in _values) {
                if (_session_index != 0) _listbox.Items.Add("");
                _listbox.Items.Add("================================");
                _listbox.Items.Add("============Session " + (_session_index + 1) + "============");
                _listbox.Items.Add("================================");
                _listbox.Items.Add("");
                double _samples_index = 1;
                foreach (List<string> _sample in _session) {
                    _listbox.Items.Add("============Sample " + _samples_index + "============");
                    int _sensor_index = 0;
                    string _sample_time = "";
                    foreach (string _sensor_value in _sample) {

                        if (_samples_index != 0)
                            if (!_sensor_value.Contains(':')) {
                                Curve[_session_index][_sensor_index].AddPoint(_samples_index, Convert.ToDouble(_sensor_value.Split('-')[1]));
                                string _list_item = Convert.ToDouble(_sensor_value.Split('-')[0]) > 9 ?
                                        "Sensor: " + _sensor_value.Split('-')[0] + " | Value= " + _sensor_value.Split('-')[1] + " | Time: " + _sample_time
                                        :
                                        "Sensor:  " + _sensor_value.Split('-')[0] + " | Value = " + _sensor_value.Split('-')[1] + " | Time: " + _sample_time;
                                _listbox.Items.Add(_list_item);
                                _sensor_index++;
                            }
                            else
                                _sample_time = _sensor_value;
                    }
                    _samples_index++;

                }
                _session_index++;
                z.AxisChange();
                z_Graph.Refresh();
            }

            
            FinalizeUI();
        }

        private void FinalizeUI() {
            int calculated_width = ("Sensor: XX | Value= XX | Time: HH:MM:SS").Length * 6;
            _listbox.Width = calculated_width;

            int _scrollBar_width = SystemInformation.VerticalScrollBarWidth;
            _listbox.Location = new Point((Width - _listbox.Width - _scrollBar_width), _listbox.Location.Y);
            _listbox.ScrollAlwaysVisible = true;
            z_Graph.Width = Width - _listbox.Width - _scrollBar_width - 5;
        }
    }
}

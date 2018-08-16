using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        private protected GraphPane z;
        private bool curveInitialized;
        private List<CurveItem> curve;

        private ListBox _listbox;

        private protected bool CurveInitialized { get => curveInitialized; set => curveInitialized = value; }
        private protected List<CurveItem> Curve { get => curve; set => curve = value; }
        

        private void SetInterface() {
            
            MaximizeBox = false;
            Location = new Point(0, 0);
            Bounds = Screen.PrimaryScreen.Bounds;
            z_Graph.Height = Height - 50;
            z_Graph.Width = Width - (Width / 4);

            _listbox = new ListBox
            {
                Location = new Point(z_Graph.Location.X + z_Graph.Width + 10, z_Graph.Location.Y),
                Height = z_Graph.Height,
            };
            Controls.Add(_listbox);
            
            InitGraphPane();
        }
        //Parse to be done here
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
            z.XAxis.Scale.MinorStep = 1;

            z.XAxis.Scale.Max = 20; //values range on X axis

            z_Graph.IsShowHScrollBar = true;

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
            z.XAxis.Title.FontSpec.Size = 7;
            z.XAxis.Scale.FontSpec.Size = 7;

            z.YAxis.Title.Text = "Temperature";
            z.YAxis.Title.FontSpec.Size = 7;
            z.YAxis.Scale.FontSpec.Size = 7;

            z.Title.Text = "Logs Overview";
            z.Title.FontSpec.Size = 10;
            z.Legend.Position = LegendPos.BottomFlushLeft;
            z.Legend.FontSpec.Size = 6;

            z.AxisChange();
            z_Graph.IsAntiAlias = true;
            z_Graph.Refresh();
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
                foreach(string _s in _session[0]) {
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

            Curve = new List<CurveItem>();
            /*LabelNames = new List<string>();
            */
            int _session_index = 0;

            foreach(List<int> _session in _init_values) {


                int _cc = 0;
                foreach (int _sensor_value in _session) {
                    Curve.Add(z_Graph.GraphPane.AddCurve(
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

            int maxSamples = 0;

            int _session_index = 0;
            foreach(List<List<string>> _session in _values) {
                if (_session_index != 0) _listbox.Items.Add("");
                _listbox.Items.Add("================================");
                _listbox.Items.Add("============Session " + (_session_index + 1) + "============");
                _listbox.Items.Add("================================");
                _listbox.Items.Add("");
                double _samples_index = 1;
                foreach (List<string> _sample in _session) {
                    _listbox.Items.Add("============Sample " + _samples_index+"============");
                    int _sensor_index = 0;
                    string _sample_time = "";
                    foreach (string _sensor_value in _sample) {
                        
                        if (_samples_index != 0)
                            if (!_sensor_value.Contains(':'))
                            {
                                Curve[_sensor_index].AddPoint(_samples_index, Convert.ToDouble(_sensor_value.Split('-')[1]));
                                string _list_item = Convert.ToDouble(_sensor_value.Split('-')[0]) > 9? 
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

            int calculated_width = ("Sensor: XX | Value= XX | Time: HH:MM:SS").Length * 6;
            _listbox.Width = calculated_width;
            FinalizeUI();
        }

        private void FinalizeUI()
        {
            int _scrollBar_width = SystemInformation.VerticalScrollBarWidth;
            _listbox.Location = new Point((Width - _listbox.Width - _scrollBar_width), _listbox.Location.Y);
            _listbox.ScrollAlwaysVisible = true;
            z_Graph.Width = Width - _listbox.Width - _scrollBar_width - 5;
        }
    }
}

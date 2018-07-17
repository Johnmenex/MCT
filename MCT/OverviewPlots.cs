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

        private protected bool CurveInitialized { get => curveInitialized; set => curveInitialized = value; }
        private protected List<CurveItem> Curve { get => curve; set => curve = value; }

        private void SetInterface() {
            Location = new Point(0, 0);
            Height = (Screen.PrimaryScreen.WorkingArea.Height * 5) / 7;
            Width = (Screen.PrimaryScreen.WorkingArea.Width * 5) / 7;


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
            z.YAxis.Title.Text = "Temperature";
            z.Title.Text = "Realtime monitoring";

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
            
            foreach (List<List<string>> _session in _Values) {

                string[] _tmp = new string[_session[0].Count];
                int _c = 0;
                foreach(string _s in _session[0]) {
                    _tmp[_c] = _s;
                    _c++;
                }
                _colors.Add(new List<string>());

                _init_values.Add(new List<int>());
                for (int i = 1; i < _tmp.Length; i++) {
                    _init_values[_init_values.Count - 1].Add(Convert.ToInt32(_tmp[i].Split('-')[1]));

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
                        "Session: " + (_session_index + 1) + "-Sensor: " + (_cc + 1),
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
            foreach(List<List<string>> _session in _values) {
                double _samples_index = 1;
                foreach (List<string> _sample in _session) {
                    int _sensor_index = 0;
                    foreach(string _sensor_value in _sample) {
                        if (_samples_index != 0)
                            if (!_sensor_value.Contains(':')) {
                                Curve[_sensor_index].AddPoint(_samples_index, Convert.ToDouble(_sensor_value.Split('-')[1]));
                                _sensor_index++;
                            }
                    }
                    _samples_index++;
                }
                _session_index++;
                z.AxisChange();
                z_Graph.Refresh();
            }
        }
    }
}

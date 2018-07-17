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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MCT {
    public partial class OpenLogs : Form {
        public OpenLogs() {
            InitializeComponent();
            //FormControls_ = new FormControls();
            InitUI();
        }

        //FormControls FormControls_;
        private int _sessionsAdded = 0;
        private int SessionsAdded { get => _sessionsAdded; set => _sessionsAdded = value; }

        private List<List<string>> _sessionSensors = new List<List<string>>();
        private List<List<string>> SessionSensors { get => _sessionSensors; set => _sessionSensors = value; }

        private void InitUI() {
            //AutoSize = true;
            //AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        private string Openfile() {
            OpenFileDialog _ofd = new OpenFileDialog();
            string _filename = "";
            _ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (_ofd.ShowDialog() == DialogResult.OK)
                _filename = _ofd.FileName;

            return _filename;
        }
        private string[] GetFileHeader() {
            string _path = Openfile();
            string[] _info = new string[2];
            if (_path == "")
                return _info;
            StreamReader _reader = new StreamReader(_path);
            
            string _value = _reader.ReadLine();
            _reader.Close();

            _info[0] = _path;
            _info[1] = _value;
            return _info;
        }

        private GroupBox SetupSessionInfoGroupBox(string _FilePath, string _SessionDate, string _SessionTime, string _SessionSamplingTime, int _NumberOfSensors) {
            GroupBox labels = new GroupBox();
            //labels.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            labels.Name = "ParentGB_" + SessionsAdded;
            labels.Text = "Session information";
            labels.BringToFront();
            //labels.AutoSize = true;
            Controls.Add(labels);

            Label Filename = new Label();
            Filename.Name = "FileName_" + SessionsAdded;
            Filename.Text = _FilePath;
            Filename.Visible = false;

            Label lb_date_created = new Label();
            lb_date_created.AutoSize = true;
            lb_date_created.Width -= 15;
            lb_date_created.Name = "lb_date_" + (SessionsAdded + 1);
            lb_date_created.Text = "Creation Date\n " + _SessionDate;
            lb_date_created.Location = new Point(3, 20);

            Label lb_time_created = new Label();
            lb_time_created.AutoSize = true;
            lb_time_created.Width -= 15;
            lb_time_created.Name = "lb_time_" + (SessionsAdded + 1);
            lb_time_created.Text = "Creation Time\n    " + _SessionTime;
            lb_time_created.Location = new Point(lb_date_created.Location.X, lb_date_created.Location.Y + lb_date_created.Height+5);

            Label lb_number_of_sensors = new Label();
            lb_number_of_sensors.AutoSize = true;
            lb_number_of_sensors.Name = "lb_sensors_number_session_" + (SessionsAdded + 1);
            lb_number_of_sensors.Text = "Sensors number: " + _NumberOfSensors;
            lb_number_of_sensors.Location = new Point(lb_time_created.Location.X + lb_time_created.Width, lb_date_created.Location.Y);

            Label lb_sampling_time = new Label();
            lb_sampling_time.AutoSize = true;
            lb_sampling_time.Name = "lb_sampling_time_session_" + (SessionsAdded + 1);
            lb_sampling_time.Text = "Sampling time: " + (Convert.ToDouble(_SessionSamplingTime) / 1000) + " s";
            lb_sampling_time.Location = new Point(lb_number_of_sensors.Location.X, lb_number_of_sensors.Location.Y + lb_number_of_sensors.Height - 7);

            Button btn_choseSensorsToPlot = new Button();
            btn_choseSensorsToPlot.AutoSize = true;
            btn_choseSensorsToPlot.Name = "btn_plot_" + (_NumberOfSensors + 1);
            btn_choseSensorsToPlot.Text = "Choose sensors";
            btn_choseSensorsToPlot.Location = new Point(lb_number_of_sensors.Location.X+3, lb_sampling_time.Location.Y + lb_sampling_time.Height - 7);
            btn_choseSensorsToPlot.Click += (sender, EventArgs) => 
            {
                btn_choseSensorsToPlot_Click(sender, EventArgs, 
                    SessionSensors[Convert.ToInt32(labels.Name.Split('_')[1])], 
                    _NumberOfSensors, 
                    (Convert.ToInt32(labels.Name.Split('_')[1]) + 1));
            };

            labels.Controls.Add(Filename);
            labels.Controls.Add(lb_date_created);
            labels.Controls.Add(lb_time_created);
            labels.Controls.Add(lb_number_of_sensors);
            labels.Controls.Add(lb_sampling_time);
            labels.Controls.Add(btn_choseSensorsToPlot);
            labels.Width = lb_sampling_time.Location.X + lb_sampling_time.Width + 5;
            labels.Height = lb_time_created.Location.Y + lb_time_created.Height+10;

            //labels.Location = new Point(3, ((button1.Location.Y + button1.Height + 5) + ((SensorsAdded) * (labels.Height + 10))));
            //labels.Show();
            return labels;
        }

        public void btn_choseSensorsToPlot_Click(object sender, EventArgs e,List<string> _SessionSensors, int _SensorsNumber,int _SessionNumber)
        {
            SensorsToPlot _SensorsSelectionForm = new SensorsToPlot(_SessionSensors, _SensorsNumber, _SessionNumber);
            if(_SensorsSelectionForm.ShowDialog() == DialogResult.OK)
            {
                SessionSensors[_SessionNumber - 1] = new List<string>();
                foreach (CheckBox _cb in _SensorsSelectionForm.SensorsToshow)
                {
                    //save the checked sensors in order to remember 
                    //which ones user selected when that session is reopened
                    SessionSensors[_SessionNumber-1].Add(_cb.Checked+""); 
                }
            }
        }

        private void ClearSessions() {
            for (int i = Controls.Count - 1; i >= 0; i--) 
                if (Controls[i].GetType() == typeof(GroupBox)) 
                    Controls.Remove(Controls[i]);

            _sessionSensors = new List<List<string>>();
            SessionsAdded = 0;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Invalidate();
            AutoSize = false;
            Width = btn_clear_sessions.Location.X + btn_clear_sessions.Width + 30;
        }
        
        private bool GetLogValidity(string _FileHeader) {
            return _FileHeader != null ? (_FileHeader.Contains("MCT|") ? true : false) : false;
        }

        private void btn_add_session_Click(object sender, EventArgs e) {
            //reads file - gets header
            //creates groupbox for session that contains:
            //1) Label with Record date 
            //2) Label with Record time 
            //3) Label with sensors
            //4) Label with Sampling rate
            //5) Checkbox for each sensor
            string[] _FileInfo = GetFileHeader();
            string _FilePath = _FileInfo[0];
            string _Fileheader = _FileInfo[1];
            if (_Fileheader == "" || _Fileheader==null)
                return;
            else if(!GetLogValidity(_Fileheader)) {
                MessageBox.Show(
                    "You have chosen an incompatible Log file.\n" +
                    "Please try again.", "File error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowOnly;

            string _SessionDate = _Fileheader.Split('|')[1];
            string _SessionTime = _Fileheader.Split('|')[2];
            string _SessionSamplingTime = _Fileheader.Split('|')[3];
            int _NumberOfSensors = _Fileheader.Split('|').Length - 4;

            GroupBox SessionInformation = SetupSessionInfoGroupBox(_FilePath, _SessionDate, _SessionTime, _SessionSamplingTime, _NumberOfSensors);

            GroupBox gb_SessionParent = new GroupBox();
            gb_SessionParent.Name = "gb_parrent_session_" + (SessionsAdded + 1);
            gb_SessionParent.Text = "File " + (SessionsAdded + 1) + " options";
            gb_SessionParent.BringToFront();

            gb_SessionParent.Controls.Add(SessionInformation);
            SessionInformation.Location = new Point(5, 15);
            gb_SessionParent.Width = SessionInformation.Width + 10;
            gb_SessionParent.Height = SessionInformation.Height + 20;
            gb_SessionParent.Location = new Point(7, ((btn_add_session.Location.Y + btn_add_session.Height + 5) + ((SessionsAdded) * (gb_SessionParent.Height+5))));
            
            Controls.Add(gb_SessionParent);

            Button btn_PlotSessions = new Button {
                Name = "btn_PlotSessions",
                Text = "Plot Sessions",
                Location = new Point(gb_SessionParent.Location.X, gb_SessionParent.Location.Y + gb_SessionParent.Height + 10)
            };
            btn_PlotSessions.Click += (object sender1, EventArgs e1) => { Btn_PlotSessions_Click(sender1, e1); };

            if (Controls.ContainsKey("btn_PlotSessions"))
                Controls.Remove(Controls.Find("btn_PlotSessions", false)[0]);
            Controls.Add(btn_PlotSessions);
            SessionSensors.Add(new List<string>()); //contains the sensors of every session that will be displayed
            SessionsAdded++;
        }

        private void Btn_PlotSessions_Click(object sender, EventArgs e)
        {
            List<string> _SessionLogs = new List<string>();
            for(int i=0;i<SessionsAdded;i++) {
                 _SessionLogs.Add(Controls.Find("FileName_" + i, true)[0].Text);
            }
            OverviewPlots overviewPlots = new OverviewPlots(_SessionLogs,SessionSensors);
            overviewPlots.Show();

        }

        private void btn_clear_sessions_Click(object sender, EventArgs e) {
            ClearSessions();
        }

        /*
        private class FormControls {

            public Button SpawnButton(Point location, string text, string name) {
                return new Button {
                    AutoSize = true,
                    Text = text,
                    Name = name,
                    Location = location,
                    Visible = true
                };
            }
            public GroupBox SpawnGroupBox(Point location, string text, string name) {

                return new GroupBox {
                    AutoSize = true,
                    Text = text,
                    Name = name,
                    Location = location,
                    Visible = true
                };
            }
            public CheckBox SpawnCheckBox(Point location, string text, string name, CheckState checkState) {
                return new CheckBox {
                    AutoSize = true,
                    Text = text,
                    Name = name,
                    Location = location,
                    Visible = true,
                    CheckState = checkState
                };
            }
            public Label SpawnLabel(Point location, string text, string name) {
                return new Label {
                    AutoSize = true,
                    Text = text,
                    Name = name,
                    Location = location,
                    Visible = true
                };
            }
        }
        */
    }
    
}

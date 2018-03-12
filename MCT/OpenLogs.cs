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
        private int _sensorsAdded = 0;
        private int SensorsAdded { get => _sensorsAdded; set => _sensorsAdded = value; }

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
        private string GetFileHeader() {
            string _path = Openfile();
            if (_path == "")
                return "";
            StreamReader _reader = new StreamReader(_path);
            
            string _value = _reader.ReadLine();
            _reader.Close();
            return _value;
        }

        private GroupBox SetupSessionInfoGroupBox(string _SessionDate, string _SessionTime, string _SessionSamplingTime, int _NumberOfSensors) {
            GroupBox labels = new GroupBox();
            //labels.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            labels.Name = "ParentGB_" + SensorsAdded;
            labels.Text = "Session information";
            labels.BringToFront();
            //labels.AutoSize = true;
            Controls.Add(labels);

            Label lb_date_created = new Label();
            lb_date_created.AutoSize = true;
            lb_date_created.Width -= 15;
            lb_date_created.Name = "lb_date_" + (SensorsAdded + 1);
            lb_date_created.Text = "Creation Date\n " + _SessionDate;
            lb_date_created.Location = new Point(3, 20);

            Label lb_time_created = new Label();
            lb_time_created.AutoSize = true;
            lb_time_created.Width -= 15;
            lb_time_created.Name = "lb_time_" + (SensorsAdded + 1);
            lb_time_created.Text = "Creation Time\n    " + _SessionTime;
            lb_time_created.Location = new Point(lb_date_created.Location.X, lb_date_created.Location.Y + lb_date_created.Height+5);

            Label lb_number_of_sensors = new Label();
            lb_number_of_sensors.AutoSize = true;
            lb_number_of_sensors.Name = "lb_sensors_number_session_" + (SensorsAdded + 1);
            lb_number_of_sensors.Text = "Sensors number: " + _NumberOfSensors;
            lb_number_of_sensors.Location = new Point(lb_time_created.Location.X + lb_time_created.Width, lb_date_created.Location.Y);

            Label lb_sampling_time = new Label();
            lb_sampling_time.AutoSize = true;
            lb_sampling_time.Name = "lb_sampling_time_session_" + (SensorsAdded + 1);
            lb_sampling_time.Text = "Sampling time: " + (Convert.ToDouble(_SessionSamplingTime) / 1000) + " s";
            lb_sampling_time.Location = new Point(lb_number_of_sensors.Location.X, lb_number_of_sensors.Location.Y + lb_number_of_sensors.Height - 7);

            Button btn_plot = new Button();
            btn_plot.AutoSize = true;
            btn_plot.Name = "btn_plot_" + (_NumberOfSensors + 1);
            btn_plot.Text = "Display sensors";
            btn_plot.Location = new Point(lb_number_of_sensors.Location.X+3, lb_sampling_time.Location.Y + lb_sampling_time.Height - 7);


            labels.Controls.Add(lb_date_created);
            labels.Controls.Add(lb_time_created);
            labels.Controls.Add(lb_number_of_sensors);
            labels.Controls.Add(lb_sampling_time);
            labels.Controls.Add(btn_plot);
            labels.Width = lb_sampling_time.Location.X + lb_sampling_time.Width + 5;
            labels.Height = lb_time_created.Location.Y + lb_time_created.Height+10;

            //labels.Location = new Point(3, ((button1.Location.Y + button1.Height + 5) + ((SensorsAdded) * (labels.Height + 10))));
            //labels.Show();
            return labels;
        }
        private void ClearSessions() {
            for (int i = Controls.Count - 1; i >= 0; i--) 
                if (Controls[i].GetType() == typeof(GroupBox)) 
                    Controls.Remove(Controls[i]);

            SensorsAdded = 0;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Invalidate();
            AutoSize = false;
            Width = btn_clear_sessions.Location.X + btn_clear_sessions.Width + 30;
        }

        private void btn_add_session_Click(object sender, EventArgs e) {
            //reads file - gets header
            //creates groupbox for session that contains:
            //1) Label with Record date 
            //2) Label with Record time 
            //3) Label with sensors
            //4) Label with Sampling rate
            //5) Checkbox for each sensor
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowOnly;
            string _Fileheader = GetFileHeader();
            if (_Fileheader == "")
                return;
            
            string _SessionDate = _Fileheader.Split('|')[1];
            string _SessionTime = _Fileheader.Split('|')[2];
            string _SessionSamplingTime = _Fileheader.Split('|')[3];
            int _NumberOfSensors = _Fileheader.Split('|').Length - 4;

            GroupBox SessionInformation = SetupSessionInfoGroupBox(_SessionDate, _SessionTime, _SessionSamplingTime, _NumberOfSensors);

            GroupBox gb_SessionParent = new GroupBox();
            gb_SessionParent.Name = "gb_parrent_session_" + (SensorsAdded + 1);
            gb_SessionParent.Text = "File " + (SensorsAdded + 1) + " options";
            gb_SessionParent.BringToFront();

            gb_SessionParent.Controls.Add(SessionInformation);
            SessionInformation.Location = new Point(5, 15);
            gb_SessionParent.Width = SessionInformation.Width + 10;
            gb_SessionParent.Height = SessionInformation.Height + 20;
            gb_SessionParent.Location = new Point(7, ((btn_add_session.Location.Y + btn_add_session.Height + 5) + ((SensorsAdded) * (gb_SessionParent.Height+5))));
            

            
            Controls.Add(gb_SessionParent);
            SensorsAdded++;
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

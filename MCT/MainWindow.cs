#define demo
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO.Ports;
using System.Diagnostics;
using System.IO;


namespace MCT {
    public partial class MainWindow : Form {
        public MainWindow() {
            InitializeComponent();
            CenterToScreen();
        }
        
        private protected string _logs = Directory.GetCurrentDirectory() + "/.tmp/_temporary/_tmpLOGS";
        private int sample_number;

        private protected RealTimeValues ValuesForm;

        private protected SerialPort SerialPort;
        private protected List<CheckBox> cb_sensors;
        private protected int _total_sensors = 0;

        private protected bool _started = false;
        private protected int _samplingTime = 0;
        private double[] serialData;

        private protected bool Started { get => _started; set => _started = value; }
        private protected int SamplingTime { get => _samplingTime; set => _samplingTime = value; }
        private protected int Total_sensors { get => _total_sensors; set => _total_sensors = value; }
        private protected double[] SerialData { get => serialData; set => serialData = value; }

        private void CreateHiddenDir() {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/.tmp/_temporary")) {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/.tmp/_temporary");
                DirectoryInfo dirinfo = new DirectoryInfo(Directory.GetCurrentDirectory() + "/.tmp");
                dirinfo.Attributes = FileAttributes.Hidden;
                dirinfo = new DirectoryInfo(Directory.GetCurrentDirectory() + "/.tmp/_temporary");
                dirinfo.Attributes = FileAttributes.Hidden;

            }
            if (File.Exists(_logs))
                File.Delete(_logs);
        }
        private string DemoMode() {
            Random _rnd = new Random();
            int _number_of_sensors;
            if (Total_sensors == 0)
                _number_of_sensors = _rnd.Next(3, 11);
            else
                _number_of_sensors = Total_sensors;

            string serial_value = "MCT";

            for (int i = 0; i < _number_of_sensors; i++) {
                serial_value += "|" + _rnd.Next(20, 45);
            }

            return serial_value;
        }
        private double[] ReceiveData() {
            double[] _SerialData = new double[Total_sensors];
            string[] _data = new string[] { "" };
#if demo
            _data = DemoMode().Split('|');
#elif !demo
            try
            {
                _data = SerialPort.ReadExisting().Split('|');
            }
            catch {
                timer_logger.Stop();
                MessageBox.Show("Could not receive any data from SerialPort.");
                Stop();
                Reset();
                return new double[] { 0 };
            }
#endif

            int _index = 0;
            foreach (string _s in _data) {
                if (_s != "MCT") {
                    _SerialData[_index] = Convert.ToDouble(_s);
                    _index++;
                }
            }

            return _SerialData;
        }
        private double[] TransmitData() {
            return SerialData;
        }
        private string DetectCOM() {
            SerialPort _serialPort = new SerialPort();
            string _serial_content = "";
            string _value = "";

            foreach (string _s in SerialPort.GetPortNames()) {

                if (!_serialPort.IsOpen)
                    _serialPort.Open();


#if demo
                _serial_content = DemoMode();
#elif !demo
                _serial_content = _serialPort.ReadExisting();
#endif
                _serialPort.Close();

#if demo
                if (_serial_content.Contains("MCT|")) //<-detects if THIS is the device we want to listen monitor
#elif !demo
                    if(_serial_content.Contains(""))
#endif
                    _value = _s;
                else
                    _value = "";
            }
            return _value;
        }
        private int DetectNumberOfSensors(SerialPort _serialPort) {
            int _value = 0;
            try {
                if (!_serialPort.IsOpen)
                    _serialPort.Open();
#if !demo
                _value = _serialPort.ReadExisting().Split('|').Length - 1;
#elif demo
                _value = DemoMode().Split('|').Length - 1;
#endif
                _serialPort.Close();
            }
            catch {
                MessageBox.Show("Could not acquire the number of sensors.");
            }
            return _value;
        }
        private void SetupSensors(int _number_of_sensors) {
            cb_sensors = new List<CheckBox>();
            gb_sensors.Controls.Clear();
            int column = 0;
            int row = 0;

            for (int i = 0; i < _number_of_sensors; i++) {
                cb_sensors.Add(new CheckBox());
                cb_sensors[i].Name = "cb_sensor_" + (i + 1);
                cb_sensors[i].Text = "Sensor " + (i + 1);
                cb_sensors[i].Checked = true;
                cb_sensors[i].AutoSize = true;

                if (column == 0)
                    cb_sensors[i].Location = new Point(
                        10 + (column * (cb_sensors[i].Width)),
                        15 + (row * 25)
                        );
                else
                    cb_sensors[i].Location = new Point(
                        (-15 * column) + (column * (cb_sensors[i].Width)),
                        15 + (row * 25)
                        );
                column++;

                if (((-15 * column) + (column * (cb_sensors[i].Width)) > gb_sensors.Width)) {
                    column = 0;
                    row++;
                }

                if ((15 + (row * 25) + cb_sensors[i].Height) > gb_sensors.Height) {
                    gb_sensors.Height += cb_sensors[i].Height;
                    Height += cb_sensors[i].Height;
                    gb_auto_mode.Location = new Point(gb_auto_mode.Location.X, gb_auto_mode.Location.Y + cb_sensors[i].Height);
                    gb_sampling_info.Height += cb_sensors[i].Height;
                }

                gb_sensors.Controls.Add(cb_sensors[i]);

            }
            lb_sensors_instructions.Visible = false;
            SerialData = new double[Total_sensors];
        }
        private void SetDTR(bool _state) {
            DTRenableToolStripMenuItem.Checked = _state;
            DTRdisableToolStripMenuItem.Checked = !_state;
            tb_DTR_state.BackColor = _state ? Color.Green : Color.Red;
        }
        private void SetRTS(bool _state) {
            RTSenableToolStripMenuItem.Checked = _state;
            RTSdisableToolStripMenuItem.Checked = !_state;
            tb_RTS_state.BackColor = _state ? Color.Green : Color.Red;
        }
        private void Start() {
            btn_start_stop.Text = "Stop";
            Started = true;

            gb_sampling_info.Enabled = false;
            gb_auto_mode.Enabled = false;

            btn_reset.Enabled = false;
            btn_save.Enabled = false;
            btn_detect_sensors.Enabled = false;
            cb_scheduled_monitor.Enabled = false;

            dTRToolStripMenuItem.Enabled = false;
            rTSToolStripMenuItem.Enabled = false;

            timer_logger.Start();
        }
        private void Stop() {
            btn_start_stop.Text = "Start";
            Started = false;

            timer_logger.Stop();
            btn_reset.Enabled = true;
            btn_save.Enabled = true;
        }
        private void Reset() {
            gb_sampling_info.Enabled = true;
            lb_USB_port.Text = "Selected USB port:";
            lb_sampling_rate.Text = "Sampling rate:";
            track_sampling_rate.Value = 0;
            track_sampling_rate.Enabled = false;
            tb_DTR_state.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            tb_RTS_state.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            lb_sensors_number.Text = "Number of detected sensors: ";

            cb_scheduled_monitor.Enabled = true;
            gb_auto_mode.Enabled = cb_scheduled_monitor.Checked;

            btn_detect_sensors.Enabled = true;
            gb_sensors.Controls.Clear();
            cb_sensors = new List<CheckBox>();

            btn_reset.Enabled = false;
            btn_save.Enabled = false;
            btn_start_stop.Enabled = false;

            Started = false;

        }
        private void ApplicationRestart() {
            DialogResult _dg = MessageBox.Show("Are you sure you want to restart \nthe application?",
                "Application restart",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (_dg == DialogResult.Yes)
                Application.Restart();
            else
                return;
        }
        private void ApplicationExit() {
            DialogResult _dg = MessageBox.Show("Are you sure you want to exit the application?",
                "Exit application",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (_dg == DialogResult.Yes)
                Application.Exit();
            else
                return;
        }
        private protected void SaveData(double[] _serialData) {
            if (!File.Exists(_logs)) {
                StreamWriter _writer = new StreamWriter(_logs);
                string _header = "MCT|" + DateTime.Now.ToString("dd/MM/yyyy|HH:mm:ss");
                foreach (CheckBox _cb in cb_sensors) {
                    if (_cb.Checked)
                        _header += "|" + _cb.Text;
                }
                _writer.WriteLine(_header);
                _writer.Close();
                sample_number = 1;
            }
            else {
                StreamReader _reader = new StreamReader(_logs);
                string _wholeFile = _reader.ReadToEnd()+"\n";
                _reader.Close();


                StreamWriter _writer = new StreamWriter(_logs);
                string _line = "Sample=" + sample_number + "|Time=" + DateTime.Now.ToString("HH:mm:ss");
                int _index = 1;
                foreach(double _v in _serialData) {
                    if(cb_sensors[_index-1].Checked) {
                        _line += "|Sensor="+_index+"-value=" + _v ;
                    }
                    _index++;
                }
                _wholeFile += _line;
                _writer.Write(_wholeFile);
                _writer.Close();
                sample_number++;
            }
        }
        
        private void btn_detect_sensors_Click(object sender, EventArgs e) {
            string _portname = DetectCOM();
            SerialPort = _portname != "" ? new SerialPort(_portname) : null;

            if (SerialPort == null)
                return;

            btn_start_stop.Text = "Start";
            btn_start_stop.Enabled = true;

            dTRToolStripMenuItem.Enabled = true;
            rTSToolStripMenuItem.Enabled = true;

            Total_sensors = DetectNumberOfSensors(SerialPort);
            SetupSensors(Total_sensors);

            lb_USB_port.Text = "Selected USB port: " + SerialPort.PortName;
            lb_sensors_number.Text = "Number of detected sensors: " + Total_sensors;
            track_sampling_rate.Enabled = true;
            SamplingTime = track_sampling_rate.Value = 500;



            SetDTR(true);
            SetRTS(true);
        }

        private void cb_scheduled_monitor_CheckedChanged(object sender, EventArgs e) {
            gb_auto_mode.Enabled = ((CheckBox)sender).Checked;
        }

        private void btn_start_stop_Click(object sender, EventArgs e) {
            if (!Started) {
                Start();
            }
            else
                Stop();
        }

        private void btn_reset_Click(object sender, EventArgs e) {
            Reset();
        }

        private void DTRenableToolStripMenuItem_Click(object sender, EventArgs e) {
            SetDTR(true);
        }

        private void DTRdisableToolStripMenuItem_Click(object sender, EventArgs e) {
            SetDTR(false);
        }

        private void RTSenableToolStripMenuItem_Click(object sender, EventArgs e) {
            SetRTS(true);
        }

        private void RTSdisableToolStripMenuItem_Click(object sender, EventArgs e) {
            SetRTS(false);
        }

        private void track_sampling_rate_Scroll(object sender, EventArgs e) {
            SamplingTime = ((TrackBar)sender).Value > 0 ? ((TrackBar)sender).Value : ((TrackBar)sender).Value + 1;
            timer_logger.Interval = SamplingTime;
            lb_sampling_rate.Text = "Sampling rate: " + track_sampling_rate.Value;
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e) {
            ApplicationRestart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            ApplicationExit();
        }

        private void realtimeValuesToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cb_sensors.Count == 0)
                return;

#if demo
            Random _rnd = new Random();
            double[] _current_Values = new double[Total_sensors];
            _current_Values = ReceiveData();
            ValuesForm = new RealTimeValues(Total_sensors, _current_Values, SamplingTime);
#elif !demo
            ValuesForm = new RealTimeValues(Total_sensors, new double[] { 1.2, 4.3, 3, 6, 7.9, 9, 17, 21.5, 14.2, 39.1, 5.5 });
#endif
            ValuesForm.Show();
        }

        private void timer_logger_Tick(object sender, EventArgs e) {
            timer_logger.Stop();
            SerialData = ReceiveData();
            SaveData(serialData);
            if (ValuesForm != null)
                ValuesForm.ReceiveData(serialData);
            timer_logger.Start();

        }
        
        private void MainWindow_Load(object sender, EventArgs e) {
            CreateHiddenDir();
        }
    }
}

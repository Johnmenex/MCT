//#define demo
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
        private int _detector_counter = 0;
        private string SerialDataToAnalyze;

        private protected RealTimeValues ValuesForm;
        private protected RealTimeGraphs GraphsForm;

        private protected SerialPort SerialPort;
        private protected List<CheckBox> cb_sensors;
        private protected int _total_sensors = 0;
        private protected bool sensorsDetected = false;

        private protected bool startDateReached = false;
        private protected bool stopDateReached = false;
        private protected bool scheduledMonitorSet = false;

        private protected bool _started = false;
        private protected int _samplingTime = 0;
        private protected double[] serialData;

        private protected bool Started { get => _started; set => _started = value; }
        private protected int SamplingTime { get => _samplingTime; set => _samplingTime = value; }
        private protected int Total_sensors { get => _total_sensors; set => _total_sensors = value; }
        private protected double[] SerialData { get => serialData; set => serialData = value; }
        private protected bool SensorsDetected { get => sensorsDetected; set => sensorsDetected = value; }
        private protected bool StartDateReached { get => startDateReached; set => startDateReached = value; }
        private protected bool StopDateReached { get => stopDateReached; set => stopDateReached = value; }
        private protected bool ScheduledMonitorSet { get => scheduledMonitorSet; set => scheduledMonitorSet = value; }

        private Timer _DateCheck = new Timer {
            Interval = 1000
        };
        private void _DateCheck_Tick(object sender, EventArgs e) {
            if (DateTime.Now.ToString("dd/MM/yyyy H:m") == dt_start_monitor.Value.ToString("dd/MM/yyyy ") + nUD_start_hour.Value + ":" + nUD_start_minute.Value) {

                StartDateReached = true;
                Start();
            }

            if (DateTime.Now.ToString("dd/MM/yyyy H:m") == dt_stop_monitor.Value.ToString("dd/MM/yyyy ") + nUD_stop_hour.Value + ":" + nUD_stop_minute.Value) {
                StopDateReached = true;
                _DateCheck.Stop();
                Stop();
            }
        }

        private void ScheduledStart() {

            ScheduledMonitorSet = !ScheduledMonitorSet;
            if (ScheduledMonitorSet) {
                _DateCheck.Tick += _DateCheck_Tick;
                btn_start_stop.Text = "Stop";
                _DateCheck.Start();
            }
            else {
                btn_start_stop.Text = "Start";
                _DateCheck.Stop();
            }


        }
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
            
            if (!SensorsDetected)
                _number_of_sensors = _rnd.Next(8, 8);
            else
                _number_of_sensors = Total_sensors;
            string serial_value = "";

            for (int i = 0; i < _number_of_sensors; i++) {
                serial_value += _rnd.Next(20, 45) + "|";
            }
            serial_value = serial_value.Remove(serial_value.Length - 1, 1);
            return serial_value;
        }
        private double[] ReceiveData(string _dataToAnalyze) {
            double[] _SerialData = new double[Total_sensors];
            string[] _data = new string[] { "" };
#if demo
            _data = DemoMode().Split('|');
#elif !demo
            try
            {
                if (_dataToAnalyze.Contains("[MCT|") && _dataToAnalyze.Contains("]")) {
                    _dataToAnalyze = _dataToAnalyze.Remove(0, _dataToAnalyze.IndexOf('['));
                    _dataToAnalyze = _dataToAnalyze.Remove(_dataToAnalyze.IndexOf('['), 5);
                    _dataToAnalyze = _dataToAnalyze.Remove(_dataToAnalyze.IndexOf(']'), _dataToAnalyze.Length - _dataToAnalyze.IndexOf(']'));
                    _data = _dataToAnalyze.Split('|');
                }
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
                _SerialData[_index] = Convert.ToDouble(_s);
                _index++;
            }

            return _SerialData;
        }
        private double[] TransmitData() {
            return SerialData;
        }
        private string DetectCOM() {
            SerialPort _serialPort = new SerialPort(); //temporary serial port
            string _serial_content = "";
            string _value = "";
            
            
            foreach (string _s in SerialPort.GetPortNames()) {
                _serialPort.PortName = _s;

                try {
                    if (!_serialPort.IsOpen)
                        _serialPort.Open();
                    _serial_content = _serialPort.ReadExisting();
                    
                    _serialPort.Close();
                    if (_serial_content.Contains("MCT|"))
                        _value = _s;
                    else
                        _value = "";

                }
                catch {}
            }
            return _value;
        }
        private int DetectNumberOfSensors(string _DataToAnalyze) {
            int _value = 0;

            try {
#if !demo
                    _DataToAnalyze = _DataToAnalyze.Remove(0, _DataToAnalyze.IndexOf('['));
                    _DataToAnalyze = _DataToAnalyze.Remove(_DataToAnalyze.IndexOf('['), 5);
                    _DataToAnalyze = _DataToAnalyze.Remove(_DataToAnalyze.IndexOf(']'), _DataToAnalyze.Length - _DataToAnalyze.IndexOf(']'));
                    _value = _DataToAnalyze.Split('|').Length;
#elif demo
                _value = DemoMode().Split('|').Length - 1;
#endif
            }
            catch {}
            if (_value != 0)
                SensorsDetected = true;
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
                if (i < _number_of_sensors - 1)
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
            SerialPort.DtrEnable = _state;
        }
        private void SetRTS(bool _state) {
            RTSenableToolStripMenuItem.Checked = _state;
            RTSdisableToolStripMenuItem.Checked = !_state;
            tb_RTS_state.BackColor = _state ? Color.Green : Color.Red;
            SerialPort.RtsEnable = _state;
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

            realtimeGraphsToolStripMenuItem.Enabled = true;
            realtimeValuesToolStripMenuItem.Enabled = true;

            timer_logger.Start();
        }
        private void Stop() {
            btn_start_stop.Text = "Start";
            Started = false;

            timer_logger.Stop();
            btn_reset.Enabled = true;
            btn_save.Enabled = true;

            cb_scheduled_monitor.Enabled = true;
            gb_auto_mode.Enabled = true;

            realtimeGraphsToolStripMenuItem.Enabled = false;
            realtimeValuesToolStripMenuItem.Enabled = false;
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

            realtimeGraphsToolStripMenuItem.Enabled = false;
            realtimeValuesToolStripMenuItem.Enabled = false;
            
            
            btn_detect_sensors.Enabled = true;
            gb_sensors.Controls.Clear();
            gb_sensors.Size = new Size(262, 127);
            gb_sampling_info.Size = new Size(200, 203);
            gb_auto_mode.Location = new Point(12, 252);
            Size = new Size(509, 399);

            cb_sensors = new List<CheckBox>();

            btn_reset.Enabled = false;
            btn_save.Enabled = false;
            btn_start_stop.Enabled = false;

            Started = false;
            SensorsDetected = false;

            StartDateReached = false;
            StopDateReached = false;
            ScheduledMonitorSet = false;

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

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            string _temporarySerialData;
            _temporarySerialData = SerialPort.ReadLine();
            if (_temporarySerialData.Contains("[MCT|") && _temporarySerialData.Contains("]")) {
                SerialDataToAnalyze = _temporarySerialData;
            }

            SerialPort.DiscardInBuffer();
        }

        private void btn_detect_sensors_Click(object sender, EventArgs e) {
#if !demo
            SensorsDetected = false;
            lb_sensors_instructions.Text = "      Detecting number " +
                                           "\n           of sensors...";
            string _portname = DetectCOM();

            if (_portname != "") {
                SerialPort = new SerialPort(_portname);
                SetDTR(true);
                SetRTS(true);
                if (!SerialPort.IsOpen)
                    SerialPort.Open();
                SerialPort.DiscardInBuffer();
                SerialPort.DataReceived += SerialPort_DataReceived;
                SerialPort.DiscardInBuffer();

            }
            else
                if (SerialPort == null) {
                    MessageBox.Show("No COM devices were detected.",
                        "Serial port error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
#endif


#if !demo
            Timer _detector = new Timer {
                Interval = 500
            };
            _detector.Tick += _detector_Tick;
            _detector.Start();
            do {
                Total_sensors = DetectNumberOfSensors(SerialDataToAnalyze);
                lb_USB_port.Text = "Selected USB port: " + SerialPort.PortName;
                Application.DoEvents();
            } while (_detector.Enabled);
#elif demo


            if (SensorsDetected)
                return;
            Total_sensors = DemoMode().Split('|').Length;
            lb_USB_port.Text = "Selected USB port: " + "Demo COM1";
            SensorsDetected = true;

#endif
            btn_start_stop.Text = "Start";
            btn_start_stop.Enabled = true;

            dTRToolStripMenuItem.Enabled = true;
            rTSToolStripMenuItem.Enabled = true;

            SetupSensors(Total_sensors);
            
            lb_sensors_number.Text = "Number of detected sensors: " + Total_sensors;
            track_sampling_rate.Enabled = true;
            timer_logger.Interval = SamplingTime = track_sampling_rate.Value = 500;
        }
        
        private void _detector_Tick(object sender, EventArgs e) {
            _detector_counter++;
            if (_detector_counter > 10 || SensorsDetected)
                ((Timer)sender).Stop();
        }

        private void cb_scheduled_monitor_CheckedChanged(object sender, EventArgs e) {
            gb_auto_mode.Enabled = ((CheckBox)sender).Checked;
        }
        
        private void btn_start_stop_Click(object sender, EventArgs e) {
            if (!Started) {
                if (cb_scheduled_monitor.Checked) {
                    ScheduledStart();
                }
                else
                    Start();
            }
            else {
                if (_DateCheck.Enabled)
                    _DateCheck.Stop();
                ScheduledMonitorSet = false;
                Stop();
            }
            
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
            _current_Values = ReceiveData("");
            ValuesForm = new RealTimeValues(Total_sensors, _current_Values, SamplingTime);
#elif !demo
            ValuesForm = new RealTimeValues(Total_sensors, serialData, SamplingTime);
#endif
            ValuesForm.Show();
        }

        private void timer_logger_Tick(object sender, EventArgs e) {
            timer_logger.Stop();
            SerialData = ReceiveData(SerialDataToAnalyze);
            SaveData(serialData);


            if (ValuesForm != null)
                ValuesForm.ReceiveData(serialData);
            if (GraphsForm != null) {
                GraphsForm.ReceiveData(serialData);
            }

            timer_logger.Start();

        }
        
        private void MainWindow_Load(object sender, EventArgs e) {
            CreateHiddenDir();
        }

        private void realtimeGraphsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cb_sensors.Count == 0)
                return;

#if demo
            Random _rnd = new Random();
            double[] _current_Values = new double[Total_sensors];
            _current_Values = ReceiveData("");
            GraphsForm = new RealTimeGraphs(Total_sensors, _current_Values, SamplingTime);
            
#elif !demo
            GraphsForm = new RealTimeGraphs(Total_sensors, SerialData, SamplingTime);
            
#endif
            GraphsForm.Show();
        }
    }
}

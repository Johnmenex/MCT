﻿using System;
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


namespace MCT
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        SerialPort SerialPort;
        List<CheckBox> cb_sensors;

        private bool _started = false;

        public bool Started { get => _started; set => _started = value; }

        private string DetectCOM()
        {
            SerialPort _serialPort = new SerialPort();
            string _serial_content = "";
            string _value = "";

            foreach (string _s in SerialPort.GetPortNames())
            {

                if (!_serialPort.IsOpen)
                    _serialPort.Open();

                _serial_content = _serialPort.ReadExisting();
                _serialPort.Close();

                if (_serial_content.Contains("")) //<-detects if THIS is the device we want to listen monitor
                    _value = _s;
                else
                    _value = "";
            }
            return _value;
        }
        private int DetectNumberOfSensors(SerialPort _serialPort)
        {
            int _value = 0;
            try
            {
                if (!_serialPort.IsOpen)
                    _serialPort.Open();

                _value = _serialPort.ReadExisting().Split('|').Length - 1;
                _serialPort.Close();
            }
            catch
            {
                MessageBox.Show("Could not acquire the number of sensors.");
            }
            return _value;
        }
        private void SetupSensors(int _number_of_sensors)
        {
            cb_sensors = new List<CheckBox>();
            int column = 0;
            int row = 0;

            for (int i = 0; i < _number_of_sensors; i++)
            {
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

                if (((-15 * column) + (column * (cb_sensors[i].Width)) > gb_sensors.Width))
                {
                    column = 0;
                    row++;
                }

                if ((15 + (row * 25) + cb_sensors[i].Height) > gb_sensors.Height)
                {
                    gb_sensors.Height += cb_sensors[i].Height;
                    Height += cb_sensors[i].Height;
                    gb_auto_mode.Location = new Point(gb_auto_mode.Location.X, gb_auto_mode.Location.Y + cb_sensors[i].Height);
                    gb_sampling_info.Height += cb_sensors[i].Height;
                }

                gb_sensors.Controls.Add(cb_sensors[i]);

            }
            lb_sensors_instructions.Visible = false;
        }
        private void SetDTR(bool _state)
        {
            DTRenableToolStripMenuItem.Checked = _state? true : false;
            DTRdisableToolStripMenuItem.Checked = !_state ? true : false;
            tb_DTR_state.BackColor = _state ? Color.Green : Color.Red;
        }
        private void SetRTS(bool _state)
        {
            RTSenableToolStripMenuItem.Checked = _state ? true : false;
            RTSdisableToolStripMenuItem.Checked = !_state ? true : false;
            tb_RTS_state.BackColor = _state ? Color.Green : Color.Red;
        }
        private void Start()
        {
            btn_start_stop.Text = "Stop";

            gb_sampling_info.Enabled = false;
            gb_auto_mode.Enabled = false;

            btn_reset.Enabled = false;
            btn_save.Enabled = false;
            btn_detect_sensors.Enabled = false;
            cb_scheduled_monitor.Enabled = false;

            timer_logger.Start();
        }
        private void Stop()
        {
            btn_start_stop.Text = "Start";

            timer_logger.Stop();
            btn_reset.Enabled = true;
            btn_save.Enabled = true;
        }
        private void Reset()
        {
            gb_sampling_info.Enabled = true;
            lb_USB_port.Text = "Selected USB port:";
            lb_sampling_rate.Text = "Sampling rate:";
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
        }

        private void btn_detect_sensors_Click(object sender, EventArgs e)
        {
            string _portname = DetectCOM();
            SerialPort = _portname!="" ? new SerialPort(_portname) : null;

            if (SerialPort == null)
                return;

            btn_start_stop.Text = "Start";
            btn_start_stop.Enabled = true;


            lb_USB_port.Text = "Selected USB port: " + SerialPort.PortName;
            lb_sensors_number.Text = "Number of detected sensors: " + DetectNumberOfSensors(SerialPort);
            track_sampling_rate.Enabled=true;

            SetupSensors(9);

            SetDTR(true);
            SetRTS(true);
        }

        private void cb_scheduled_monitor_CheckedChanged(object sender, EventArgs e)
        {
            gb_auto_mode.Enabled = ((CheckBox)sender).Checked;
            
        }

        private void btn_start_stop_Click(object sender, EventArgs e)
        {
            if (!Started)
                Start();
            else
                Stop();
            
            Started = !Started;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
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
            catch {
                MessageBox.Show("Could not acquire the number of sensors.");
            }
            return _value;
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
                
                if((15 + (row * 25) + cb_sensors[i].Height) >gb_sensors.Height)
                {
                    gb_sensors.Height += cb_sensors[i].Height;
                    Height += cb_sensors[i].Height;
                    gb_auto_mode.Location = new Point(gb_auto_mode.Location.X, gb_auto_mode.Location.Y + cb_sensors[i].Height);
                    gb_sampling_info.Height += cb_sensors[i].Height;
                }

                gb_sensors.Controls.Add(cb_sensors[i]);

            }
            gb_sensors.Visible = true;
        }

        private void btn_detect_sensors_Click(object sender, EventArgs e)
        {
            string _portname = DetectCOM();
            SerialPort = _portname!="" ? new SerialPort(_portname) : null;

            if (SerialPort == null)
                return;

            lb_USB_port.Text += SerialPort.PortName;
            lb_sensors_number.Text += "" + DetectNumberOfSensors(SerialPort);
            track_sampling_rate.Enabled=true;

            SetupSensors(9);

            SetDTR(true);
            SetRTS(true);
        }
    }
}

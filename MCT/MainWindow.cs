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

        private string DetectCOM()
        {
            SerialPort _serialPort = new SerialPort();
            string _serial_content="";
            string _value = "";

            foreach (string _s in SerialPort.GetPortNames())
            {

                if (_serialPort.IsOpen)
                    _serial_content = _serialPort.ReadExisting();
                else
                {
                    _serialPort.Open();
                    _serial_content = _serialPort.ReadExisting();
                    _serialPort.Close();
                }

                if (_serial_content == "MCT|") //<-detects if THIS is the device we want to listen monitor
                    _value = _s;
                else
                    _value = "";
            }
            return _value;
        }

        private void btn_detect_sensors_Click(object sender, EventArgs e)
        {
            string _portname = DetectCOM();
            SerialPort = _portname!="" ? new SerialPort(_portname) : null;
        }
    }
}

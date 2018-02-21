using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace MCT {
    public partial class RealTimeGraphs : Form {
        public RealTimeGraphs() {
            InitializeComponent();
        }


        public RealTimeGraphs(int _n_sensors, double[] _current_Values, int _sampling_rate) {
            if (_n_sensors == 0)
                return;

            InitializeComponent();
        }

        public void ReceiveData(double[] _sensor_values) {
            SensorValues = _sensor_values;
        }

        private protected GraphPane z;
        private protected List<CurveItem> _curves;
        double[] _sensorValues;

        private protected List<CurveItem> Curves { get => _curves; set => _curves = value; }
        private protected double[] SensorValues { get => _sensorValues; set => _sensorValues = value; }
    }
}
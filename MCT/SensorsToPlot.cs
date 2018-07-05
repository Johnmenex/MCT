using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCT
{
    public partial class SensorsToPlot : Form
    {
        public SensorsToPlot(List<string> _SessionSensors, int _NumberOfSessionSensors, int _SessionID)
        {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowOnly;

            InitializeComponent();
            SetInterface(_SessionSensors, _NumberOfSessionSensors, _SessionID);
        }
        private List<CheckBox> _sensorsToshow = new List<CheckBox>();
        public List<CheckBox> SensorsToshow { get => _sensorsToshow; }


        Button btn_setSensors;

        private void SetInterface(List<string> _SessionSensors, int _NumberOfSessionSensors, int _SessionID)
        {
            //MessageBox.Show(_SessionSensors.Count+"");
            string __s = "";
                foreach(string _s in _SessionSensors)
                {
                    __s += _s + "\n";
                }
                //MessageBox.Show(__s);
            
            Text = "Session" + _SessionID + " - Sensors ";
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;

            btn_setSensors = new Button();
            btn_setSensors.Click += Btn_SetDemands_Click;
            btn_setSensors.Width = 85;
            btn_setSensors.Text = "Set Sensors";

            int column = 0;
            int row = 0;
            for (int i = 0; i < _NumberOfSessionSensors; i++)
            {
                CheckBox _tmpCB = new CheckBox
                {
                    AutoSize = true,
                    Text = "Sensor " + (i + 1)
                };

                SensorsToshow.Add(new CheckBox
                {
                    AutoSize = true,
                    Text = "Sensor " + (i + 1),
                    Location = new Point(
                    10 + (column * ((_tmpCB.Width) - 20)),
                    5 + (row * 25)
                    ),
                    Checked = _SessionSensors.Count > 0 ?
                        _SessionSensors[i].Contains("True") ? true : false
                        : true

                });

                Controls.Add(SensorsToshow[i]);
                column++;
                    if (column > 2)
                    {
                        column = 0;
                        row++;
                    }
            }
            Width = SensorsToshow[SensorsToshow.Count - 1].Location.X + 10;
            Height = SensorsToshow[SensorsToshow.Count - 1].Location.X + 10;
            btn_setSensors.Location = new Point(
                Convert.ToInt32((Size.Width / 2) - (btn_setSensors.Width / 2)) - 7,
                Convert.ToInt32(Size.Height - btn_setSensors.Height)
                );
            Controls.Add(btn_setSensors);
        }

        private void Btn_SetDemands_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}

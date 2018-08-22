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
using System.Drawing;
using System.Windows.Forms;

namespace MCT {
    public partial class SensorsToPlot : Form {
        public SensorsToPlot(List<string> _SessionSensors, int _NumberOfSessionSensors, int _SessionID) {
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowOnly;

            InitializeComponent();
            SetInterface(_SessionSensors, _NumberOfSessionSensors, _SessionID);
        }
        private List<CheckBox> _sensorsToshow = new List<CheckBox>();
        public List<CheckBox> SensorsToshow { get => _sensorsToshow; }


        Button btn_setSensors;

        private void SetInterface(List<string> _SessionSensors, int _NumberOfSessionSensors, int _SessionID) {
            //MessageBox.Show(_SessionSensors.Count+"");
            string __s = "";
            foreach (string _s in _SessionSensors) {
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
            for (int i = 0; i < _NumberOfSessionSensors; i++) {
                CheckBox _tmpCB = new CheckBox {
                    AutoSize = true,
                    Text = "Sensor " + (i + 1)
                };

                SensorsToshow.Add(new CheckBox {
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
                if (column > 2) {
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

        private void Btn_SetDemands_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}

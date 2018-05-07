using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCT {
    public partial class Progress : Form {
        public Progress() {
            InitializeComponent();
        }

        public bool stopped = false;
        Point location = new Point();

        public void GetSet_location(Point f1_loc) {
            location = f1_loc;
        }

        private void stop_Click(object sender, EventArgs e) {
            stopped = !stopped;
            if (((Button)(sender)).Text == "Close")
                this.Close();
        }

        private void Progress_FormClosing(object sender, FormClosingEventArgs e) {
            stopped = !stopped;
            this.Dispose();
        }

        private void Progress_Load(object sender, EventArgs e) {
            this.Location = location;
        }
    }
}

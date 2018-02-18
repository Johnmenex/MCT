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

namespace MCT
{
    public partial class RealTimeValues : Form
    {
        public RealTimeValues()
        {
            InitializeComponent();
        }
        GraphPane z;

        private void InitGraphPane()
        {
            z = zedGraphControl1.GraphPane;
            //z.Rect = new RectangleF(new PointF(2, 2), new SizeF(Width, Height));

            //z.XAxis.Scale.MinorStep = 1;
            //z.XAxis.Scale.Max = 5; //values range on X axis
            //z.YAxis.Scale.Max = 100; //values range on Y axis
            z.YAxis.Scale.MaxAuto = true;
            z.YAxis.Scale.MinAuto = true;

            z.XAxis.MajorGrid.DashOff = 0;
            z.YAxis.MajorGrid.DashOff = 0;

            z.XAxis.MajorGrid.Color = Color.DarkSlateGray;
            z.XAxis.MinorGrid.IsVisible = true;
            z.XAxis.MinorGrid.Color = Color.Gray;
            z.XAxis.MajorGrid.IsVisible = true;

            z.YAxis.MajorGrid.Color = Color.DarkSlateGray;
            z.YAxis.MajorGrid.IsVisible = true;
            z.YAxis.MinorGrid.Color = Color.Gray;
            z.YAxis.MinorGrid.IsVisible = true;

            z.XAxis.IsAxisSegmentVisible = false;
            z.XAxis.IsVisible = false;

            z.Title.Text = "Realtime Values";

            z.XAxis.Title.Text = "Sensors";
            z.XAxis.IsVisible = true;

            z.YAxis.Title.Text = "Temperature";
            z.YAxis.IsVisible = true;
        }

        private void RealTimeValues_Load(object sender, EventArgs e)
        {
            CenterToScreen();

            InitGraphPane();
        }
    }
}

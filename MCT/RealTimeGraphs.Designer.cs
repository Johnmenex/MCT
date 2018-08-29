namespace MCT {
    partial class RealTimeGraphs {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.timer_visualizer = new System.Windows.Forms.Timer(this.components);
            this.gb_parent = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(813, 439);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // timer_visualizer
            // 
            this.timer_visualizer.Tick += new System.EventHandler(this.timer_visualizer_Tick);
            // 
            // gb_parent
            // 
            this.gb_parent.Location = new System.Drawing.Point(13, 459);
            this.gb_parent.Name = "gb_parent";
            this.gb_parent.Size = new System.Drawing.Size(813, 140);
            this.gb_parent.TabIndex = 2;
            this.gb_parent.TabStop = false;
            this.gb_parent.Text = "Thresholds";
            // 
            // RealTimeGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 611);
            this.Controls.Add(this.gb_parent);
            this.Controls.Add(this.zedGraphControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "RealTimeGraphs";
            this.Text = "RealTimeGraphs";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Timer timer_visualizer;
        private System.Windows.Forms.GroupBox gb_parent;
    }
}
namespace MCT
{
    partial class RealTimeValues
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.timer_visualiser = new System.Windows.Forms.Timer(this.components);
            this.gb_parent = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(13, 13);
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
            // timer_visualiser
            // 
            this.timer_visualiser.Tick += new System.EventHandler(this.timer_visualiser_Tick);
            // 
            // gb_parent
            // 
            this.gb_parent.Location = new System.Drawing.Point(13, 459);
            this.gb_parent.Name = "gb_parent";
            this.gb_parent.Size = new System.Drawing.Size(813, 128);
            this.gb_parent.TabIndex = 1;
            this.gb_parent.TabStop = false;
            this.gb_parent.Text = "Thresholds";
            // 
            // RealTimeValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 596);
            this.Controls.Add(this.gb_parent);
            this.Controls.Add(this.zedGraphControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "RealTimeValues";
            this.Text = "RealTimeValues";
            this.Load += new System.EventHandler(this.RealTimeValues_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Timer timer_visualiser;
        private System.Windows.Forms.GroupBox gb_parent;
    }
}
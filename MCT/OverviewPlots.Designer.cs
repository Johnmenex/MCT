namespace MCT {
    partial class OverviewPlots {
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
            this.z_Graph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // z_Graph
            // 
            this.z_Graph.Location = new System.Drawing.Point(2, 2);
            this.z_Graph.Name = "z_Graph";
            this.z_Graph.ScrollGrace = 0D;
            this.z_Graph.ScrollMaxX = 0D;
            this.z_Graph.ScrollMaxY = 0D;
            this.z_Graph.ScrollMaxY2 = 0D;
            this.z_Graph.ScrollMinX = 0D;
            this.z_Graph.ScrollMinY = 0D;
            this.z_Graph.ScrollMinY2 = 0D;
            this.z_Graph.Size = new System.Drawing.Size(813, 439);
            this.z_Graph.TabIndex = 1;
            // 
            // OverviewPlots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 450);
            this.Controls.Add(this.z_Graph);
            this.Name = "OverviewPlots";
            this.Text = "OverviewPlots";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl z_Graph;
    }
}
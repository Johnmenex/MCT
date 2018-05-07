namespace MCT {
    partial class Progress {
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
            this.stop = new System.Windows.Forms.Button();
            this.current_samples_LB = new System.Windows.Forms.Label();
            this.conversion_progress_LB = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(103, 84);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 7;
            this.stop.Text = "button1";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // current_samples_LB
            // 
            this.current_samples_LB.AutoSize = true;
            this.current_samples_LB.Location = new System.Drawing.Point(13, 58);
            this.current_samples_LB.Name = "current_samples_LB";
            this.current_samples_LB.Size = new System.Drawing.Size(35, 13);
            this.current_samples_LB.TabIndex = 6;
            this.current_samples_LB.Text = "label2";
            // 
            // conversion_progress_LB
            // 
            this.conversion_progress_LB.AutoSize = true;
            this.conversion_progress_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.conversion_progress_LB.Location = new System.Drawing.Point(12, 9);
            this.conversion_progress_LB.Name = "conversion_progress_LB";
            this.conversion_progress_LB.Size = new System.Drawing.Size(182, 20);
            this.conversion_progress_LB.TabIndex = 5;
            this.conversion_progress_LB.Text = "Conversion in progress...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 32);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(260, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 144);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.current_samples_LB);
            this.Controls.Add(this.conversion_progress_LB);
            this.Controls.Add(this.progressBar1);
            this.Name = "Progress";
            this.Text = "Progress";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Progress_FormClosing);
            this.Load += new System.EventHandler(this.Progress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button stop;
        public System.Windows.Forms.Label current_samples_LB;
        public System.Windows.Forms.Label conversion_progress_LB;
        public System.Windows.Forms.ProgressBar progressBar1;
    }
}
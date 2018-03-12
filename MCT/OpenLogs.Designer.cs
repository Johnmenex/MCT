namespace MCT {
    partial class OpenLogs {
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
            this.btn_add_session = new System.Windows.Forms.Button();
            this.btn_clear_sessions = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_add_session
            // 
            this.btn_add_session.Location = new System.Drawing.Point(12, 12);
            this.btn_add_session.Name = "btn_add_session";
            this.btn_add_session.Size = new System.Drawing.Size(90, 38);
            this.btn_add_session.TabIndex = 0;
            this.btn_add_session.Text = "Open Session";
            this.btn_add_session.UseVisualStyleBackColor = true;
            this.btn_add_session.Click += new System.EventHandler(this.btn_add_session_Click);
            // 
            // btn_clear_sessions
            // 
            this.btn_clear_sessions.Location = new System.Drawing.Point(108, 12);
            this.btn_clear_sessions.Name = "btn_clear_sessions";
            this.btn_clear_sessions.Size = new System.Drawing.Size(90, 38);
            this.btn_clear_sessions.TabIndex = 1;
            this.btn_clear_sessions.Text = "Clear Sessions";
            this.btn_clear_sessions.UseVisualStyleBackColor = true;
            // 
            // OpenLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 64);
            this.Controls.Add(this.btn_clear_sessions);
            this.Controls.Add(this.btn_add_session);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OpenLogs";
            this.Text = "OpenLogs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_add_session;
        private System.Windows.Forms.Button btn_clear_sessions;
    }
}
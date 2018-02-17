namespace MCT
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dTRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DTRenableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DTRdisableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rTSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RTSenableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RTSdisableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activityMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realtimeValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realtimeGraphsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareRecordingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelCompatibilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertXmlFileToTxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertXmlFileToXlsxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gb_sensors = new System.Windows.Forms.GroupBox();
            this.btn_start_stop = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_detect_sensors = new System.Windows.Forms.Button();
            this.gb_sampling_info = new System.Windows.Forms.GroupBox();
            this.tb_RTS_state = new System.Windows.Forms.TextBox();
            this.tb_DTR_state = new System.Windows.Forms.TextBox();
            this.track_sampling_rate = new System.Windows.Forms.TrackBar();
            this.lb_sensors_number = new System.Windows.Forms.Label();
            this.lb_RTS_state = new System.Windows.Forms.Label();
            this.lb_DTR_state = new System.Windows.Forms.Label();
            this.lb_sampling_rate = new System.Windows.Forms.Label();
            this.lb_USB_port = new System.Windows.Forms.Label();
            this.gb_buttons = new System.Windows.Forms.GroupBox();
            this.cb_scheduled_monitor = new System.Windows.Forms.CheckBox();
            this.gb_auto_mode = new System.Windows.Forms.GroupBox();
            this.lb_scheduled_minute = new System.Windows.Forms.Label();
            this.lb_scheduled_hour = new System.Windows.Forms.Label();
            this.lb_scheduled_date = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lb_finish_date = new System.Windows.Forms.Label();
            this.lb_start_date = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.gb_sampling_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_sampling_rate)).BeginInit();
            this.gb_buttons.SuspendLayout();
            this.gb_auto_mode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.activityMonitorToolStripMenuItem,
            this.recordingsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.applicationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(493, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portToolStripMenuItem,
            this.dTRToolStripMenuItem,
            this.rTSToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.portToolStripMenuItem.Text = "Port";
            // 
            // dTRToolStripMenuItem
            // 
            this.dTRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DTRenableToolStripMenuItem,
            this.DTRdisableToolStripMenuItem});
            this.dTRToolStripMenuItem.Name = "dTRToolStripMenuItem";
            this.dTRToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dTRToolStripMenuItem.Text = "DTR";
            // 
            // DTRenableToolStripMenuItem
            // 
            this.DTRenableToolStripMenuItem.Name = "DTRenableToolStripMenuItem";
            this.DTRenableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DTRenableToolStripMenuItem.Text = "Enable";
            // 
            // DTRdisableToolStripMenuItem
            // 
            this.DTRdisableToolStripMenuItem.Name = "DTRdisableToolStripMenuItem";
            this.DTRdisableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DTRdisableToolStripMenuItem.Text = "Disable";
            // 
            // rTSToolStripMenuItem
            // 
            this.rTSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RTSenableToolStripMenuItem,
            this.RTSdisableToolStripMenuItem});
            this.rTSToolStripMenuItem.Name = "rTSToolStripMenuItem";
            this.rTSToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rTSToolStripMenuItem.Text = "RTS";
            // 
            // RTSenableToolStripMenuItem
            // 
            this.RTSenableToolStripMenuItem.Name = "RTSenableToolStripMenuItem";
            this.RTSenableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.RTSenableToolStripMenuItem.Text = "Enable";
            // 
            // RTSdisableToolStripMenuItem
            // 
            this.RTSdisableToolStripMenuItem.Name = "RTSdisableToolStripMenuItem";
            this.RTSdisableToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.RTSdisableToolStripMenuItem.Text = "Disable";
            // 
            // activityMonitorToolStripMenuItem
            // 
            this.activityMonitorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realtimeValuesToolStripMenuItem,
            this.realtimeGraphsToolStripMenuItem});
            this.activityMonitorToolStripMenuItem.Name = "activityMonitorToolStripMenuItem";
            this.activityMonitorToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.activityMonitorToolStripMenuItem.Text = "Activity Monitor";
            // 
            // realtimeValuesToolStripMenuItem
            // 
            this.realtimeValuesToolStripMenuItem.Name = "realtimeValuesToolStripMenuItem";
            this.realtimeValuesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.realtimeValuesToolStripMenuItem.Text = "Real-time Values";
            // 
            // realtimeGraphsToolStripMenuItem
            // 
            this.realtimeGraphsToolStripMenuItem.Name = "realtimeGraphsToolStripMenuItem";
            this.realtimeGraphsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.realtimeGraphsToolStripMenuItem.Text = "Real-time Graphs";
            // 
            // recordingsToolStripMenuItem
            // 
            this.recordingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compareRecordingsToolStripMenuItem,
            this.excelCompatibilityToolStripMenuItem});
            this.recordingsToolStripMenuItem.Name = "recordingsToolStripMenuItem";
            this.recordingsToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.recordingsToolStripMenuItem.Text = "Recordings";
            // 
            // compareRecordingsToolStripMenuItem
            // 
            this.compareRecordingsToolStripMenuItem.Name = "compareRecordingsToolStripMenuItem";
            this.compareRecordingsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.compareRecordingsToolStripMenuItem.Text = "Compare Recordings";
            // 
            // excelCompatibilityToolStripMenuItem
            // 
            this.excelCompatibilityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertXmlFileToTxtToolStripMenuItem,
            this.convertXmlFileToXlsxToolStripMenuItem});
            this.excelCompatibilityToolStripMenuItem.Name = "excelCompatibilityToolStripMenuItem";
            this.excelCompatibilityToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.excelCompatibilityToolStripMenuItem.Text = "Excel compatibility";
            // 
            // convertXmlFileToTxtToolStripMenuItem
            // 
            this.convertXmlFileToTxtToolStripMenuItem.Name = "convertXmlFileToTxtToolStripMenuItem";
            this.convertXmlFileToTxtToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.convertXmlFileToTxtToolStripMenuItem.Text = "Convert xml file to txt";
            // 
            // convertXmlFileToXlsxToolStripMenuItem
            // 
            this.convertXmlFileToXlsxToolStripMenuItem.Name = "convertXmlFileToXlsxToolStripMenuItem";
            this.convertXmlFileToXlsxToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.convertXmlFileToXlsxToolStripMenuItem.Text = "Convert xml file to xlsx";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.applicationToolStripMenuItem.Text = "Application";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // gb_sensors
            // 
            this.gb_sensors.Location = new System.Drawing.Point(12, 103);
            this.gb_sensors.Name = "gb_sensors";
            this.gb_sensors.Size = new System.Drawing.Size(262, 127);
            this.gb_sensors.TabIndex = 1;
            this.gb_sensors.TabStop = false;
            this.gb_sensors.Text = "Sensors to monitor";
            this.gb_sensors.Visible = false;
            // 
            // btn_start_stop
            // 
            this.btn_start_stop.Enabled = false;
            this.btn_start_stop.Location = new System.Drawing.Point(193, 13);
            this.btn_start_stop.Name = "btn_start_stop";
            this.btn_start_stop.Size = new System.Drawing.Size(63, 50);
            this.btn_start_stop.TabIndex = 2;
            this.btn_start_stop.Text = "Start \r\n--------\r\nStop";
            this.btn_start_stop.UseVisualStyleBackColor = true;
            // 
            // btn_reset
            // 
            this.btn_reset.Enabled = false;
            this.btn_reset.Location = new System.Drawing.Point(140, 12);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(51, 23);
            this.btn_reset.TabIndex = 3;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Enabled = false;
            this.btn_save.Location = new System.Drawing.Point(140, 40);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(51, 23);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_detect_sensors
            // 
            this.btn_detect_sensors.Location = new System.Drawing.Point(6, 12);
            this.btn_detect_sensors.Name = "btn_detect_sensors";
            this.btn_detect_sensors.Size = new System.Drawing.Size(128, 24);
            this.btn_detect_sensors.TabIndex = 5;
            this.btn_detect_sensors.Text = "Detect sensors";
            this.btn_detect_sensors.UseVisualStyleBackColor = true;
            this.btn_detect_sensors.Click += new System.EventHandler(this.btn_detect_sensors_Click);
            // 
            // gb_sampling_info
            // 
            this.gb_sampling_info.Controls.Add(this.tb_RTS_state);
            this.gb_sampling_info.Controls.Add(this.tb_DTR_state);
            this.gb_sampling_info.Controls.Add(this.track_sampling_rate);
            this.gb_sampling_info.Controls.Add(this.lb_sensors_number);
            this.gb_sampling_info.Controls.Add(this.lb_RTS_state);
            this.gb_sampling_info.Controls.Add(this.lb_DTR_state);
            this.gb_sampling_info.Controls.Add(this.lb_sampling_rate);
            this.gb_sampling_info.Controls.Add(this.lb_USB_port);
            this.gb_sampling_info.Location = new System.Drawing.Point(280, 27);
            this.gb_sampling_info.Name = "gb_sampling_info";
            this.gb_sampling_info.Size = new System.Drawing.Size(200, 203);
            this.gb_sampling_info.TabIndex = 5;
            this.gb_sampling_info.TabStop = false;
            this.gb_sampling_info.Text = "Monitoring parameters and information";
            // 
            // tb_RTS_state
            // 
            this.tb_RTS_state.BackColor = System.Drawing.SystemColors.Control;
            this.tb_RTS_state.Enabled = false;
            this.tb_RTS_state.Location = new System.Drawing.Point(68, 145);
            this.tb_RTS_state.Multiline = true;
            this.tb_RTS_state.Name = "tb_RTS_state";
            this.tb_RTS_state.Size = new System.Drawing.Size(20, 20);
            this.tb_RTS_state.TabIndex = 7;
            // 
            // tb_DTR_state
            // 
            this.tb_DTR_state.BackColor = System.Drawing.SystemColors.Control;
            this.tb_DTR_state.Enabled = false;
            this.tb_DTR_state.Location = new System.Drawing.Point(68, 115);
            this.tb_DTR_state.Multiline = true;
            this.tb_DTR_state.Name = "tb_DTR_state";
            this.tb_DTR_state.Size = new System.Drawing.Size(20, 20);
            this.tb_DTR_state.TabIndex = 6;
            // 
            // track_sampling_rate
            // 
            this.track_sampling_rate.Enabled = false;
            this.track_sampling_rate.Location = new System.Drawing.Point(6, 70);
            this.track_sampling_rate.Name = "track_sampling_rate";
            this.track_sampling_rate.Size = new System.Drawing.Size(187, 45);
            this.track_sampling_rate.TabIndex = 5;
            // 
            // lb_sensors_number
            // 
            this.lb_sensors_number.AutoSize = true;
            this.lb_sensors_number.Location = new System.Drawing.Point(6, 175);
            this.lb_sensors_number.Name = "lb_sensors_number";
            this.lb_sensors_number.Size = new System.Drawing.Size(146, 13);
            this.lb_sensors_number.TabIndex = 4;
            this.lb_sensors_number.Text = "Number of detected sensors: ";
            // 
            // lb_RTS_state
            // 
            this.lb_RTS_state.AutoSize = true;
            this.lb_RTS_state.Location = new System.Drawing.Point(7, 148);
            this.lb_RTS_state.Name = "lb_RTS_state";
            this.lb_RTS_state.Size = new System.Drawing.Size(55, 13);
            this.lb_RTS_state.TabIndex = 3;
            this.lb_RTS_state.Text = "RTS state";
            // 
            // lb_DTR_state
            // 
            this.lb_DTR_state.AutoSize = true;
            this.lb_DTR_state.Location = new System.Drawing.Point(7, 118);
            this.lb_DTR_state.Name = "lb_DTR_state";
            this.lb_DTR_state.Size = new System.Drawing.Size(56, 13);
            this.lb_DTR_state.TabIndex = 2;
            this.lb_DTR_state.Text = "DTR state";
            // 
            // lb_sampling_rate
            // 
            this.lb_sampling_rate.AutoSize = true;
            this.lb_sampling_rate.Location = new System.Drawing.Point(6, 45);
            this.lb_sampling_rate.Name = "lb_sampling_rate";
            this.lb_sampling_rate.Size = new System.Drawing.Size(77, 13);
            this.lb_sampling_rate.TabIndex = 1;
            this.lb_sampling_rate.Text = "Sampling rate: ";
            // 
            // lb_USB_port
            // 
            this.lb_USB_port.AutoSize = true;
            this.lb_USB_port.Location = new System.Drawing.Point(6, 21);
            this.lb_USB_port.Name = "lb_USB_port";
            this.lb_USB_port.Size = new System.Drawing.Size(101, 13);
            this.lb_USB_port.TabIndex = 0;
            this.lb_USB_port.Text = "Selected USB port: ";
            // 
            // gb_buttons
            // 
            this.gb_buttons.Controls.Add(this.btn_detect_sensors);
            this.gb_buttons.Controls.Add(this.cb_scheduled_monitor);
            this.gb_buttons.Controls.Add(this.btn_start_stop);
            this.gb_buttons.Controls.Add(this.btn_reset);
            this.gb_buttons.Controls.Add(this.btn_save);
            this.gb_buttons.Location = new System.Drawing.Point(12, 27);
            this.gb_buttons.Name = "gb_buttons";
            this.gb_buttons.Size = new System.Drawing.Size(262, 70);
            this.gb_buttons.TabIndex = 6;
            this.gb_buttons.TabStop = false;
            // 
            // cb_scheduled_monitor
            // 
            this.cb_scheduled_monitor.AutoSize = true;
            this.cb_scheduled_monitor.Location = new System.Drawing.Point(6, 41);
            this.cb_scheduled_monitor.Name = "cb_scheduled_monitor";
            this.cb_scheduled_monitor.Size = new System.Drawing.Size(128, 17);
            this.cb_scheduled_monitor.TabIndex = 6;
            this.cb_scheduled_monitor.Text = "Scheduled monitoring";
            this.cb_scheduled_monitor.UseVisualStyleBackColor = true;
            // 
            // gb_auto_mode
            // 
            this.gb_auto_mode.Controls.Add(this.lb_scheduled_minute);
            this.gb_auto_mode.Controls.Add(this.lb_scheduled_hour);
            this.gb_auto_mode.Controls.Add(this.lb_scheduled_date);
            this.gb_auto_mode.Controls.Add(this.numericUpDown4);
            this.gb_auto_mode.Controls.Add(this.numericUpDown3);
            this.gb_auto_mode.Controls.Add(this.numericUpDown2);
            this.gb_auto_mode.Controls.Add(this.numericUpDown1);
            this.gb_auto_mode.Controls.Add(this.dateTimePicker2);
            this.gb_auto_mode.Controls.Add(this.dateTimePicker1);
            this.gb_auto_mode.Controls.Add(this.lb_finish_date);
            this.gb_auto_mode.Controls.Add(this.lb_start_date);
            this.gb_auto_mode.Location = new System.Drawing.Point(13, 236);
            this.gb_auto_mode.Name = "gb_auto_mode";
            this.gb_auto_mode.Size = new System.Drawing.Size(468, 96);
            this.gb_auto_mode.TabIndex = 7;
            this.gb_auto_mode.TabStop = false;
            this.gb_auto_mode.Text = "Scheduled monitoring";
            // 
            // lb_scheduled_minute
            // 
            this.lb_scheduled_minute.AutoSize = true;
            this.lb_scheduled_minute.Location = new System.Drawing.Point(404, 12);
            this.lb_scheduled_minute.Name = "lb_scheduled_minute";
            this.lb_scheduled_minute.Size = new System.Drawing.Size(39, 13);
            this.lb_scheduled_minute.TabIndex = 10;
            this.lb_scheduled_minute.Text = "Minute";
            // 
            // lb_scheduled_hour
            // 
            this.lb_scheduled_hour.AutoSize = true;
            this.lb_scheduled_hour.Location = new System.Drawing.Point(352, 12);
            this.lb_scheduled_hour.Name = "lb_scheduled_hour";
            this.lb_scheduled_hour.Size = new System.Drawing.Size(30, 13);
            this.lb_scheduled_hour.TabIndex = 9;
            this.lb_scheduled_hour.Text = "Hour";
            // 
            // lb_scheduled_date
            // 
            this.lb_scheduled_date.AutoSize = true;
            this.lb_scheduled_date.Location = new System.Drawing.Point(194, 12);
            this.lb_scheduled_date.Name = "lb_scheduled_date";
            this.lb_scheduled_date.Size = new System.Drawing.Size(30, 13);
            this.lb_scheduled_date.TabIndex = 8;
            this.lb_scheduled_date.Text = "Date";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(401, 64);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown4.TabIndex = 7;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(345, 64);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown3.TabIndex = 6;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(345, 31);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown2.TabIndex = 5;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(401, 31);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown1.TabIndex = 4;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(114, 64);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(215, 20);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(114, 31);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(215, 20);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // lb_finish_date
            // 
            this.lb_finish_date.AutoSize = true;
            this.lb_finish_date.Location = new System.Drawing.Point(16, 66);
            this.lb_finish_date.Name = "lb_finish_date";
            this.lb_finish_date.Size = new System.Drawing.Size(95, 13);
            this.lb_finish_date.TabIndex = 1;
            this.lb_finish_date.Text = "Stop monitoring at:";
            // 
            // lb_start_date
            // 
            this.lb_start_date.AutoSize = true;
            this.lb_start_date.Location = new System.Drawing.Point(16, 33);
            this.lb_start_date.Name = "lb_start_date";
            this.lb_start_date.Size = new System.Drawing.Size(95, 13);
            this.lb_start_date.TabIndex = 0;
            this.lb_start_date.Text = "Start monitoring at:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 339);
            this.Controls.Add(this.gb_auto_mode);
            this.Controls.Add(this.gb_buttons);
            this.Controls.Add(this.gb_sampling_info);
            this.Controls.Add(this.gb_sensors);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Control Panel";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gb_sampling_info.ResumeLayout(false);
            this.gb_sampling_info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.track_sampling_rate)).EndInit();
            this.gb_buttons.ResumeLayout(false);
            this.gb_buttons.PerformLayout();
            this.gb_auto_mode.ResumeLayout(false);
            this.gb_auto_mode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dTRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rTSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activityMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realtimeValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realtimeGraphsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareRecordingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelCompatibilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertXmlFileToTxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertXmlFileToXlsxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox gb_sensors;
        private System.Windows.Forms.Button btn_start_stop;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_detect_sensors;
        private System.Windows.Forms.GroupBox gb_sampling_info;
        private System.Windows.Forms.TextBox tb_RTS_state;
        private System.Windows.Forms.TextBox tb_DTR_state;
        private System.Windows.Forms.TrackBar track_sampling_rate;
        private System.Windows.Forms.Label lb_sensors_number;
        private System.Windows.Forms.Label lb_RTS_state;
        private System.Windows.Forms.Label lb_DTR_state;
        private System.Windows.Forms.Label lb_sampling_rate;
        private System.Windows.Forms.Label lb_USB_port;
        private System.Windows.Forms.GroupBox gb_buttons;
        private System.Windows.Forms.CheckBox cb_scheduled_monitor;
        private System.Windows.Forms.GroupBox gb_auto_mode;
        private System.Windows.Forms.Label lb_scheduled_minute;
        private System.Windows.Forms.Label lb_scheduled_hour;
        private System.Windows.Forms.Label lb_scheduled_date;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lb_finish_date;
        private System.Windows.Forms.Label lb_start_date;
        private System.Windows.Forms.ToolStripMenuItem DTRenableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DTRdisableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RTSenableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RTSdisableToolStripMenuItem;
    }
}


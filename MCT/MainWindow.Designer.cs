﻿namespace MCT {
    partial class MainWindow {
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.convertLogFileToTxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertLogFileToXlsxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gb_sensors = new System.Windows.Forms.GroupBox();
            this.lb_sensors_instructions = new System.Windows.Forms.Label();
            this.btn_start_stop = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_detect_sensors = new System.Windows.Forms.Button();
            this.gb_sampling_info = new System.Windows.Forms.GroupBox();
            this.nud_sampling_rate = new System.Windows.Forms.NumericUpDown();
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
            this.nUD_stop_minute = new System.Windows.Forms.NumericUpDown();
            this.nUD_stop_hour = new System.Windows.Forms.NumericUpDown();
            this.nUD_start_hour = new System.Windows.Forms.NumericUpDown();
            this.nUD_start_minute = new System.Windows.Forms.NumericUpDown();
            this.dt_stop_monitor = new System.Windows.Forms.DateTimePicker();
            this.dt_start_monitor = new System.Windows.Forms.DateTimePicker();
            this.lb_finish_date = new System.Windows.Forms.Label();
            this.lb_start_date = new System.Windows.Forms.Label();
            this.timer_logger = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.gb_sensors.SuspendLayout();
            this.gb_sampling_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sampling_rate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_sampling_rate)).BeginInit();
            this.gb_buttons.SuspendLayout();
            this.gb_auto_mode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_stop_minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_stop_hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_start_hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_start_minute)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.activityMonitorToolStripMenuItem,
            this.recordingsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.applicationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(657, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dTRToolStripMenuItem,
            this.rTSToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // dTRToolStripMenuItem
            // 
            this.dTRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DTRenableToolStripMenuItem,
            this.DTRdisableToolStripMenuItem});
            this.dTRToolStripMenuItem.Enabled = false;
            this.dTRToolStripMenuItem.Name = "dTRToolStripMenuItem";
            this.dTRToolStripMenuItem.Size = new System.Drawing.Size(111, 26);
            this.dTRToolStripMenuItem.Text = "DTR";
            // 
            // DTRenableToolStripMenuItem
            // 
            this.DTRenableToolStripMenuItem.Name = "DTRenableToolStripMenuItem";
            this.DTRenableToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.DTRenableToolStripMenuItem.Text = "Enable";
            this.DTRenableToolStripMenuItem.Click += new System.EventHandler(this.DTRenableToolStripMenuItem_Click);
            // 
            // DTRdisableToolStripMenuItem
            // 
            this.DTRdisableToolStripMenuItem.Name = "DTRdisableToolStripMenuItem";
            this.DTRdisableToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.DTRdisableToolStripMenuItem.Text = "Disable";
            this.DTRdisableToolStripMenuItem.Click += new System.EventHandler(this.DTRdisableToolStripMenuItem_Click);
            // 
            // rTSToolStripMenuItem
            // 
            this.rTSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RTSenableToolStripMenuItem,
            this.RTSdisableToolStripMenuItem});
            this.rTSToolStripMenuItem.Enabled = false;
            this.rTSToolStripMenuItem.Name = "rTSToolStripMenuItem";
            this.rTSToolStripMenuItem.Size = new System.Drawing.Size(111, 26);
            this.rTSToolStripMenuItem.Text = "RTS";
            // 
            // RTSenableToolStripMenuItem
            // 
            this.RTSenableToolStripMenuItem.Name = "RTSenableToolStripMenuItem";
            this.RTSenableToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.RTSenableToolStripMenuItem.Text = "Enable";
            this.RTSenableToolStripMenuItem.Click += new System.EventHandler(this.RTSenableToolStripMenuItem_Click);
            // 
            // RTSdisableToolStripMenuItem
            // 
            this.RTSdisableToolStripMenuItem.Name = "RTSdisableToolStripMenuItem";
            this.RTSdisableToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.RTSdisableToolStripMenuItem.Text = "Disable";
            this.RTSdisableToolStripMenuItem.Click += new System.EventHandler(this.RTSdisableToolStripMenuItem_Click);
            // 
            // activityMonitorToolStripMenuItem
            // 
            this.activityMonitorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realtimeValuesToolStripMenuItem,
            this.realtimeGraphsToolStripMenuItem});
            this.activityMonitorToolStripMenuItem.Name = "activityMonitorToolStripMenuItem";
            this.activityMonitorToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.activityMonitorToolStripMenuItem.Text = "Activity Monitor";
            // 
            // realtimeValuesToolStripMenuItem
            // 
            this.realtimeValuesToolStripMenuItem.Enabled = false;
            this.realtimeValuesToolStripMenuItem.Name = "realtimeValuesToolStripMenuItem";
            this.realtimeValuesToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.realtimeValuesToolStripMenuItem.Text = "Real-time Values";
            this.realtimeValuesToolStripMenuItem.Click += new System.EventHandler(this.realtimeValuesToolStripMenuItem_Click);
            // 
            // realtimeGraphsToolStripMenuItem
            // 
            this.realtimeGraphsToolStripMenuItem.Enabled = false;
            this.realtimeGraphsToolStripMenuItem.Name = "realtimeGraphsToolStripMenuItem";
            this.realtimeGraphsToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.realtimeGraphsToolStripMenuItem.Text = "Real-time Graphs";
            this.realtimeGraphsToolStripMenuItem.Click += new System.EventHandler(this.realtimeGraphsToolStripMenuItem_Click);
            // 
            // recordingsToolStripMenuItem
            // 
            this.recordingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compareRecordingsToolStripMenuItem,
            this.excelCompatibilityToolStripMenuItem});
            this.recordingsToolStripMenuItem.Name = "recordingsToolStripMenuItem";
            this.recordingsToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.recordingsToolStripMenuItem.Text = "Recordings";
            // 
            // compareRecordingsToolStripMenuItem
            // 
            this.compareRecordingsToolStripMenuItem.Name = "compareRecordingsToolStripMenuItem";
            this.compareRecordingsToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.compareRecordingsToolStripMenuItem.Text = "Compare Recordings";
            this.compareRecordingsToolStripMenuItem.Click += new System.EventHandler(this.compareRecordingsToolStripMenuItem_Click);
            // 
            // excelCompatibilityToolStripMenuItem
            // 
            this.excelCompatibilityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertLogFileToTxtToolStripMenuItem,
            this.convertLogFileToXlsxToolStripMenuItem});
            this.excelCompatibilityToolStripMenuItem.Name = "excelCompatibilityToolStripMenuItem";
            this.excelCompatibilityToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.excelCompatibilityToolStripMenuItem.Text = "Excel compatibility";
            // 
            // convertLogFileToTxtToolStripMenuItem
            // 
            this.convertLogFileToTxtToolStripMenuItem.Name = "convertLogFileToTxtToolStripMenuItem";
            this.convertLogFileToTxtToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.convertLogFileToTxtToolStripMenuItem.Text = "Convert log file to csv";
            this.convertLogFileToTxtToolStripMenuItem.Click += new System.EventHandler(this.convertLogFileToTxtToolStripMenuItem_Click);
            // 
            // convertLogFileToXlsxToolStripMenuItem
            // 
            this.convertLogFileToXlsxToolStripMenuItem.Name = "convertLogFileToXlsxToolStripMenuItem";
            this.convertLogFileToXlsxToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.convertLogFileToXlsxToolStripMenuItem.Text = "Convert log file to xlsx";
            this.convertLogFileToXlsxToolStripMenuItem.Click += new System.EventHandler(this.convertLogFileToXlsxToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(133, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.applicationToolStripMenuItem.Text = "Application";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // gb_sensors
            // 
            this.gb_sensors.Controls.Add(this.lb_sensors_instructions);
            this.gb_sensors.Location = new System.Drawing.Point(16, 127);
            this.gb_sensors.Margin = new System.Windows.Forms.Padding(4);
            this.gb_sensors.Name = "gb_sensors";
            this.gb_sensors.Padding = new System.Windows.Forms.Padding(4);
            this.gb_sensors.Size = new System.Drawing.Size(349, 156);
            this.gb_sensors.TabIndex = 1;
            this.gb_sensors.TabStop = false;
            this.gb_sensors.Text = "Sensors to monitor";
            // 
            // lb_sensors_instructions
            // 
            this.lb_sensors_instructions.AutoSize = true;
            this.lb_sensors_instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lb_sensors_instructions.Location = new System.Drawing.Point(21, 46);
            this.lb_sensors_instructions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_sensors_instructions.Name = "lb_sensors_instructions";
            this.lb_sensors_instructions.Size = new System.Drawing.Size(275, 75);
            this.lb_sensors_instructions.TabIndex = 0;
            this.lb_sensors_instructions.Text = "Press the \"Detect sensors\" \r\nbutton for the sensors to \r\nbe detected and displaye" +
    "d.";
            // 
            // btn_start_stop
            // 
            this.btn_start_stop.Enabled = false;
            this.btn_start_stop.Location = new System.Drawing.Point(257, 16);
            this.btn_start_stop.Margin = new System.Windows.Forms.Padding(4);
            this.btn_start_stop.Name = "btn_start_stop";
            this.btn_start_stop.Size = new System.Drawing.Size(84, 62);
            this.btn_start_stop.TabIndex = 2;
            this.btn_start_stop.Text = "Start";
            this.btn_start_stop.UseVisualStyleBackColor = true;
            this.btn_start_stop.Click += new System.EventHandler(this.btn_start_stop_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.Enabled = false;
            this.btn_reset.Location = new System.Drawing.Point(187, 15);
            this.btn_reset.Margin = new System.Windows.Forms.Padding(4);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(68, 28);
            this.btn_reset.TabIndex = 3;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_save
            // 
            this.btn_save.Enabled = false;
            this.btn_save.Location = new System.Drawing.Point(187, 49);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(68, 28);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_detect_sensors
            // 
            this.btn_detect_sensors.Location = new System.Drawing.Point(8, 15);
            this.btn_detect_sensors.Margin = new System.Windows.Forms.Padding(4);
            this.btn_detect_sensors.Name = "btn_detect_sensors";
            this.btn_detect_sensors.Size = new System.Drawing.Size(171, 30);
            this.btn_detect_sensors.TabIndex = 5;
            this.btn_detect_sensors.Text = "Detect sensors";
            this.btn_detect_sensors.UseVisualStyleBackColor = true;
            this.btn_detect_sensors.Click += new System.EventHandler(this.btn_detect_sensors_Click);
            // 
            // gb_sampling_info
            // 
            this.gb_sampling_info.Controls.Add(this.nud_sampling_rate);
            this.gb_sampling_info.Controls.Add(this.tb_RTS_state);
            this.gb_sampling_info.Controls.Add(this.tb_DTR_state);
            this.gb_sampling_info.Controls.Add(this.track_sampling_rate);
            this.gb_sampling_info.Controls.Add(this.lb_sensors_number);
            this.gb_sampling_info.Controls.Add(this.lb_RTS_state);
            this.gb_sampling_info.Controls.Add(this.lb_DTR_state);
            this.gb_sampling_info.Controls.Add(this.lb_sampling_rate);
            this.gb_sampling_info.Controls.Add(this.lb_USB_port);
            this.gb_sampling_info.Location = new System.Drawing.Point(373, 33);
            this.gb_sampling_info.Margin = new System.Windows.Forms.Padding(4);
            this.gb_sampling_info.Name = "gb_sampling_info";
            this.gb_sampling_info.Padding = new System.Windows.Forms.Padding(4);
            this.gb_sampling_info.Size = new System.Drawing.Size(267, 250);
            this.gb_sampling_info.TabIndex = 5;
            this.gb_sampling_info.TabStop = false;
            this.gb_sampling_info.Text = "Monitoring parameters and information";
            // 
            // nud_sampling_rate
            // 
            this.nud_sampling_rate.Enabled = false;
            this.nud_sampling_rate.Location = new System.Drawing.Point(142, 56);
            this.nud_sampling_rate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_sampling_rate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_sampling_rate.Name = "nud_sampling_rate";
            this.nud_sampling_rate.Size = new System.Drawing.Size(61, 22);
            this.nud_sampling_rate.TabIndex = 0;
            this.nud_sampling_rate.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nud_sampling_rate.ValueChanged += new System.EventHandler(this.nud_sampling_rate_ValueChanged);
            // 
            // tb_RTS_state
            // 
            this.tb_RTS_state.BackColor = System.Drawing.SystemColors.Control;
            this.tb_RTS_state.Enabled = false;
            this.tb_RTS_state.Location = new System.Drawing.Point(91, 178);
            this.tb_RTS_state.Margin = new System.Windows.Forms.Padding(4);
            this.tb_RTS_state.Multiline = true;
            this.tb_RTS_state.Name = "tb_RTS_state";
            this.tb_RTS_state.Size = new System.Drawing.Size(25, 24);
            this.tb_RTS_state.TabIndex = 7;
            // 
            // tb_DTR_state
            // 
            this.tb_DTR_state.BackColor = System.Drawing.SystemColors.Control;
            this.tb_DTR_state.Enabled = false;
            this.tb_DTR_state.Location = new System.Drawing.Point(91, 142);
            this.tb_DTR_state.Margin = new System.Windows.Forms.Padding(4);
            this.tb_DTR_state.Multiline = true;
            this.tb_DTR_state.Name = "tb_DTR_state";
            this.tb_DTR_state.Size = new System.Drawing.Size(25, 24);
            this.tb_DTR_state.TabIndex = 6;
            // 
            // track_sampling_rate
            // 
            this.track_sampling_rate.Enabled = false;
            this.track_sampling_rate.Location = new System.Drawing.Point(8, 86);
            this.track_sampling_rate.Margin = new System.Windows.Forms.Padding(4);
            this.track_sampling_rate.Maximum = 1000;
            this.track_sampling_rate.Name = "track_sampling_rate";
            this.track_sampling_rate.Size = new System.Drawing.Size(249, 56);
            this.track_sampling_rate.TabIndex = 5;
            this.track_sampling_rate.Value = 500;
            this.track_sampling_rate.Scroll += new System.EventHandler(this.track_sampling_rate_Scroll);
            // 
            // lb_sensors_number
            // 
            this.lb_sensors_number.AutoSize = true;
            this.lb_sensors_number.Location = new System.Drawing.Point(8, 215);
            this.lb_sensors_number.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_sensors_number.Name = "lb_sensors_number";
            this.lb_sensors_number.Size = new System.Drawing.Size(195, 17);
            this.lb_sensors_number.TabIndex = 4;
            this.lb_sensors_number.Text = "Number of detected sensors: ";
            // 
            // lb_RTS_state
            // 
            this.lb_RTS_state.AutoSize = true;
            this.lb_RTS_state.Location = new System.Drawing.Point(9, 182);
            this.lb_RTS_state.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_RTS_state.Name = "lb_RTS_state";
            this.lb_RTS_state.Size = new System.Drawing.Size(71, 17);
            this.lb_RTS_state.TabIndex = 3;
            this.lb_RTS_state.Text = "RTS state";
            // 
            // lb_DTR_state
            // 
            this.lb_DTR_state.AutoSize = true;
            this.lb_DTR_state.Location = new System.Drawing.Point(9, 145);
            this.lb_DTR_state.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_DTR_state.Name = "lb_DTR_state";
            this.lb_DTR_state.Size = new System.Drawing.Size(72, 17);
            this.lb_DTR_state.TabIndex = 2;
            this.lb_DTR_state.Text = "DTR state";
            // 
            // lb_sampling_rate
            // 
            this.lb_sampling_rate.AutoSize = true;
            this.lb_sampling_rate.Location = new System.Drawing.Point(8, 55);
            this.lb_sampling_rate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_sampling_rate.Name = "lb_sampling_rate";
            this.lb_sampling_rate.Size = new System.Drawing.Size(135, 17);
            this.lb_sampling_rate.TabIndex = 1;
            this.lb_sampling_rate.Text = "Sampling rate (ms): ";
            // 
            // lb_USB_port
            // 
            this.lb_USB_port.AutoSize = true;
            this.lb_USB_port.Location = new System.Drawing.Point(8, 26);
            this.lb_USB_port.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_USB_port.Name = "lb_USB_port";
            this.lb_USB_port.Size = new System.Drawing.Size(132, 17);
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
            this.gb_buttons.Location = new System.Drawing.Point(16, 33);
            this.gb_buttons.Margin = new System.Windows.Forms.Padding(4);
            this.gb_buttons.Name = "gb_buttons";
            this.gb_buttons.Padding = new System.Windows.Forms.Padding(4);
            this.gb_buttons.Size = new System.Drawing.Size(349, 86);
            this.gb_buttons.TabIndex = 6;
            this.gb_buttons.TabStop = false;
            // 
            // cb_scheduled_monitor
            // 
            this.cb_scheduled_monitor.AutoSize = true;
            this.cb_scheduled_monitor.Location = new System.Drawing.Point(8, 50);
            this.cb_scheduled_monitor.Margin = new System.Windows.Forms.Padding(4);
            this.cb_scheduled_monitor.Name = "cb_scheduled_monitor";
            this.cb_scheduled_monitor.Size = new System.Drawing.Size(167, 21);
            this.cb_scheduled_monitor.TabIndex = 6;
            this.cb_scheduled_monitor.Text = "Scheduled monitoring";
            this.cb_scheduled_monitor.UseVisualStyleBackColor = true;
            this.cb_scheduled_monitor.CheckedChanged += new System.EventHandler(this.cb_scheduled_monitor_CheckedChanged);
            // 
            // gb_auto_mode
            // 
            this.gb_auto_mode.Controls.Add(this.lb_scheduled_minute);
            this.gb_auto_mode.Controls.Add(this.lb_scheduled_hour);
            this.gb_auto_mode.Controls.Add(this.lb_scheduled_date);
            this.gb_auto_mode.Controls.Add(this.nUD_stop_minute);
            this.gb_auto_mode.Controls.Add(this.nUD_stop_hour);
            this.gb_auto_mode.Controls.Add(this.nUD_start_hour);
            this.gb_auto_mode.Controls.Add(this.nUD_start_minute);
            this.gb_auto_mode.Controls.Add(this.dt_stop_monitor);
            this.gb_auto_mode.Controls.Add(this.dt_start_monitor);
            this.gb_auto_mode.Controls.Add(this.lb_finish_date);
            this.gb_auto_mode.Controls.Add(this.lb_start_date);
            this.gb_auto_mode.Enabled = false;
            this.gb_auto_mode.Location = new System.Drawing.Point(16, 310);
            this.gb_auto_mode.Margin = new System.Windows.Forms.Padding(4);
            this.gb_auto_mode.Name = "gb_auto_mode";
            this.gb_auto_mode.Padding = new System.Windows.Forms.Padding(4);
            this.gb_auto_mode.Size = new System.Drawing.Size(624, 118);
            this.gb_auto_mode.TabIndex = 7;
            this.gb_auto_mode.TabStop = false;
            this.gb_auto_mode.Text = "Scheduled monitoring";
            // 
            // lb_scheduled_minute
            // 
            this.lb_scheduled_minute.AutoSize = true;
            this.lb_scheduled_minute.Location = new System.Drawing.Point(539, 15);
            this.lb_scheduled_minute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_scheduled_minute.Name = "lb_scheduled_minute";
            this.lb_scheduled_minute.Size = new System.Drawing.Size(50, 17);
            this.lb_scheduled_minute.TabIndex = 10;
            this.lb_scheduled_minute.Text = "Minute";
            // 
            // lb_scheduled_hour
            // 
            this.lb_scheduled_hour.AutoSize = true;
            this.lb_scheduled_hour.Location = new System.Drawing.Point(469, 15);
            this.lb_scheduled_hour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_scheduled_hour.Name = "lb_scheduled_hour";
            this.lb_scheduled_hour.Size = new System.Drawing.Size(39, 17);
            this.lb_scheduled_hour.TabIndex = 9;
            this.lb_scheduled_hour.Text = "Hour";
            // 
            // lb_scheduled_date
            // 
            this.lb_scheduled_date.AutoSize = true;
            this.lb_scheduled_date.Location = new System.Drawing.Point(259, 15);
            this.lb_scheduled_date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_scheduled_date.Name = "lb_scheduled_date";
            this.lb_scheduled_date.Size = new System.Drawing.Size(38, 17);
            this.lb_scheduled_date.TabIndex = 8;
            this.lb_scheduled_date.Text = "Date";
            // 
            // nUD_stop_minute
            // 
            this.nUD_stop_minute.Location = new System.Drawing.Point(535, 79);
            this.nUD_stop_minute.Margin = new System.Windows.Forms.Padding(4);
            this.nUD_stop_minute.Name = "nUD_stop_minute";
            this.nUD_stop_minute.Size = new System.Drawing.Size(57, 22);
            this.nUD_stop_minute.TabIndex = 7;
            // 
            // nUD_stop_hour
            // 
            this.nUD_stop_hour.Location = new System.Drawing.Point(460, 79);
            this.nUD_stop_hour.Margin = new System.Windows.Forms.Padding(4);
            this.nUD_stop_hour.Name = "nUD_stop_hour";
            this.nUD_stop_hour.Size = new System.Drawing.Size(57, 22);
            this.nUD_stop_hour.TabIndex = 6;
            // 
            // nUD_start_hour
            // 
            this.nUD_start_hour.Location = new System.Drawing.Point(460, 38);
            this.nUD_start_hour.Margin = new System.Windows.Forms.Padding(4);
            this.nUD_start_hour.Name = "nUD_start_hour";
            this.nUD_start_hour.Size = new System.Drawing.Size(57, 22);
            this.nUD_start_hour.TabIndex = 5;
            // 
            // nUD_start_minute
            // 
            this.nUD_start_minute.Location = new System.Drawing.Point(535, 38);
            this.nUD_start_minute.Margin = new System.Windows.Forms.Padding(4);
            this.nUD_start_minute.Name = "nUD_start_minute";
            this.nUD_start_minute.Size = new System.Drawing.Size(57, 22);
            this.nUD_start_minute.TabIndex = 4;
            // 
            // dt_stop_monitor
            // 
            this.dt_stop_monitor.Location = new System.Drawing.Point(152, 79);
            this.dt_stop_monitor.Margin = new System.Windows.Forms.Padding(4);
            this.dt_stop_monitor.Name = "dt_stop_monitor";
            this.dt_stop_monitor.Size = new System.Drawing.Size(285, 22);
            this.dt_stop_monitor.TabIndex = 3;
            // 
            // dt_start_monitor
            // 
            this.dt_start_monitor.Location = new System.Drawing.Point(152, 38);
            this.dt_start_monitor.Margin = new System.Windows.Forms.Padding(4);
            this.dt_start_monitor.Name = "dt_start_monitor";
            this.dt_start_monitor.Size = new System.Drawing.Size(285, 22);
            this.dt_start_monitor.TabIndex = 2;
            // 
            // lb_finish_date
            // 
            this.lb_finish_date.AutoSize = true;
            this.lb_finish_date.Location = new System.Drawing.Point(21, 81);
            this.lb_finish_date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_finish_date.Name = "lb_finish_date";
            this.lb_finish_date.Size = new System.Drawing.Size(127, 17);
            this.lb_finish_date.TabIndex = 1;
            this.lb_finish_date.Text = "Stop monitoring at:";
            // 
            // lb_start_date
            // 
            this.lb_start_date.AutoSize = true;
            this.lb_start_date.Location = new System.Drawing.Point(21, 41);
            this.lb_start_date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_start_date.Name = "lb_start_date";
            this.lb_start_date.Size = new System.Drawing.Size(128, 17);
            this.lb_start_date.TabIndex = 0;
            this.lb_start_date.Text = "Start monitoring at:";
            // 
            // timer_logger
            // 
            this.timer_logger.Tick += new System.EventHandler(this.timer_logger_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 443);
            this.Controls.Add(this.gb_auto_mode);
            this.Controls.Add(this.gb_buttons);
            this.Controls.Add(this.gb_sampling_info);
            this.Controls.Add(this.gb_sensors);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Control Panel";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gb_sensors.ResumeLayout(false);
            this.gb_sensors.PerformLayout();
            this.gb_sampling_info.ResumeLayout(false);
            this.gb_sampling_info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sampling_rate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_sampling_rate)).EndInit();
            this.gb_buttons.ResumeLayout(false);
            this.gb_buttons.PerformLayout();
            this.gb_auto_mode.ResumeLayout(false);
            this.gb_auto_mode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_stop_minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_stop_hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_start_hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_start_minute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dTRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rTSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activityMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realtimeValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realtimeGraphsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareRecordingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelCompatibilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertLogFileToTxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertLogFileToXlsxToolStripMenuItem;
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
        private System.Windows.Forms.NumericUpDown nUD_stop_minute;
        private System.Windows.Forms.NumericUpDown nUD_stop_hour;
        private System.Windows.Forms.NumericUpDown nUD_start_hour;
        private System.Windows.Forms.NumericUpDown nUD_start_minute;
        private System.Windows.Forms.DateTimePicker dt_stop_monitor;
        private System.Windows.Forms.DateTimePicker dt_start_monitor;
        private System.Windows.Forms.Label lb_finish_date;
        private System.Windows.Forms.Label lb_start_date;
        private System.Windows.Forms.ToolStripMenuItem DTRenableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DTRdisableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RTSenableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RTSdisableToolStripMenuItem;
        private System.Windows.Forms.Label lb_sensors_instructions;
        private System.Windows.Forms.Timer timer_logger;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.NumericUpDown nud_sampling_rate;
    }
}


﻿namespace AirMonit_Admin
{
    partial class FormAdmin
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.checkBoxNO2 = new System.Windows.Forms.CheckBox();
            this.checkBoxCO = new System.Windows.Forms.CheckBox();
            this.checkBoxO3 = new System.Windows.Forms.CheckBox();
            this.labelParameters = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.dateTimeEndDate = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.dateTimeStartDate = new System.Windows.Forms.DateTimePicker();
            this.labelCities = new System.Windows.Forms.Label();
            this.comboBoxCities = new System.Windows.Forms.ComboBox();
            this.tabPageUncommonEvents = new System.Windows.Forms.TabPage();
            this.labelTotalEvents = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelEventsNoData = new System.Windows.Forms.Label();
            this.labelEventsEndDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelEventsStartDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelUncommonCityOrCities = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridViewUncommonEvents = new System.Windows.Forms.DataGridView();
            this.tabPageRaisedAlarms = new System.Windows.Forms.TabPage();
            this.labelAlarmsCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRaisedAlarmsNoData = new System.Windows.Forms.Label();
            this.labelDateEnd = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelDateStart = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelRaisedAlarmsCityOrCities = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewRaisedAlarms = new System.Windows.Forms.DataGridView();
            this.tabChart = new System.Windows.Forms.TabPage();
            this.labelChartCurrentCityName = new System.Windows.Forms.Label();
            this.labelChartCurrentCity = new System.Windows.Forms.Label();
            this.labelChartFunctionType = new System.Windows.Forms.Label();
            this.labelChartFunction = new System.Windows.Forms.Label();
            this.labelNoDataAvailable = new System.Windows.Forms.Label();
            this.labelChartValues = new System.Windows.Forms.Label();
            this.labelChartDays = new System.Windows.Forms.Label();
            this.chartDaysData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelChartActiveMode1 = new System.Windows.Forms.Label();
            this.labelChartActiveMode = new System.Windows.Forms.Label();
            this.labelChartViewMode = new System.Windows.Forms.Label();
            this.buttonMode = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.labelGroupBy = new System.Windows.Forms.Label();
            this.comboBoxGroupBy = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.tabPageUncommonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUncommonEvents)).BeginInit();
            this.tabPageRaisedAlarms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaisedAlarms)).BeginInit();
            this.tabChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDaysData)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxNO2
            // 
            this.checkBoxNO2.AutoSize = true;
            this.checkBoxNO2.Checked = true;
            this.checkBoxNO2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNO2.Enabled = false;
            this.checkBoxNO2.Location = new System.Drawing.Point(1364, 463);
            this.checkBoxNO2.Name = "checkBoxNO2";
            this.checkBoxNO2.Size = new System.Drawing.Size(67, 24);
            this.checkBoxNO2.TabIndex = 1;
            this.checkBoxNO2.Text = "NO2";
            this.checkBoxNO2.UseVisualStyleBackColor = true;
            this.checkBoxNO2.CheckedChanged += new System.EventHandler(this.CheckBoxNO2_CheckedChanged);
            // 
            // checkBoxCO
            // 
            this.checkBoxCO.AutoSize = true;
            this.checkBoxCO.Checked = true;
            this.checkBoxCO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCO.Enabled = false;
            this.checkBoxCO.Location = new System.Drawing.Point(1364, 495);
            this.checkBoxCO.Name = "checkBoxCO";
            this.checkBoxCO.Size = new System.Drawing.Size(58, 24);
            this.checkBoxCO.TabIndex = 2;
            this.checkBoxCO.Text = "CO";
            this.checkBoxCO.UseVisualStyleBackColor = true;
            this.checkBoxCO.CheckedChanged += new System.EventHandler(this.CheckBoxCO_CheckedChanged);
            // 
            // checkBoxO3
            // 
            this.checkBoxO3.AutoSize = true;
            this.checkBoxO3.Checked = true;
            this.checkBoxO3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxO3.Enabled = false;
            this.checkBoxO3.Location = new System.Drawing.Point(1364, 528);
            this.checkBoxO3.Name = "checkBoxO3";
            this.checkBoxO3.Size = new System.Drawing.Size(56, 24);
            this.checkBoxO3.TabIndex = 3;
            this.checkBoxO3.Text = "O3";
            this.checkBoxO3.UseVisualStyleBackColor = true;
            this.checkBoxO3.CheckedChanged += new System.EventHandler(this.CheckBoxO3_CheckedChanged);
            // 
            // labelParameters
            // 
            this.labelParameters.AutoSize = true;
            this.labelParameters.Location = new System.Drawing.Point(1359, 440);
            this.labelParameters.Name = "labelParameters";
            this.labelParameters.Size = new System.Drawing.Size(95, 20);
            this.labelParameters.TabIndex = 4;
            this.labelParameters.Text = "Parameters:";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(1359, 286);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(81, 20);
            this.labelEndDate.TabIndex = 3;
            this.labelEndDate.Text = "End Date:";
            // 
            // dateTimeEndDate
            // 
            this.dateTimeEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeEndDate.Location = new System.Drawing.Point(1364, 309);
            this.dateTimeEndDate.Name = "dateTimeEndDate";
            this.dateTimeEndDate.Size = new System.Drawing.Size(134, 26);
            this.dateTimeEndDate.TabIndex = 1;
            this.dateTimeEndDate.ValueChanged += new System.EventHandler(this.DateTimePickerEndDate_ValueChanged);
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStartDate.Location = new System.Drawing.Point(1359, 212);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(96, 22);
            this.labelStartDate.TabIndex = 4;
            this.labelStartDate.Text = "Start Date:";
            // 
            // dateTimeStartDate
            // 
            this.dateTimeStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeStartDate.Location = new System.Drawing.Point(1364, 238);
            this.dateTimeStartDate.Name = "dateTimeStartDate";
            this.dateTimeStartDate.Size = new System.Drawing.Size(134, 26);
            this.dateTimeStartDate.TabIndex = 3;
            this.dateTimeStartDate.ValueChanged += new System.EventHandler(this.DateTimePickerStartDate_ValueChanged);
            // 
            // labelCities
            // 
            this.labelCities.AutoSize = true;
            this.labelCities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCities.Location = new System.Drawing.Point(1359, 358);
            this.labelCities.Name = "labelCities";
            this.labelCities.Size = new System.Drawing.Size(60, 22);
            this.labelCities.TabIndex = 2;
            this.labelCities.Text = "Cities:";
            // 
            // comboBoxCities
            // 
            this.comboBoxCities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCities.FormattingEnabled = true;
            this.comboBoxCities.Location = new System.Drawing.Point(1364, 385);
            this.comboBoxCities.Name = "comboBoxCities";
            this.comboBoxCities.Size = new System.Drawing.Size(134, 28);
            this.comboBoxCities.TabIndex = 1;
            this.comboBoxCities.SelectedIndexChanged += new System.EventHandler(this.comboBoxCities_SelectedIndexChanged);
            // 
            // tabPageUncommonEvents
            // 
            this.tabPageUncommonEvents.Controls.Add(this.labelTotalEvents);
            this.tabPageUncommonEvents.Controls.Add(this.label4);
            this.tabPageUncommonEvents.Controls.Add(this.labelEventsNoData);
            this.tabPageUncommonEvents.Controls.Add(this.labelEventsEndDate);
            this.tabPageUncommonEvents.Controls.Add(this.label6);
            this.tabPageUncommonEvents.Controls.Add(this.labelEventsStartDate);
            this.tabPageUncommonEvents.Controls.Add(this.label9);
            this.tabPageUncommonEvents.Controls.Add(this.labelUncommonCityOrCities);
            this.tabPageUncommonEvents.Controls.Add(this.label10);
            this.tabPageUncommonEvents.Controls.Add(this.dataGridViewUncommonEvents);
            this.tabPageUncommonEvents.Location = new System.Drawing.Point(4, 39);
            this.tabPageUncommonEvents.Name = "tabPageUncommonEvents";
            this.tabPageUncommonEvents.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageUncommonEvents.Size = new System.Drawing.Size(1348, 686);
            this.tabPageUncommonEvents.TabIndex = 4;
            this.tabPageUncommonEvents.Text = "Uncommon Events";
            this.tabPageUncommonEvents.Enter += new System.EventHandler(this.TabPageUncommonEvents_Enter);
            // 
            // labelTotalEvents
            // 
            this.labelTotalEvents.BackColor = System.Drawing.Color.Transparent;
            this.labelTotalEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalEvents.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelTotalEvents.Location = new System.Drawing.Point(1210, 8);
            this.labelTotalEvents.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotalEvents.Name = "labelTotalEvents";
            this.labelTotalEvents.Size = new System.Drawing.Size(126, 35);
            this.labelTotalEvents.TabIndex = 21;
            this.labelTotalEvents.Text = "999999";
            this.labelTotalEvents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1106, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 22);
            this.label4.TabIndex = 20;
            this.label4.Text = "Total events:";
            // 
            // labelEventsNoData
            // 
            this.labelEventsNoData.AutoSize = true;
            this.labelEventsNoData.BackColor = System.Drawing.Color.Transparent;
            this.labelEventsNoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEventsNoData.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelEventsNoData.Location = new System.Drawing.Point(506, 308);
            this.labelEventsNoData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEventsNoData.Name = "labelEventsNoData";
            this.labelEventsNoData.Size = new System.Drawing.Size(327, 46);
            this.labelEventsNoData.TabIndex = 19;
            this.labelEventsNoData.Text = "No data available";
            // 
            // labelEventsEndDate
            // 
            this.labelEventsEndDate.AutoSize = true;
            this.labelEventsEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEventsEndDate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelEventsEndDate.Location = new System.Drawing.Point(488, 17);
            this.labelEventsEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEventsEndDate.Name = "labelEventsEndDate";
            this.labelEventsEndDate.Size = new System.Drawing.Size(73, 22);
            this.labelEventsEndDate.TabIndex = 18;
            this.labelEventsEndDate.Text = "<date>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(465, 17);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 22);
            this.label6.TabIndex = 17;
            this.label6.Text = "to";
            // 
            // labelEventsStartDate
            // 
            this.labelEventsStartDate.AutoSize = true;
            this.labelEventsStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEventsStartDate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelEventsStartDate.Location = new System.Drawing.Point(333, 17);
            this.labelEventsStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEventsStartDate.Name = "labelEventsStartDate";
            this.labelEventsStartDate.Size = new System.Drawing.Size(73, 22);
            this.labelEventsStartDate.TabIndex = 16;
            this.labelEventsStartDate.Text = "<date>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(282, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 22);
            this.label9.TabIndex = 15;
            this.label9.Text = "From";
            // 
            // labelUncommonCityOrCities
            // 
            this.labelUncommonCityOrCities.AutoSize = true;
            this.labelUncommonCityOrCities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUncommonCityOrCities.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelUncommonCityOrCities.Location = new System.Drawing.Point(84, 17);
            this.labelUncommonCityOrCities.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUncommonCityOrCities.Name = "labelUncommonCityOrCities";
            this.labelUncommonCityOrCities.Size = new System.Drawing.Size(65, 22);
            this.labelUncommonCityOrCities.TabIndex = 10;
            this.labelUncommonCityOrCities.Text = "<city>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 17);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 22);
            this.label10.TabIndex = 9;
            this.label10.Text = "Events at";
            // 
            // dataGridViewUncommonEvents
            // 
            this.dataGridViewUncommonEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUncommonEvents.Location = new System.Drawing.Point(0, 48);
            this.dataGridViewUncommonEvents.Name = "dataGridViewUncommonEvents";
            this.dataGridViewUncommonEvents.RowTemplate.Height = 24;
            this.dataGridViewUncommonEvents.Size = new System.Drawing.Size(1344, 615);
            this.dataGridViewUncommonEvents.TabIndex = 0;
            // 
            // tabPageRaisedAlarms
            // 
            this.tabPageRaisedAlarms.Controls.Add(this.labelAlarmsCount);
            this.tabPageRaisedAlarms.Controls.Add(this.label1);
            this.tabPageRaisedAlarms.Controls.Add(this.labelRaisedAlarmsNoData);
            this.tabPageRaisedAlarms.Controls.Add(this.labelDateEnd);
            this.tabPageRaisedAlarms.Controls.Add(this.label8);
            this.tabPageRaisedAlarms.Controls.Add(this.labelDateStart);
            this.tabPageRaisedAlarms.Controls.Add(this.label3);
            this.tabPageRaisedAlarms.Controls.Add(this.labelRaisedAlarmsCityOrCities);
            this.tabPageRaisedAlarms.Controls.Add(this.label5);
            this.tabPageRaisedAlarms.Controls.Add(this.dataGridViewRaisedAlarms);
            this.tabPageRaisedAlarms.Location = new System.Drawing.Point(4, 39);
            this.tabPageRaisedAlarms.Name = "tabPageRaisedAlarms";
            this.tabPageRaisedAlarms.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageRaisedAlarms.Size = new System.Drawing.Size(1348, 686);
            this.tabPageRaisedAlarms.TabIndex = 3;
            this.tabPageRaisedAlarms.Text = "Raised Alarms";
            this.tabPageRaisedAlarms.Enter += new System.EventHandler(this.TabPageRaisedAlarms_Enter);
            // 
            // labelAlarmsCount
            // 
            this.labelAlarmsCount.BackColor = System.Drawing.Color.Transparent;
            this.labelAlarmsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlarmsCount.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelAlarmsCount.Location = new System.Drawing.Point(1214, 6);
            this.labelAlarmsCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAlarmsCount.Name = "labelAlarmsCount";
            this.labelAlarmsCount.Size = new System.Drawing.Size(126, 35);
            this.labelAlarmsCount.TabIndex = 17;
            this.labelAlarmsCount.Text = "999999";
            this.labelAlarmsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1044, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 22);
            this.label1.TabIndex = 16;
            this.label1.Text = "Total occurrences:";
            // 
            // labelRaisedAlarmsNoData
            // 
            this.labelRaisedAlarmsNoData.AutoSize = true;
            this.labelRaisedAlarmsNoData.BackColor = System.Drawing.Color.Transparent;
            this.labelRaisedAlarmsNoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRaisedAlarmsNoData.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelRaisedAlarmsNoData.Location = new System.Drawing.Point(506, 308);
            this.labelRaisedAlarmsNoData.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRaisedAlarmsNoData.Name = "labelRaisedAlarmsNoData";
            this.labelRaisedAlarmsNoData.Size = new System.Drawing.Size(327, 46);
            this.labelRaisedAlarmsNoData.TabIndex = 15;
            this.labelRaisedAlarmsNoData.Text = "No data available";
            // 
            // labelDateEnd
            // 
            this.labelDateEnd.AutoSize = true;
            this.labelDateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateEnd.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelDateEnd.Location = new System.Drawing.Point(488, 17);
            this.labelDateEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDateEnd.Name = "labelDateEnd";
            this.labelDateEnd.Size = new System.Drawing.Size(73, 22);
            this.labelDateEnd.TabIndex = 14;
            this.labelDateEnd.Text = "<date>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(465, 17);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 22);
            this.label8.TabIndex = 13;
            this.label8.Text = "to";
            // 
            // labelDateStart
            // 
            this.labelDateStart.AutoSize = true;
            this.labelDateStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateStart.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelDateStart.Location = new System.Drawing.Point(333, 17);
            this.labelDateStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDateStart.Name = "labelDateStart";
            this.labelDateStart.Size = new System.Drawing.Size(73, 22);
            this.labelDateStart.TabIndex = 12;
            this.labelDateStart.Text = "<date>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(282, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "From";
            // 
            // labelRaisedAlarmsCityOrCities
            // 
            this.labelRaisedAlarmsCityOrCities.AutoSize = true;
            this.labelRaisedAlarmsCityOrCities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRaisedAlarmsCityOrCities.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelRaisedAlarmsCityOrCities.Location = new System.Drawing.Point(87, 17);
            this.labelRaisedAlarmsCityOrCities.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRaisedAlarmsCityOrCities.Name = "labelRaisedAlarmsCityOrCities";
            this.labelRaisedAlarmsCityOrCities.Size = new System.Drawing.Size(65, 22);
            this.labelRaisedAlarmsCityOrCities.TabIndex = 10;
            this.labelRaisedAlarmsCityOrCities.Text = "<city>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Alarms at ";
            // 
            // dataGridViewRaisedAlarms
            // 
            this.dataGridViewRaisedAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRaisedAlarms.Location = new System.Drawing.Point(0, 48);
            this.dataGridViewRaisedAlarms.Name = "dataGridViewRaisedAlarms";
            this.dataGridViewRaisedAlarms.RowTemplate.Height = 24;
            this.dataGridViewRaisedAlarms.Size = new System.Drawing.Size(1344, 615);
            this.dataGridViewRaisedAlarms.TabIndex = 4;
            // 
            // tabChart
            // 
            this.tabChart.BackColor = System.Drawing.SystemColors.Control;
            this.tabChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabChart.Controls.Add(this.labelChartCurrentCityName);
            this.tabChart.Controls.Add(this.labelChartCurrentCity);
            this.tabChart.Controls.Add(this.labelChartFunctionType);
            this.tabChart.Controls.Add(this.labelChartFunction);
            this.tabChart.Controls.Add(this.labelNoDataAvailable);
            this.tabChart.Controls.Add(this.labelChartValues);
            this.tabChart.Controls.Add(this.labelChartDays);
            this.tabChart.Controls.Add(this.chartDaysData);
            this.tabChart.Location = new System.Drawing.Point(4, 39);
            this.tabChart.Name = "tabChart";
            this.tabChart.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabChart.Size = new System.Drawing.Size(1348, 686);
            this.tabChart.TabIndex = 0;
            this.tabChart.Text = "Charts";
            this.tabChart.Enter += new System.EventHandler(this.tabChart_Enter);
            // 
            // labelChartCurrentCityName
            // 
            this.labelChartCurrentCityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChartCurrentCityName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelChartCurrentCityName.Location = new System.Drawing.Point(1168, 202);
            this.labelChartCurrentCityName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChartCurrentCityName.Name = "labelChartCurrentCityName";
            this.labelChartCurrentCityName.Size = new System.Drawing.Size(150, 35);
            this.labelChartCurrentCityName.TabIndex = 11;
            this.labelChartCurrentCityName.Text = "<>";
            this.labelChartCurrentCityName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelChartCurrentCity
            // 
            this.labelChartCurrentCity.AutoSize = true;
            this.labelChartCurrentCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChartCurrentCity.Location = new System.Drawing.Point(1179, 175);
            this.labelChartCurrentCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChartCurrentCity.Name = "labelChartCurrentCity";
            this.labelChartCurrentCity.Size = new System.Drawing.Size(122, 25);
            this.labelChartCurrentCity.TabIndex = 10;
            this.labelChartCurrentCity.Text = "Current City:";
            // 
            // labelChartFunctionType
            // 
            this.labelChartFunctionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChartFunctionType.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelChartFunctionType.Location = new System.Drawing.Point(1170, 306);
            this.labelChartFunctionType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChartFunctionType.Name = "labelChartFunctionType";
            this.labelChartFunctionType.Size = new System.Drawing.Size(150, 35);
            this.labelChartFunctionType.TabIndex = 9;
            this.labelChartFunctionType.Text = "<>";
            this.labelChartFunctionType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelChartFunction
            // 
            this.labelChartFunction.AutoSize = true;
            this.labelChartFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChartFunction.Location = new System.Drawing.Point(1168, 280);
            this.labelChartFunction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChartFunction.Name = "labelChartFunction";
            this.labelChartFunction.Size = new System.Drawing.Size(145, 25);
            this.labelChartFunction.TabIndex = 8;
            this.labelChartFunction.Text = "Active function:";
            // 
            // labelNoDataAvailable
            // 
            this.labelNoDataAvailable.AutoSize = true;
            this.labelNoDataAvailable.BackColor = System.Drawing.Color.Transparent;
            this.labelNoDataAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoDataAvailable.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelNoDataAvailable.Location = new System.Drawing.Point(464, 283);
            this.labelNoDataAvailable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNoDataAvailable.Name = "labelNoDataAvailable";
            this.labelNoDataAvailable.Size = new System.Drawing.Size(327, 46);
            this.labelNoDataAvailable.TabIndex = 7;
            this.labelNoDataAvailable.Text = "No data available";
            // 
            // labelChartValues
            // 
            this.labelChartValues.AutoSize = true;
            this.labelChartValues.BackColor = System.Drawing.Color.Transparent;
            this.labelChartValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChartValues.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelChartValues.Location = new System.Drawing.Point(54, 12);
            this.labelChartValues.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChartValues.Name = "labelChartValues";
            this.labelChartValues.Size = new System.Drawing.Size(79, 26);
            this.labelChartValues.TabIndex = 6;
            this.labelChartValues.Text = "Values";
            // 
            // labelChartDays
            // 
            this.labelChartDays.BackColor = System.Drawing.Color.Transparent;
            this.labelChartDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChartDays.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelChartDays.Location = new System.Drawing.Point(438, 629);
            this.labelChartDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChartDays.Name = "labelChartDays";
            this.labelChartDays.Size = new System.Drawing.Size(375, 28);
            this.labelChartDays.TabIndex = 5;
            this.labelChartDays.Text = "Date";
            this.labelChartDays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chartDaysData
            // 
            this.chartDaysData.BackColor = System.Drawing.Color.Transparent;
            this.chartDaysData.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.Name = "ChartArea1";
            this.chartDaysData.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDaysData.Legends.Add(legend1);
            this.chartDaysData.Location = new System.Drawing.Point(-3, 23);
            this.chartDaysData.Name = "chartDaysData";
            this.chartDaysData.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.chartDaysData.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDaysData.Series.Add(series1);
            this.chartDaysData.Size = new System.Drawing.Size(1341, 637);
            this.chartDaysData.TabIndex = 4;
            this.chartDaysData.Text = "chart1";
            // 
            // labelChartActiveMode1
            // 
            this.labelChartActiveMode1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChartActiveMode1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelChartActiveMode1.Location = new System.Drawing.Point(1364, 163);
            this.labelChartActiveMode1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChartActiveMode1.Name = "labelChartActiveMode1";
            this.labelChartActiveMode1.Size = new System.Drawing.Size(136, 35);
            this.labelChartActiveMode1.TabIndex = 14;
            this.labelChartActiveMode1.Text = "<>";
            this.labelChartActiveMode1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelChartActiveMode
            // 
            this.labelChartActiveMode.AutoSize = true;
            this.labelChartActiveMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChartActiveMode.Location = new System.Drawing.Point(1366, 137);
            this.labelChartActiveMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChartActiveMode.Name = "labelChartActiveMode";
            this.labelChartActiveMode.Size = new System.Drawing.Size(127, 25);
            this.labelChartActiveMode.TabIndex = 13;
            this.labelChartActiveMode.Text = "Active Mode:";
            // 
            // labelChartViewMode
            // 
            this.labelChartViewMode.AutoSize = true;
            this.labelChartViewMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChartViewMode.Location = new System.Drawing.Point(1354, 58);
            this.labelChartViewMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChartViewMode.Name = "labelChartViewMode";
            this.labelChartViewMode.Size = new System.Drawing.Size(152, 22);
            this.labelChartViewMode.TabIndex = 12;
            this.labelChartViewMode.Text = "Chart View Mode:";
            // 
            // buttonMode
            // 
            this.buttonMode.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMode.Location = new System.Drawing.Point(1364, 86);
            this.buttonMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonMode.Name = "buttonMode";
            this.buttonMode.Size = new System.Drawing.Size(136, 46);
            this.buttonMode.TabIndex = 7;
            this.buttonMode.Text = "24Hour Mode";
            this.buttonMode.UseVisualStyleBackColor = false;
            this.buttonMode.Click += new System.EventHandler(this.buttonMode_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabChart);
            this.tabControl1.Controls.Add(this.tabPageRaisedAlarms);
            this.tabControl1.Controls.Add(this.tabPageUncommonEvents);
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 35);
            this.tabControl1.Location = new System.Drawing.Point(-3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1356, 729);
            this.tabControl1.TabIndex = 0;
            // 
            // labelGroupBy
            // 
            this.labelGroupBy.AutoSize = true;
            this.labelGroupBy.Location = new System.Drawing.Point(1359, 575);
            this.labelGroupBy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGroupBy.Name = "labelGroupBy";
            this.labelGroupBy.Size = new System.Drawing.Size(80, 20);
            this.labelGroupBy.TabIndex = 5;
            this.labelGroupBy.Text = "Group By:";
            // 
            // comboBoxGroupBy
            // 
            this.comboBoxGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroupBy.FormattingEnabled = true;
            this.comboBoxGroupBy.Location = new System.Drawing.Point(1364, 600);
            this.comboBoxGroupBy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxGroupBy.Name = "comboBoxGroupBy";
            this.comboBoxGroupBy.Size = new System.Drawing.Size(134, 28);
            this.comboBoxGroupBy.TabIndex = 6;
            this.comboBoxGroupBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroupBy_SelectedIndexChanged);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1512, 728);
            this.Controls.Add(this.labelChartActiveMode1);
            this.Controls.Add(this.comboBoxGroupBy);
            this.Controls.Add(this.labelChartActiveMode);
            this.Controls.Add(this.labelGroupBy);
            this.Controls.Add(this.labelChartViewMode);
            this.Controls.Add(this.labelParameters);
            this.Controls.Add(this.buttonMode);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.checkBoxO3);
            this.Controls.Add(this.checkBoxCO);
            this.Controls.Add(this.dateTimeEndDate);
            this.Controls.Add(this.checkBoxNO2);
            this.Controls.Add(this.comboBoxCities);
            this.Controls.Add(this.labelCities);
            this.Controls.Add(this.dateTimeStartDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAdmin";
            this.Text = "AirMonit Admin";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.tabPageUncommonEvents.ResumeLayout(false);
            this.tabPageUncommonEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUncommonEvents)).EndInit();
            this.tabPageRaisedAlarms.ResumeLayout(false);
            this.tabPageRaisedAlarms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaisedAlarms)).EndInit();
            this.tabChart.ResumeLayout(false);
            this.tabChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDaysData)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxNO2;
        private System.Windows.Forms.CheckBox checkBoxCO;
        private System.Windows.Forms.CheckBox checkBoxO3;
        private System.Windows.Forms.Label labelParameters;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.DateTimePicker dateTimeStartDate;
        private System.Windows.Forms.Label labelCities;
        private System.Windows.Forms.ComboBox comboBoxCities;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.DateTimePicker dateTimeEndDate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDaysData;
        private System.Windows.Forms.TabPage tabPageRaisedAlarms;
        private System.Windows.Forms.Label labelDateEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelDateStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelRaisedAlarmsCityOrCities;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewRaisedAlarms;
        private System.Windows.Forms.TabPage tabPageUncommonEvents;
        private System.Windows.Forms.Label labelUncommonCityOrCities;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridViewUncommonEvents;
        private System.Windows.Forms.Label labelEventsEndDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelEventsStartDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelChartValues;
        private System.Windows.Forms.Label labelChartDays;
        private System.Windows.Forms.Label labelNoDataAvailable;
        private System.Windows.Forms.ComboBox comboBoxGroupBy;
        private System.Windows.Forms.Label labelGroupBy;
        private System.Windows.Forms.Label labelRaisedAlarmsNoData;
        private System.Windows.Forms.Label labelEventsNoData;
        private System.Windows.Forms.Label labelChartCurrentCityName;
        private System.Windows.Forms.Label labelChartCurrentCity;
        private System.Windows.Forms.Label labelChartFunctionType;
        private System.Windows.Forms.Label labelChartFunction;
        private System.Windows.Forms.Button buttonMode;
        private System.Windows.Forms.Label labelChartViewMode;
        private System.Windows.Forms.Label labelChartActiveMode1;
        private System.Windows.Forms.Label labelChartActiveMode;
        private System.Windows.Forms.Label labelAlarmsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTotalEvents;
        private System.Windows.Forms.Label label4;
    }
}


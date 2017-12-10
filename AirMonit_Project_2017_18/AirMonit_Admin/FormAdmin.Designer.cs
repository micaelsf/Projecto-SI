namespace AirMonit_Admin
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.checkBoxNO2 = new System.Windows.Forms.CheckBox();
            this.checkBoxCO = new System.Windows.Forms.CheckBox();
            this.checkBoxO3 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.tabPageUncommonEvents = new System.Windows.Forms.TabPage();
            this.dataGridViewUncommonEvents = new System.Windows.Forms.DataGridView();
            this.tabPageAlarmBetweenDates = new System.Windows.Forms.TabPage();
            this.dataGridViewAlarmsBetweenDates = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerAlarmBetweenDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerAlarmBetweenDateBegin = new System.Windows.Forms.DateTimePicker();
            this.tabPageRaisedAlarm = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimeRaisedAlarms = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxCities = new System.Windows.Forms.ComboBox();
            this.dataGridViewRaisedAlarms = new System.Windows.Forms.DataGridView();
            this.tabPageAllCities = new System.Windows.Forms.TabPage();
            this.chartAllCities = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonChartAllCities = new System.Windows.Forms.Button();
            this.tabPageSingleCity = new System.Windows.Forms.TabPage();
            this.chartSingleCity = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonChart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSingleCitySelectCity = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.tabPageUncommonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUncommonEvents)).BeginInit();
            this.tabPageAlarmBetweenDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlarmsBetweenDates)).BeginInit();
            this.tabPageRaisedAlarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaisedAlarms)).BeginInit();
            this.tabPageAllCities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAllCities)).BeginInit();
            this.tabPageSingleCity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSingleCity)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxNO2
            // 
            this.checkBoxNO2.AutoSize = true;
            this.checkBoxNO2.Checked = true;
            this.checkBoxNO2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNO2.Enabled = false;
            this.checkBoxNO2.Location = new System.Drawing.Point(771, 318);
            this.checkBoxNO2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxNO2.Name = "checkBoxNO2";
            this.checkBoxNO2.Size = new System.Drawing.Size(48, 17);
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
            this.checkBoxCO.Location = new System.Drawing.Point(770, 340);
            this.checkBoxCO.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxCO.Name = "checkBoxCO";
            this.checkBoxCO.Size = new System.Drawing.Size(41, 17);
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
            this.checkBoxO3.Location = new System.Drawing.Point(770, 362);
            this.checkBoxO3.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxO3.Name = "checkBoxO3";
            this.checkBoxO3.Size = new System.Drawing.Size(40, 17);
            this.checkBoxO3.TabIndex = 3;
            this.checkBoxO3.Text = "O3";
            this.checkBoxO3.UseVisualStyleBackColor = true;
            this.checkBoxO3.CheckedChanged += new System.EventHandler(this.CheckBoxO3_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(768, 302);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Parameters:";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Location = new System.Drawing.Point(4, 34);
            this.tabPageAbout.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageAbout.Size = new System.Drawing.Size(762, 377);
            this.tabPageAbout.TabIndex = 5;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // tabPageUncommonEvents
            // 
            this.tabPageUncommonEvents.Controls.Add(this.dataGridViewUncommonEvents);
            this.tabPageUncommonEvents.Location = new System.Drawing.Point(4, 34);
            this.tabPageUncommonEvents.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageUncommonEvents.Name = "tabPageUncommonEvents";
            this.tabPageUncommonEvents.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageUncommonEvents.Size = new System.Drawing.Size(762, 377);
            this.tabPageUncommonEvents.TabIndex = 4;
            this.tabPageUncommonEvents.Text = "Uncommon Events";
            this.tabPageUncommonEvents.UseVisualStyleBackColor = true;
            this.tabPageUncommonEvents.Enter += new System.EventHandler(this.TabPageUncommonEvents_Enter);
            // 
            // dataGridViewUncommonEvents
            // 
            this.dataGridViewUncommonEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUncommonEvents.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewUncommonEvents.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewUncommonEvents.Name = "dataGridViewUncommonEvents";
            this.dataGridViewUncommonEvents.RowTemplate.Height = 24;
            this.dataGridViewUncommonEvents.Size = new System.Drawing.Size(764, 362);
            this.dataGridViewUncommonEvents.TabIndex = 0;
            // 
            // tabPageAlarmBetweenDates
            // 
            this.tabPageAlarmBetweenDates.Controls.Add(this.dataGridViewAlarmsBetweenDates);
            this.tabPageAlarmBetweenDates.Controls.Add(this.label4);
            this.tabPageAlarmBetweenDates.Controls.Add(this.label3);
            this.tabPageAlarmBetweenDates.Controls.Add(this.dateTimePickerAlarmBetweenDateEnd);
            this.tabPageAlarmBetweenDates.Controls.Add(this.dateTimePickerAlarmBetweenDateBegin);
            this.tabPageAlarmBetweenDates.Location = new System.Drawing.Point(4, 34);
            this.tabPageAlarmBetweenDates.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageAlarmBetweenDates.Name = "tabPageAlarmBetweenDates";
            this.tabPageAlarmBetweenDates.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageAlarmBetweenDates.Size = new System.Drawing.Size(762, 377);
            this.tabPageAlarmBetweenDates.TabIndex = 3;
            this.tabPageAlarmBetweenDates.Text = "Alarms Between Dates";
            this.tabPageAlarmBetweenDates.UseVisualStyleBackColor = true;
            this.tabPageAlarmBetweenDates.Enter += new System.EventHandler(this.TabPageAlarmBetweenDates_Enter);
            // 
            // dataGridViewAlarmsBetweenDates
            // 
            this.dataGridViewAlarmsBetweenDates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlarmsBetweenDates.Location = new System.Drawing.Point(23, 62);
            this.dataGridViewAlarmsBetweenDates.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewAlarmsBetweenDates.Name = "dataGridViewAlarmsBetweenDates";
            this.dataGridViewAlarmsBetweenDates.RowTemplate.Height = 24;
            this.dataGridViewAlarmsBetweenDates.Size = new System.Drawing.Size(711, 286);
            this.dataGridViewAlarmsBetweenDates.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "End Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Begin Date:";
            // 
            // dateTimePickerAlarmBetweenDateEnd
            // 
            this.dateTimePickerAlarmBetweenDateEnd.Location = new System.Drawing.Point(434, 16);
            this.dateTimePickerAlarmBetweenDateEnd.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerAlarmBetweenDateEnd.Name = "dateTimePickerAlarmBetweenDateEnd";
            this.dateTimePickerAlarmBetweenDateEnd.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerAlarmBetweenDateEnd.TabIndex = 1;
            this.dateTimePickerAlarmBetweenDateEnd.ValueChanged += new System.EventHandler(this.DateTimePickerAlarmBetweenDateBegin_ValueChanged);
            // 
            // dateTimePickerAlarmBetweenDateBegin
            // 
            this.dateTimePickerAlarmBetweenDateBegin.Location = new System.Drawing.Point(148, 16);
            this.dateTimePickerAlarmBetweenDateBegin.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerAlarmBetweenDateBegin.Name = "dateTimePickerAlarmBetweenDateBegin";
            this.dateTimePickerAlarmBetweenDateBegin.Size = new System.Drawing.Size(151, 20);
            this.dateTimePickerAlarmBetweenDateBegin.TabIndex = 0;
            this.dateTimePickerAlarmBetweenDateBegin.ValueChanged += new System.EventHandler(this.DateTimePickerAlarmBetweenDateBegin_ValueChanged);
            // 
            // tabPageRaisedAlarm
            // 
            this.tabPageRaisedAlarm.Controls.Add(this.label6);
            this.tabPageRaisedAlarm.Controls.Add(this.dateTimeRaisedAlarms);
            this.tabPageRaisedAlarm.Controls.Add(this.label5);
            this.tabPageRaisedAlarm.Controls.Add(this.comboBoxCities);
            this.tabPageRaisedAlarm.Controls.Add(this.dataGridViewRaisedAlarms);
            this.tabPageRaisedAlarm.Location = new System.Drawing.Point(4, 34);
            this.tabPageRaisedAlarm.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageRaisedAlarm.Name = "tabPageRaisedAlarm";
            this.tabPageRaisedAlarm.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageRaisedAlarm.Size = new System.Drawing.Size(762, 377);
            this.tabPageRaisedAlarm.TabIndex = 2;
            this.tabPageRaisedAlarm.Text = "Raised Alarms";
            this.tabPageRaisedAlarm.UseVisualStyleBackColor = true;
            this.tabPageRaisedAlarm.Enter += new System.EventHandler(this.TabRaisedAlarms_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 314);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Choose a date:";
            // 
            // dateTimeRaisedAlarms
            // 
            this.dateTimeRaisedAlarms.Location = new System.Drawing.Point(392, 313);
            this.dateTimeRaisedAlarms.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimeRaisedAlarms.Name = "dateTimeRaisedAlarms";
            this.dateTimeRaisedAlarms.Size = new System.Drawing.Size(151, 20);
            this.dateTimeRaisedAlarms.TabIndex = 3;
            this.dateTimeRaisedAlarms.ValueChanged += new System.EventHandler(this.dateTimeRaisedAlarms_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(571, 313);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Cities:";
            // 
            // comboBoxCities
            // 
            this.comboBoxCities.FormattingEnabled = true;
            this.comboBoxCities.Location = new System.Drawing.Point(610, 310);
            this.comboBoxCities.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCities.Name = "comboBoxCities";
            this.comboBoxCities.Size = new System.Drawing.Size(139, 21);
            this.comboBoxCities.TabIndex = 1;
            this.comboBoxCities.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCities_SelectedIndexChanged);
            // 
            // dataGridViewRaisedAlarms
            // 
            this.dataGridViewRaisedAlarms.AllowUserToAddRows = false;
            this.dataGridViewRaisedAlarms.AllowUserToDeleteRows = false;
            this.dataGridViewRaisedAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRaisedAlarms.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewRaisedAlarms.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRaisedAlarms.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewRaisedAlarms.Name = "dataGridViewRaisedAlarms";
            this.dataGridViewRaisedAlarms.ReadOnly = true;
            this.dataGridViewRaisedAlarms.RowTemplate.Height = 24;
            this.dataGridViewRaisedAlarms.Size = new System.Drawing.Size(764, 297);
            this.dataGridViewRaisedAlarms.TabIndex = 0;
            // 
            // tabPageAllCities
            // 
            this.tabPageAllCities.Controls.Add(this.chartAllCities);
            this.tabPageAllCities.Controls.Add(this.buttonChartAllCities);
            this.tabPageAllCities.Location = new System.Drawing.Point(4, 34);
            this.tabPageAllCities.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageAllCities.Name = "tabPageAllCities";
            this.tabPageAllCities.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageAllCities.Size = new System.Drawing.Size(762, 377);
            this.tabPageAllCities.TabIndex = 1;
            this.tabPageAllCities.Text = "All Cities";
            this.tabPageAllCities.UseVisualStyleBackColor = true;
            // 
            // chartAllCities
            // 
            chartArea3.Name = "ChartAllCities";
            this.chartAllCities.ChartAreas.Add(chartArea3);
            legend3.Name = "Statical information All Cities";
            this.chartAllCities.Legends.Add(legend3);
            this.chartAllCities.Location = new System.Drawing.Point(52, 47);
            this.chartAllCities.Margin = new System.Windows.Forms.Padding(2);
            this.chartAllCities.Name = "chartAllCities";
            this.chartAllCities.Size = new System.Drawing.Size(624, 290);
            this.chartAllCities.TabIndex = 1;
            this.chartAllCities.Text = "chart All Cities";
            // 
            // buttonChartAllCities
            // 
            this.buttonChartAllCities.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonChartAllCities.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonChartAllCities.Location = new System.Drawing.Point(344, 342);
            this.buttonChartAllCities.Margin = new System.Windows.Forms.Padding(2);
            this.buttonChartAllCities.Name = "buttonChartAllCities";
            this.buttonChartAllCities.Size = new System.Drawing.Size(78, 19);
            this.buttonChartAllCities.TabIndex = 0;
            this.buttonChartAllCities.Text = "Show Plot";
            this.buttonChartAllCities.UseVisualStyleBackColor = false;
            this.buttonChartAllCities.Click += new System.EventHandler(this.ButtonChartAllCities_Click);
            // 
            // tabPageSingleCity
            // 
            this.tabPageSingleCity.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPageSingleCity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageSingleCity.Controls.Add(this.chartSingleCity);
            this.tabPageSingleCity.Controls.Add(this.buttonChart);
            this.tabPageSingleCity.Controls.Add(this.label2);
            this.tabPageSingleCity.Controls.Add(this.comboBoxSingleCitySelectCity);
            this.tabPageSingleCity.Location = new System.Drawing.Point(4, 34);
            this.tabPageSingleCity.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageSingleCity.Name = "tabPageSingleCity";
            this.tabPageSingleCity.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageSingleCity.Size = new System.Drawing.Size(762, 377);
            this.tabPageSingleCity.TabIndex = 0;
            this.tabPageSingleCity.Text = "Single City";
            // 
            // chartSingleCity
            // 
            chartArea4.Name = "chartSingleCity";
            this.chartSingleCity.ChartAreas.Add(chartArea4);
            legend4.Name = "Statical information Single City";
            this.chartSingleCity.Legends.Add(legend4);
            this.chartSingleCity.Location = new System.Drawing.Point(56, 70);
            this.chartSingleCity.Margin = new System.Windows.Forms.Padding(2);
            this.chartSingleCity.Name = "chartSingleCity";
            this.chartSingleCity.Size = new System.Drawing.Size(517, 244);
            this.chartSingleCity.TabIndex = 4;
            this.chartSingleCity.Text = "Single City";
            // 
            // buttonChart
            // 
            this.buttonChart.Location = new System.Drawing.Point(633, 339);
            this.buttonChart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonChart.Name = "buttonChart";
            this.buttonChart.Size = new System.Drawing.Size(85, 19);
            this.buttonChart.TabIndex = 3;
            this.buttonChart.Text = "Show Plot";
            this.buttonChart.UseVisualStyleBackColor = true;
            this.buttonChart.Click += new System.EventHandler(this.ButtonChart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(639, 228);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select city:";
            // 
            // comboBoxSingleCitySelectCity
            // 
            this.comboBoxSingleCitySelectCity.FormattingEnabled = true;
            this.comboBoxSingleCitySelectCity.Items.AddRange(new object[] {
            "Lisboa",
            "Leiria",
            "Porto",
            "Coimbra"});
            this.comboBoxSingleCitySelectCity.Location = new System.Drawing.Point(627, 245);
            this.comboBoxSingleCitySelectCity.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSingleCitySelectCity.Name = "comboBoxSingleCitySelectCity";
            this.comboBoxSingleCitySelectCity.Size = new System.Drawing.Size(92, 21);
            this.comboBoxSingleCitySelectCity.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSingleCity);
            this.tabControl1.Controls.Add(this.tabPageAllCities);
            this.tabControl1.Controls.Add(this.tabPageRaisedAlarm);
            this.tabControl1.Controls.Add(this.tabPageAlarmBetweenDates);
            this.tabControl1.Controls.Add(this.tabPageUncommonEvents);
            this.tabControl1.Controls.Add(this.tabPageAbout);
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl1.Location = new System.Drawing.Point(-2, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(770, 415);
            this.tabControl1.TabIndex = 0;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(836, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxO3);
            this.Controls.Add(this.checkBoxCO);
            this.Controls.Add(this.checkBoxNO2);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormAdmin";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.tabPageUncommonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUncommonEvents)).EndInit();
            this.tabPageAlarmBetweenDates.ResumeLayout(false);
            this.tabPageAlarmBetweenDates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlarmsBetweenDates)).EndInit();
            this.tabPageRaisedAlarm.ResumeLayout(false);
            this.tabPageRaisedAlarm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaisedAlarms)).EndInit();
            this.tabPageAllCities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartAllCities)).EndInit();
            this.tabPageSingleCity.ResumeLayout(false);
            this.tabPageSingleCity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSingleCity)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxNO2;
        private System.Windows.Forms.CheckBox checkBoxCO;
        private System.Windows.Forms.CheckBox checkBoxO3;
        private System.Windows.Forms.Label label1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSingleCity;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSingleCity;
        private System.Windows.Forms.Button buttonChart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSingleCitySelectCity;
        private System.Windows.Forms.TabPage tabPageAllCities;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAllCities;
        private System.Windows.Forms.Button buttonChartAllCities;
        private System.Windows.Forms.TabPage tabPageRaisedAlarm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimeRaisedAlarms;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxCities;
        private System.Windows.Forms.DataGridView dataGridViewRaisedAlarms;
        private System.Windows.Forms.TabPage tabPageAlarmBetweenDates;
        private System.Windows.Forms.DataGridView dataGridViewAlarmsBetweenDates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerAlarmBetweenDateEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerAlarmBetweenDateBegin;
        private System.Windows.Forms.TabPage tabPageUncommonEvents;
        private System.Windows.Forms.DataGridView dataGridViewUncommonEvents;
        private System.Windows.Forms.TabPage tabPageAbout;
    }
}


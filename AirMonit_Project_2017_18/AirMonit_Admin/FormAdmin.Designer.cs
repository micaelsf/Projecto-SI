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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.checkBoxNO2 = new System.Windows.Forms.CheckBox();
            this.checkBoxCO = new System.Windows.Forms.CheckBox();
            this.checkBoxO3 = new System.Windows.Forms.CheckBox();
            this.labelParameters = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.dateTimePickerAlarmDateEnd = new System.Windows.Forms.DateTimePicker();
            this.labelChooseDate = new System.Windows.Forms.Label();
            this.dateTimeMainPicker = new System.Windows.Forms.DateTimePicker();
            this.labelCities = new System.Windows.Forms.Label();
            this.comboBoxCities = new System.Windows.Forms.ComboBox();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.tabPageUncommonEvents = new System.Windows.Forms.TabPage();
            this.labelUncommonCityOrCities = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridViewUncommonEvents = new System.Windows.Forms.DataGridView();
            this.tabPageRaisedAlarms = new System.Windows.Forms.TabPage();
            this.labelDateEnd = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelDateStart = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelRaisedAlarmsCityOrCities = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewRaisedAlarms = new System.Windows.Forms.DataGridView();
            this.tabPageAllCities = new System.Windows.Forms.TabPage();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPageSingleCity = new System.Windows.Forms.TabPage();
            this.chartSingleCity = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonChart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSingleCitySelectCity = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.labelEventsEndDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelEventsStartDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.tabPageUncommonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUncommonEvents)).BeginInit();
            this.tabPageRaisedAlarms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRaisedAlarms)).BeginInit();
            this.tabPageAllCities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
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
            this.checkBoxNO2.Location = new System.Drawing.Point(911, 197);
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
            this.checkBoxCO.Location = new System.Drawing.Point(911, 218);
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
            this.checkBoxO3.Location = new System.Drawing.Point(911, 239);
            this.checkBoxO3.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxO3.Name = "checkBoxO3";
            this.checkBoxO3.Size = new System.Drawing.Size(40, 17);
            this.checkBoxO3.TabIndex = 3;
            this.checkBoxO3.Text = "O3";
            this.checkBoxO3.UseVisualStyleBackColor = true;
            this.checkBoxO3.CheckedChanged += new System.EventHandler(this.CheckBoxO3_CheckedChanged);
            // 
            // labelParameters
            // 
            this.labelParameters.AutoSize = true;
            this.labelParameters.Location = new System.Drawing.Point(908, 182);
            this.labelParameters.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelParameters.Name = "labelParameters";
            this.labelParameters.Size = new System.Drawing.Size(63, 13);
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
            this.labelEndDate.Location = new System.Drawing.Point(908, 82);
            this.labelEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(55, 13);
            this.labelEndDate.TabIndex = 3;
            this.labelEndDate.Text = "End Date:";
            // 
            // dateTimePickerAlarmDateEnd
            // 
            this.dateTimePickerAlarmDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerAlarmDateEnd.Location = new System.Drawing.Point(911, 97);
            this.dateTimePickerAlarmDateEnd.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerAlarmDateEnd.Name = "dateTimePickerAlarmDateEnd";
            this.dateTimePickerAlarmDateEnd.Size = new System.Drawing.Size(91, 20);
            this.dateTimePickerAlarmDateEnd.TabIndex = 1;
            this.dateTimePickerAlarmDateEnd.ValueChanged += new System.EventHandler(this.DateTimePickerAlarmBetweenDateBegin_ValueChanged);
            // 
            // labelChooseDate
            // 
            this.labelChooseDate.AutoSize = true;
            this.labelChooseDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChooseDate.Location = new System.Drawing.Point(908, 34);
            this.labelChooseDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelChooseDate.Name = "labelChooseDate";
            this.labelChooseDate.Size = new System.Drawing.Size(89, 15);
            this.labelChooseDate.TabIndex = 4;
            this.labelChooseDate.Text = "Choose a date:";
            // 
            // dateTimeMainPicker
            // 
            this.dateTimeMainPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeMainPicker.Location = new System.Drawing.Point(911, 51);
            this.dateTimeMainPicker.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimeMainPicker.Name = "dateTimeMainPicker";
            this.dateTimeMainPicker.Size = new System.Drawing.Size(91, 20);
            this.dateTimeMainPicker.TabIndex = 3;
            this.dateTimeMainPicker.ValueChanged += new System.EventHandler(this.dateTimeRaisedAlarms_ValueChanged);
            // 
            // labelCities
            // 
            this.labelCities.AutoSize = true;
            this.labelCities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCities.Location = new System.Drawing.Point(908, 129);
            this.labelCities.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCities.Name = "labelCities";
            this.labelCities.Size = new System.Drawing.Size(40, 15);
            this.labelCities.TabIndex = 2;
            this.labelCities.Text = "Cities:";
            // 
            // comboBoxCities
            // 
            this.comboBoxCities.FormattingEnabled = true;
            this.comboBoxCities.Location = new System.Drawing.Point(911, 146);
            this.comboBoxCities.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxCities.Name = "comboBoxCities";
            this.comboBoxCities.Size = new System.Drawing.Size(91, 21);
            this.comboBoxCities.TabIndex = 1;
            this.comboBoxCities.SelectedIndexChanged += new System.EventHandler(this.comboBoxCities_SelectedIndexChanged);
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Location = new System.Drawing.Point(4, 34);
            this.tabPageAbout.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageAbout.Size = new System.Drawing.Size(723, 377);
            this.tabPageAbout.TabIndex = 5;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // tabPageUncommonEvents
            // 
            this.tabPageUncommonEvents.Controls.Add(this.labelEventsEndDate);
            this.tabPageUncommonEvents.Controls.Add(this.label6);
            this.tabPageUncommonEvents.Controls.Add(this.labelEventsStartDate);
            this.tabPageUncommonEvents.Controls.Add(this.label9);
            this.tabPageUncommonEvents.Controls.Add(this.labelUncommonCityOrCities);
            this.tabPageUncommonEvents.Controls.Add(this.label10);
            this.tabPageUncommonEvents.Controls.Add(this.dataGridViewUncommonEvents);
            this.tabPageUncommonEvents.Location = new System.Drawing.Point(4, 34);
            this.tabPageUncommonEvents.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageUncommonEvents.Name = "tabPageUncommonEvents";
            this.tabPageUncommonEvents.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageUncommonEvents.Size = new System.Drawing.Size(896, 431);
            this.tabPageUncommonEvents.TabIndex = 4;
            this.tabPageUncommonEvents.Text = "Uncommon Events";
            this.tabPageUncommonEvents.Enter += new System.EventHandler(this.TabPageUncommonEvents_Enter);
            // 
            // labelUncommonCityOrCities
            // 
            this.labelUncommonCityOrCities.AutoSize = true;
            this.labelUncommonCityOrCities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUncommonCityOrCities.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelUncommonCityOrCities.Location = new System.Drawing.Point(56, 11);
            this.labelUncommonCityOrCities.Name = "labelUncommonCityOrCities";
            this.labelUncommonCityOrCities.Size = new System.Drawing.Size(44, 15);
            this.labelUncommonCityOrCities.TabIndex = 10;
            this.labelUncommonCityOrCities.Text = "<city>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Events at";
            // 
            // dataGridViewUncommonEvents
            // 
            this.dataGridViewUncommonEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUncommonEvents.Location = new System.Drawing.Point(0, 31);
            this.dataGridViewUncommonEvents.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewUncommonEvents.Name = "dataGridViewUncommonEvents";
            this.dataGridViewUncommonEvents.RowTemplate.Height = 24;
            this.dataGridViewUncommonEvents.Size = new System.Drawing.Size(896, 400);
            this.dataGridViewUncommonEvents.TabIndex = 0;
            // 
            // tabPageRaisedAlarms
            // 
            this.tabPageRaisedAlarms.Controls.Add(this.labelDateEnd);
            this.tabPageRaisedAlarms.Controls.Add(this.label8);
            this.tabPageRaisedAlarms.Controls.Add(this.labelDateStart);
            this.tabPageRaisedAlarms.Controls.Add(this.label3);
            this.tabPageRaisedAlarms.Controls.Add(this.labelRaisedAlarmsCityOrCities);
            this.tabPageRaisedAlarms.Controls.Add(this.label5);
            this.tabPageRaisedAlarms.Controls.Add(this.dataGridViewRaisedAlarms);
            this.tabPageRaisedAlarms.Location = new System.Drawing.Point(4, 34);
            this.tabPageRaisedAlarms.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageRaisedAlarms.Name = "tabPageRaisedAlarms";
            this.tabPageRaisedAlarms.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageRaisedAlarms.Size = new System.Drawing.Size(896, 431);
            this.tabPageRaisedAlarms.TabIndex = 3;
            this.tabPageRaisedAlarms.Text = "Raised Alarms";
            this.tabPageRaisedAlarms.Enter += new System.EventHandler(this.TabPageRaisedAlarms_Enter);
            // 
            // labelDateEnd
            // 
            this.labelDateEnd.AutoSize = true;
            this.labelDateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateEnd.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelDateEnd.Location = new System.Drawing.Point(325, 11);
            this.labelDateEnd.Name = "labelDateEnd";
            this.labelDateEnd.Size = new System.Drawing.Size(51, 15);
            this.labelDateEnd.TabIndex = 14;
            this.labelDateEnd.Text = "<date>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(310, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "to";
            // 
            // labelDateStart
            // 
            this.labelDateStart.AutoSize = true;
            this.labelDateStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateStart.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelDateStart.Location = new System.Drawing.Point(222, 11);
            this.labelDateStart.Name = "labelDateStart";
            this.labelDateStart.Size = new System.Drawing.Size(51, 15);
            this.labelDateStart.TabIndex = 12;
            this.labelDateStart.Text = "<date>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(188, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "From";
            // 
            // labelRaisedAlarmsCityOrCities
            // 
            this.labelRaisedAlarmsCityOrCities.AutoSize = true;
            this.labelRaisedAlarmsCityOrCities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRaisedAlarmsCityOrCities.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelRaisedAlarmsCityOrCities.Location = new System.Drawing.Point(58, 11);
            this.labelRaisedAlarmsCityOrCities.Name = "labelRaisedAlarmsCityOrCities";
            this.labelRaisedAlarmsCityOrCities.Size = new System.Drawing.Size(44, 15);
            this.labelRaisedAlarmsCityOrCities.TabIndex = 10;
            this.labelRaisedAlarmsCityOrCities.Text = "<city>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Alarms at ";
            // 
            // dataGridViewRaisedAlarms
            // 
            this.dataGridViewRaisedAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRaisedAlarms.Location = new System.Drawing.Point(0, 31);
            this.dataGridViewRaisedAlarms.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewRaisedAlarms.Name = "dataGridViewRaisedAlarms";
            this.dataGridViewRaisedAlarms.RowTemplate.Height = 24;
            this.dataGridViewRaisedAlarms.Size = new System.Drawing.Size(896, 400);
            this.dataGridViewRaisedAlarms.TabIndex = 4;
            // 
            // tabPageAllCities
            // 
            this.tabPageAllCities.Controls.Add(this.chart2);
            this.tabPageAllCities.Controls.Add(this.button1);
            this.tabPageAllCities.Location = new System.Drawing.Point(4, 34);
            this.tabPageAllCities.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageAllCities.Name = "tabPageAllCities";
            this.tabPageAllCities.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageAllCities.Size = new System.Drawing.Size(723, 377);
            this.tabPageAllCities.TabIndex = 1;
            this.tabPageAllCities.Text = "All Cities";
            this.tabPageAllCities.UseVisualStyleBackColor = true;
            // 
            // chart2
            // 
            chartArea11.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.chart2.Legends.Add(legend11);
            this.chart2.Location = new System.Drawing.Point(52, 47);
            this.chart2.Margin = new System.Windows.Forms.Padding(2);
            this.chart2.Name = "chart2";
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            this.chart2.Series.Add(series11);
            this.chart2.Size = new System.Drawing.Size(624, 290);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(344, 342);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 19);
            this.button1.TabIndex = 0;
            this.button1.Text = "Show Plot";
            this.button1.UseVisualStyleBackColor = false;
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
            this.tabPageSingleCity.Size = new System.Drawing.Size(723, 377);
            this.tabPageSingleCity.TabIndex = 0;
            this.tabPageSingleCity.Text = "Single City";
            // 
            // chartSingleCity
            // 
            chartArea12.Name = "ChartArea1";
            this.chartSingleCity.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this.chartSingleCity.Legends.Add(legend12);
            this.chartSingleCity.Location = new System.Drawing.Point(56, 70);
            this.chartSingleCity.Margin = new System.Windows.Forms.Padding(2);
            this.chartSingleCity.Name = "chartSingleCity";
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            this.chartSingleCity.Series.Add(series12);
            this.chartSingleCity.Size = new System.Drawing.Size(517, 244);
            this.chartSingleCity.TabIndex = 4;
            this.chartSingleCity.Text = "chart1";
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
            this.tabControl1.Controls.Add(this.tabPageRaisedAlarms);
            this.tabControl1.Controls.Add(this.tabPageUncommonEvents);
            this.tabControl1.Controls.Add(this.tabPageAbout);
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl1.Location = new System.Drawing.Point(-2, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(904, 469);
            this.tabControl1.TabIndex = 0;
            // 
            // labelEventsEndDate
            // 
            this.labelEventsEndDate.AutoSize = true;
            this.labelEventsEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEventsEndDate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelEventsEndDate.Location = new System.Drawing.Point(325, 11);
            this.labelEventsEndDate.Name = "labelEventsEndDate";
            this.labelEventsEndDate.Size = new System.Drawing.Size(51, 15);
            this.labelEventsEndDate.TabIndex = 18;
            this.labelEventsEndDate.Text = "<date>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(310, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "to";
            // 
            // labelEventsStartDate
            // 
            this.labelEventsStartDate.AutoSize = true;
            this.labelEventsStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEventsStartDate.ForeColor = System.Drawing.SystemColors.Highlight;
            this.labelEventsStartDate.Location = new System.Drawing.Point(222, 11);
            this.labelEventsStartDate.Name = "labelEventsStartDate";
            this.labelEventsStartDate.Size = new System.Drawing.Size(51, 15);
            this.labelEventsStartDate.TabIndex = 16;
            this.labelEventsStartDate.Text = "<date>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(188, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "From";
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1008, 473);
            this.Controls.Add(this.labelParameters);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.checkBoxO3);
            this.Controls.Add(this.checkBoxCO);
            this.Controls.Add(this.dateTimePickerAlarmDateEnd);
            this.Controls.Add(this.checkBoxNO2);
            this.Controls.Add(this.comboBoxCities);
            this.Controls.Add(this.labelCities);
            this.Controls.Add(this.dateTimeMainPicker);
            this.Controls.Add(this.labelChooseDate);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
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
            this.tabPageAllCities.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
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
        private System.Windows.Forms.Label labelParameters;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label labelChooseDate;
        private System.Windows.Forms.DateTimePicker dateTimeMainPicker;
        private System.Windows.Forms.Label labelCities;
        private System.Windows.Forms.ComboBox comboBoxCities;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerAlarmDateEnd;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSingleCity;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSingleCity;
        private System.Windows.Forms.Button buttonChart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSingleCitySelectCity;
        private System.Windows.Forms.TabPage tabPageAllCities;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.Label labelEventsEndDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelEventsStartDate;
        private System.Windows.Forms.Label label9;
    }
}


using AirMonit_Admin.AitMonitService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AirMonit_Admin
{
    public partial class FormAdmin : Form
    {
        private string[] Parameters = { "NO2", "CO", "O3" };
        private string[] groupBy = { "AVG", "MAX", "MIN" };
        private string[] cities = { "Leiria", "Lisboa", "Porto", "Coimbra", "All cities" };
        private IAirMonit_AccessingData airMonitServiceAccess;

        private enum Modes { HOUR_MODE, DATE_MODE };
        private Modes ActiveMode { get; set; }

        public FormAdmin()
        {
            InitializeComponent();
            airMonitServiceAccess = new AirMonit_AccessingDataClient();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            ActiveMode = Modes.DATE_MODE;
            labelChartActiveMode1.Text = "Date Mode";

            comboBoxCities.Items.AddRange(cities);
            comboBoxGroupBy.Items.AddRange(groupBy);
            comboBoxCities.SelectedIndex = 0;
            //comboBoxGroupBy.SelectedIndex = 0; // is getting selected at comboBoxCities triggered event
            ParametersCheckBoxEnable(true);
            HideChartContentLabels();
        }

        private List<string> GetActiveParameters()
        {
            List<string> checkedParameters = new List<string>();

            if (checkBoxNO2.Checked)
                checkedParameters.Add("NO2");

            if (checkBoxCO.Checked)
                checkedParameters.Add("CO");

            if (checkBoxO3.Checked)
                checkedParameters.Add("O3");

            return checkedParameters;
        }

        private void comboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTabIndex = tabControl1.SelectedIndex;
            Debug.WriteLine("Selected Tab index: " + selectedTabIndex);

            switch (selectedTabIndex)
            {
                case 0:
                    ShowActiveChartMode();
                    break;
                case 1:
                    RefreshDataGridAtTAB("RAISED_ALARMS", dataGridViewRaisedAlarms);
                    break;
                case 2:
                    RefreshDataGridAtTAB("EVENTS", dataGridViewUncommonEvents);
                    break;
            }
        }

        private void RefreshDataGridAtTAB(string tabFlag, DataGridView datagrid)
        {
            switch (tabFlag)
            {
                case "RAISED_ALARMS":
                    RefreshRaisedAlarms();
                    break;
                case "EVENTS":
                    RefreshEventsGrid();
                    break;
            }
        }

        private void RefreshEventsGrid()
        {
            string selectedCity;
            DateTime startDate, endDate;
            UncommonEvents[] events;
            DataGridView contextGrid = GetCurrentDataGrid();

            selectedCity = comboBoxCities.SelectedItem.ToString();

            try
            {
                startDate = DateTime.Parse(dateTimeStartDate.Value.ToString());
                endDate = DateTime.Parse(dateTimeEndDate.Value.ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error parsing date: " + e.Message);
                return;
            }

            labelUncommonCityOrCities.Text = selectedCity;
            labelEventsStartDate.Text = startDate.ToString("yyyy-MM-dd");
            labelEventsEndDate.Text = endDate.ToString("yyyy-MM-dd");

            if (selectedCity == "All cities")
            {
                selectedCity = null;
            }

            events = (UncommonEvents[])GetUncommonEvents(selectedCity, startDate, endDate);

            if (events == null)
            {
                contextGrid.DataSource = null;
                return;
            }

            if (events.Count() == 0)
            {
                labelEventsNoData.Show();
                contextGrid.DataSource = null;
                return;
            }

            labelEventsNoData.Hide();

            DataGridRefresh(events, contextGrid);
        }

        private void RefreshRaisedAlarms()
        {
            string selectedCity;
            DateTime startDate, endDate;
            AlarmLog[] alarms;
            DataGridView contextGrid = GetCurrentDataGrid();

            selectedCity = comboBoxCities.SelectedItem.ToString();

            try
            {
                startDate = DateTime.Parse(dateTimeStartDate.Value.ToString());
                endDate = DateTime.Parse(dateTimeEndDate.Value.ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error parsing date: " + e.Message);
                return;
            }

            if (startDate > endDate)
            {
                MessageBox.Show("Start Date cannot be after End Date");
                contextGrid.DataSource = null;
                return;
            }

            labelRaisedAlarmsCityOrCities.Text = selectedCity;
            labelDateStart.Text = startDate.ToString("yyyy-MM-dd");
            labelDateEnd.Text = endDate.ToString("yyyy-MM-dd");

            if (selectedCity == "All cities")
            {
                selectedCity = null;
            }

            alarms = (AlarmLog[])GetAlarmsBetweenDates(selectedCity, startDate, endDate);

            if (alarms == null)
            {
                contextGrid.DataSource = null;
                return;
            }

            if (alarms.Count() == 0)
            {
                labelRaisedAlarmsNoData.Show();
                contextGrid.DataSource = null;
                return;
            }

            if (GetActiveParameters().Count() == 0)
            {
                labelRaisedAlarmsNoData.Show();
                contextGrid.DataSource = null;
                return;
            }

            labelRaisedAlarmsNoData.Hide();

            DataGridRefresh(alarms, contextGrid);
            DataGridFilterParam(contextGrid);
        }

        private void TabPageRaisedAlarms_Enter(object sender, EventArgs e)
        {
            labelGroupBy.Hide();
            comboBoxGroupBy.Hide();
            labelStartDate.Text = "Start Date";
            labelEndDate.Show();
            ShowParametersCheckBox();
            HideChartModeLayout();
            dateTimeEndDate.Show();
            RefreshDataGridAtTAB("RAISED_ALARMS", dataGridViewRaisedAlarms);
        }

        private void TabPageUncommonEvents_Enter(object sender, EventArgs e)
        {
            labelGroupBy.Hide();
            comboBoxGroupBy.Hide();
            labelStartDate.Text = "Start Date";
            labelEndDate.Show();
            HideParametersCheckBox();
            HideChartModeLayout();
            dateTimeEndDate.Show();
            RefreshDataGridAtTAB("EVENTS", dataGridViewUncommonEvents);
        }

        private void HideParametersCheckBox()
        {
            labelParameters.Hide();
            checkBoxO3.Hide();
            checkBoxCO.Hide();
            checkBoxNO2.Hide();
        }

        private void ShowParametersCheckBox()
        {
            labelParameters.Show();
            checkBoxO3.Show();
            checkBoxCO.Show();
            checkBoxNO2.Show();
        }

        private void CheckBoxCO_CheckedChanged(object sender, EventArgs e)
        {
            DataGridView dataGrid = GetCurrentDataGrid();
            if (dataGrid != null)
            {
                DataGridFilterParam(dataGrid);
                return;
            }

            ShowActiveChartMode();

        }

        private void CheckBoxO3_CheckedChanged(object sender, EventArgs e)
        {
            DataGridView dataGrid = GetCurrentDataGrid();
            if (dataGrid != null)
            {
                DataGridFilterParam(dataGrid);
                return;
            }

            ShowActiveChartMode();

        }

        private void CheckBoxNO2_CheckedChanged(object sender, EventArgs e)
        {
            DataGridView dataGrid = GetCurrentDataGrid();
            if (dataGrid != null)
            {
                DataGridFilterParam(dataGrid);
                return;
            }

            ShowActiveChartMode();

        }

        private void DataGridFilterParam(DataGridView dataGrid)
        {
            Debug.WriteLine("Current DataGrid name: " + dataGrid.Name);

            int paramCellIndex = getParameterCellIndex(dataGrid);

            if (paramCellIndex == -1)
            {
                return;
            }

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                string s = row.Cells[paramCellIndex].Value.ToString();

                if (checkBoxO3.Checked && s.StartsWith(checkBoxO3.Text, true, null))
                {
                    DataGridSetRowVisibility(row, true, dataGrid);
                }
                else if (checkBoxNO2.Checked && s.StartsWith(checkBoxNO2.Text, true, null))
                {
                    DataGridSetRowVisibility(row, true, dataGrid);
                }
                else if (checkBoxCO.Checked && s.StartsWith(checkBoxCO.Text, true, null))
                {
                    DataGridSetRowVisibility(row, true, dataGrid);
                }
                else
                {
                    DataGridSetRowVisibility(row, false, dataGrid);
                }
            }
        }

        private int getParameterCellIndex(DataGridView dataGrid)
        {
            int paramCellIndex = -1;

            if (dataGrid.RowCount > 0)
            {
                if (dataGrid.Columns["Parameter"] != null)
                {
                    paramCellIndex = dataGrid.Columns["Parameter"].Index;
                    Debug.WriteLine("Parameter cell index: " + dataGrid.Columns["Parameter"].Index);
                }
            }

            return paramCellIndex;
        }

        private void DateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            int selectedTabIndex = tabControl1.SelectedIndex;

            switch (selectedTabIndex)
            {
                case 0:
                    ShowActiveChartMode();
                    break;
                case 1:
                    RefreshDataGridAtTAB("RAISED_ALARMS", dataGridViewRaisedAlarms);
                    break;
                case 2:
                    RefreshDataGridAtTAB("EVENTS", dataGridViewUncommonEvents);
                    break;
            }
        }

        private void DateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            int selectedTabIndex = tabControl1.SelectedIndex;

            switch (selectedTabIndex)
            {
                case 0:
                    ShowActiveChartMode();
                    break;
                case 1:
                    RefreshDataGridAtTAB("RAISED_ALARMS", dataGridViewRaisedAlarms);
                    break;
                case 2:
                    RefreshDataGridAtTAB("EVENTS", dataGridViewUncommonEvents);
                    break;
            }
        }

        private DataGridView GetCurrentDataGrid()
        {
            int currentTabIndex = tabControl1.SelectedIndex;

            switch (currentTabIndex)
            {
                case 1: return dataGridViewRaisedAlarms;
                case 2: return dataGridViewUncommonEvents;
            }

            return null;
        }

        private void ParametersCheckBoxEnable(bool enable)
        {
            checkBoxCO.Enabled = enable;
            checkBoxNO2.Enabled = enable;
            checkBoxO3.Enabled = enable;
        }

        private void DataGridSetRowVisibility(DataGridViewRow row, bool visibilitiy, DataGridView dataGrid)
        {
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGrid.DataSource];
            currencyManager1.SuspendBinding();
            row.Visible = visibilitiy;
            currencyManager1.ResumeBinding();
        }

        private void DataGridRefresh(IEnumerable<Object> source, DataGridView dataGrid)
        {
            dataGrid.DataSource = null;
            dataGrid.Refresh();
            dataGrid.DataSource = source;

            // datagrid width is 896 - 43 (first blank column), we need to calc the right width for the columns
            int dataGridWidth = 896 - 43;
            int usedWidth = 0;
            int usedIndex = 0;

            if (dataGrid.Columns["City"] != null || dataGrid.Columns["CityName"] != null)
            {
                string cityField;

                if (dataGrid.Columns["City"] != null)
                {
                    cityField = "City";
                }
                else
                {
                    cityField = "CityName";
                }

                dataGrid.Columns[cityField].DisplayIndex = usedIndex;
                dataGrid.Columns[cityField].Width = 60;
                usedWidth += 60;
                Debug.WriteLine("Index at " + cityField + ": " + usedIndex);
                usedIndex++;
            }

            if (dataGrid.Columns["Parameter"] != null || dataGrid.Columns["Type"] != null)
            {
                string paramType;

                if (dataGrid.Columns["Parameter"] != null)
                {
                    paramType = "Parameter";
                }
                else
                {
                    paramType = "Type";
                }

                dataGrid.Columns[paramType].DisplayIndex = usedIndex;
                dataGrid.Columns[paramType].Width = 60;
                usedWidth += 60;
                Debug.WriteLine("Index at " + paramType + ": " + usedIndex);
                usedIndex++;
            }

            if (dataGrid.Columns["Value"] != null || dataGrid.Columns["Temperature"] != null)
            {
                string value;
                int width;

                if (dataGrid.Columns["Value"] != null)
                {
                    value = "Value";
                    width = 60;
                }
                else
                {
                    value = "Temperature";
                    width = 75;
                }

                dataGrid.Columns[value].DisplayIndex = usedIndex;
                dataGrid.Columns[value].Width = width;
                usedWidth += width;
                Debug.WriteLine("Index at " + value + ": " + usedIndex);
                usedIndex++;
            }

            if (dataGrid.Columns["UserName"] != null)
            {
                dataGrid.Columns["UserName"].DisplayIndex = usedIndex;
                dataGrid.Columns["UserName"].Width = 100;
                usedWidth += 100;
                Debug.WriteLine("Index at username: " + usedIndex);
                usedIndex++;
            }

            if (dataGrid.Columns["DateTime"] != null)
            {
                dataGrid.Columns["DateTime"].DisplayIndex = usedIndex;
                dataGrid.Columns["DateTime"].Width = 125;
                usedWidth += 125;
                Debug.WriteLine("Index at DateTime: " + usedIndex);
                usedIndex++;
            }

            if (dataGrid.Columns["Description"] != null)
            {
                dataGrid.Columns["Description"].DisplayIndex = usedIndex;
                dataGrid.Columns["Description"].Width = dataGridWidth - usedWidth;
                Debug.WriteLine("Index at Description: " + usedIndex);
            }
        }

        private void tabChart_Enter(object sender, EventArgs e)
        {
            //ShowChartContentLabels();
            labelGroupBy.Show();
            comboBoxGroupBy.Show();
            ShowParametersCheckBox();
            ShowChartModeLayout();

            ShowActiveChartMode();
        }

        private void DisplayHourChart()
        {
            chartDaysData.Series.Clear();

            DateTime startDate = new DateTime();

            try
            {
                startDate = DateTime.Parse(dateTimeStartDate.Value.ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error parsing dates at DisplayHourChart() method: " + e.Message);
                return;
            }

            if (GetActiveParameters().Count() == 0)
            {
                chartDaysData.Series.Clear();
                HideChartContentLabels();
                return;
            }

            if (comboBoxGroupBy.SelectedItem == null)
            {
                chartDaysData.Series.Clear();
                HideChartContentLabels();
                return;
            }

            string selectedGroupGy = comboBoxGroupBy.SelectedItem.ToString();

            labelChartFunctionType.Text = selectedGroupGy;

            switch (selectedGroupGy)
            {
                case "AVG":
                    ShowHourAVGChart(startDate);
                    break;
                case "MAX":
                    ShowHourMAXChart(startDate);
                    break;
                case "MIN":
                    ShowHourMINChart(startDate);
                    break;
            }

            chartDaysData.Show();
        }

        private void ShowHourMINChart(DateTime startDate)
        {
            InfoBetweenDate[] minHourInfo_NO2 = null, minHourInfo_CO = null, minHourInfo_O3 = null;

            if (checkBoxNO2.Checked == true)
            {
                minHourInfo_NO2 = RefreshHourSeries("NO2", "MIN", startDate);
            }

            if (checkBoxCO.Checked == true)
            {
                minHourInfo_CO = RefreshHourSeries("CO", "MIN", startDate);
            }

            if (checkBoxO3.Checked == true)
            {
                minHourInfo_O3 = RefreshHourSeries("O3", "MIN", startDate);
            }

            chartDaysData.Visible = true;

            int periodicityNO2 = 0, periodicityCO = 0, periodicityO3 = 0;
            int bigger = 0;

            // get periodicity,
            if (minHourInfo_NO2 != null)
            {
                periodicityNO2 = minHourInfo_NO2.Count();
                bigger = bigger >= periodicityNO2 ? bigger : periodicityNO2;
            }

            if (minHourInfo_CO != null)
            {
                periodicityCO = minHourInfo_CO.Count();
                bigger = bigger >= periodicityCO ? bigger : periodicityCO;
            }

            if (minHourInfo_O3 != null)
            {
                periodicityO3 = minHourInfo_O3.Count();
                bigger = bigger >= periodicityO3 ? bigger : periodicityO3;
            }

            Debug.WriteLine("Bigger peridicity is: " + bigger);

            if (periodicityNO2 == 0 && periodicityCO == 0 && periodicityO3 == 0)
            {
                HideChartContentLabels();
                return;
            }

            ShowChartContentLabels();

            int valueNO2, valueCO, valueO3;
            string hourNO2, hourCO, hourO3;

            for (int i = 0; i < bigger; i++)
            {
                if (checkBoxNO2.Checked == true)
                {
                    if (i < periodicityNO2) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueNO2 = minHourInfo_NO2[i].Value;
                        hourNO2 = DateTime.Parse(minHourInfo_NO2[i].Date).ToString("HH");
                        chartDaysData.Series["NO2"].Points.AddXY(hourNO2, valueNO2);
                        chartDaysData.Series["NO2"].ChartType = SeriesChartType.Line;
                        chartDaysData.Series["NO2"].Points[i].Label = valueNO2 + "";
                        chartDaysData.Series["NO2"].LabelForeColor = Color.Black;
                    }
                }

                if (checkBoxCO.Checked == true)
                {
                    if (i < periodicityCO) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueCO = minHourInfo_CO[i].Value;
                        hourCO = DateTime.Parse(minHourInfo_CO[i].Date).ToString("HH");
                        chartDaysData.Series["CO"].Points.AddXY(hourCO, valueCO);
                        chartDaysData.Series["CO"].ChartType = SeriesChartType.Line;
                        chartDaysData.Series["CO"].Points[i].Label = valueCO + "";
                        chartDaysData.Series["CO"].LabelForeColor = Color.Black;
                    }
                }

                if (checkBoxO3.Checked == true)
                {
                    if (i < periodicityO3) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueO3 = minHourInfo_O3[i].Value;
                        hourO3 = DateTime.Parse(minHourInfo_O3[i].Date).ToString("HH");
                        chartDaysData.Series["O3"].Points.AddXY(hourO3, valueO3);
                        chartDaysData.Series["O3"].ChartType = SeriesChartType.Line;
                        chartDaysData.Series["O3"].Points[i].Label = valueO3 + "";
                        chartDaysData.Series["O3"].LabelForeColor = Color.Black;
                    }
                }
            }
        }

        private void ShowHourMAXChart(DateTime startDate)
        {
            InfoBetweenDate[] maxHourInfo_NO2 = null, maxHourInfo_CO = null, maxHourInfo_O3 = null;

            if (checkBoxNO2.Checked == true)
            {
                maxHourInfo_NO2 = RefreshHourSeries("NO2", "MAX", startDate);
            }

            if (checkBoxCO.Checked == true)
            {
                maxHourInfo_CO = RefreshHourSeries("CO", "MAX", startDate);
            }

            if (checkBoxO3.Checked == true)
            {
                maxHourInfo_O3 = RefreshHourSeries("O3", "MAX", startDate);
            }

            chartDaysData.Visible = true;

            int periodicityNO2 = 0, periodicityCO = 0, periodicityO3 = 0;
            int bigger = 0;

            // get periodicity,
            if (maxHourInfo_NO2 != null)
            {
                periodicityNO2 = maxHourInfo_NO2.Count();
                bigger = bigger >= periodicityNO2 ? bigger : periodicityNO2;
            }

            if (maxHourInfo_CO != null)
            {
                periodicityCO = maxHourInfo_CO.Count();
                bigger = bigger >= periodicityCO ? bigger : periodicityCO;
            }

            if (maxHourInfo_O3 != null)
            {
                periodicityO3 = maxHourInfo_O3.Count();
                bigger = bigger >= periodicityO3 ? bigger : periodicityO3;
            }

            Debug.WriteLine("Bigger peridicity is: " + bigger);

            if (periodicityNO2 == 0 && periodicityCO == 0 && periodicityO3 == 0)
            {
                HideChartContentLabels();
                return;
            }

            ShowChartContentLabels();

            int valueNO2, valueCO, valueO3;
            string hourNO2, hourCO, hourO3;

            for (int i = 0; i < bigger; i++)
            {
                if (checkBoxNO2.Checked == true)
                {
                    if (i < periodicityNO2) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueNO2 = maxHourInfo_NO2[i].Value;
                        hourNO2 = DateTime.Parse(maxHourInfo_NO2[i].Date).ToString("HH");
                        chartDaysData.Series["NO2"].Points.AddXY(hourNO2, valueNO2);
                        chartDaysData.Series["NO2"].ChartType = SeriesChartType.Line;
                        chartDaysData.Series["NO2"].Points[i].Label = valueNO2 + "";
                        chartDaysData.Series["NO2"].LabelForeColor = Color.Black;
                    }
                }

                if (checkBoxCO.Checked == true)
                {
                    if (i < periodicityCO) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueCO = maxHourInfo_CO[i].Value;
                        hourCO = DateTime.Parse(maxHourInfo_CO[i].Date).ToString("HH");
                        chartDaysData.Series["CO"].Points.AddXY(hourCO, valueCO);
                        chartDaysData.Series["CO"].ChartType = SeriesChartType.Line;
                        chartDaysData.Series["CO"].Points[i].Label = valueCO + "";
                        chartDaysData.Series["CO"].LabelForeColor = Color.Black;
                    }
                }

                if (checkBoxO3.Checked == true)
                {
                    if (i < periodicityO3) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueO3 = maxHourInfo_O3[i].Value;
                        hourO3 = DateTime.Parse(maxHourInfo_O3[i].Date).ToString("HH");
                        chartDaysData.Series["O3"].Points.AddXY(hourO3, valueO3);
                        chartDaysData.Series["O3"].ChartType = SeriesChartType.Line;
                        chartDaysData.Series["O3"].Points[i].Label = valueO3 + "";
                        chartDaysData.Series["O3"].LabelForeColor = Color.Black;
                    }
                }
            }
        }

        private void ShowHourAVGChart(DateTime startDate)
        {
            InfoBetweenDate[] avgHourInfo_NO2 = null, avgHourInfo_CO = null, avgHourInfo_O3 = null;

            if (checkBoxNO2.Checked == true)
            {
                avgHourInfo_NO2 = RefreshHourSeries("NO2", "AVG", startDate);
            }

            if (checkBoxCO.Checked == true)
            {
                avgHourInfo_CO = RefreshHourSeries("CO", "AVG", startDate);
            }

            if (checkBoxO3.Checked == true)
            {
                avgHourInfo_O3 = RefreshHourSeries("O3", "AVG", startDate);
            }

            chartDaysData.Visible = true;

            int periodicityNO2 = 0, periodicityCO = 0, periodicityO3 = 0;
            int bigger = 0;

            // get periodicity,
            if (avgHourInfo_NO2 != null)
            {
                periodicityNO2 = avgHourInfo_NO2.Count();
                bigger = bigger >= periodicityNO2 ? bigger : periodicityNO2;
            }

            if (avgHourInfo_CO != null)
            {
                periodicityCO = avgHourInfo_CO.Count();
                bigger = bigger >= periodicityCO ? bigger : periodicityCO;
            }

            if (avgHourInfo_O3 != null)
            {
                periodicityO3 = avgHourInfo_O3.Count();
                bigger = bigger >= periodicityO3 ? bigger : periodicityO3;
            }

            Debug.WriteLine("Bigger peridicity is: " + bigger);

            if (periodicityNO2 == 0 && periodicityCO == 0 && periodicityO3 == 0)
            {
                HideChartContentLabels();
                return;
            }

            ShowChartContentLabels();

            int valueNO2, valueCO, valueO3;
            string hourNO2, hourCO, hourO3;

            for (int i = 0; i < bigger; i++)
            {
                if (checkBoxNO2.Checked == true)
                {
                    if (i < periodicityNO2) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueNO2 = avgHourInfo_NO2[i].Value;
                        hourNO2 = DateTime.Parse(avgHourInfo_NO2[i].Date).ToString("HH");
                        chartDaysData.Series["NO2"].Points.AddXY(hourNO2, valueNO2);
                        chartDaysData.Series["NO2"].ChartType = SeriesChartType.Line;
                        chartDaysData.Series["NO2"].Points[i].Label = valueNO2 + "";
                        chartDaysData.Series["NO2"].LabelForeColor = Color.Black;
                    }
                }

                if (checkBoxCO.Checked == true)
                {
                    if (i < periodicityCO) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueCO = avgHourInfo_CO[i].Value;
                        hourCO = DateTime.Parse(avgHourInfo_CO[i].Date).ToString("HH");
                        chartDaysData.Series["CO"].Points.AddXY(hourCO, valueCO);
                        chartDaysData.Series["CO"].ChartType = SeriesChartType.Line;
                        chartDaysData.Series["CO"].Points[i].Label = valueCO + "";
                        chartDaysData.Series["CO"].LabelForeColor = Color.Black;
                    }
                }

                if (checkBoxO3.Checked == true)
                {
                    if (i < periodicityO3) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueO3 = avgHourInfo_O3[i].Value;
                        hourO3 = DateTime.Parse(avgHourInfo_O3[i].Date).ToString("HH");
                        chartDaysData.Series["O3"].Points.AddXY(hourO3, valueO3);
                        chartDaysData.Series["O3"].ChartType = SeriesChartType.Line;
                        chartDaysData.Series["O3"].Points[i].Label = valueO3 + "";
                        chartDaysData.Series["O3"].LabelForeColor = Color.Black;
                    }
                }
            }
        }

        private InfoBetweenDate[] RefreshHourSeries(string param, string type, DateTime startDate)
        {
            string selectedCity = comboBoxCities.SelectedItem.ToString();

            labelChartCurrentCityName.Text = selectedCity;

            if (selectedCity == "All cities")
            {
                selectedCity = null;
            }

            InfoBetweenDate[] info = null;

            switch (type)
            {
                case "AVG":
                    info = (InfoBetweenDate[])GetInfoAvgEachHour(param, selectedCity, startDate);
                    break;
                case "MIN":
                    info = (InfoBetweenDate[])GetInfoMinEachHour(param, selectedCity, startDate);
                    break;
                case "MAX":
                    info = (InfoBetweenDate[])GetInfoMaxEachHour(param, selectedCity, startDate);
                    break;
            }

            chartDaysData.Series.Add(param);

            return info;
        }

        private void DisplayChart()
        {
            // o clear só funciona corretamente quando o DisplayChart() é chamado pelo evento dos checkboxes
            chartDaysData.Series.Clear();

            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();

            try
            {
                startDate = DateTime.Parse(dateTimeStartDate.Value.ToString());
                endDate = DateTime.Parse(dateTimeEndDate.Value.ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error parsing dates at DisplayChart() method: " + e.Message);
                return;
            }

            if (GetActiveParameters().Count() == 0)
            {
                chartDaysData.Series.Clear();
                HideChartContentLabels();
                return;
            }

            if (startDate > endDate)
            {
                MessageBox.Show("Start Date cannot be after End Date");
                chartDaysData.Series.Clear();
                HideChartContentLabels();
                return;
            }

            if (comboBoxGroupBy.SelectedItem == null)
            {
                chartDaysData.Series.Clear();
                HideChartContentLabels();
                return;
            }

            string selectedGroupGy = comboBoxGroupBy.SelectedItem.ToString();

            labelChartFunctionType.Text = selectedGroupGy;

            switch (selectedGroupGy)
            {
                case "AVG":
                    ShowAVGChart(startDate, endDate);
                    break;
                case "MAX":
                    ShowMAXChart(startDate, endDate);
                    break;
                case "MIN":
                    ShowMINChart(startDate, endDate);
                    break;
            }

            chartDaysData.Show();
        }

        private void ShowMINChart(DateTime startDate, DateTime endDate)
        {
            InfoBetweenDate[] minInfo_NO2 = null, minInfo_CO = null, minInfo_O3 = null;

            if (checkBoxNO2.Checked == true)
            {
                minInfo_NO2 = (InfoBetweenDate[])RefreshSeries("NO2", "MIN", startDate, endDate);
            }

            if (checkBoxCO.Checked == true)
            {
                minInfo_CO = (InfoBetweenDate[])RefreshSeries("CO", "MIN", startDate, endDate);
            }

            if (checkBoxO3.Checked == true)
            {
                minInfo_O3 = (InfoBetweenDate[])RefreshSeries("O3", "MIN", startDate, endDate);
            }

            chartDaysData.Visible = true;

            int periodicityNO2 = 0, periodicityCO = 0, periodicityO3 = 0;
            int bigger = 0;

            // get periodicity,
            if (minInfo_NO2 != null)
            {
                periodicityNO2 = minInfo_NO2.Count();
                bigger = bigger >= periodicityNO2 ? bigger : periodicityNO2;
            }

            if (minInfo_CO != null)
            {
                periodicityCO = minInfo_CO.Count();
                bigger = bigger >= periodicityCO ? bigger : periodicityCO;
            }

            if (minInfo_O3 != null)
            {
                periodicityO3 = minInfo_O3.Count();
                bigger = bigger >= periodicityO3 ? bigger : periodicityO3;
            }

            Debug.WriteLine("Bigger peridicity is: " + bigger);

            if (periodicityNO2 == 0 && periodicityCO == 0 && periodicityO3 == 0)
                {
                    HideChartContentLabels();
                return;
            }

            ShowChartContentLabels();

            int valueNO2, valueCO, valueO3;
            string dateNO2, dateCO, dateO3;
            string cityNO2, cityCO, cityO3;

            for (int i = 0; i < bigger; i++)
                {
                    if (checkBoxNO2.Checked == true)
                {
                    if (i < periodicityNO2) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueNO2 = minInfo_NO2[i].Value;
                        dateNO2 = minInfo_NO2[i].Date;
                        cityNO2 = minInfo_NO2[i].City;
                        chartDaysData.Series["NO2"].Points.AddXY(dateNO2, valueNO2);
                        chartDaysData.Series["NO2"].Points[i].Label = valueNO2 + "";
                        chartDaysData.Series["NO2"].LabelForeColor = Color.Black;
                    }
                }

                if (checkBoxCO.Checked == true)
                {
                    if (i < periodicityCO) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueCO = minInfo_CO[i].Value;
                        dateCO = minInfo_CO[i].Date;
                        cityCO = minInfo_CO[i].City;
                        chartDaysData.Series["CO"].Points.AddXY(dateCO, valueCO);
                        chartDaysData.Series["CO"].Points[i].Label = valueCO + "";
                        chartDaysData.Series["CO"].LabelForeColor = Color.Black;
                    }
                }

                if (checkBoxO3.Checked == true)
                {
                    if (i < periodicityO3) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueO3 = minInfo_O3[i].Value;
                        dateO3 = minInfo_O3[i].Date;
                        cityO3 = minInfo_O3[i].City;
                        chartDaysData.Series["O3"].Points.AddXY(dateO3, valueO3);
                        chartDaysData.Series["O3"].Points[i].Label = valueO3 + "";
                        chartDaysData.Series["O3"].LabelForeColor = Color.Black;
                    }
                }
            }
        }

        private void ShowMAXChart(DateTime startDate, DateTime endDate)
        {
            InfoBetweenDate[] maxInfo_NO2 = null, maxInfo_CO = null, maxInfo_O3 = null;

            if (checkBoxNO2.Checked == true)
            {
                maxInfo_NO2 = (InfoBetweenDate[])RefreshSeries("NO2", "MAX", startDate, endDate);
            }

            if (checkBoxCO.Checked == true)
            {
                maxInfo_CO = (InfoBetweenDate[])RefreshSeries("CO", "MAX", startDate, endDate);
            }

            if (checkBoxO3.Checked == true)
            {
                maxInfo_O3 = (InfoBetweenDate[])RefreshSeries("O3", "MAX", startDate, endDate);
            }

            chartDaysData.Visible = true;

            int periodicityNO2 = 0, periodicityCO = 0, periodicityO3 = 0;
            int bigger = 0;

            // get periodicity,
            if (maxInfo_NO2 != null)
            {
                periodicityNO2 = maxInfo_NO2.Count();
                bigger = bigger >= periodicityNO2 ? bigger : periodicityNO2;
            }

            if (maxInfo_CO != null)
            {
                periodicityCO = maxInfo_CO.Count();
                bigger = bigger >= periodicityCO ? bigger : periodicityCO;
            }

            if (maxInfo_O3 != null)
            {
                periodicityO3 = maxInfo_O3.Count();
                bigger = bigger >= periodicityO3 ? bigger : periodicityO3;
            }

            Debug.WriteLine("Bigger peridicity is: " + bigger);

            if (periodicityNO2 == 0 && periodicityCO == 0 && periodicityO3 == 0)
            {
                HideChartContentLabels();
                return;
            }

            ShowChartContentLabels();

            int valueNO2, valueCO, valueO3;
            string dateNO2, dateCO, dateO3;

            for (int i = 0; i < bigger; i++)
            {
                if (checkBoxNO2.Checked == true)
                {
                    if (i < periodicityNO2) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueNO2 = maxInfo_NO2[i].Value;
                        dateNO2 = maxInfo_NO2[i].Date;
                        chartDaysData.Series["NO2"].Points.AddXY(dateNO2, valueNO2);
                        chartDaysData.Series["NO2"].Points[i].Label = valueNO2 + "";
                        chartDaysData.Series["NO2"].LabelForeColor = Color.Black;
                    }
                }

                if (checkBoxCO.Checked == true)
                {
                    if (i < periodicityCO) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueCO = maxInfo_CO[i].Value;
                        dateCO = maxInfo_CO[i].Date;
                        chartDaysData.Series["CO"].Points.AddXY(dateCO, valueCO);
                        chartDaysData.Series["CO"].Points[i].Label = valueCO + "";
                        chartDaysData.Series["CO"].LabelForeColor = Color.Black;
                    }
                }

                if (checkBoxO3.Checked == true)
                {
                    if (i < periodicityO3) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueO3 = maxInfo_O3[i].Value;
                        dateO3 = maxInfo_O3[i].Date;
                        chartDaysData.Series["O3"].Points.AddXY(dateO3, valueO3);
                        chartDaysData.Series["O3"].Points[i].Label = valueO3 + "";
                        chartDaysData.Series["O3"].LabelForeColor = Color.Black;
                    }
                }
            }
        }

        private void ShowAVGChart(DateTime startDate, DateTime endDate)
        {
            InfoBetweenDate[] avgInfo_NO2 = null, avgInfo_CO = null, avgInfo_O3 = null;

            if (checkBoxNO2.Checked == true)
            {
                avgInfo_NO2 = (InfoBetweenDate[])RefreshSeries("NO2", "AVG", startDate, endDate);
            }

            if (checkBoxCO.Checked == true)
            {
                avgInfo_CO = (InfoBetweenDate[])RefreshSeries("CO", "AVG", startDate, endDate);
            }

            if (checkBoxO3.Checked == true)
            {
                avgInfo_O3 = (InfoBetweenDate[])RefreshSeries("O3", "AVG", startDate, endDate);
            }

            chartDaysData.Visible = true;

            int periodicityNO2 = 0, periodicityCO = 0, periodicityO3 = 0;
            int bigger = 0;

            // get periodicity,
            if (avgInfo_NO2 != null)
            {
                periodicityNO2 = avgInfo_NO2.Count();
                bigger = bigger >= periodicityNO2 ? bigger : periodicityNO2;
            }

            if (avgInfo_CO != null)
            {
                periodicityCO = avgInfo_CO.Count();
                bigger = bigger >= periodicityCO ? bigger : periodicityCO;
            }

            if (avgInfo_O3 != null)
            {
                periodicityO3 = avgInfo_O3.Count();
                bigger = bigger >= periodicityO3 ? bigger : periodicityO3;
            }

            Debug.WriteLine("Bigger peridicity is: " + bigger);

            if (periodicityNO2 == 0 && periodicityCO == 0 && periodicityO3 == 0)
                {
                    HideChartContentLabels();
                return;
            }

            ShowChartContentLabels();

            int valueNO2, valueCO, valueO3;
            string dateNO2, dateCO, dateO3;

            for (int i = 0; i < bigger; i++)
            {
                if (checkBoxNO2.Checked == true)
                {
                    if (i < periodicityNO2) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueNO2 = avgInfo_NO2[i].Value;
                        dateNO2 = avgInfo_NO2[i].Date;
                        Debug.WriteLine("[" + i + "] avgValueNO2 is: " + valueNO2);
                        chartDaysData.Series["NO2"].Points.AddXY(dateNO2, valueNO2);
                        chartDaysData.Series["NO2"].Points[i].Label = valueNO2 + "";
                        chartDaysData.Series["NO2"].LabelForeColor = Color.Black;
                    }
                }

                if (checkBoxCO.Checked == true)
                {
                    if (i < periodicityCO) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueCO = avgInfo_CO[i].Value;
                        dateCO = avgInfo_CO[i].Date;
                        chartDaysData.Series["CO"].Points.AddXY(dateCO, valueCO);
                        chartDaysData.Series["CO"].Points[i].Label = valueCO + "";
                        chartDaysData.Series["CO"].LabelForeColor = Color.Black;
                    }
                }

                if (checkBoxO3.Checked == true)
                {
                    if (i < periodicityO3) // only do as much as the items it gots in the array, even if 'i' is bigger
                    {
                        valueO3 = avgInfo_O3[i].Value;
                        dateO3 = avgInfo_O3[i].Date;
                        chartDaysData.Series["O3"].Points.AddXY(dateO3, valueO3);
                        chartDaysData.Series["O3"].Points[i].Label = valueO3 + "";
                        chartDaysData.Series["O3"].LabelForeColor = Color.Black;
                    }
                }
            }
        }

        private void ShowChartContentLabels()
        {
            labelChartFunction.Show();
            labelChartFunctionType.Show();
            labelChartCurrentCity.Show();
            labelChartCurrentCityName.Show();
            labelChartDays.Show();
            labelChartValues.Show();
     
            labelNoDataAvailable.Hide();
        }

        private void HideChartContentLabels()
        {
            labelChartFunction.Hide();
            labelChartFunctionType.Hide();
            labelChartCurrentCity.Hide();
            labelChartCurrentCityName.Hide();
            labelChartDays.Hide();
            labelChartValues.Hide();

            labelNoDataAvailable.Show();
        }

        private void HideChartModeLayout()
        {
            labelChartViewMode.Hide();
            buttonMode.Hide();
            labelChartActiveMode.Hide();
            labelChartActiveMode1.Hide();
        }

        private void ShowChartModeLayout()
        {
            labelChartViewMode.Show();
            buttonMode.Show();
            labelChartActiveMode.Show();
            labelChartActiveMode1.Show();
        }

        private void comboBoxGroupBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowActiveChartMode();
        }

        private IEnumerable<InfoBetweenDate> RefreshSeries(string param, string type, DateTime startDate, DateTime endDate)
        {
            string selectedCity = comboBoxCities.SelectedItem.ToString();

            labelChartCurrentCityName.Text = selectedCity;

            if (selectedCity == "All cities")
            {
                selectedCity = null;
            }

            InfoBetweenDate[] info = null;

            switch (type)
            {
                case "AVG":
                    info = (InfoBetweenDate[]) GetInfoAvgBetweenDates(param, selectedCity, startDate, endDate);
                    break;
                case "MIN":
                    info = (InfoBetweenDate[]) GetInfoMinBetweenDates(param, selectedCity, startDate, endDate);
                    break;
                case "MAX":
                    info = (InfoBetweenDate[]) GetInfoMaxBetweenDates(param, selectedCity, startDate, endDate);
                    break;
            }

            chartDaysData.Series.Add(param);

            return info;
        }

        private void buttonMode_Click(object sender, EventArgs e)
        {
            if (ActiveMode == Modes.DATE_MODE)
            {
                ActiveMode = Modes.HOUR_MODE;
            }
            else
            {
                ActiveMode = Modes.DATE_MODE;
            }

            ShowActiveChartMode();
        }

        private void ShowActiveChartMode()
        {
            Debug.WriteLine("Active chart mode: " + ActiveMode);

            if (ActiveMode == Modes.HOUR_MODE)
            {
                labelChartActiveMode1.Text = "24Hour Mode";
                buttonMode.Text = "Date Mode";
                labelEndDate.Hide();
                dateTimeEndDate.Hide();
                labelStartDate.Text = "Choose a date";
                labelChartDays.Text = "Hours during day " + DateTime.Parse(dateTimeStartDate.Value.ToString()).ToString("yyyy-MM-dd");

                DisplayHourChart();
            }
            else
            {
                labelChartActiveMode1.Text = "Date Mode";
                buttonMode.Text = "24Hour Mode";
                labelEndDate.Show();
                dateTimeEndDate.Show();
                labelStartDate.Text = "Start date";
                labelChartDays.Text = "Specific Days";

                DisplayChart();
            }
        }

        private IEnumerable<InfoBetweenDate> GetInfoAvgBetweenDates(string parameter, string city, DateTime startDate, DateTime endDate)
        {
            InfoBetweenDate[] avgInfo = airMonitServiceAccess.getInfoAvgBetweenDates(parameter, city, startDate, endDate);

            if (avgInfo == null)
            {
                MessageBox.Show("Something went wrong pulling AVG data from service. Please, try again later");
                return null;
            }

            // invert the order of the data in arrays to properly show data on chart from older date to current date
            InfoBetweenDate[] avgInfoInverted = new InfoBetweenDate[avgInfo.Count()];
            int x = 0;
            for (int i = avgInfo.Count() - 1; i >= 0; i--)
            {
                avgInfoInverted[x] = avgInfo[i];
                x++;
            }

            Debug.WriteLine("Received AVG info count: " + avgInfoInverted.Count());
            return avgInfoInverted;
        }

        private IEnumerable<InfoBetweenDate> GetInfoMinBetweenDates(string parameter, string city, DateTime startDate, DateTime endDate)
        {
            InfoBetweenDate[] minInfo = airMonitServiceAccess.getInfoMinBetweenDates(parameter, city, startDate, endDate);

            if (minInfo == null)
            {
                MessageBox.Show("Something went wrong pulling MIN data from service. Please, try again later");
                return null;
            }

            // invert the order of the data in arrays to properly show data on chart from older date to current date
            InfoBetweenDate[] minInfoInverted = new InfoBetweenDate[minInfo.Count()];
            int x = 0;
            for (int i = minInfo.Count() - 1; i >= 0; i--)
            {
                minInfoInverted[x] = minInfo[i];
                x++;
            }

            Debug.WriteLine("Received MIN info count: " + minInfo.Count());
            return minInfoInverted;
        }

        private IEnumerable<InfoBetweenDate> GetInfoMaxBetweenDates(string parameter, string city, DateTime startDate, DateTime endDate)
        {
            InfoBetweenDate[] maxInfo = airMonitServiceAccess.getInfoMaxBetweenDates(parameter, city, startDate, endDate);

            if (maxInfo == null)
            {
                MessageBox.Show("Something went wrong pulling MAX data from service. Please, try again later");
                return null;
            }

            // invert the order of the data in arrays to properly show data on chart from older date to current date
            InfoBetweenDate[] maxInfoInverted = new InfoBetweenDate[maxInfo.Count()];
            int x = 0;
            for (int i = maxInfo.Count() - 1; i >= 0; i--)
            {
                maxInfoInverted[x] = maxInfo[i];
                x++;
            }

            Debug.WriteLine("Received MAX info count: " + maxInfo.Count());
            return maxInfoInverted;
        }

        private IEnumerable<InfoBetweenDate> GetInfoAvgEachHour(string parameter, string city, DateTime startDate)
        {
            InfoBetweenDate[] avgInfo = airMonitServiceAccess.getInfoAvgEachHour(parameter, city, startDate);

            if (avgInfo == null)
            {
                MessageBox.Show("Something went wrong pulling AVG data from service. Please, try again later");
                return null;
            }

            // invert the order of the data in arrays to properly show data on chart from older date to current date
            InfoBetweenDate[] avgInfoInverted = new InfoBetweenDate[avgInfo.Count()];
            int x = 0;
            for (int i = avgInfo.Count() - 1; i >= 0; i--)
            {
                avgInfoInverted[x] = avgInfo[i];
                x++;
            }

            Debug.WriteLine("Received AVG info count: " + avgInfoInverted.Count());
            return avgInfoInverted;
        }

        private IEnumerable<InfoBetweenDate> GetInfoMinEachHour(string parameter, string city, DateTime startDate)
        {
            InfoBetweenDate[] minInfo = airMonitServiceAccess.getInfoMinEachHour(parameter, city, startDate);

            if (minInfo == null)
            {
                MessageBox.Show("Something went wrong pulling MIN data from service. Please, try again later");
                return null;
            }

            // invert the order of the data in arrays to properly show data on chart from older date to current date
            InfoBetweenDate[] minInfoInverted = new InfoBetweenDate[minInfo.Count()];
            int x = 0;
            for (int i = minInfo.Count() - 1; i >= 0; i--)
            {
                minInfoInverted[x] = minInfo[i];
                x++;
            }

            Debug.WriteLine("Received MIN info count: " + minInfo.Count());
            return minInfoInverted;
        }

        private IEnumerable<InfoBetweenDate> GetInfoMaxEachHour(string parameter, string city, DateTime startDate)
        {
            InfoBetweenDate[] maxInfo = airMonitServiceAccess.getInfoMaxEachHour(parameter, city, startDate);

            if (maxInfo == null)
            {
                MessageBox.Show("Something went wrong pulling MAX data from service. Please, try again later");
                return null;
            }

            // invert the order of the data in arrays to properly show data on chart from older date to current date
            InfoBetweenDate[] maxInfoInverted = new InfoBetweenDate[maxInfo.Count()];
            int x = 0;
            for (int i = maxInfo.Count() - 1; i >= 0; i--)
            {
                maxInfoInverted[x] = maxInfo[i];
                x++;
            }

            Debug.WriteLine("Received MAX info count: " + maxInfo.Count());
            return maxInfoInverted;
        }

        private IEnumerable<AlarmLog> GetAlarmsBetweenDates(String city, DateTime startDate, DateTime endDate)
        {
            AlarmLog[] alarms = airMonitServiceAccess.getDailyAlarmsByCityBetweenDates(city, startDate, endDate);

            if (alarms == null)
            {
                MessageBox.Show("Something went wrong pulling data from service. Please, try again later");
                return null;
            }

            Debug.WriteLine("Received alarms between dates count: " + alarms.Count());
            labelAlarmsCount.Text = alarms.Count() + "";

            return alarms;
        }

        private IEnumerable<UncommonEvents> GetUncommonEvents(String city, DateTime startDate, DateTime endDate)
        {
            UncommonEvents[] events = airMonitServiceAccess.getUncommonEventsBetweenDates(city, startDate, endDate);

            if (events == null)
            {
                MessageBox.Show("Something went wrong pulling data from service. Please, try again later");
                return null;
            }

            Debug.WriteLine("Received events count: " + events.Count());
            labelTotalEvents.Text = events.Count() + "";

            return events;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            int selectedTabIndex = tabControl1.SelectedIndex;

            switch (selectedTabIndex)
            {
                case 0:
                    ShowActiveChartMode();
                    break;
                case 1:
                    RefreshDataGridAtTAB("RAISED_ALARMS", dataGridViewRaisedAlarms);
                    break;
                case 2:
                    RefreshDataGridAtTAB("EVENTS", dataGridViewUncommonEvents);
                    break;
            }
        }
    }
}
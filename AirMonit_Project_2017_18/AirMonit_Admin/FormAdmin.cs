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
        private string[] cities = { "Leiria", "Lisboa", "Porto", "Coimbra", "All cities" };
        private IAirMonit_AccessingData airMonitServiceAccess;
        
        //servico
        public FormAdmin()
        {
            InitializeComponent();
            airMonitServiceAccess = new AirMonit_AccessingDataClient();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            comboBoxCities.Items.AddRange(cities);
            comboBoxCities.SelectedIndex = 0;
            ParametersCheckBoxEnable(true);
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

        private IEnumerable<AlarmLog> GetAlarmsBetweenDates(String city, DateTime startDate, DateTime endDate)
        {
            AlarmLog[] alarms = airMonitServiceAccess.getDailyAlarmsByCityBetweenDates(city, startDate, endDate);

            if (alarms == null)
            {
                Debug.WriteLine("Something went wrong at method 'GetAlarmsBetweenDates' ");
                return null;
            }

            Debug.WriteLine("Received alarms between dates count: " + alarms.Count());
            return alarms;
        }

        private IEnumerable<UncommonEvents> GetUncommonEvents(String city, DateTime startDate, DateTime endDate)
        {
            UncommonEvents[] events = airMonitServiceAccess.getUncommonEventsBetweenDates(city, startDate, endDate);

            if (events == null)
            {
                Debug.WriteLine("Something went wrong at method 'GetUncommonEvents' ");
                return null;
            }

            Debug.WriteLine("Received events count: " + events.Count());
            return events;
        }

        private void comboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTabIndex = tabControl1.SelectedIndex;
            Debug.WriteLine("Tab index: " + selectedTabIndex);
            switch (selectedTabIndex)
            {
                case 2:
                    RefreshDataGridAtTAB("RAISED_ALARMS", dataGridViewRaisedAlarms);
                    break;
                case 3:
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
            DateTime datetime, endDate;
            UncommonEvents[] events;
            DataGridView contextGrid = GetCurrentDataGrid();

            selectedCity = comboBoxCities.SelectedItem.ToString();

            try
            {
                datetime = DateTime.Parse(dateTimeMainPicker.Value.ToString());
                endDate = DateTime.Parse(dateTimePickerAlarmDateEnd.Value.ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error parsing date: " + e.Message);
                return;
            }

            labelUncommonCityOrCities.Text = selectedCity;
            labelEventsStartDate.Text = datetime.ToString("yyyy-MM-dd");
            labelEventsEndDate.Text = endDate.ToString("yyyy-MM-dd");

            if (selectedCity == "All cities")
            {
                selectedCity = null;
            }

            events = (UncommonEvents[])GetUncommonEvents(selectedCity, datetime, endDate);

            if (events == null)
            {
                contextGrid.DataSource = null;
                return;
            }

            DataGridRefresh(events, contextGrid);
        }

        private void RefreshRaisedAlarms()
        {
            string selectedCity;
            DateTime datetime, endDate;
            AlarmLog[] alarms;
            DataGridView contextGrid = GetCurrentDataGrid();

            selectedCity = comboBoxCities.SelectedItem.ToString();

            try
            {
                datetime = DateTime.Parse(dateTimeMainPicker.Value.ToString());
                endDate = DateTime.Parse(dateTimePickerAlarmDateEnd.Value.ToString());
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error parsing date: " + e.Message);
                return;
            }

            if (datetime > endDate)
            {
                MessageBox.Show("Start Date cannot be after End Date");
                contextGrid.DataSource = null;
                return;
            }

            labelRaisedAlarmsCityOrCities.Text = selectedCity;
            labelDateStart.Text = datetime.ToString("yyyy-MM-dd");
            labelDateEnd.Text = endDate.ToString("yyyy-MM-dd");

            if (selectedCity == "All cities")
            {
                selectedCity = null;
            }

            alarms = (AlarmLog[])GetAlarmsBetweenDates(selectedCity, datetime, endDate);

            if (alarms == null)
            {
                contextGrid.DataSource = null;
                return;
            }

            DataGridRefresh(alarms, contextGrid);
            DataGridFilterParam();
        }

        private void TabPageRaisedAlarms_Enter(object sender, EventArgs e)
        {
            labelChooseDate.Text = "Start Date";
            labelEndDate.Show();
            ShowParametersCheckBox();
            dateTimePickerAlarmDateEnd.Show();
            RefreshDataGridAtTAB("RAISED_ALARMS", dataGridViewRaisedAlarms);
        }

        private void TabPageUncommonEvents_Enter(object sender, EventArgs e)
        {
            labelChooseDate.Text = "Start Date";
            labelEndDate.Show();
            HideParametersCheckBox();
            dateTimePickerAlarmDateEnd.Show();
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
            //ParametersCheckBoxEnable(true);
            DataGridFilterParam();
        }

        private void CheckBoxO3_CheckedChanged(object sender, EventArgs e)
        {
            //ParametersCheckBoxEnable(true);
            DataGridFilterParam();
        }


        private void CheckBoxNO2_CheckedChanged(object sender, EventArgs e)
        {
            //ParametersCheckBoxEnable(true);
            DataGridFilterParam();
        }

        private void DataGridFilterParam()
        {
            DataGridView dataGrid = GetCurrentDataGrid();
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
                    Debug.WriteLine("Param cell index: " + dataGrid.Columns["Parameter"].Index);
                }
            }

            return paramCellIndex;
        }

        private void DateTimePickerAlarmBetweenDateBegin_ValueChanged(object sender, EventArgs e)
        {
            int selectedTabIndex = tabControl1.SelectedIndex;

            switch (selectedTabIndex)
            {
                case 2:
                    RefreshDataGridAtTAB("RAISED_ALARMS", dataGridViewRaisedAlarms);
                    break;
                case 3:
                    RefreshDataGridAtTAB("EVENTS", dataGridViewUncommonEvents);
                    break;
            }
        }

        private void dateTimeRaisedAlarms_ValueChanged(object sender, EventArgs e)
        {
            int selectedTabIndex = tabControl1.SelectedIndex;

            switch (selectedTabIndex)
            {
                case 2:
                    RefreshDataGridAtTAB("RAISED_ALARMS", dataGridViewRaisedAlarms);
                    break;
                case 3:
                    RefreshDataGridAtTAB("EVENTS", dataGridViewUncommonEvents);
                    break;
            }
        }

        private DataGridView GetCurrentDataGrid()
        {
            int currentTabIndex = tabControl1.SelectedIndex;

            switch (currentTabIndex)
            {
                case 2: return dataGridViewRaisedAlarms;
                case 3: return dataGridViewUncommonEvents;
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

        private void ButtonChart_Click(object sender, EventArgs e)
        {
            chartSingleCity.Series.Clear();
            int periodicity;
            periodicity = 24; //semana 7 ou dia 24

            if (checkBoxNO2.Checked == true)
            {
                chartSingleCity.Series.Add("NO2");
                chartSingleCity.Series["NO2"].SetDefault(true);
                chartSingleCity.Series["NO2"].Enabled = true;
            }

            if (checkBoxCO.Checked == true)
            {
                chartSingleCity.Series.Add("CO");
                chartSingleCity.Series["CO"].SetDefault(true);
                chartSingleCity.Series["CO"].Enabled = true;
            }

            if (checkBoxO3.Checked == true)
            {
                chartSingleCity.Series.Add("O3");
                chartSingleCity.Series["O3"].SetDefault(true);
                chartSingleCity.Series["O3"].Enabled = true;
            }


            chartSingleCity.Visible = true;

            for (int i = 0; i <= periodicity; i++)
            {
                if (checkBoxCO.Checked == true)
                {
                    chartSingleCity.Series["NO2"].Points.AddXY(1, 1250 + i);
                }

                if (checkBoxCO.Checked == true)
                {
                    chartSingleCity.Series["CO"].Points.AddXY(2, 500 + i);
                }

                if (checkBoxCO.Checked == true)
                {
                    chartSingleCity.Series["O3"].Points.AddXY(3, 800 + i);
                }

            }

            chartSingleCity.Show();
        }
    }
}
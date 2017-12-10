﻿using AirMonit_Admin.AitMonitService;
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
        private string[] cities = { "Leiria", "Lisboa", "Porto", "Coimbra" };
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

        private IEnumerable<AlarmLog> GetDailyAlarmsByCity(String city, DateTime dateIime)
        {
            AlarmLog[] alarms = airMonitServiceAccess.getDailyAlarmsByCity(city, dateIime);
            Debug.WriteLine("Received alarms count: " + alarms.Count());
            return alarms;
        }

        private void comboBoxCities_TextUpdate(object sender, EventArgs e)
        {
            RefreshDataGridAtTAB("RAISED_ALARMS", dataGridViewRaisedAlarms);
        }

        private void RefreshDataGridAtTAB(string tabFlag, DataGridView datagrid)
        {
            ParametersCheckBoxEnable(true);

            switch (tabFlag)
            {
                case "RAISED_ALARMS":
                    string selectedCity = comboBoxCities.SelectedItem.ToString();
                    DateTime datetime = DateTime.Parse(dateTimeRaisedAlarms.Value.ToString());

                    labelRaisedAlarmsCityName.Text = selectedCity;
                    labelRaisedAlarmsDate.Text = datetime.ToString("yyyy-MM-dd");

                    DataGridRefresh(GetDailyAlarmsByCity(selectedCity, datetime), datagrid);
                    DataGridFilterParam();
                    break;
            }
        }

        private void TabRaisedAlarms_Enter(object sender, EventArgs e)
        {
            RefreshDataGridAtTAB("RAISED_ALARMS", dataGridViewRaisedAlarms);
        }

        private void TabPageAlarmBetweenDates_Enter(object sender, EventArgs e)
        {
            //ParametersCheckBoxEnable(true);

            string selectedCity = comboBoxCities.SelectedItem.ToString();
            DateTime datetime = DateTime.Parse(dateTimeRaisedAlarms.Value.ToString());

            DataGridRefresh(GetDailyAlarmsByCity(selectedCity, datetime), dataGridViewAlarmsBetweenDates);
            DataGridFilterParam();

        }
        private void TabPageUncommonEvents_Enter(object sender, EventArgs e)
        {
            //ParametersCheckBoxEnable(true);

            string selectedCity = comboBoxCities.SelectedItem.ToString();
            DateTime datetime = DateTime.Parse(dateTimeRaisedAlarms.Value.ToString());

            DataGridRefresh(GetDailyAlarmsByCity(selectedCity, datetime), dataGridViewAlarmsBetweenDates);
            //DataGridRefresh(GetDailyAlarmsByCity(selectedCity, dateTimeRaisedAlarms.Value.ToString()), dataGridViewUncommonEvents);
            DataGridFilterParam();
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

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                string s = row.Cells[2].Value.ToString();

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

        private void DateTimePickerAlarmBetweenDateBegin_ValueChanged(object sender, EventArgs e)
        {
            DataGridView dataGrid = GetCurrentDataGrid();

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                try
                {
                    DateTime timeRow = DateTime.Parse(row.Cells[2].Value.ToString());
                  //  MessageBox.Show("timerow " + timeRow.Date.ToString());
                   // MessageBox.Show("picker " + dateTimePickerAlarmBetweenDateBegin.Value.Date.ToString());

                    //datetime compare - earlier = -1 / same = 0 / later = 1
                    if (DateTime.Compare(dateTimePickerAlarmBetweenDateBegin.Value.Date, timeRow.Date) <= 0 &&
                            DateTime.Compare(dateTimePickerAlarmBetweenDateEnd.Value.Date, timeRow.Date) >= 0)
                    {
                        DataGridSetRowVisibility(row, true, dataGrid);
                    }
                    else
                    {
                        DataGridSetRowVisibility(row, false, dataGrid);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("The datetime is in wrong format at line " + row.Index);
                    return;
                }
            }
        }

        private void dateTimeRaisedAlarms_ValueChanged(object sender, EventArgs e)
        {
            RefreshDataGridAtTAB("RAISED_ALARMS", dataGridViewRaisedAlarms);
            /*DataGridView dataGrid = GetCurrentDataGrid();

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                try
                {
                    DateTime timeRow = DateTime.Parse(row.Cells[2].Value.ToString());
                    //  MessageBox.Show("timerow " + timeRow.Date.ToString());
                    // MessageBox.Show("picker " + dateTimePickerAlarmBetweenDateBegin.Value.Date.ToString());

                    //datetime compare - earlier = -1 / same = 0 / later = 1
                    if (DateTime.Compare(dateTimeRaisedAlarms.Value.Date, timeRow.Date) == 0)
                    {
                        DataGridSetRowVisibilitie(row, true, dataGrid);
                    }
                    else
                    {
                        DataGridSetRowVisibilitie(row, false, dataGrid);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("The datetime is in wrong format at line " + row.Index);
                    return;
                }
            }*/
        }

        private DataGridView GetCurrentDataGrid()
        {
            foreach (TabPage tbp in tabControl1.TabPages)
            {
                foreach (Control ctrl in tbp.Controls)    
                {
                    if (ctrl is DataGridView)
                    {
                        return (DataGridView)ctrl;
                    }
                }
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

        private void DataGridRefresh(IEnumerable<AlarmLog> alarms, DataGridView dataGrid)
        {
            dataGrid.DataSource = null;
            dataGrid.Refresh();
            dataGrid.DataSource = alarms;
        }

        private void ButtonChart_Click(object sender, EventArgs e)
        {
            chartSingleCity.Series.Clear();

            chartSingleCity.Series.Add("City");
            chartSingleCity.Series.Add("Alarms");

            chartSingleCity.Series["City"].SetDefault(true);
            chartSingleCity.Series["City"].Enabled = true;
            chartSingleCity.Visible = true;

 
            chartSingleCity.Series["City"].Points.AddXY(1, 10);
            chartSingleCity.Series["City"].Points.AddXY(2, 9);
            chartSingleCity.Series["City"].Points.AddXY(3, 8);


            chartSingleCity.Show();
        }
    }
}
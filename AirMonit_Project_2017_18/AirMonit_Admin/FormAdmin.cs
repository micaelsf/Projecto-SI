using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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


        //servico
        public FormAdmin()
        {
            InitializeComponent();
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

        private void ComboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
           // string selectedCity = comboBoxCities.SelectedItem.ToString();

          // dataGridRefresh(getDailyAlarmsByCity(selectedCity, dateTimeRaisedAlarms.Value.ToString()));

            /*foreach (AlarmLog alarm in alarms)
            {
                int index = dataGridViewRaisedAlarms.Rows.Add();
                DataGridViewRow row = dataGridViewRaisedAlarms.Rows[index];

               // row.Cells["RA_id"].Value = alarm.Id;
               // row.Cells["RA_paramType"].Value = alarm.ParamType;
               // row.Cells["RA_paramValue"].Value = alarm.ParamValue;
              //  row.Cells["RA_description"].Value = alarm.Description;
            }*/
        }

        private List<AlarmLog> GetDailyAlarmsByCity(String city, string dateIimeOffset)
        {
            List<AlarmLog> temporaryList = new List<AlarmLog>();
            AlarmLog alarm1 = new AlarmLog(1, "Qualidade do NO2: Normal", dateIimeOffset, "NO2", 300);
            AlarmLog alarm2 = new AlarmLog(2, "Qualidade do NO2: Má", dateIimeOffset, "NO2", 10);
            AlarmLog alarm3 = new AlarmLog(3, "Qualidade do O3: Horrivel", dateIimeOffset, "O3", 200);
            AlarmLog alarm4 = new AlarmLog(4, "Qualidade do CO: Normal", dateIimeOffset, "CO", 679);
            AlarmLog alarm5 = new AlarmLog(5, "Qualidade do CO: Normal", dateIimeOffset, "NO2", 111);
            AlarmLog alarm6 = new AlarmLog(6, "Qualidade do CO: Horrivel", dateIimeOffset, "NO2", 122);

            temporaryList.Add(alarm1);
            temporaryList.Add(alarm2);
            temporaryList.Add(alarm3);
            temporaryList.Add(alarm4);
            temporaryList.Add(alarm5);
            temporaryList.Add(alarm6);

            return temporaryList;
        }

      //  private void TabRaisedAlarms_LostFocus(object sender, EventArgs e)
       // {
          //  ParametersCheckBoxEnable(false);
       // }

        private void TabRaisedAlarms_Enter(object sender, EventArgs e)
        {
            ParametersCheckBoxEnable(true);

            string selectedCity = comboBoxCities.SelectedItem.ToString();
            DataGridRefresh(GetDailyAlarmsByCity(selectedCity, dateTimeRaisedAlarms.Value.ToString()), dataGridViewRaisedAlarms);
            DataGridFilterParam();

        }
        private void TabPageAlarmBetweenDates_Enter(object sender, EventArgs e)
        {
            ParametersCheckBoxEnable(true);

            string selectedCity = comboBoxCities.SelectedItem.ToString();
            DataGridRefresh(GetDailyAlarmsByCity(selectedCity, dateTimeRaisedAlarms.Value.ToString()), dataGridViewAlarmsBetweenDates);
            DataGridFilterParam();

        }
        private void TabPageUncommonEvents_Enter(object sender, EventArgs e)
        {
            ParametersCheckBoxEnable(true);

            string selectedCity = comboBoxCities.SelectedItem.ToString();
            DataGridRefresh(GetDailyAlarmsByCity(selectedCity, dateTimeRaisedAlarms.Value.ToString()), dataGridViewUncommonEvents);
            DataGridFilterParam();

        }

        private void CheckBoxCO_CheckedChanged(object sender, EventArgs e)
        {
            ParametersCheckBoxEnable(true);
            DataGridFilterParam();
        }

        private void CheckBoxO3_CheckedChanged(object sender, EventArgs e)
        {
            ParametersCheckBoxEnable(true);
            DataGridFilterParam();
        }


        private void CheckBoxNO2_CheckedChanged(object sender, EventArgs e)
        {
            ParametersCheckBoxEnable(true);
            DataGridFilterParam();
        }

        private void DataGridFilterParam()
        {
            DataGridView dataGrid = GetCurrentDataGrid();

            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                string s = row.Cells[3].Value.ToString();

                if (checkBoxO3.Checked && s.StartsWith(checkBoxO3.Text, true, null))
                {
                    DataGridSetRowVisibilitie(row, true, dataGrid);
                }
                else if (checkBoxNO2.Checked && s.StartsWith(checkBoxNO2.Text, true, null))
                {
                    DataGridSetRowVisibilitie(row, true, dataGrid);
                }
                else if (checkBoxCO.Checked && s.StartsWith(checkBoxCO.Text, true, null))
                {
                    DataGridSetRowVisibilitie(row, true, dataGrid);
                }
                else
                {
                    DataGridSetRowVisibilitie(row, false, dataGrid);
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
            }
        }

        private void dateTimeRaisedAlarms_ValueChanged(object sender, EventArgs e)
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
            }
        }


        private DataGridView GetCurrentDataGrid()
        {
            foreach (TabPage tbp in tabControl1.TabPages)
            {
                foreach (Control ctrl in tabControl1.SelectedTab.Controls)    
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

        private void DataGridSetRowVisibilitie(DataGridViewRow row, bool visibilitie, DataGridView dataGrid)
        {
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGrid.DataSource];
            currencyManager1.SuspendBinding();
            row.Visible = visibilitie;
            currencyManager1.ResumeBinding();
        }

        private void DataGridRefresh(List<AlarmLog> alarms, DataGridView dataGrid)
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
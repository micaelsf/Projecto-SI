using AirMonit_Admin.AitMonitService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            comboBoxCities.Items.AddRange(cities);
            checkBoxCO.Checked = true;
            checkBoxNO2.Checked = true;
            checkBoxO3.Checked = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private List<string> getActiveParameters()
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

        private void tabControlRaisedAlarms_MouseClick(object sender, MouseEventArgs e)
        {
            comboBoxCities.SelectedIndex = 0;
            //comboBoxCities.Items.AddRange(cities);
        }

        private void comboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = comboBoxCities.SelectedItem.ToString();
            DateTime datetime = DateTime.Parse(dateTimeRaisedAlarms.Text);

            dataGridRefresh(getDailyAlarmsByCity(selectedCity, datetime));

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

        private IEnumerable<AlarmLog> getDailyAlarmsByCity(String city, DateTime dateIime)
        {
            return airMonitServiceAccess.getDailyAlarmsByCity(city, dateIime);
        }

        
        private void tabPage3_Click(object sender, EventArgs e)
        {
            string selectedCity = comboBoxCities.SelectedItem.ToString();
            DateTime datetime = DateTime.Parse(dateTimeRaisedAlarms.Text);

            dataGridRefresh(getDailyAlarmsByCity(selectedCity, datetime));
        }
        private void checkBoxCO_CheckedChanged(object sender, EventArgs e)
        {
            dataGridFilterParam();
        }

        private void checkBoxO3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridFilterParam();
        }

        private void checkBoxNO2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridFilterParam();
        }

        private void dataGridFilterParam()
        {
            foreach (DataGridViewRow row in dataGridViewRaisedAlarms.Rows)
            {
                string s = row.Cells[3].Value.ToString();

                if (checkBoxO3.Checked && s.StartsWith(checkBoxO3.Text, true, null))
                {
                    dataGridSetRowVisibility(row, true);
                }
                else if (checkBoxNO2.Checked && s.StartsWith(checkBoxNO2.Text, true, null))
                {
                    dataGridSetRowVisibility(row, true);
                }
                else if (checkBoxCO.Checked && s.StartsWith(checkBoxCO.Text, true, null))
                {
                    dataGridSetRowVisibility(row, true);
                }
                else
                {
                    dataGridSetRowVisibility(row, false);
                }
            }
        }

        private void dataGridSetRowVisibility(DataGridViewRow row, bool visibilitie)
        {
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridViewRaisedAlarms.DataSource];
            currencyManager1.SuspendBinding();
            row.Visible = visibilitie;
            currencyManager1.ResumeBinding();
        }

        private void dataGridRefresh(IEnumerable<AlarmLog> alarms)
        {
            dataGridViewRaisedAlarms.DataSource = null;
            dataGridViewRaisedAlarms.Refresh();
            dataGridViewRaisedAlarms.DataSource = alarms;
        }
    }
}

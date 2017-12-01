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


        //servico
        public FormAdmin()
        {
            InitializeComponent();
            comboBoxCities.Items.AddRange(cities);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

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

            if (checkBox1.Checked)
                checkedParameters.Add("NO2");

            if (checkBox2.Checked)
                checkedParameters.Add("CO");

            if (checkBox3.Checked)
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

            List<AlarmLog> alarms = getDailyAlarmsByCity(selectedCity, dateTimeRaisedAlarms.ToString());
            dataGridViewRaisedAlarms.ReadOnly = true;
            dataGridViewRaisedAlarms.Rows.Clear();

            foreach(AlarmLog alarm in alarms)
            {
                int index = dataGridViewRaisedAlarms.Rows.Add();
                DataGridViewRow row = dataGridViewRaisedAlarms.Rows[index];

                row.Cells["RA_id"].Value = alarm.Id;
                row.Cells["RA_paramType"].Value = alarm.ParamType;
                row.Cells["RA_paramValue"].Value = alarm.ParamValue;
                row.Cells["RA_description"].Value = alarm.Description;
            }

        }

        private List<AlarmLog> getDailyAlarmsByCity(String city, string dateIimeOffset)
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

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}

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
        public readonly string[] Parameters = { "NO2", "CO", "O3" };
        //servico
        public FormAdmin()
        {
            InitializeComponent();
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
    }
}

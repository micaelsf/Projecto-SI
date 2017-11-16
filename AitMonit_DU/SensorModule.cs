using AirMonit_DU;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AitMonit_DU
{
    public partial class SensorModule : Form
    {
        private HandleSensorData hsd;

        public SensorModule()
        {
            hsd = new HandleSensorData();

            InitializeComponent();
            labelErrorDelay.Visible = false;
            labelErrorIP.Visible = false;
            textBoxIp.Text = "127.0.0.1";
            labelStatus.Text = "Disconnected";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int delay;
            IPAddress ip;

            if (!int.TryParse(textBoxTime.Text, out delay))
            {
                labelErrorDelay.Visible = true;
                return;
            }

            if (!IPAddress.TryParse(textBoxIp.Text, out ip))
            {
                labelErrorIP.Visible = true;
                return;
            }

            labelErrorDelay.Visible = false;
            labelErrorIP.Visible = false;

            if (hsd.Init(delay, ip))
            {
                labelStatus.Text = "Connected";
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (hsd.Stop())
            {
                labelStatus.Text = "Disconnected";
            }
        }
    }
}

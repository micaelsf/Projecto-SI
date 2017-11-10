﻿using System;
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
        private Boolean running;

        public SensorModule()
        {
            hsd = new HandleSensorData();

            InitializeComponent();
            labelErrorDelay.Visible = false;
            labelErrorIP.Visible = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (running)
            {
                return;
            }

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

                labelStatus.Text = "ON";
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (hsd.Stop() && running)
            {
                running = false;
                labelStatus.Text = "OFF";
            }
        }

    }
}
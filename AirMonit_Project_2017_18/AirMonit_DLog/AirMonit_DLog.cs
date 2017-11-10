using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;

namespace AirMonit_DLog
{
    public partial class AirMonit_DLog : Form
    {
        MqttClient m_cClient;
        Boolean serviceActive;

        public AirMonit_DLog()
        {
            InitializeComponent();
            serviceActive = false;
        }

        private void AirMonit_DLog_Load(object sender, EventArgs e)
        {
            listBoxAlarmLog.Items.Add("alarm");
            listBoxCityLog.Items.Insert(0, "city");
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (serviceActive)
            {
                // desliga o serviço
                serviceActive = false;
                m_cClient =  new MqttClient(textBoxBrokerIP.Text);
                btnStartStop.Text = "Start";
                btnStartStop.ForeColor = Color.Green;
            }
            else
            {
                // desliga o serviço
                serviceActive = true;
                m_cClient.Disconnect();
                btnStartStop.Text = "Stop";
                btnStartStop.ForeColor = Color.Red;
            }
        }
    }
}

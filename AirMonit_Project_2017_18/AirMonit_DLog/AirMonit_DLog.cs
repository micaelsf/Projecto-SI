using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace AirMonit_DLog
{
    public partial class AirMonit_DLog : Form
    {
        private MqttClient m_cClient;
        private Boolean serviceActive;
        private string[] topics = { "data", "alarm" };
        private XMLDataHandler handlerXml;

        //validacao xml
        private string xmlSchemaPathData = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Local_data\XMLParameterSchema.xsd");
        private string xmlSchemaPathAlarm = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Local_data\XMLAlarmsSchema.xsd");

        public AirMonit_DLog()
        {
            InitializeComponent();
            serviceActive = false;
            labelStatus.Text = "Disconnected";
            textBoxBrokerIP.Text = "127.0.0.1";
            handlerXml = new XMLDataHandler(xmlSchemaPathData, xmlSchemaPathAlarm);
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            String brokerIP = textBoxBrokerIP.Text;
            IPAddress ipAddress;

            if (!IPAddress.TryParse(brokerIP, out ipAddress))
            {
                MessageBox.Show("Please insert valid IP", "Invalid IP", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                return;
            }

            if (!serviceActive)
            { // activa o serviço
                m_cClient = new MqttClient(ipAddress.ToString());
                m_cClient.Connect(Guid.NewGuid().ToString());

                if (!m_cClient.IsConnected)
                {
                    MessageBox.Show("Error connecting to message broker...");
                    return;
                }

                serviceActive = true;
                labelStatus.Text = "Connected";
                btnStartStop.Text = "Stop";
                btnStartStop.ForeColor = Color.White;
                btnStartStop.BackColor = Color.Firebrick;

                //New Msg Arrived
                m_cClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

                //Subscribe to topics
                byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                                        MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE};//QoS
                m_cClient.Subscribe(topics, qosLevels);
            }
            else
            {
                // desliga o serviço
                m_cClient.Unsubscribe(topics); //Put this in a button to see notif!
                m_cClient.Disconnect();
                serviceActive = false;
                btnStartStop.Text = "Start";
                labelStatus.Text = "Disconnected";
                btnStartStop.ForeColor = Color.White;
                btnStartStop.BackColor = Color.LimeGreen;
            }
        }

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            if (e.Topic.Equals(topics[1])) // alarm
            {
                if (handlerXml.ValidateXMLStructure(Encoding.UTF8.GetString(e.Message), topics[1]))
                {
                    listBoxAlarmLog.BeginInvoke(
                       (MethodInvoker)delegate {
                           listBoxAlarmLog.Items.Insert(0, handlerXml.ParseXMLAlarm(
                               Encoding.UTF8.GetString(e.Message))
                               );
                       }
                   );
                }
            }
            if (e.Topic.Equals(topics[0])) //data
            {
                if (handlerXml.ValidateXMLStructure(Encoding.UTF8.GetString(e.Message), topics[0]))
                {
                    listBoxCityLog.BeginInvoke(
                        (MethodInvoker)delegate {
                            listBoxCityLog.Items.Insert(0, handlerXml.ParseXMLData(
                                Encoding.UTF8.GetString(e.Message))
                                );
                        }
                    );
                }
            }
        }
    }
}
 
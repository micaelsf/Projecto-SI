using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

namespace AirMonit_Alarm
{
    public partial class Form1 : Form
    {
        private MqttClient mClient;
        private string[] topics = { "data", "alarm" };
        private IPAddress ipAddress;
        private XMLHandler xmlhandler;

        public Form1()
        {
            InitializeComponent();
            SensorData sensorData = new SensorData();

            labelInvalidIp.Visible = false;
            labelStatus.Text = "Disconnected";
            textBoxIpAddress.Text = "127.0.0.1";

            xmlhandler = new XMLHandler();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (!xmlhandler.IsValidXmlRules)
            {
                MessageBox.Show("XML rules file is not valid.");
                return;
            }

            bool validIP;

            validIP = IPAddress.TryParse(textBoxIpAddress.Text, out ipAddress);

            labelStatus.Text = "Connected";

            if (validIP)
            {
                labelInvalidIp.Visible = false;

                mClient = new MqttClient(textBoxIpAddress.Text);

                mClient.Connect(Guid.NewGuid().ToString());

                mClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

                byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };//QoS
                mClient.Subscribe(topics, qosLevels);

                if (!mClient.IsConnected)
                {
                    MessageBox.Show("Error connecting to message broker...");
                    return;
                }
            }
            else
            {
                labelInvalidIp.Visible = true;
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {

        }

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string dataStr = xmlhandler.ParseXMLData(Encoding.UTF8.GetString(e.Message));

            if (dataStr == null)
            {
                MessageBox.Show(xmlhandler.ValidationMessage);
                return;
            }

            this.Invoke((MethodInvoker)delegate ()
            {
                listBoxData.Items.Insert(0, dataStr + Environment.NewLine);
            });

            // if e.message arrives here, it means it is already validated
            xmlhandler.ValidateParameters(Encoding.UTF8.GetString(e.Message));

            // now every rules are validated and alarms triggered, lets publish the alarms
            if (mClient == null || !mClient.IsConnected)
            {
                MessageBox.Show("Error connecting to message broker...");
                return;
            }
            string outerXML = xmlhandler.GetDocAlarm();

            if (outerXML == null)
            {
                MessageBox.Show("Created alarm is not valid");
                return;
            }

            mClient.Publish("alarm", Encoding.UTF8.GetBytes(outerXML));
            Debug.WriteLine("\nPUBLISHED: " + outerXML + "\n\n");
        }

        private void checkBoxActive_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

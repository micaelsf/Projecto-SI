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
        private string[] m_strTopicsInfo = { "data", "alarm" };
        private XMLDataHandler handlerXml;

        //validacao xml
        private string xmlSchemaPathData = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Local_data\XMLParameterSchemaData.xsd");
        private string xmlSchemaPathAlarm = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Local_data\XMLAlarmsSchemaAlarm.xsd");

        public AirMonit_DLog()
        {
            InitializeComponent();
            serviceActive = false;
            textBoxBrokerIP.Text = "127.0.0.1";
            handlerXml = new XMLDataHandler(xmlSchemaPathData, xmlSchemaPathAlarm);
        }

        private void AirMonit_DLog_Load(object sender, EventArgs e)
        {
            //just for some inicial show off purpose
           // listBoxAlarmLog.Items.Add("alarm");
            //listBoxCityLog.Items.Insert(0, "city");
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            String brokerIP = textBoxBrokerIP.Text;
            if (!IsIpAddressValid(brokerIP))
            {
                MessageBox.Show("Please insert valid IP", "Invalid IP", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                return;
            }

            if (!serviceActive)
            { // activa o serviço
                m_cClient = new MqttClient(brokerIP);
                m_cClient.Connect(Guid.NewGuid().ToString());

                if (!m_cClient.IsConnected)
                {
                    MessageBox.Show("Error connecting to message broker...");
                    return;
                }

                serviceActive = true;
                btnStartStop.Text = "Stop";
                btnStartStop.ForeColor = Color.Red;

                //Specify events we are interest on
                //New Msg Arrived
                m_cClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
                //This client's subscription operation id done
               // m_cClient.MqttMsgSubscribed += client_MqttMsgSubscribed;

                //Subscribe to topics
                byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                                        MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE};//QoS
                m_cClient.Subscribe(m_strTopicsInfo, qosLevels);
            }
            else
            {
                // desliga o serviço
                m_cClient.Unsubscribe(m_strTopicsInfo); //Put this in a button to see notif!
                m_cClient.Disconnect();
                serviceActive = false;
                btnStartStop.Text = "Start";
                btnStartStop.ForeColor = Color.Green;
            }
        }

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            //XMLHandler handlerXml = new XMLHandler(xmlSchemaPath);

            if (e.Topic.Equals(m_strTopicsInfo[1])) // alarm
            {
                if (handlerXml.ValidateXMLStructure(Encoding.UTF8.GetString(e.Message), m_strTopicsInfo[1]))
                {
                    listBoxAlarmLog.BeginInvoke(
                       (MethodInvoker)delegate {
                           listBoxAlarmLog.Items.Insert(0, handlerXml.ParseXMLAlarm(
                               Encoding.UTF8.GetString(e.Message))
                               );
                       }
                   );
                    ///listBoxAlarmLog.Items.Insert(0, Encoding.UTF8.GetString(e.Message));
                }
            }
            if (e.Topic.Equals(m_strTopicsInfo[0])) //data
            {
                if (handlerXml.ValidateXMLStructure(Encoding.UTF8.GetString(e.Message), m_strTopicsInfo[0]))
                {
                    listBoxCityLog.BeginInvoke(
                        (MethodInvoker)delegate {
                            listBoxCityLog.Items.Insert(0, handlerXml.ParseXMLData(
                                Encoding.UTF8.GetString(e.Message))
                                );
                        }
                    );
                    //StoreData.storeSensorData(SensorData.Instance);
                }
            }
        }

        public bool IsIpAddressValid(string Address)
        {
            System.Net.IPAddress parsed;
            return System.Net.IPAddress.TryParse(Address, out parsed);
        }


    }
}
 
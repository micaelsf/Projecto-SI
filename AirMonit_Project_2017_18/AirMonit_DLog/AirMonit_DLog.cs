using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        MqttClient m_cClient;
        Boolean serviceActive;
        string[] m_strTopicsInfo = { "data", "alarm" };

        //validacao xml
        private string xmlSchemaPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Local_data\XMLParameterSchema.xsd");
        private bool isValid;
        private string validationMessage;

        public AirMonit_DLog()
        {
            InitializeComponent();
            serviceActive = false;
        }

        private void AirMonit_DLog_Load(object sender, EventArgs e)
        {
            //just for some inicial show off purpose
            listBoxAlarmLog.Items.Add("alarm");
            listBoxCityLog.Items.Insert(0, "city");
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
                serviceActive = true;
                btnStartStop.Text = "Stop";
                btnStartStop.ForeColor = Color.Red;

                if (!m_cClient.IsConnected)
                {
                    MessageBox.Show("Error connecting to message broker...");
                    return;
                }

                m_cClient.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

                byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };//QoS
                m_cClient.Subscribe(m_strTopicsInfo, qosLevels);

                return;
            }

            // desliga o serviço
            m_cClient.Disconnect();
            serviceActive = false;
            btnStartStop.Text = "Start";
            btnStartStop.ForeColor = Color.Green;
        }

        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            if (e.Topic.Equals("Alarm"))
            {
                if (ValidateXMLStructure(e.Message.ToString()))
                {
                    listBoxAlarmLog.Items.Insert(0, Encoding.UTF8.GetString(e.Message));
                }
            }
            if (e.Topic.Equals("Data"))
            {
                if (ValidateXMLStructure(e.Message.ToString()))
                {
                    listBoxCityLog.Items.Insert(0, Encoding.UTF8.GetString(e.Message));
                }
            }
        }

        private bool ValidateXMLStructure(string outerXml)
        {
            isValid = true;
            XmlDocument doc = new XmlDocument();
            validationMessage = "Valid XML";

            try
            {
                doc.LoadXml(outerXml);
                ValidationEventHandler eventHandler = new ValidationEventHandler(MyValidateMethod);
                doc.Schemas.Add(null, xmlSchemaPath);
                doc.Validate(eventHandler);
            }
            catch (XmlException ex)
            {
                isValid = false;
                validationMessage = string.Format("ERROR: {0}", ex.ToString());
            }

            return isValid;
        }

        private void MyValidateMethod(object sender, ValidationEventArgs e)
        {
            isValid = false;
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    validationMessage = string.Format("ERROR: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    validationMessage = string.Format("WARNING: {0}", e.Message);
                    break;
                default:
                    break;
            }
        }


        public bool IsIpAddressValid(string Address)
        {
            System.Net.IPAddress parsed;
            return System.Net.IPAddress.TryParse(Address, out parsed);
        }


    }
}
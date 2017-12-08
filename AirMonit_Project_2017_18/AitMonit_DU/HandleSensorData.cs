using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using uPLibrary.Networking.M2Mqtt;

namespace AirMonit_DU
{
    class HandleSensorData
    {
        private string xmlSchemaPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Local_data\XMLParameterSchema.xsd");
        private bool isValid;
        MqttClient mClient;
        private string topic = "data";

        AirSensorNodeDll.AirSensorNodeDll dll;
        private XmlDocument doc;
        private XmlElement airMonitParam;
        private XmlElement sensorId;
        private XmlElement sensorValue;
        private XmlElement sensorDate;
        private XmlElement sensorTime;
        private XmlElement sensorCity;
        private XmlElement sensorDataUID;

        private string validationMessage;

        public HandleSensorData()
        {
            createXMLStructure();
        }

        private void createXMLStructure()
        {
            doc = new XmlDocument();
            airMonitParam = doc.CreateElement("AirMonitParam");
            sensorId = doc.CreateElement("id");
            sensorValue = doc.CreateElement("value");
            sensorDate = doc.CreateElement("date");
            sensorTime = doc.CreateElement("time");
            sensorCity = doc.CreateElement("city");
            sensorDataUID = doc.CreateElement("sensorDataUID");

            airMonitParam.SetAttribute("param", "");
            airMonitParam.AppendChild(sensorId);
            airMonitParam.AppendChild(sensorValue);
            airMonitParam.AppendChild(sensorDate);
            airMonitParam.AppendChild(sensorTime);
            airMonitParam.AppendChild(sensorCity);
            airMonitParam.AppendChild(sensorDataUID);

            doc.AppendChild(airMonitParam);
        }

        public Boolean Init(int delay, IPAddress ip)
        {
            mClient = new MqttClient(ip.ToString());

            mClient.Connect(Guid.NewGuid().ToString());

            if (!mClient.IsConnected)
            {
                Debug.WriteLine("Error connecting to message broker...");
                return false;
            }

            if (dll == null)
            {
                dll = new AirSensorNodeDll.AirSensorNodeDll();
                dll.Initialize(TransformData, delay);
                return true;
            }

            return false;
        }

        public Boolean Stop()
        {
            if (dll != null)
            {
                dll.Stop();
                dll = null;
                return true;
            }

            return false;
        }

        private void TransformData(string message)
        {
            SHA256 mySHA256 = SHA256.Create();
            byte[] hashValue;

            // Compute message hash
            hashValue = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(message));

            // convert hash to hexadecimal
            StringBuilder hexHash = new StringBuilder(hashValue.Length * 2);
            foreach (byte b in hashValue)
            {
                hexHash.AppendFormat("{0:x2}", b);
            }

            // split message
            string[] splitedSensorData = message.Split(';');

            airMonitParam.SetAttribute("param", splitedSensorData[1].Trim());
            sensorId.InnerText = splitedSensorData[0].Trim();
            sensorValue.InnerText = splitedSensorData[2].Trim();

            string[] splitedDateTime = splitedSensorData[3].Split(' ');
            string[] splitedTime = splitedDateTime[1].Split(':');

            // handle hours to match correct format HH:MM:SS 
            int hour = 0;
            string hourStr = splitedTime[0];

            try
            {
                int.TryParse(splitedTime[0], out hour);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

            if (hour < 10 && hourStr.Length == 1)
            {
                hourStr = "0" + splitedTime[0];
            }
            // end handling hours

            sensorDate.InnerText = splitedDateTime[0].Trim();
            sensorTime.InnerText = hourStr + ":" + splitedTime[1] + ":" + splitedTime[2];

            sensorCity.InnerText = splitedSensorData[4].Trim();
            sensorDataUID.InnerText = hexHash.ToString();

            Debug.WriteLine(message);

            PublishData(airMonitParam.OuterXml);
        }

        private void PublishData(string outerXml)
        {
            if (mClient == null || !mClient.IsConnected)
            {
                Debug.WriteLine("ERROR: No connection with message broker");
                return;
            }

            if (!ValidateXMLStructure(outerXml))
            {
                Debug.WriteLine("ERROR: " + validationMessage);
                return;
            }

            mClient.Publish(topic, Encoding.UTF8.GetBytes(outerXml));
            Debug.WriteLine("Sended data: " + outerXml);

        }

        private bool ValidateXMLStructure(string outerXml)
        {
            isValid = true;
            XmlDocument doc = new XmlDocument();
            validationMessage = "Data structure is valid";

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
    }
}

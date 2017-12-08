using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace AirMonit_DLog
{
    class XMLDataHandler
    {
        private bool isValid = true;
        private string validationMessage;
        private string xmlSchemaDataPath;
        private string xmlshcemaAlarmPath;

        private StoreData storeData;
        private XmlDocument doc;

        public string ValidationMessage { get; set; }

        public XMLDataHandler(String xmlSchemaDataPath, string xmlshcemaAlarmPath)
        {
            storeData = new StoreData();
            doc = new XmlDocument();
            this.xmlSchemaDataPath = xmlSchemaDataPath;
            this.xmlshcemaAlarmPath = xmlshcemaAlarmPath;

        }

        public string ParseXMLData(string xmldata)
        {
            if (!ValidateXMLStructure(xmldata, "data"))
            {
                Debug.WriteLine(ValidationMessage);
                return null;
            }

            doc.LoadXml(xmldata);
            XmlElement root = (XmlElement)doc.SelectSingleNode("/AirMonitParam");

            try
            {
                SensorData.Instance.Param = root.Attributes["param"].Value;
                SensorData.Instance.Id = int.Parse(root.SelectSingleNode("id").InnerText);
                SensorData.Instance.Value = int.Parse(root.SelectSingleNode("value").InnerText);
                SensorData.Instance.Date = root.SelectSingleNode("date").InnerText;
                SensorData.Instance.Time = root.SelectSingleNode("time").InnerText;
                SensorData.Instance.City = root.SelectSingleNode("city").InnerText;
                SensorData.Instance.SensorDataUID = root.SelectSingleNode("sensorDataUID").InnerText;
            } catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            

            storeData.StoreSensorData(SensorData.Instance);

            return SensorData.Instance.ToString();
        }

        public string ParseXMLAlarm(string xmldata)
        {
            if (!ValidateXMLStructure(xmldata, "alarm"))
            {
                Debug.WriteLine(ValidationMessage);
                return null;
            }

            // parse the received xml data to a singleton class 

            doc.LoadXml(xmldata);
            XmlElement temporaryRoot = (XmlElement)doc.SelectSingleNode("/airMonitAlarm");

            AlarmData.Instance.SensorId = temporaryRoot.SelectSingleNode("AirMonitParam/id").InnerText;
            AlarmData.Instance.SensorCity = temporaryRoot.SelectSingleNode("AirMonitParam/city").InnerText;
            AlarmData.Instance.SensorTime = temporaryRoot.SelectSingleNode("AirMonitParam/time").InnerText;
            AlarmData.Instance.SensorDate = temporaryRoot.SelectSingleNode("AirMonitParam/city").InnerText;
            AlarmData.Instance.SensorValue = temporaryRoot.SelectSingleNode("AirMonitParam/value").InnerText;
            AlarmData.Instance.SensorParam = temporaryRoot.SelectSingleNode("AirMonitParam").Attributes["param"].Value;
            AlarmData.Instance.SensorDataUID = temporaryRoot.SelectSingleNode("AirMonitParam/sensorDataUID").InnerText;

            AlarmData.Instance.AlarmDescription = temporaryRoot.SelectSingleNode("description").InnerText;
            AlarmData.Instance.AlarmDate = temporaryRoot.SelectSingleNode("date").InnerText;
            AlarmData.Instance.AlarmTime = temporaryRoot.SelectSingleNode("time").InnerText;

            storeData.StoreAlarmData(AlarmData.Instance);

            return AlarmData.Instance.ToString();
        }

        public bool ValidateXMLStructure(string outerXml, string topic)
        {
            isValid = true;
            XmlDocument doc = new XmlDocument();
            validationMessage = "Valid XML";

            try
            {
                doc.LoadXml(outerXml);
                ValidationEventHandler eventHandler = new ValidationEventHandler(MyValidateMethod);
                if (topic.Equals("alarm"))
                {
                    doc.Schemas.Add(null, xmlshcemaAlarmPath);
                }
                else if(topic.Equals("data")){
                    doc.Schemas.Add(null, xmlSchemaDataPath);
                }

                doc.Validate(eventHandler);
            }
            catch (XmlException ex)
            {
                isValid = false;
                validationMessage = string.Format("ERROR: {0}", ex.ToString());
            }

            return isValid;
        }

        private void MyValidateMethod(object sender, ValidationEventArgs args)
        {
            isValid = false;
            switch (args.Severity)
            {
                case XmlSeverityType.Error:
                    validationMessage = string.Format("ERROR: {0}", args.Message);
                    break;
                case XmlSeverityType.Warning:
                    validationMessage = string.Format("WARNING: {0}", args.Message);
                    break;
                default:
                    break;
            }
        }

    }
}
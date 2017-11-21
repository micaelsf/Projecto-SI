using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace AirMonit_Alarm
{
    class XMLHandler
    {
        private string xmlSchemaPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Local_data\XMLParameterSchema.xsd");
        private bool isValid;
        private XmlDocument doc;

        public string ValidationMessage { get; set; }

        public XMLHandler()
        {
            doc = new XmlDocument();
        }

        public string ParseXMLData(string xmldata)
        {
            if (!ValidateXMLStructure(xmldata))
            {
                Debug.WriteLine(ValidationMessage);
            }

            doc.LoadXml(xmldata);
            XmlElement root = (XmlElement)doc.SelectSingleNode("/AirMonitParam");

            SensorData.Instance.Param = root.Attributes["param"].Value;
            SensorData.Instance.Id = int.Parse(root.SelectSingleNode("id").InnerText);
            SensorData.Instance.Value = long.Parse(root.SelectSingleNode("value").InnerText);
            SensorData.Instance.Date = root.SelectSingleNode("date").InnerText;
            SensorData.Instance.Time = root.SelectSingleNode("time").InnerText;
            SensorData.Instance.City = root.SelectSingleNode("city").InnerText;

            return SensorData.Instance.ToString();
        }

        public bool ValidateXMLStructure(string outerXml)
        {
            isValid = true;
            XmlDocument doc = new XmlDocument();
            ValidationMessage = "Data structure is valid";

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
                ValidationMessage = string.Format("ERROR: {0}", ex.ToString());
            }

            return isValid;
        }

        public void MyValidateMethod(object sender, ValidationEventArgs e)
        {
            isValid = false;
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    ValidationMessage = string.Format("ERROR: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    ValidationMessage = string.Format("WARNING: {0}", e.Message);
                    break;
                default:
                    break;
            }
        }
    }
}

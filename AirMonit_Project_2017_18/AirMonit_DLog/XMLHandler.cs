using System;
using System.Collections.Generic;
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
    class XMLHandler
    {
        private bool isValid = true;
        private string validationMessage;
        private string xmlSchemaPath;
        public string City { get; set; }
        public int O3 { get; set; }
        public int No2 { get; set; }
        public int CO { get; set; }

        private XmlDocument doc;

        public string ValidationMessage { get; set; }

        public XMLHandler(String xmlSchemaPath)
        {
            doc = new XmlDocument();
            this.xmlSchemaPath = xmlSchemaPath;
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

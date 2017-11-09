using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace AitMonit_DU
{
    class HandleSensorData
    {
        private string xmlSchemaPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Local_data\XMLParameterSchema.xsd");
        bool isValid;

        AirSensorNodeDll.AirSensorNodeDll dll;
        private XmlDocument doc;
        private XmlElement airMonitParam;
        private XmlElement sensorId;
        private XmlElement sensorValue;
        private XmlElement sensorDate;
        private XmlElement sensorTime;
        private XmlElement sensorCity;

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

            airMonitParam.SetAttribute("parameter", "");
            airMonitParam.AppendChild(sensorId);
            airMonitParam.AppendChild(sensorValue);
            airMonitParam.AppendChild(sensorDate);
            airMonitParam.AppendChild(sensorTime);
            airMonitParam.AppendChild(sensorCity);

            doc.AppendChild(airMonitParam);
        }

        public Boolean Init(int delay, IPAddress ip)
        {
            dll = new AirSensorNodeDll.AirSensorNodeDll();
            dll.Initialize(TransformData, delay);
            return true;
        }

        public Boolean Stop()
        {
            dll.Stop();
            return true;
        }

        private void TransformData(string message)
        {
            string[] splitedSensorData = message.Split(';');

            airMonitParam.SetAttribute("parameter", splitedSensorData[1].Trim());
            sensorId.InnerText = splitedSensorData[0].Trim();
            sensorValue.InnerText = splitedSensorData[2].Trim();

            string[] splitedDate = splitedSensorData[3].Split(' ');

            sensorDate.InnerText = splitedDate[0].Trim();
            sensorTime.InnerText = splitedDate[1].Trim();

            sensorCity.InnerText = splitedSensorData[4].Trim();

            Debug.WriteLine(message);

            SendXMLStructure(airMonitParam.OuterXml);
        }

        private void SendXMLStructure(string outerXml)
        {
            isValid = true;
            XmlDocument doc = new XmlDocument();
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
                //validationMessage = string.Format("ERROR: {0}", ex.ToString());
            }
            //return isValid;

            Debug.WriteLine(isValid + "");
        }

        private void MyValidateMethod(object sender, ValidationEventArgs e)
        {
            isValid = false;
            //throw new NotImplementedException();
        }
    }
}

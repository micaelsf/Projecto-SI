using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace AirMonit_Alarm
{
    class XMLHandler
    {
        private string xmlRulesPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Local_data\trigger-rules.xml");
        private string xmlParamSchemaPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Local_data\XMLParameterSchema.xsd");
        private string xmlAlarmSchemaPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Local_data\XMLAlarmsSchema.xsd");
        private string xmlRulesSchemaPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Local_data\trigger-rules.xsd");
        private bool isValid;
        private XmlDocument docParam;
        private XmlDocument docAlarm;
        private XmlDocument docRules;

        private XmlElement airMonitAlarm;
        private XmlElement airMonitParam;
        private XmlElement sensorId;
        private XmlElement sensorValue;
        private XmlElement sensorDate;
        private XmlElement sensorTime;
        private XmlElement sensorCity;
        private XmlElement description;
        private XmlElement alarmDate;
        private XmlElement alarmTime;

        public bool IsValidXmlRules { get; set; }
        public string ValidationMessage { get; set; }

        public XMLHandler()
        {
            docParam = new XmlDocument();
            InitXMLDocuments();
        }

        private void InitXMLDocuments()
        {
            docRules = new XmlDocument();
            docRules.Load(xmlRulesSchemaPath);

            if (!ValidateXML("rules"))
            {
                Debug.WriteLine(ValidationMessage);
                IsValidXmlRules = false;
            }

            IsValidXmlRules = true;

            // Create alarm document
            docAlarm = new XmlDocument();

            airMonitAlarm = docAlarm.CreateElement("airMonitAlarm");
            airMonitParam = docAlarm.CreateElement("AirMonitParam");

            // create parameter document
            sensorId = docAlarm.CreateElement("id");
            sensorValue = docAlarm.CreateElement("value");
            sensorDate = docAlarm.CreateElement("date");
            sensorTime = docAlarm.CreateElement("time");
            sensorCity = docAlarm.CreateElement("city");

            airMonitParam.SetAttribute("param", "");
            airMonitParam.AppendChild(sensorId);
            airMonitParam.AppendChild(sensorValue);
            airMonitParam.AppendChild(sensorDate);
            airMonitParam.AppendChild(sensorTime);
            airMonitParam.AppendChild(sensorCity);

            // append parameter structure to alarm document
            airMonitAlarm.AppendChild(airMonitParam);

            description = docAlarm.CreateElement("description");
            alarmDate = docAlarm.CreateElement("date");
            alarmTime = docAlarm.CreateElement("time");

            airMonitAlarm.AppendChild(description);
            airMonitAlarm.AppendChild(alarmDate);
            airMonitAlarm.AppendChild(alarmTime);

            docAlarm.AppendChild(airMonitAlarm);
        }

        public string ParseXMLData(string xmldata)
        {
            if (!ValidateXML("params"))
            {
                Debug.WriteLine(ValidationMessage);
                return null;
            }

            // parse the received xml data to a singleton class 

            docParam.LoadXml(xmldata);
            XmlElement temporaryRoot = (XmlElement)docParam.SelectSingleNode("/AirMonitParam");

            SensorData.Instance.Param = temporaryRoot.Attributes["param"].Value;
            SensorData.Instance.Id = temporaryRoot.SelectSingleNode("id").InnerText;
            SensorData.Instance.Value = temporaryRoot.SelectSingleNode("value").InnerText;
            SensorData.Instance.Date = temporaryRoot.SelectSingleNode("date").InnerText;
            SensorData.Instance.Time = temporaryRoot.SelectSingleNode("time").InnerText;
            SensorData.Instance.City = temporaryRoot.SelectSingleNode("city").InnerText;

            return SensorData.Instance.ToString();
        }

        public void ValidateParameters(string xmldata)
        {
            docParam.LoadXml(xmldata);
            airMonitParam = (XmlElement)docParam.SelectSingleNode("/AirMonitParam");
            string paramStr = airMonitParam.Attributes["param"].Value;

            // Get rules that apply to this specific param
            XmlNodeList parameterRules = docRules.SelectNodes("/conditions/parameter[@type='" + paramStr + "']/rule[@active='true']");

            foreach (XmlElement rule in parameterRules)
            {
                checkAlarmToParam(airMonitParam, rule);
            }
        }

        private void checkAlarmToParam(XmlElement parameter, XmlElement rule)
        {
            XmlNode ruleCondition = rule.SelectSingleNode("rule[@condition]");
            float ruleValue, ruleMinVal, ruleMaxVal, paramValue;

            // Get parameter value
            string parameterValueStr = parameter.SelectSingleNode("value").InnerText.Replace('.', ',');

            // Validate xml values
            if (!float.TryParse(ruleCondition.SelectSingleNode("value").InnerText.Replace('.', ','), out ruleValue) ||
                !float.TryParse(ruleCondition.SelectSingleNode("minValue").InnerText.Replace('.', ','), out ruleMinVal) ||
                !float.TryParse(ruleCondition.SelectSingleNode("maxValue").InnerText.Replace('.', ','), out ruleMaxVal) ||
                !float.TryParse(parameterValueStr, out paramValue))
            {
                Debug.WriteLine("Error parsing parameter and rule values");
                Debug.WriteLine("ruleValue: " + ruleCondition.SelectSingleNode("ruleValue").InnerText);
                Debug.WriteLine("ruleMinVal: " + ruleCondition.SelectSingleNode("ruleMinVal").InnerText);
                Debug.WriteLine("ruleMaxVal: " + ruleCondition.SelectSingleNode("ruleMaxVal").InnerText);
                Debug.WriteLine("paramValue: " + parameterValueStr);
                return;
            }

            // get condition name
            string condition = ruleCondition.Name;

            switch (condition)
            {
                case "greaterThan":
                    if (paramValue > ruleValue)
                    {
                        triggerAlarm(parameter, rule, condition);
                    }
                    break;

                case "lessThan":
                    if (paramValue < ruleValue)
                    {
                        triggerAlarm(parameter, rule, condition);
                    }
                    break;

                case "equal":
                    if (paramValue == ruleValue)
                    {
                        triggerAlarm(parameter, rule, condition);
                    }
                    break;

                case "between":
                    if (paramValue >= ruleMinVal && paramValue <= ruleMaxVal)
                    {
                        triggerAlarm(parameter, rule, condition);
                    }
                    break;
            }
        }

        private void triggerAlarm(XmlElement parameter, XmlNode rule, string condition)
        {
            try
            {
                // update alarm document created initialy
                airMonitParam.SetAttribute("param", parameter.Attributes["param"].Value);
                sensorId.InnerText = SensorData.Instance.Id;
                sensorValue.InnerText = SensorData.Instance.Value;
                sensorDate.InnerText = SensorData.Instance.Date;
                sensorTime.InnerText = SensorData.Instance.Time;
                sensorCity.InnerText = SensorData.Instance.City;
                description.InnerText = rule.SelectSingleNode("description").InnerText;
                alarmDate.InnerText = DateTime.Now.ToString("yyyy'-'MM'-'dd");
                alarmTime.InnerText = DateTime.Now.ToString("HH':'mm':'ss");
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine("Error on makeAlarm: " + ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine("Error on makeAlarm: " + ex.ToString());
            }
        }

        public string GetDocAlarm()
        {
            // check if alarm is valid
            if (!ValidateXML("alarms"))
            {
                Debug.WriteLine(ValidationMessage);
                return null;
            }

            return docAlarm.OuterXml;
        }

        public void saveXmlRules()
        {
            XmlDocument xml = new XmlDocument();

            if (!ValidateXML("rules"))
            {
                MessageBox.Show("trigger-rules.xml file is not valid!\n" + ValidationMessage);
            }
            else
            {
                xml.LoadXml(docRules.OuterXml);
                xml.Save(xmlRulesPath);
            }

        }

        public bool ValidateXML(string type)
        {
            if (type == "rules")
            {
                return ValidateXMLStructure(docRules.OuterXml, xmlRulesSchemaPath);
            }
            else if (type == "alarms")
            {
                return ValidateXMLStructure(docAlarm.OuterXml, xmlAlarmSchemaPath);
            }
            else if (type == "params")
            {
                return ValidateXMLStructure(docParam.OuterXml, xmlParamSchemaPath);
            }

            return false;
        }

        private bool ValidateXMLStructure(string outerXml, string xmlParamSchemaPath)
        {
            isValid = true;
            XmlDocument doc = new XmlDocument();
            ValidationMessage = "XML structure is valid";

            try
            {
                doc.LoadXml(outerXml);
                ValidationEventHandler eventHandler = new ValidationEventHandler(MyValidateMethod);
                doc.Schemas.Add(null, xmlParamSchemaPath);
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

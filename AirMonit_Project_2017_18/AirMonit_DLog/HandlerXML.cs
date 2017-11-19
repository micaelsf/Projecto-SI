using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ProjectXML
{
    class HandlerXML
    {
        private bool isValid = true;
        private string validationMessage;
        private string xmlSchemaPath;
        public string City { get; set; }
        public int O3 { get; set; }
        public int No2 { get; set; }
        public int CO { get; set; }

        public string ValidationMessage
        {
            get { return validationMessage; }
        }

        public HandlerXML(String xmlSchemaPath)
        {
            this.xmlSchemaPath = xmlSchemaPath;
        }

        public void LoadAlarms(string outerXml)
        {
            XElement xmlroot = XElement.Parse(outerXml);
            City = ((XElement)(xmlroot.FirstNode)).Value;
            No2 = (int)((XElement)(xmlroot.PreviousNode));
            O3 = (int)((XElement)(xmlroot.PreviousNode));
            CO = (int)((XElement)(xmlroot.PreviousNode));
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

using AirMonit_DU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunicationChannelInfrastructure
{
    public class CCI
    {
        //private string xmlPath = @"air_data.xml";
        //private XmlDocument doc;
        //private XmlElement root;
        private DataUpload du;
        private DataSensor data;
        private Boolean initializedSensors;

        public CCI()
        {
            du = new DataUpload();
        }

        public void InitializeSensors()
        {
            initializedSensors = du.InitializeSensor();

            while (initializedSensors)
            {
                data = CallDataSensors(du);
                if (data != null)
                {
                    Console.WriteLine(data.toString());
                    Console.WriteLine("\n");

                }
            }
        }

        private DataSensor CallDataSensors(DataUpload du)
        {
            int iteration = 0;
            Thread.Sleep(500);

            iteration = du.Iteration;

            if (iteration % 3 == 0)
            {
                return du.DataLocation;
            }

            return null;
        }


/*
        private void HandleData(DataSensor value)
        {
            root.AppendChild(CreateData(value));
            doc.Save(xmlPath);
        }

        private XmlNode CreateData(DataSensor value)
        {
            XmlElement data = doc.CreateElement("air_data");

            XmlElement city = doc.CreateElement("city");
            XmlElement co = doc.CreateElement("co");
            XmlElement no2 = doc.CreateElement("no2");
            XmlElement o3 = doc.CreateElement("o3");
            XmlElement date = doc.CreateElement("date");

            data.AppendChild(city);
            city.InnerText = value.City;
            data.AppendChild(co);
            co.InnerText = value.CO_data.ToString();
            data.AppendChild(no2);
            no2.InnerText = value.NO2_data.ToString();
            data.AppendChild(o3);
            o3.InnerText = value.O3_data.ToString();
            data.AppendChild(date);
            date.InnerText = value.Date;

            return data;
        }

        private void CreateBaseXMLStructure()
        {
            doc = new XmlDocument();
            XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(decl);

            root = doc.CreateElement("air_quality_data");
            doc.AppendChild(root);

            doc.Save(xmlPath);
        }
        */
    }
}

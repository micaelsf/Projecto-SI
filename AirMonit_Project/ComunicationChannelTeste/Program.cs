using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirMonit_DU;
using System.Threading;
using System.Xml;

namespace ComunicationChannelTeste
{
    class Program
    {
        //private static string xmlPath = AppDomain.CurrentDomain.BaseDirectory + @"data/air_data.xml";
        private static string xmlPath =  @"air_data.xml";
        private static XmlDocument doc;
        private static XmlElement root;

        static void Main(string[] args)
        {
            Console.WriteLine("..::Communication channel Initialized::..");
            Console.WriteLine("\n");

            SensorData sensorData = new SensorData();
            Data[] dataArray = new Data[4];
            Boolean initializedSensors;

            bool keyPress;

            createBaseXMLStructure();
            initializedSensors = sensorData.initializeSensor();

            while (initializedSensors)
            {
                dataArray = callDataSensors(sensorData);
                if (dataArray != null)
                {
                    foreach (var value in dataArray)
                    {
                        Console.WriteLine(value.toString());
                        handleData(value);
                    }
                    Console.WriteLine("\n");

                }
                else
                {
                    //just to check
                    //Console.WriteLine("No data available!");
                }
            }
        }

        private static void handleData(Data value)
        {
            root.AppendChild(createData(value));
            doc.Save(xmlPath);
        }

        private static XmlNode createData(Data value)
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

        private static void createBaseXMLStructure()
        {
            doc = new XmlDocument();
            XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(decl);

            root = doc.CreateElement("air_quality_data");
            doc.AppendChild(root);

            doc.Save(xmlPath);
        }

        private static Data[] callDataSensors(SensorData sensorData)
        {
            int iteration = 0;
            Thread.Sleep(500);
            iteration = sensorData.Iteration;

            if (iteration == 12)
            {
                return sensorData.GetData;
            }
            return null;
        }
    }
}

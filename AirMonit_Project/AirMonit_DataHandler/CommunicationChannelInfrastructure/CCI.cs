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
        private DataUpload du;
        private int iteration_;

        private DataAlarm dataAlarm_;
        private DataSensorClean dataSensorClean_;
        private DataSensor dataSensor_;

        public Data Data
        {
            get { return Data; }
        }

        public DataSensorClean DataSensorClean
        {
            get { return dataSensorClean_; }
        }

        // construct
        public CCI()
        {
            du = new DataUpload();
            dataSensorClean_ = new DataSensorClean(0, 0, 0, "", "");
        }

        public Boolean InitializeSensors(int time)
        {
            return du.InitializeSensor(time);
        }

        public Boolean StopSensors()
        {
            return du.StopSensor();
        }

        public DataSensorClean TimeDataSensors(int time)
        {
            Thread.Sleep(time);

            iteration_ = du.Iteration;

            if (iteration_ % 3 == 0)
            {
                dataSensor_ = du.DataLocation;

                dataSensorClean_.City = dataSensor_.City;
                dataSensorClean_.Date = dataSensor_.Date;
                dataSensorClean_.CO_data = dataSensor_.CO_data;
                dataSensorClean_.NO2_data = dataSensor_.NO2_data;
                dataSensorClean_.O3_data = dataSensor_.O3_data;

                return dataSensorClean_;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirSensorNodeDll;

namespace AirMonit_DU
{
    public class SensorData
    {
        AirSensorNodeDll.AirSensorNodeDll dll;
        private Data dataLeiria_;
        private Data dataCoimbra_;
        private Data dataLisboa_;
        private Data dataPorto_;
        private int currentIteration_;
        private Boolean initialized = false;

        public Data[] GetData
        {
            get {
                Data[] dataArray = new Data[4];
                dataArray[0] = dataLeiria_;
                dataArray[1] = dataCoimbra_;
                dataArray[2] = dataLisboa_;
                dataArray[3] = dataPorto_;
                return dataArray;
            }
        }

        public int Iteration
        {
            get { return currentIteration_; }
        }

        public SensorData()
        {
            dataLeiria_ = new Data(0, 0, 0, "Leiria", "");
            dataCoimbra_ = new Data(0, 0, 0, "Coimbra", "");
            dataLisboa_ = new Data(0, 0, 0, "Lisboa", "");
            dataPorto_ = new Data(0, 0, 0, "Porto", "");
        }

        public Boolean initializeSensor()
        {
            if (!initialized)
            {
                initialized = true;
                dll = new AirSensorNodeDll.AirSensorNodeDll();
                dll.Initialize(transformData, 500);
                return true;
            }
            return false;
        }

        public Boolean stopSensor()
        {
            if (initialized)
            {
                initialized = false;
                dll.Stop();
                return true;
            }
            return false;
        }

        private void transformData(string message)
        {
            string[] splited_val = message.Split(';');
            if (splited_val[4] == "Leiria")
            {
                if (splited_val[1] == "CO")
                {
                    dataLeiria_.CO_data = Double.Parse(splited_val[2]);
                }
                if (splited_val[1] == "NO2")
                {
                    dataLeiria_.NO2_data = Double.Parse(splited_val[2]);
                }
                if (splited_val[1] == "O3")
                {
                    dataLeiria_.O3_data = Double.Parse(splited_val[2]);
                }
                dataLeiria_.Date = splited_val[3];
            }

            if (splited_val[4] == "Coimbra")
            {
                if (splited_val[1] == "CO")
                {
                    dataCoimbra_.CO_data = Double.Parse(splited_val[2]);
                }
                if (splited_val[1] == "NO2")
                {
                    dataCoimbra_.NO2_data = Double.Parse(splited_val[2]);
                }
                if (splited_val[1] == "O3")
                {
                    dataCoimbra_.O3_data = Double.Parse(splited_val[2]);
                }
                dataCoimbra_.Date = splited_val[3];
            }

            if (splited_val[4] == "Lisboa")
            {
                if (splited_val[1] == "CO")
                {
                    dataLisboa_.CO_data = Double.Parse(splited_val[2]);
                }
                if (splited_val[1] == "NO2")
                {
                    dataLisboa_.NO2_data = Double.Parse(splited_val[2]);
                }
                if (splited_val[1] == "O3")
                {
                    dataLisboa_.O3_data = Double.Parse(splited_val[2]);
                }
                dataLisboa_.Date = splited_val[3];
            }

            if (splited_val[4] == "Porto")
            {
                if (splited_val[1] == "CO")
                {
                    dataPorto_.CO_data = Double.Parse(splited_val[2]);
                }
                if (splited_val[1] == "NO2")
                {
                    dataPorto_.NO2_data = Double.Parse(splited_val[2]);
                }
                if (splited_val[1] == "O3")
                {
                    dataPorto_.O3_data = Double.Parse(splited_val[2]);
                }
                dataPorto_.Date = splited_val[3];
            }

            currentIteration_ = int.Parse(splited_val[0]);

        }
    }
}

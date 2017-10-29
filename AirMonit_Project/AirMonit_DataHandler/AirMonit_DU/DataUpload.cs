using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirMonit_DU
{
    public class DataUpload
    {
        AirSensorNodeDll.AirSensorNodeDll dll;
        private DataSensor dataLocation_;
        private int currentIteration_;
        private Boolean initialized = false;
        
        public DataSensor DataLocation
        {
            get
            {
                return dataLocation_;
            }
        }

        public int Iteration
        {
            get { return currentIteration_; }
        }

        public DataUpload()
        {
            dataLocation_ = new DataSensor(0, 0, 0, "", "");
        }

        public Boolean InitializeSensor(int time)
        {
            if (!initialized)
            {
                initialized = true;
                dll = new AirSensorNodeDll.AirSensorNodeDll();
                dll.Initialize(TransformData, time);
                return true;
            }
            return false;
        }

        public Boolean StopSensor()
        {
            if (initialized)
            {
                initialized = false;
                dll.Stop();
                return true;
            }
            return false;
        }

        private void TransformData(string message)
        {
            string[] splited_val = message.Split(';');

            if (splited_val[1] == "CO")
            {
                dataLocation_.CO_data = Double.Parse(splited_val[2]);
            }
            if (splited_val[1] == "NO2")
            {
                dataLocation_.NO2_data = Double.Parse(splited_val[2]);
            }
            if (splited_val[1] == "O3")
            {
                dataLocation_.O3_data = Double.Parse(splited_val[2]);
            }
                
            dataLocation_.City = splited_val[4];

            dataLocation_.Date = splited_val[3];

            currentIteration_ = int.Parse(splited_val[0]);

        }
    }
}

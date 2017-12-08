using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirMonit_DLog
{
    public class AlarmData
    {
        public string SensorParam { get; set; }
        public string SensorId { get; set; }
        public string SensorValue { get; set; }
        public string SensorDate { get; set; }
        public string SensorTime { get; set; }
        public string SensorCity { get; set; }

        public string AlarmDate { get; set; }
        public string AlarmTime { get; set; }
        public string AlarmDescription { get; set; }

        private static AlarmData instance;

        // this singleton class will handle every line received from broker
        public static AlarmData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AlarmData();
                }

                return instance;
            }
        }

        override
        public string ToString()
        {
            return
                "Sensor Param: " + SensorParam +
                ", Description: " + AlarmDescription +
                ", Date Time: " + AlarmDate + " at " + AlarmTime;
        }
    }
}

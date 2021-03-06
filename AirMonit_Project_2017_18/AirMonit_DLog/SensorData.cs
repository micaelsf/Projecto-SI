﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirMonit_DLog
{
    public class SensorData
    {
        public string Param { get; set; }
        public int Id { get; set; }
        public int Value { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string City { get; set; }
        public string SensorDataUID { get; set; }

        private static SensorData instance;

        // this singleton class will handle every line received from broker
        public static SensorData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SensorData();
                }

                return instance;
            }
        }

        override
        public string ToString()
        {
            return
                "[ " + Param + " ] " +
                ", Sensor Id: " + Id + 
                ", Value: " + Value + 
                ", Date Time: " + Date + " at " + Time + 
                ", City: " + City ;
        }
    }
}

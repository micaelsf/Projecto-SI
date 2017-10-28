using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirMonit_DU
{
    public class DataSensor
    {
        public double NO2_data { get; set; }
        public double CO_data { get; set; }
        public double O3_data { get; set; }
        public string City { get; set; }
        public string Date { get; set; }

        public DataSensor(double nO2_data, double cO_data, double o3_data, string city_, string date_)
        {
            NO2_data = nO2_data;
            CO_data = cO_data;
            O3_data = o3_data;
            City = city_;
            Date = date_;
        }

        public string toString()
        {
            return "NO2: " + NO2_data.ToString() +
                    " | CO: " + CO_data.ToString() +
                    " | O3: " + O3_data.ToString() +
                    " | Date: " + Date +
                    " | City: " + City;
        }
    }
}

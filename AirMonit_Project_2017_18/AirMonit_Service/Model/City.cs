using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirMonit_Service.Model
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public DateTime Date_Time { get; set; }
        public int NO2 { get; set; }
        public int CO { get; set; }
        public int O3 { get; set; }
    }
}
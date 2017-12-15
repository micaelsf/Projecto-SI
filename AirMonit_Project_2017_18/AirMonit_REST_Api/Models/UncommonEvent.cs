using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirMonit_REST_Api.Models
{
    public class UncommonEvent
    {
        public string CityName { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public float Temperature { get; set; }
        public DateTime DateTime { get; set; }

        public UncommonEvent(string cityName, string type, string description, string username, float temperature, DateTime datetime)
        {
            CityName = cityName;
            Type = type;
            Description = description;
            Username = username;
            Temperature = temperature;
            DateTime = datetime;
        }
    }
}
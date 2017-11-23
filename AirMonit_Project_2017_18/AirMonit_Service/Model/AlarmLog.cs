using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirMonit_Service.Model
{
    public class AlarmLog
    {
        public int Id { get; set; }
        public int IdCity { get; set; }
        public string AirParameter { get; set; }
        public string UncommonEvents { get; set; }
        public string severity { get; set; }
        public string description { get; set; }
        public DateTime Date_Time { get; set; }
        public int Value { get; set; }
    }
}
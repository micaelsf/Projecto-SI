using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirMonit_DLog.Models
{
    class Alarm
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Alarm_Name { get; set; }
        public string Incident { get; set; }
        public DateTime Date_Time { get; set; }
        public string UncommonEvent { get; set; }
        public string Value { get; set; } 
    }
}

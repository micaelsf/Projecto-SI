using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirMonit_DLog.Models
{
    class City
    {
        public int Id { get; set; }
        public string City_Name { get; set; }
        public DateTime Date_Time { get; set; }
        public string NO2 { get; set; }
        public string CO { get; set; }
        public string O3 { get; set; }
    }
}

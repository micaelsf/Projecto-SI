using System;

namespace AirMonit_Admin
{
    class AlarmLog_
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
        public string ParamType { get; set; }
        public int ParamValue { get; set; }

        public AlarmLog_(int id, string description, string datetime, string paramType, int paramValue)
        {
            Id = id;
            Description = description;
            DateTime = datetime;
            ParamType = paramType;
            ParamValue = paramValue;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationChannelInfrastructure
{
    public class DataAlarm
    {
        private string parameterType_;
        private string qualityCode_;
        private string qualityLevel_;
        private string city_;
        private string message_;
        private string dateTime_;

        public string ParameterType
        {
            get { return parameterType_; }
        }

        public string QualityCode
        {
            get { return qualityCode_; }
        }

        public string QualityLevel
        {
            get { return qualityLevel_; }
        }

        public string City
        {
            get { return city_; }
        }

        public string Message
        {
            get { return message_; }
        }

        public string Date
        {
            get { return dateTime_; }
        }
    }
}

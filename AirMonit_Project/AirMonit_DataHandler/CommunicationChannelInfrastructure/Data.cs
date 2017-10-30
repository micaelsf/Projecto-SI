using AirMonit_DU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationChannelInfrastructure
{
    public class Data
    {
        private DataSensorClean datasensor_;
        private List<DataAlarm> dataalarm_;

        public Data(DataSensorClean datasensor)
        {
            this.datasensor_ = datasensor;

            dataalarm_ = new List<DataAlarm>();
        }

        public List<DataAlarm> getDataAlarm()
        {
            return dataalarm_;
        }

        public Boolean addDataAlarm(DataAlarm dataAlarm)
        {
            if (dataAlarm != null)
            {
                dataalarm_.Add(dataAlarm);
                return true;
            }

            return false;
        }

        public Boolean removeDataAlarm(DataAlarm dataAlarm)
        {
            if (dataAlarm != null)
            {
                dataalarm_.Remove(dataAlarm);
                return true;
            }

            return false;
        }
    }
}

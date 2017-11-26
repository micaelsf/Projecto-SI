using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AirMonit_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccessingData" in both code and config file together.
    [ServiceContract]
    public interface IAccessingData
    {

        [OperationContract]
        string getInfoMinEachHour(string sensor, string dateTime);
        [OperationContract]
        string getInfoMaxEachHour(string sensor, string dateTime);
        [OperationContract]
        string getInfoAvgEachHour(string sensor, string dateTime);

        [OperationContract]
        string getInfoMinEachDay(string sensor, string dateTime);
        [OperationContract]
        string getInfoMaxEachDay(string sensor, string dateTime);
        [OperationContract]
        string getInfoAvgEachDay(string sensor, string dateTime);

        [OperationContract]
        string getDailyAlarmsByCity(string cityParam, string dateTime);

    }

        /*
        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }*/
    
}

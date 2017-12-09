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
    public interface IAirMonit_AccessingData
    {
        [OperationContract]
        List<InfoBetweenDate> getInfoMinEachHour(string Parameter, string city, DateTime dateTime);
        [OperationContract]
        List<InfoBetweenDate> getInfoMaxEachHour(string Parameter, string city, DateTime dateTime);
        [OperationContract]
        List<InfoBetweenDate> getInfoAvgEachHour(string Parameter, string city, DateTime dateTime);

        [OperationContract]
        List<InfoBetweenDate> getInfoMinBetweenDates(string Parameter, string city, DateTime startDate, DateTime endDate);
        [OperationContract]
        List<InfoBetweenDate> getInfoMaxBetweenDates(string Parameter, string city, DateTime startDate, DateTime endDate);
        [OperationContract]
        List<InfoBetweenDate> getInfoAvgBetweenDates(string Parameter, string city, DateTime startDate, DateTime endDate);

        [OperationContract]
        List<AlarmLog> getDailyAlarmsByCity(string city, DateTime dateTime);

    }

    [ServiceContract]
    public interface IAirMonit_StoreData
    {
        [OperationContract]
        int storeUncommonEvent(UncommonEvents userInfo);
    }

    [DataContract]
    public class SensorData //DONE 
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Param { get; set; }
        [DataMember]
        public int Value { get; set; }
        [DataMember]
        public int CityId { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public int SensorId { get; set; }
    }

    [DataContract]
    public class AlarmLog  //DONE
    {
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public string Parameter { get; set; }
        [DataMember]
        public int Value { get; set; }
    }

    [DataContract]
    public class InfoBetweenDate
    {
        [DataMember]
        public int Value { get; set; }
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public string City { get; set; }
    }

    [DataContract]
    public class UncommonEvents //DONE
    {
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public float Temperature { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }

    }
}








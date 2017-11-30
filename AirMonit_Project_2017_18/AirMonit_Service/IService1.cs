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
        City getInfoMinEachHour(string city, string dateTime);
        [OperationContract]
        City getInfoMaxEachHour(string city, string dateTime);
        [OperationContract]
        City getInfoAvgEachHour(string city, string dateTime);

        [OperationContract]
        City getInfoMinEachDay(string city, string dateTime);
        [OperationContract]
        City getInfoMaxEachDay(string city, string dateTime);
        [OperationContract]
        City getInfoAvgEachDay(string city, string dateTime);

        [OperationContract]
        List<AlarmLog> getDailyAlarmsByCity(string city, string dateTime);
       
    }

    public interface IStoreData
    {
        [OperationContract]
        void sendUserInfo(UserInput userInfo);
    }


    [DataContract]
    public class City
    {
        
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public DateTime Date_Time { get; set; }
        [DataMember]
        public int NO2 { get; set; }
        [DataMember]
        public int CO { get; set; }
        [DataMember]
        public int O3 { get; set; }
    }

    [DataContract]
    public class AlarmLog
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string IdCity { get; set; }
        [DataMember]
        public string AirParameter { get; set; }
        [DataMember]
        public string UncommonEvents { get; set; }
        [DataMember]
        public string Severity { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime Date_Time { get; set; }
        [DataMember]
        public int Value { get; set; }
    }

    [DataContract]
    public class UserInput
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string UncommonEvent { get; set; }
        [DataMember]
        public int Temperature { get; set; }
        [DataMember]
        public string City { get; set; }
    }
}






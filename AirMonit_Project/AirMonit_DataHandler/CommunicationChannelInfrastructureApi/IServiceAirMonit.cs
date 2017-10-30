using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CommunicationChannelInfrastructureApi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceAirMonit
    {

        [OperationContract]
        string GetData(int value);

        #region Alarm // Contract
        [OperationContract]
        void AddAlarm(Alarm newAlarm);

        [OperationContract]
        List<Alarm> GetAlarms();

        [OperationContract]
        List<Alarm> GetAlarmCategory(AlarmCategory category);

        [OperationContract]
        Alarm GetAlarmByTitle(string title);

        [OperationContract]
        bool DeleteAlarm(string title);
        #endregion

        #region City //contract
        [OperationContract]
        void AddCity(City newCity);

        [OperationContract]
        List<City> GetCities();

        [OperationContract]
        Alarm GetCityByTitle(string title);
        #endregion
    }

    #region Class Alarm
    [DataContract]
    public class Alarm
    {
        string city = "Leiria";
        DateTime date_time();
        AlarmCategory alarmcategory = new AlarmCategory();

        [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        [DataMember]
        public DateTime Date_Time
        {
            get { return date_time; }
            set { date_time = value; }
        }

        [DataMember]
        public string Incident
        {
            get { return incident; }
            set { incident = value; }
        }

        [DataMember]
        public AlarmCategory alarmCategory
        {
            get { return alarmCategory; }
            set { alarmCategory = value; }
        }

        [DataMember]
        public string UncommonEvent
        {
            get { return uncommonEvent; }
            set { uncommonEvent = value; }
        }

        [DataMember]
        public string Value
        {
            get { return incident; }
            set { incident = value; }
        }
    }
    #endregion

    #region Class City
    [DataContract]
    public class City
    {

        [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        [DataMember]
        public DateTime Date_Time
        {
            get { return date_time; }
            set { date_time = value; }
        }

        [DataMember]
        public int NO2
        {
            get { return no2; }
            set { no2 = value; }
        }

        [DataMember]
        public int Co
        {
            get { return co; }
            set { co = value; }
        }

        [DataMember]
        public string O3
        {
            get { return o3; }
            set { o3 = value; }
        }
    }
    #endregion

    public class AlarmCategory
    {
        enum alarmCategory { High, Severe, Medium, Moderate, Low};
    }


}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace AirMonit_Service
{

    public static class databaseTableConstants
    {
        public const string tableAlarms = "dbo.AlarmLogs";
        public const string tableCity = "dbo.Citys";
    }

    

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AirMonit_Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AirMonit_Service.svc or AirMonit_Service.svc.cs at the Solution Explorer and start debugging.
    public class AirMonit_Service : IAccessingData, IStoreData
    {


        String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionDBProducts"].ConnectionString;

        public List<AlarmLog> getDailyAlarmsByCity(string cityParam, string dateDay)
        {
            List<AlarmLog> alarmsOnData = new List<AlarmLog>();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                int idCity = fetchCityIdFromName(connection, cityParam);
                SqlCommand command = new SqlCommand("SELECT  * FROM @tableName WHERE date_time = @date AND IdCity= @idCity  ORDER BY id", connection);
                command.Parameters.AddWithValue("tableName", databaseTableConstants.tableAlarms);
                command.Parameters.AddWithValue("date", dateDay);
                command.Parameters.AddWithValue("idCity", idCity);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AlarmLog alarm = new AlarmLog
                    {
                        Id = (int)reader["Id"],
                        IdCity = (string)reader["Name"],
                        AirParameter = (string)reader["AirParameter"],
                        UncommonEvents = (string)reader["UncommonEvents"],
                        Severity = reader["Severity"] == DBNull.Value ? "" :  (string)reader["Severity"],
                        Description = (string)reader["Description"],
                        Date_Time = (DateTime)reader["Date_Time"],
                        Value = (int)reader["Value"]
                    };
                    alarmsOnData.Add(alarm);
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine((e.ToString()));
            }
            return alarmsOnData;
        }




        public City getInfoAvgEachDay(string cityParam, string dateDay)
        {
            City avgInfo = null;

             SqlConnection connection = new SqlConnection(connectionString);
             connection.Open();

             try { 
            SqlCommand command = new SqlCommand("SELECT  AVG(NO2), AVG(CO), AVG(O3) FROM " + databaseTableConstants.tableAlarms + " WHERE date_time = @date", connection);
             command.Parameters.AddWithValue("@date", dateDay);

             SqlDataReader reader = command.ExecuteReader();

             while (reader.Read())
             {
                 avgInfo = new City
                 {
                     Id = (int)reader["Id"],
                     CityName = (string)reader["City_Name"],
                     Date_Time = (DateTime)reader["Date_Time"],
                     NO2 = (int)reader["NO2"],
                     CO = (int)reader["CO"],
                     O3 = (int)reader["O3"]
                 };
             };
                reader.Close();
            } catch(Exception e)
            {
                Console.WriteLine("Error while fetching avg for each day")
            }
             
             connection.Close();

             return avgInfo;
        }

        public string getInfoAvgEachHour(string cityParam, string dateDay)
        {
            throw new NotImplementedException();
        }

        public City GetInfoMaxEachDay(string cityParam, string dateDay)
        {
            City maxInfo = null;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                SqlCommand command = new SqlCommand("SELECT  MAX(NO2), MAX(CO), MAX(O3) FROM " + databaseTableConstants.tableAlarms + " WHERE date_time = @date", connection);
                command.Parameters.AddWithValue("@date", dateDay);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    maxInfo = new City
                    {
                        Id = (int)reader["Id"],
                        CityName = (string)reader["City_Name"],
                        Date_Time = (DateTime)reader["Date_Time"],
                        NO2 = (int)reader["NO2"],
                        CO = (int)reader["CO"],
                        O3 = (int)reader["O3"]
                    };
                };
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while fetching avg for each day")
            }

            connection.Close();

            return maxInfo;
        }

        public string getInfoMaxEachHour(string cityParam, string dateDay)
        {
            throw new NotImplementedException();
        }

        public string getInfoMinEachDay(string cityParam, string dateDay)
        {
            throw new NotImplementedException();
        }

        public string getInfoMinEachHour(string cityParam, string dateDay)
        {
            throw new NotImplementedException();
        }

        public void sendUserInfo(UserInput userInfo)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();


            // SqlCommand insertCommand = new SqlCommand("INSERT INTO TableName (FirstColumn, SecondColumn, ThirdColumn, ForthColumn) VALUES (@0, @1, @2, @3)", conn);

            try
            {
                int cityIdFromDB = fetchCityIdFromName(connection, userInfo.City);
            SqlCommand command = new SqlCommand("INSERT INTO @tableName (IdCity, AirParameter, UncommonEvents, Severity, Description, Date_Time, Value)" +
                "VALUES (@city, @AirParameter, @UncommonEvent, @Severity, @Description, @Date_Time, @Value)", connection);
            command.Parameters.AddWithValue("tableName", databaseTableConstants.tableAlarms);
            command.Parameters.AddWithValue("city", value: cityIdFromDB); //ALTERAR A FORMA DE OBTER O ID DA CIDADE , SWITCH CASE ? XML FILE? DICIONARIO DE DADOS ?
            command.Parameters.AddWithValue("AirParameter", "Temperature");
            command.Parameters.AddWithValue("UncommonEvent", "User Defined");
            command.Parameters.AddWithValue("Severity", DBNull.Value);
            command.Parameters.AddWithValue("Description", userInfo.UncommonEvent);
            command.Parameters.AddWithValue("Date_Time", DateTime.Now);
            command.Parameters.AddWithValue("Value", userInfo.Temperature);

            Console.WriteLine("Commands executed! Total rows affected are " + command.ExecuteNonQuery());

            } catch(Exception e)
                {
                connection.Close();

                Console.WriteLine("Erro ao escrever na BD: " + e.ToString());
                }
            connection.Close();
        }

        City IAccessingData.getInfoAvgEachHour(string city, string dateTime)
        {
            throw new NotImplementedException();
        }

        City IAccessingData.getInfoMaxEachDay(string city, string dateTime)
        {
            throw new NotImplementedException();
        }

        City IAccessingData.getInfoMaxEachHour(string city, string dateTime)
        {
            throw new NotImplementedException();
        }

        City IAccessingData.getInfoMinEachDay(string city, string dateTime)
        {
            throw new NotImplementedException();
        }

        City IAccessingData.getInfoMinEachHour(string city, string dateTime)
        {
            throw new NotImplementedException();
        }

        private int fetchCityIdFromName(SqlConnection connection, string cityName)
        {

            int cityIdFromDB = -1;
            try
            {
                SqlCommand commandForCityId = new SqlCommand("SELECT id FROM @tableName WHERE CityName = @cityName");
                commandForCityId.Parameters.AddWithValue("tableName", databaseTableConstants.tableCity);
                commandForCityId.Parameters.AddWithValue("cityName", cityName);
                SqlDataReader readerForID = commandForCityId.ExecuteReader();
                while (readerForID.Read())
                {
                    cityIdFromDB = (int)readerForID["Id"];
                    Console.WriteLine("ID of city: " + cityIdFromDB.ToString());
                }
                readerForID.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                Console.WriteLine("Error retrieving city Id from name: " + e.ToString());
            }
            return cityIdFromDB;
        }
    }
}

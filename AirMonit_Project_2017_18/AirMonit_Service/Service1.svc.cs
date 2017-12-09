using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace AirMonit_Service
{

    public static class DatabaseTableConstant  //Constantes para os nomes das tabelas, para quando inserimos parametros nas queries (FROM ...)
    {
        public const string tableAlarms = "AlarmLogs";
        public const string tableCity = "Cities";
        public const string tableSensorData = "SensorData";
        public const string tableUncommonEvents = "UncommonEvents";
    }

    public class AirMonit_Service : IAccessingData, IStoreData
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["appHarborConnect"].ConnectionString;
        private SqlConnection connection;

        public AirMonit_Service()
        {
            connection = new SqlConnection(connectionString);
        }

        public int storeUncommonEvent(UncommonEvents userInfo)
        {
            int linesReturned = -1;
            string query = string.Format(@"INSERT INTO {0} (CityId, Type, Description, UserName, Temperature, DateTime) 
                            VALUES (@cityId, @type, @description, @username, @temperature, @dateTime)", DatabaseTableConstant.tableUncommonEvents);

            int cityId = fetchCityIdFromName(userInfo.CityName);

            if (cityId == -1)
            {
                return -1;
            }

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("cityId", cityId);
                command.Parameters.AddWithValue("type", userInfo.Type);
                command.Parameters.AddWithValue("description", userInfo.Description);
                command.Parameters.AddWithValue("username", userInfo.Username);
                command.Parameters.AddWithValue("dateTime", DateTime.Now);
                command.Parameters.AddWithValue("temperature", userInfo.Temperature);

                try
                {
                    connection.Open();
                    linesReturned = command.ExecuteNonQuery();
                    Debug.WriteLine("Commands executed! Total rows affected are " + linesReturned);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Erro ao escrever na BD: " + e.ToString());
                }
            }

            return linesReturned;
        }

        public List<AlarmLog> getDailyAlarmsByCity(string cityName, DateTime dateTime)
        {
            string query = string.Format(@"SELECT al.Description, al.DateTime, s.Param, s.Value 
                        FROM {0} al JOIN {1} s ON al.SensorDataUID = s.SensorDataUID 
                        WHERE LEFT(@fulldate, 10) = @date AND CityId = @cityId ORDER BY 2 DESC", DatabaseTableConstant.tableAlarms, DatabaseTableConstant.tableSensorData);
            List<AlarmLog> dataAlarms = new List<AlarmLog>();
            
            string[] splitedDate = (dateTime + "").Split(' ');
            string date = splitedDate[0];
            Debug.WriteLine(date);

            int cityId = fetchCityIdFromName(cityName);

            if (cityId == -1)
            {
                return null;
            }

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("fulldate", dateTime.ToString("yyyy-MM-dd HH:mm::ss"));
                command.Parameters.AddWithValue("date", date);
                command.Parameters.AddWithValue("cityId", cityId);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        AlarmLog alarm = new AlarmLog
                        {
                            Description = (string) reader["Description"],
                            DateTime = (DateTime) reader["DateTime"],
                            Parameter = (string) reader["Param"],
                            Value = (int) reader["Value"]
                        };

                        dataAlarms.Add(alarm);
                    }

                    reader.Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine((e.ToString()));
                }

                return dataAlarms;
            }
        }

        public List<InfoBetweenDate> getInfoAvgBetweenDates(string parameter, string cityName, DateTime startDate, DateTime endDate)
        {
            string query = string.Format(@"
                    SELECT AVG(Value) as Average, CONVERT(varchar, DateTime, 23) as Day
                    FROM {0}
                    WHERE Param = @userParam AND CityId = @cityId 
                    AND DateTime >= @startDate AND DateTime <= @endDate
                    GROUP BY CONVERT(varchar, DateTime, 23)
                    ORDER BY 2 DESC", DatabaseTableConstant.tableSensorData);

            List<InfoBetweenDate> listValues = new List<InfoBetweenDate>();

            int cityId = fetchCityIdFromName(cityName);

            if (cityId == -1)
            {
                return null;
            }

            if (startDate > endDate)
            {
                return null;
            }

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("userParam", parameter.ToUpper());
                command.Parameters.AddWithValue("cityId", cityId);
                command.Parameters.AddWithValue("startDate", startDate.ToString("yyyy-MM-dd") + "");
                command.Parameters.AddWithValue("endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss") + "");

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        InfoBetweenDate infoBetweenDate = new InfoBetweenDate
                        {
                            Value = int.Parse(reader["Average"] + ""),
                            Date = reader["Day"] + "",
                        };

                        listValues.Add(infoBetweenDate);
                    };

                    reader.Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error while fetching avg for each day: " + e.Message);
                }
            }
            
            return listValues;
        }

        public List<InfoBetweenDate> getInfoMaxBetweenDates(string parameter, string cityName, DateTime startDate, DateTime endDate)
        {
            string query = string.Format(@"
                    SELECT MAX(Value) as Maximum, CONVERT(varchar, DateTime, 23) as Day
                    FROM {0}
                    WHERE Param = @userParam AND CityId = @cityId 
                    AND DateTime >= @startDate AND DateTime <= @endDate
                    GROUP BY CONVERT(varchar, DateTime, 23)
                    ORDER BY 2 DESC", DatabaseTableConstant.tableSensorData);

            List<InfoBetweenDate> listValues = new List<InfoBetweenDate>();

            int cityId = fetchCityIdFromName(cityName);

            if (cityId == -1)
            {
                return null;
            }

            if (startDate > endDate)
            {
                return null;
            }

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("userParam", parameter.ToUpper());
                command.Parameters.AddWithValue("cityId", cityId);
                command.Parameters.AddWithValue("startDate", startDate.ToString("yyyy-MM-dd") + "");
                command.Parameters.AddWithValue("endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss") + "");

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        InfoBetweenDate infoBetweenDate = new InfoBetweenDate
                        {
                            Value = int.Parse(reader["Maximum"] + ""),
                            Date = reader["Day"] + "",
                        };

                        listValues.Add(infoBetweenDate);
                    };

                    reader.Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error while fetching max for each day: " + e.Message);
                }
            }

            return listValues;
        }

        public List<InfoBetweenDate> getInfoMinBetweenDates(string parameter, string cityName, DateTime startDate, DateTime endDate)
        {
            string query = string.Format(@"
                    SELECT MIN(Value) as Minimum, CONVERT(varchar, DateTime, 23) as Day
                    FROM {0}
                    WHERE Param = @userParam AND CityId = @cityId 
                    AND DateTime >= @startDate AND DateTime <= @endDate
                    GROUP BY CONVERT(varchar, DateTime, 23)
                    ORDER BY 2 DESC", DatabaseTableConstant.tableSensorData);

            List<InfoBetweenDate> listValues = new List<InfoBetweenDate>();

            int cityId = fetchCityIdFromName(cityName);

            if (cityId == -1)
            {
                return null;
            }

            if (startDate > endDate)
            {
                return null;
            }

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("userParam", parameter.ToUpper());
                command.Parameters.AddWithValue("cityId", cityId);
                command.Parameters.AddWithValue("startDate", startDate.ToString("yyyy-MM-dd") + "");
                command.Parameters.AddWithValue("endDate", endDate.ToString("yyyy-MM-dd HH:mm:ss") + "");

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        InfoBetweenDate infoBetweenDate = new InfoBetweenDate
                        {
                            Value = int.Parse(reader["Minimum"] + ""),
                            Date = reader["Day"] + "",
                        };

                        listValues.Add(infoBetweenDate);
                    };

                    reader.Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error while fetching max for each day: " + e.Message);
                }
            }

            return listValues;
        }

        public City getInfoAvgEachDay(string city, DateTime dateTime)
        {
            City avgInfo = null;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                SqlCommand command = new SqlCommand("SELECT  AVG(NO2), AVG(CO), AVG(O3) FROM " + DatabaseTableConstant.tableAlarms + " WHERE date_time = @date", connection);
                command.Parameters.AddWithValue("@date", dateTime);     //MESMO PROBLEMA COM AS DATAS 

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    avgInfo = new City
                    {
                    /*    Id = (int)reader["Id"],
                        CityName = (string)reader["City_Name"],
                        Date_Time = (DateTime)reader["Date_Time"],
                        NO2 = (int)reader["NO2"],
                        CO = (int)reader["CO"],
                        O3 = (int)reader["O3"]*/
                    };
                };
                reader.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error while fetching avg for each day: " + e.Message);
            }

            connection.Close();

            return avgInfo;
        }

        public City getInfoMinEachDay(string city, DateTime dateTime)
        {
            City minInfo = null;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                SqlCommand command = new SqlCommand("SELECT  MIN(NO2), MIN(CO), MIN(O3) FROM " + DatabaseTableConstant.tableAlarms + " WHERE date_time = @date", connection);
                command.Parameters.AddWithValue("@date", dateTime);     //MESMO PROBLEMA COM AS DATAS 

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    minInfo = new City
                    {
                     /*   Id = (int)reader["Id"],
                        CityName = (string)reader["City_Name"],
                        Date_Time = (DateTime)reader["Date_Time"],
                        NO2 = (int)reader["NO2"],
                        CO = (int)reader["CO"],
                        O3 = (int)reader["O3"]*/
                    };
                };
                reader.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error while fetching avg for each day: " + e.Message);
            }

            connection.Close();

            return minInfo;
        }

        public City getInfoMaxEachDay(string city, DateTime dateTime)
        {
            City maxInfo = null;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            try
            {
                SqlCommand command = new SqlCommand("SELECT  MAX(NO2), MAX(CO), MAX(O3) FROM " + DatabaseTableConstant.tableAlarms + " WHERE date_time = @date", connection);
                command.Parameters.AddWithValue("@date", dateTime);     //MESMO PROBLEMA COM AS DATAS 

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    maxInfo = new City
                    {
                     /*   Id = (int)reader["Id"],
                        CityName = (string)reader["City_Name"],
                        Date_Time = (DateTime)reader["Date_Time"],
                        NO2 = (int)reader["NO2"],
                        CO = (int)reader["CO"],
                        O3 = (int)reader["O3"]*/
                    };
                };
                reader.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error while fetching avg for each day: " + e.Message);
            }

            connection.Close();

            return maxInfo;
        }


        public List<InfoBetweenDate> getInfoAvgEachHour(string Parameter, string city, DateTime dateTime)
        {
            List<InfoBetweenDate> listValues = new List<InfoBetweenDate>();
            int cityIdFetched = -1;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                cityIdFetched = fetchCityIdFromName(city);
                if (cityIdFetched == -1)
                {
                    throw new Exception("Couldn't fetch city ID from city name. Wrong city name perhaps?");
                } //thrown new exception for no city ID found

                SqlCommand command = new SqlCommand("SELECT AVG(Value), DateTime" +
                                                    "FROM @tableName " +
                                                    "WHERE UPPER(PARAM) = UPPER(@userParam) AND" +
                                                    "cityId = @cityIdFetched AND " +
                                                    "DateTime = @date" + //Só dados do dia selecionado 
                                                    "GROUP BY TO_CHAR(DateTime, 'HH24')" + //Group by horas do dia exemplo: 11h30, 11h31, 11h45 é tudo considerado 11h
                                                    "ORDER BY 2", connection);
                command.Parameters.AddWithValue("tableName", DatabaseTableConstant.tableSensorData);
                command.Parameters.AddWithValue("userParam", Parameter);
                command.Parameters.AddWithValue("cityIdFetched", cityIdFetched);
                command.Parameters.AddWithValue("@date", dateTime); //COMO RESOLVER INCONGROÊNCIAS NAS DATAS ?????

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    InfoBetweenDate infoBetweenDate = new InfoBetweenDate
                    {
                        Value = (int)reader["AVG(Value)"],
                        Date = reader["DateTime"] + "",
                    };
                    listValues.Add(infoBetweenDate);
                };
                reader.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error while fetching avg for each hour: + ", e);
            }
            connection.Close();
            return listValues;
        }

        public List<InfoBetweenDate> getInfoMaxEachHour(string Parameter, string city, DateTime dateTime)
        {
            List<InfoBetweenDate> listValues = new List<InfoBetweenDate>();
            int cityIdFetched = -1;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                cityIdFetched = fetchCityIdFromName(city);
                if (cityIdFetched == -1)
                {
                    throw new Exception("Couldn't fetch city ID from city name. Wrong city name perhaps?");
                } //thrown new exception for no city ID found

                SqlCommand command = new SqlCommand("SELECT MAX(Value), DateTime" +
                                                    "FROM @tableName " +
                                                    "WHERE UPPER(PARAM) = UPPER(@userParam) AND" +
                                                    "cityId = @cityIdFetched AND " +
                                                    "DateTime = @date" + //Só dados do dia selecionado 
                                                    "GROUP BY TO_CHAR(DateTime, 'HH24')" + //Group by horas do dia exemplo: 11h30, 11h31, 11h45 é tudo considerado 11h
                                                    "ORDER BY 2", connection);
                command.Parameters.AddWithValue("tableName", DatabaseTableConstant.tableSensorData);
                command.Parameters.AddWithValue("userParam", Parameter);
                command.Parameters.AddWithValue("cityIdFetched", cityIdFetched);
                command.Parameters.AddWithValue("@date", dateTime); //COMO RESOLVER INCONGROÊNCIAS NAS DATAS ?????

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    InfoBetweenDate infoBetweenDate = new InfoBetweenDate
                    {
                        Value = (int)reader["MAX(Value)"],
                        Date = reader["DateTime"] + "",
                    };
                    listValues.Add(infoBetweenDate);
                };
                reader.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error while fetching max for each hour: + ", e);
            }
            connection.Close();
            return listValues;
        }

        public List<InfoBetweenDate> getInfoMinEachHour(string Parameter, string city, DateTime dateTime)
        {
            List<InfoBetweenDate> listValues = new List<InfoBetweenDate>();
            int cityIdFetched = -1;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                cityIdFetched = fetchCityIdFromName(city);
                if (cityIdFetched == -1)
                {
                    throw new Exception("Couldn't fetch city ID from city name. Wrong city name perhaps?");
                } //thrown new exception for no city ID found

                SqlCommand command = new SqlCommand("SELECT MIN(Value), DateTime" +
                                                    "FROM @tableName " +
                                                    "WHERE UPPER(PARAM) = UPPER(@userParam) AND" +
                                                    "cityId = @cityIdFetched AND " +
                                                    "DateTime = @date" + //Só dados do dia selecionado 
                                                    "GROUP BY TO_CHAR(DateTime, 'HH24')" + //Group by horas do dia exemplo: 11h30, 11h31, 11h45 é tudo considerado 11h
                                                    "ORDER BY 2", connection);
                command.Parameters.AddWithValue("tableName", DatabaseTableConstant.tableSensorData);
                command.Parameters.AddWithValue("userParam", Parameter);
                command.Parameters.AddWithValue("cityIdFetched", cityIdFetched);
                command.Parameters.AddWithValue("@date", dateTime); //COMO RESOLVER INCONGROÊNCIAS NAS DATAS ?????

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    InfoBetweenDate infoBetweenDate = new InfoBetweenDate
                    {
                        Value = (int)reader["MIN(Value)"],
                        Date = reader["DateTime"] + "",
                    };
                    listValues.Add(infoBetweenDate);
                };
                reader.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error while fetching min for each hour: + ", e);
            }
            connection.Close();
            return listValues;
        }

        //***********************************TO DO **************************************************************************************************************************
        //   - Em todas as funções, validar e testar                                                                               *
        //   - Garantir a uniformização das datas     
        //   - Connection String atribuida. Funcional ? 
        //*******************************************************************************************************************************************************************

        // * Util function

        public int fetchCityIdFromName(string cityName)
        {
            string query = string.Format(@"SELECT id FROM {0} WHERE City_Name = @cityName", DatabaseTableConstant.tableCity);
            int cityIdFromDB = -1;
            
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("cityName", cityName.First().ToString().ToUpper() + cityName.Substring(1));

            try
            {
                connection.Open();

                cityIdFromDB = (int) command.ExecuteScalar();
                Debug.WriteLine("ID of city: " + cityIdFromDB);

            }
            catch (Exception e)
            {
                Debug.WriteLine("Error retrieving city Id from name: " + e.Message);
            }

            connection.Close();
            
            return cityIdFromDB;
        }
    }
}

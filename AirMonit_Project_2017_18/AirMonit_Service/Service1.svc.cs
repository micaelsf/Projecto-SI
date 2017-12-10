using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace AirMonit_Service
{
    //Constantes para os nomes das tabelas, para quando inserimos parametros nas queries (FROM ...)
    public static class DatabaseTableConstant
    {
        public const string tableAlarms = "AlarmLogs";
        public const string tableCity = "Cities";
        public const string tableSensorData = "SensorData";
        public const string tableUncommonEvents = "UncommonEvents";
    }

    public class AirMonit_Service : IAirMonit_AccessingData, IAirMonit_StoreData
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
            string query = string.Format(@"
                        INSERT INTO {0} (CityId, Type, Description, UserName, Temperature, DateTime) 
                        VALUES (@cityId, @type, @description, @username, @temperature, @dateTime)", DatabaseTableConstant.tableUncommonEvents);

            if (userInfo.Username == null || userInfo.Username.Trim().Count() == 0)
            {
                return -1;
            }

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
            string query = string.Format(@"
                        SELECT al.Description, al.DateTime, s.Param, s.Value 
                        FROM {0} al JOIN {1} s ON al.SensorDataUID = s.SensorDataUID 
                        WHERE CONVERT(varchar, al.DateTime, 23) = @date 
                        AND CityId = @cityId 
                        ORDER BY 2 DESC", DatabaseTableConstant.tableAlarms, DatabaseTableConstant.tableSensorData);

            List<AlarmLog> dataAlarms = new List<AlarmLog>();

            string date = dateTime.ToString("yyyy-MM-dd");

            if (dateTime == null)
            {
                return null;
            }

            int cityId = fetchCityIdFromName(cityName);

            if (cityId == -1)
            {
                return null;
            }

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("date", date);
                command.Parameters.AddWithValue("cityId", cityId);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AlarmLog alarm = new AlarmLog
                            {
                                Description = (string)reader["Description"],
                                DateTime = (DateTime)reader["DateTime"],
                                Parameter = (string)reader["Param"],
                                Value = (int)reader["Value"]
                            };

                            dataAlarms.Add(alarm);
                        }
                    }
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
            string query;
            bool allcity = false;
            int cityId = -1;

            if (startDate == null || endDate == null || startDate > endDate)
            {
                return null;
            }

            if (cityName == null)
            {
                query = string.Format(@"
                    SELECT AVG(Value) as Average, CONVERT(varchar, DateTime, 23) as Day, City_Name AS City
                    FROM {0} s JOIN {1} c ON s.CityId = c.Id
                    WHERE Param = @userParam 
                    AND DateTime >= @startDate AND DateTime <= @endDate
                    GROUP BY CONVERT(varchar, DateTime, 23), City_Name
                    ORDER BY 2 DESC", DatabaseTableConstant.tableSensorData, DatabaseTableConstant.tableCity);

                allcity = true;
            }
            else
            {
                query = string.Format(@"
                    SELECT AVG(Value) as Average, CONVERT(varchar, DateTime, 23) as Day, City_Name AS City
                    FROM {0} s JOIN {1} c ON s.CityId = c.Id
                    WHERE Param = @userParam AND CityId = @cityId 
                    AND DateTime >= @startDate AND DateTime <= @endDate
                    GROUP BY CONVERT(varchar, DateTime, 23), City_Name
                    ORDER BY 2 DESC", DatabaseTableConstant.tableSensorData, DatabaseTableConstant.tableCity);

                cityId = fetchCityIdFromName(cityName);

                if (cityId == -1)
                {
                    return null;
                }
            }

            List<InfoBetweenDate> listValues = new List<InfoBetweenDate>();

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("userParam", parameter.ToUpper());
                if (!allcity)
                {
                    command.Parameters.AddWithValue("cityId", cityId);
                }
                command.Parameters.AddWithValue("startDate", startDate.ToString("yyyy-MM-dd 00:00:00"));
                command.Parameters.AddWithValue("endDate", endDate.ToString("yyyy-MM-dd 23:59:59"));

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InfoBetweenDate infoBetweenDate = new InfoBetweenDate
                            {
                                Value = int.Parse(reader["Average"] + ""),
                                Date = reader["Day"] + "",
                                City = reader["City"] + "",
                            };

                            listValues.Add(infoBetweenDate);
                        };
                    }
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
            string query;
            bool allcity = false;
            int cityId = -1;

            if (startDate == null || endDate == null || startDate > endDate)
            {
                return null;
            }

            if (cityName == null)
            {
                query = string.Format(@"
                    SELECT MAX(Value) as Maximum, CONVERT(varchar, DateTime, 23) as Day, City_Name AS City
                    FROM {0} s JOIN {1} c ON s.CityId = c.Id
                    WHERE Param = @userParam 
                    AND DateTime >= @startDate AND DateTime <= @endDate
                    GROUP BY CONVERT(varchar, DateTime, 23), City_Name
                    ORDER BY 2 DESC", DatabaseTableConstant.tableSensorData, DatabaseTableConstant.tableCity);

                allcity = true;
            }
            else
            {
                query = string.Format(@"
                    SELECT MAX(Value) as Maximum, CONVERT(varchar, DateTime, 23) as Day, City_Name AS City
                    FROM {0} s JOIN {1} c ON s.CityId = c.Id
                    WHERE Param = @userParam AND CityId = @cityId 
                    AND DateTime >= @startDate AND DateTime <= @endDate
                    GROUP BY CONVERT(varchar, DateTime, 23), City_Name
                    ORDER BY 2 DESC", DatabaseTableConstant.tableSensorData, DatabaseTableConstant.tableCity);

                cityId = fetchCityIdFromName(cityName);

                if (cityId == -1)
                {
                    return null;
                }
            }

            List<InfoBetweenDate> listValues = new List<InfoBetweenDate>();

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("userParam", parameter.ToUpper());
                if (!allcity)
                {
                    command.Parameters.AddWithValue("cityId", cityId);
                }
                command.Parameters.AddWithValue("startDate", startDate.ToString("yyyy-MM-dd 00:00:00"));
                command.Parameters.AddWithValue("endDate", endDate.ToString("yyyy-MM-dd 23:59:59"));

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InfoBetweenDate infoBetweenDate = new InfoBetweenDate
                            {
                                Value = int.Parse(reader["Maximum"] + ""),
                                Date = reader["Day"] + "",
                                City = reader["City"] + "",
                            };

                            listValues.Add(infoBetweenDate);
                        };
                    }
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
            string query;
            bool allcity = false;
            int cityId = -1;

            if (startDate == null || endDate == null || startDate > endDate)
            {
                return null;
            }

            if (cityName == null)
            {
                query = string.Format(@"
                    SELECT MIN(Value) AS Minimum, CONVERT(varchar, DateTime, 23) AS Day, City_Name AS City
                    FROM {0} s JOIN {1} c ON s.CityId = c.Id
                    WHERE Param = @userParam 
                    AND DateTime >= @startDate AND DateTime <= @endDate
                    GROUP BY CONVERT(varchar, DateTime, 23), City_Name
                    ORDER BY 2 DESC", DatabaseTableConstant.tableSensorData, DatabaseTableConstant.tableCity);

                allcity = true;
            }
            else
            {
                query = string.Format(@"
                    SELECT MIN(Value) as Minimum, CONVERT(varchar, DateTime, 23) as Day, City_Name AS City
                    FROM {0} s JOIN {1} c ON s.CityId = c.Id
                    WHERE Param = @userParam AND CityId = @cityId 
                    AND DateTime >= @startDate AND DateTime <= @endDate
                    GROUP BY CONVERT(varchar, DateTime, 23), City_Name
                    ORDER BY 2 DESC", DatabaseTableConstant.tableSensorData, DatabaseTableConstant.tableCity);

                cityId = fetchCityIdFromName(cityName);

                if (cityId == -1)
                {
                    return null;
                }
            }

            List<InfoBetweenDate> listValues = new List<InfoBetweenDate>();

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("userParam", parameter.ToUpper());
                if (!allcity)
                {
                    command.Parameters.AddWithValue("cityId", cityId);
                }
                command.Parameters.AddWithValue("startDate", startDate.ToString("yyyy-MM-dd 00:00:00"));
                command.Parameters.AddWithValue("endDate", endDate.ToString("yyyy-MM-dd 23:59:59"));

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InfoBetweenDate infoBetweenDate = new InfoBetweenDate
                            {
                                Value = int.Parse(reader["Minimum"] + ""),
                                Date = reader["Day"] + "",
                                City = reader["City"] + "",
                            };

                            listValues.Add(infoBetweenDate);
                        };
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error while fetching min for each day: " + e.Message);
                }
            }

            return listValues;
        }

        public List<InfoBetweenDate> getInfoAvgEachHour(string parameter, string cityName, DateTime dateTime)
        {
            string query;
            bool allcity = false;
            int cityId = -1;

            if (dateTime == null)
            {
                return null;
            }

            if (cityName == null)
            {

                query = string.Format(@"
                    SELECT AVG(Value) AS Average,  
                        (CONVERT(varchar, DateTime, 23) + ' ' + LEFT(CONVERT(varchar, DateTime, 108), 2) + ':00:00') as Hour,
                        City_Name AS City
                    FROM {0} s JOIN {1} c ON s.CityId = c.Id
                    WHERE Param = @userParam AND CONVERT(varchar, DateTime, 23) = @datetime
                    GROUP BY (CONVERT(varchar, DateTime, 23) + ' ' + LEFT(CONVERT(varchar, DateTime, 108),2) + ':00:00'), City_Name
                    ORDER BY 2 DESC", DatabaseTableConstant.tableSensorData, DatabaseTableConstant.tableCity);

                allcity = true;
            }
            else
            {
                query = string.Format(@"
                    SELECT AVG(Value) AS Average,  
                        (CONVERT(varchar, DateTime, 23) + ' ' + LEFT(CONVERT(varchar, DateTime, 108), 2) + ':00:00') as Hour,
                        City_Name AS City
                    FROM {0} s JOIN {1} c ON s.CityId = c.Id
                    WHERE Param = @userParam AND CityId = @cityId AND CONVERT(varchar, DateTime, 23) = @datetime
                    GROUP BY (CONVERT(varchar, DateTime, 23) + ' ' + LEFT(CONVERT(varchar, DateTime, 108),2) + ':00:00'), City_Name
                    ORDER BY 2 DESC", DatabaseTableConstant.tableSensorData, DatabaseTableConstant.tableCity);

                cityId = fetchCityIdFromName(cityName);

                if (cityId == -1)
                {
                    return null;
                }
            }

            List<InfoBetweenDate> listValues = new List<InfoBetweenDate>();

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("userParam", parameter.ToUpper());
                if (!allcity)
                {
                    command.Parameters.AddWithValue("cityId", cityId);
                }
                command.Parameters.AddWithValue("datetime", dateTime.ToString("yyyy-MM-dd") + "");

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InfoBetweenDate infoBetweenDate = new InfoBetweenDate
                            {
                                Value = int.Parse(reader["Average"] + ""),
                                Date = reader["Hour"] + "",
                                City = reader["City"] + "",
                            };

                            listValues.Add(infoBetweenDate);
                        };
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error while fetching avg for each hour: " + e.Message);
                }
            }

            return listValues;
        }

        public List<InfoBetweenDate> getInfoMaxEachHour(string parameter, string cityName, DateTime dateTime)
        {
            string query;
            bool allcity = false;
            int cityId = -1;

            if (dateTime == null)
            {
                return null;
            }

            if (cityName == null)
            {

                query = string.Format(@"
                    SELECT MAX(Value) AS Maximum,  
                        (CONVERT(varchar, DateTime, 23) + ' ' + LEFT(CONVERT(varchar, DateTime, 108), 2) + ':00:00') as Hour,
                        City_Name AS City
                    FROM {0} s JOIN {1} c ON s.CityId = c.Id
                    WHERE Param = @userParam AND CONVERT(varchar, DateTime, 23) = @datetime
                    GROUP BY (CONVERT(varchar, DateTime, 23) + ' ' + LEFT(CONVERT(varchar, DateTime, 108),2) + ':00:00'), City_Name
                    ORDER BY 2 DESC", DatabaseTableConstant.tableSensorData, DatabaseTableConstant.tableCity);

                allcity = true;
            }
            else
            {
                query = string.Format(@"
                    SELECT MAX(Value) AS Maximum,  
                        (CONVERT(varchar, DateTime, 23) + ' ' + LEFT(CONVERT(varchar, DateTime, 108), 2) + ':00:00') as Hour,
                        City_Name AS City
                    FROM {0} s JOIN {1} c ON s.CityId = c.Id
                    WHERE Param = @userParam AND CityId = @cityId AND CONVERT(varchar, DateTime, 23) = @datetime
                    GROUP BY (CONVERT(varchar, DateTime, 23) + ' ' + LEFT(CONVERT(varchar, DateTime, 108),2) + ':00:00'), City_Name
                    ORDER BY 2 DESC", DatabaseTableConstant.tableSensorData, DatabaseTableConstant.tableCity);

                cityId = fetchCityIdFromName(cityName);

                if (cityId == -1)
                {
                    return null;
                }
            }

            List<InfoBetweenDate> listValues = new List<InfoBetweenDate>();

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("userParam", parameter.ToUpper());
                if (!allcity)
                {
                    command.Parameters.AddWithValue("cityId", cityId);
                }
                command.Parameters.AddWithValue("datetime", dateTime.ToString("yyyy-MM-dd") + "");

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InfoBetweenDate infoBetweenDate = new InfoBetweenDate
                            {
                                Value = int.Parse(reader["Maximum"] + ""),
                                Date = reader["Hour"] + "",
                                City = reader["City"] + "",
                            };

                            listValues.Add(infoBetweenDate);
                        };
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error while fetching max for each hour: " + e.Message);
                }
            }

            return listValues;
        }

        public List<InfoBetweenDate> getInfoMinEachHour(string parameter, string cityName, DateTime dateTime)
        {
            string query;
            bool allcity = false;
            int cityId = -1;

            if (dateTime == null)
            {
                return null;
            }

            if (cityName == null)
            {

                query = string.Format(@"
                    SELECT MIN(Value) AS Minimum,  
                        (CONVERT(varchar, DateTime, 23) + ' ' + LEFT(CONVERT(varchar, DateTime, 108), 2) + ':00:00') as Hour,
                        City_Name AS City
                    FROM {0} s JOIN {1} c ON s.CityId = c.Id
                    WHERE Param = @userParam AND CONVERT(varchar, DateTime, 23) = @datetime
                    GROUP BY (CONVERT(varchar, DateTime, 23) + ' ' + LEFT(CONVERT(varchar, DateTime, 108),2) + ':00:00'), City_Name
                    ORDER BY 2 DESC", DatabaseTableConstant.tableSensorData, DatabaseTableConstant.tableCity);

                allcity = true;
            }
            else
            {
                query = string.Format(@"
                    SELECT MIN(Value) AS Minimum,  
                        (CONVERT(varchar, DateTime, 23) + ' ' + LEFT(CONVERT(varchar, DateTime, 108), 2) + ':00:00') as Hour,
                        City_Name AS City
                    FROM {0} s JOIN {1} c ON s.CityId = c.Id
                    WHERE Param = @userParam AND CityId = @cityId AND CONVERT(varchar, DateTime, 23) = @datetime
                    GROUP BY (CONVERT(varchar, DateTime, 23) + ' ' + LEFT(CONVERT(varchar, DateTime, 108),2) + ':00:00'), City_Name
                    ORDER BY 2 DESC", DatabaseTableConstant.tableSensorData, DatabaseTableConstant.tableCity);

                cityId = fetchCityIdFromName(cityName);

                if (cityId == -1)
                {
                    return null;
                }
            }

            List<InfoBetweenDate> listValues = new List<InfoBetweenDate>();

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("userParam", parameter.ToUpper());
                if (!allcity)
                {
                    command.Parameters.AddWithValue("cityId", cityId);
                }
                command.Parameters.AddWithValue("datetime", dateTime.ToString("yyyy-MM-dd") + "");

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InfoBetweenDate infoBetweenDate = new InfoBetweenDate
                            {
                                Value = int.Parse(reader["Minimum"] + ""),
                                Date = reader["Hour"] + "",
                                City = reader["City"] + "",
                            };

                            listValues.Add(infoBetweenDate);
                        };
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error while fetching min for each hour: " + e.Message);
                }
            }

            return listValues;
        }


        // UTIL FUNCTION
        private int fetchCityIdFromName(string cityName)
        {
            string query = string.Format(@"SELECT id FROM {0} WHERE City_Name = @cityName", DatabaseTableConstant.tableCity);
            int cityIdFromDB = -1;

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("cityName", cityName.First().ToString().ToUpper() + cityName.Substring(1));

            try
            {
                connection.Open();

                cityIdFromDB = (int)command.ExecuteScalar();
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

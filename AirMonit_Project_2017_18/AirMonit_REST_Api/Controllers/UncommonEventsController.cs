using AirMonit_REST_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AirMonit_REST_Api.Controllers
{
    public static class DatabaseTableConstant
    {
        public const string tableCity = "Cities";
        public const string tableUncommonEvents = "UncommonEvents";
    }

    public class UncommonEventsController : ApiController
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["appHarborConnect"].ConnectionString;
        private SqlConnection connection;
        List<UncommonEvent> products = new List<UncommonEvent>();

        public UncommonEventsController()
        {
            connection = new SqlConnection(connectionString);
        }

        [HttpPost]
        [Route("api/uncommonEvents")]
        public IHttpActionResult storeUncommonEvent(UncommonEvent uncommonEvent)
        {
            int linesReturned = -1;
            string query = string.Format(@"
                        INSERT INTO {0} (CityId, Type, Description, UserName, Temperature, DateTime) 
                        VALUES (@cityId, @type, @description, @username, @temperature, @dateTime)", DatabaseTableConstant.tableUncommonEvents);

            if (uncommonEvent.Username == null || uncommonEvent.Username.Trim().Count() == 0)
            {
                return NotFound();
            }

            int cityId = fetchCityIdFromName(uncommonEvent.CityName);

            if (cityId == -1)
            {
                return NotFound();
            }

            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("cityId", cityId);
                command.Parameters.AddWithValue("type", uncommonEvent.Type);
                command.Parameters.AddWithValue("description", uncommonEvent.Description);
                command.Parameters.AddWithValue("username", uncommonEvent.Username);
                command.Parameters.AddWithValue("dateTime", DateTime.Now);
                command.Parameters.AddWithValue("temperature", uncommonEvent.Temperature);

                try
                {
                    connection.Open();
                    linesReturned = command.ExecuteNonQuery();
                    Debug.WriteLine("Command executed! Total rows affected are " + linesReturned);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Erro ao escrever na BD: " + e.ToString());
                }
            }

            if (linesReturned < 1)
            {
                return BadRequest();
            }

            return Ok(); //Respecting HTTP errors (200 OK)
        }

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

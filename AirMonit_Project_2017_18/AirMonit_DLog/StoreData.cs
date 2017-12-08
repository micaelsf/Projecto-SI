using System;
using System.Data;
using System.Data.SqlClient;

namespace AirMonit_DLog
{
    public class StoreData
    {
        //private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["appHarborConnect"].ConnectionString;
        //private SqlConnection connection;
        private AppHarborDataSet appHarborDataSet;
        private AppHarborDataSetTableAdapters.SensorDataTableAdapter sensorDataTableAdapter;
        private AppHarborDataSetTableAdapters.AlarmLogsTableAdapter alarmDataTableAdapter;
        private AppHarborDataSetTableAdapters.CitiesTableAdapter citiesTableAdapter;

        public StoreData()
        {
            //connection = new SqlConnection(connectionString);
            appHarborDataSet = new AppHarborDataSet();
            sensorDataTableAdapter = new AppHarborDataSetTableAdapters.SensorDataTableAdapter();
            alarmDataTableAdapter = new AppHarborDataSetTableAdapters.AlarmLogsTableAdapter();
            citiesTableAdapter = new AppHarborDataSetTableAdapters.CitiesTableAdapter();
        }

        public void StoreSensorData(SensorData sensorData)
        {
            AppHarborDataSet.SensorDataRow newSensorDataRow;

            int cityId = GetCityIdFrom(sensorData.City);

            try { 
                newSensorDataRow = (AppHarborDataSet.SensorDataRow) appHarborDataSet.SensorData.NewRow();
                newSensorDataRow.Param = sensorData.Param;
                newSensorDataRow.Value = sensorData.Value;
                newSensorDataRow.CityId = cityId;
                newSensorDataRow.DateTime = DateTime.Parse(sensorData.Date + " " + sensorData.Time);
                newSensorDataRow.SensorId = sensorData.Id;

                // Add the row to the Region table
                this.appHarborDataSet.SensorData.Rows.Add(newSensorDataRow);

                // Save the new row to the database
                this.sensorDataTableAdapter.Update(this.appHarborDataSet.SensorData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void StoreAlarmData(AlarmData alarmData)
        {
            AppHarborDataSet.AlarmLogsRow newAlarmDataRow;

            try
            {
                newAlarmDataRow = (AppHarborDataSet.AlarmLogsRow)appHarborDataSet.AlarmLogs.NewRow();
                newAlarmDataRow.Description = alarmData.AlarmDescription;
                newAlarmDataRow.Date_Time = DateTime.Parse(alarmData.AlarmDate + " " + alarmData.AlarmTime);
                newAlarmDataRow.SensorDataId = int.Parse(alarmData.SensorId);

                // Add the row to the Region table
                this.appHarborDataSet.AlarmLogs.Rows.Add(newAlarmDataRow);

                // Save the new row to the database
                this.alarmDataTableAdapter.Update(this.appHarborDataSet.AlarmLogs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public int GetCityIdFrom(string cityName)
        {
            DataTable dataTable;
            DataRow[] dataRows;

            int cityId;
            dataTable = this.citiesTableAdapter.GetData();

            dataRows = dataTable.Select("City_Name = '" + cityName +"'");
            
            cityId = Convert.ToInt32(dataRows[0]["Id"]);

            return cityId;
        }
    }
}
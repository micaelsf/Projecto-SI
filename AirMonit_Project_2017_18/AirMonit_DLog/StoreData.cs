using System;
using System.Data;
using System.Data.SqlClient;

namespace AirMonit_DLog
{
    public class StoreData
    {
        //private SqlConnection connection;

        // appHarbor dataset
        private AppHarborDataSet appHarborDataSet;

        // appHabror adapters, needed to update the tables at server, or get data from it
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
            newSensorDataRow = (AppHarborDataSet.SensorDataRow)appHarborDataSet.SensorData.NewRow();

            int cityId = GetCityIdFrom(sensorData.City);

            try { 
                newSensorDataRow.Param = sensorData.Param;
                newSensorDataRow.Value = sensorData.Value;
                newSensorDataRow.CityId = cityId;
                newSensorDataRow.DateTime = DateTime.Parse(sensorData.Date + " " + sensorData.Time);
                newSensorDataRow.SensorId = sensorData.Id;

                // Add the row to the SensorData table
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
            newAlarmDataRow = (AppHarborDataSet.AlarmLogsRow)appHarborDataSet.AlarmLogs.NewRow();

            try
            {
                newAlarmDataRow.Description = alarmData.AlarmDescription;
                newAlarmDataRow.Date_Time = DateTime.Parse(alarmData.AlarmDate + " " + alarmData.AlarmTime);
                newAlarmDataRow.SensorDataId = int.Parse(alarmData.SensorId);

                // Add the row to the AlarmLogs table
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

            // get all data from Cities table
            dataTable = this.citiesTableAdapter.GetData();

            dataRows = dataTable.Select("City_Name = '" + cityName + "'");
            
            cityId = Convert.ToInt32(dataRows[0]["Id"]);

            return cityId;
        }
    }
}
using System;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace AirMonit_DLog.Controllers
{
    internal class StoreData
    {

        internal static void storeSensorData(SensorData sensorData)
        {
            string baseURI = @"http://localhost:50611/api/products"; //needs to be updated!
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseURI);


            System.Text.UTF8Encoding encoding = new UTF8Encoding();

            ///ERRO ???????????????
            byte[] byteArray = encoding.GetBytes(sensorData.ToString());

            request.Method = "post"; //add new
            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/xml";

            Stream data = request.GetRequestStream();
            data.Write(byteArray, 0, byteArray.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //MessageBox.Show(response.ContentLength.ToString());
            response.Close();
        }
    }
}
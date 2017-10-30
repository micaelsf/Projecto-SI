using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirMonit_DLog;
using System.Threading;

namespace AirMonit_DLog
{
    public partial class AirMonitView : Form
    {
        //private CCI cci;
        // time by default is 500ms
        private static int TIME = 500;
        private Thread threadCity;
        private Thread threadAlarm;

        public AirMonitView()
        {
            InitializeComponent();
            //cci = new CCI();
            // To avoid freezing the UI, we create a thread to handle the listbox populate

        }

        private void populateList()
        {
         //   DataSensor data;
          //  cci = new CCI();

            try
            {
                int timeTmp = 500; //hardcodedd

                if (timeTmp > 0)
                {
                    TIME = (timeTmp * 1000) / 3;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            // initializedSensors = cci.InitializeSensors(TIME);
            Boolean initializedSensors = true; //apagar

            while (initializedSensors)
            {
              //  data = cci.TimeDataSensors(TIME);

                if ("data" != null)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        // insert at first line
                      //  listViewAlarmLog.Items.Insert(0, data.toString());
                    }));

                }
            }
        }

        private void btnSetAlarmLog_Click(object sender, EventArgs e)
        {
            threadAlarm = new Thread(populateList);
            threadAlarm.Start();
        }

        private void btnStopAlarmLog_Click(object sender, EventArgs e)
        {
            // initializedSensors = !cci.StopSensors();
            threadAlarm.Abort();
        }

        private void btnSetCityLog_Click(object sender, EventArgs e)
        {
            threadCity = new Thread(populateList);
            threadCity.Start();

        }

        private void btnStopCityLog_Click(object sender, EventArgs e)
        {
            threadCity.Abort();
        //    initializedSensors = !cci.StopSensors();
        }


    }
}

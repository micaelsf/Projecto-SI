using AirMonit_DU;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AirMonitAlarm : Form
    {
       // private CCI cci;
        // time by default is 500ms
        private static int TIME = 500;
        private Boolean initializedSensors;

        public AirMonitAlarm()
        {
            InitializeComponent();
         //   cci = new CCI();
        }

        private void InitSensorsButton_Click(object sender, EventArgs e)
        {
            // To avoid freezing the UI, we create a thread to handle the listbox populate
            Thread thread1 = new Thread(populateList);
            thread1.Start();
        }

        private void populateList()
        {
            DataSensor data;
          //  cci = new CCI();

            try
            {
                int timeTmp = int.Parse(timeTextbox.Text);

                if (timeTmp > 0)
                {
                    TIME = (timeTmp * 1000) / 3;
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

          //  initializedSensors = cci.InitializeSensors(TIME);

            while (initializedSensors)
            {
           //     data = cci.TimeDataSensors(TIME);

                if ("data" != null)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        // insert at first line
              //          listBox1.Items.Insert(0, data.toString());
                    }));

                }
            }
        }

        private void StopSensorsButton_Click(object sender, EventArgs e)
        {
          //  initializedSensors = !cci.StopSensors();
        }
    }
}

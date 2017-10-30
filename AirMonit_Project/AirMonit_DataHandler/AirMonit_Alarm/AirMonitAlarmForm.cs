using CommunicationChannelInfrastructure;
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
    public partial class AirMonitAlarmForm : Form
    {
        private CCI cci;
        // time by default is 3334ms * 3 parameters = ~10000/per city
        private static int TIME = 3334;
        private Boolean initializedSensors;
        private Thread currentThread_ = null;

        private string errorNotANumber = "Inserted frequency is not a valid number. Initialized by default (10 seconds)";
        private string errorNotWithinNumber = "Inserted number must be between [0.1 and 60]. Initialized by default (10 seconds)";

        public AirMonitAlarmForm()
        {
            InitializeComponent();
            cci = new CCI();
        }

        private void InitSensorsButton_Click(object sender, EventArgs e)
        {
            // To avoid freezing the UI, we create a thread to handle the listbox populate
            if (currentThread_ == null)
            {
                currentThread_ = new Thread(populateList);
                currentThread_.Start();
            } else
            {
                try
                {
                    currentThread_.Abort();
                }
                catch (ThreadAbortException ex)
                {
                }

                currentThread_ = new Thread(populateList);
                currentThread_.Start();
            }

            errorFrequencyLabel.Text = "";
        }

        private void populateList()
        {
            DataSensorClean data;
            cci = new CCI();
            int runtime = TIME;

            if (timeTextbox.Text.Length > 0)
            {
                try
                {
                    double timeTmp = double.Parse(timeTextbox.Text);

                    if (timeTmp >= 0.1 && timeTmp <= 60)
                    {
                        errorFrequencyLabel.Text = "";
                        runtime = (int)Math.Round((timeTmp * 1000) / 3);

                    }
                    else
                    {
                        errorFrequencyLabel.Text = errorNotWithinNumber;
                    }

                }
                catch (Exception ex)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        errorFrequencyLabel.Text = errorNotANumber;
                    }));
                }
            }

            initializedSensors = cci.InitializeSensors(runtime);

            while (initializedSensors)
            {
                data = cci.TimeDataSensors(runtime);

                if (data != null)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        // insert at first line
                        listBox1.Items.Insert(0, data.toString());
                    }));
                }
            }
        }

        private void StopSensorsButton_Click(object sender, EventArgs e)
        {
            initializedSensors = !cci.StopSensors();
        }

        private void AirMonitAlarmForm_FormClosing(object sender, CancelEventArgs e)
        {
            if (currentThread_ != null)
            {
                try
                {
                    currentThread_.Abort();
                }
                catch (ThreadAbortException ex)
                {
                }

                // set thread null to avoid close the program and thread running (raising an exception)
                currentThread_ = null;
            }
            
            initializedSensors = !cci.StopSensors();
        }

        private void timeTextbox_TextChanged(object sender, EventArgs e)
        {
            if (timeTextbox.Text.Length == 0)
            {
                errorFrequencyLabel.Text = "";
            }
        }
    }
}

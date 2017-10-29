using AirMonit_DU;
using CommunicationChannelInfrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTeste
{
    class Program
    {
        private static CCI cci;

        static void Main(string[] args)
        {
            DataSensor data;
            cci = new CCI();

            data = cci.InitializeSensors();

            Thread th = new Thread(stopSensors);
            th.Start();
        }

        private static void stopSensors()
        {
            string str = Console.ReadLine();

            if (str == "STOP")
            {
                cci.StopSensors();
            }
        }
    }
}

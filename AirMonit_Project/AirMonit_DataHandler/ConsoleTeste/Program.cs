﻿using CommunicationChannelInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            CCI cci = new CCI();

            cci.InitializeSensors();
        }
    }
}

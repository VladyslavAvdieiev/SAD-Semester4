﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public interface IBattery {
        string Title { get; }
        double Capacity { get; }
        double Percentage { get; }
        double FreeCharge { get; set; }
        bool Charge();
    }
}
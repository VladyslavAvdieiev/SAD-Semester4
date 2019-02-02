using System;
using Simulation.Software;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public interface IDevice {
        string Title { get; }
        IOS OS { get; }
        ICPU CPU { get; }
        IBattery Battery { get; set; }
        IInternalMemory RAM { get; }
        IExternalStorage ExternalStorage { get; }
        List<IProgram> Programs { get; }
        List<IExternalDevice> ExternalDevices { get; }
        bool HasElectricityConnection { get; set; }
        bool HasNetworkConnection { get; set; }
    }
}

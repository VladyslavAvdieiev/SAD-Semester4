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
        bool InProgress { get; }
        ICPU CPU { get; }
        IBattery Battery { get; }
        IInternalMemory RAM { get; }
        IExternalStorage ExternalStorage { get; }
        IOperatingSystem OperatingSystem { get; }
        IList<IExternalDevice> ExternalDevices { get; }
        bool HasElectricityConnection { get; set; }
        bool HasNetworkConnection { get; set; }
        Task TurnOn();
        Task TurnOff();
        Task Connect(IExternalDevice externalDevice);
        Task Disconnect(IExternalDevice externalDevice);
    }
}

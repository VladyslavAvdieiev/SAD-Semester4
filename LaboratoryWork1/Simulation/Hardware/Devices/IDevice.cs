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
        IOS OS { get; }
        ICPU CPU { get; }
        IBattery Battery { get; }
        IInternalMemory RAM { get; }
        IExternalStorage ExternalStorage { get; }
        IList<IProgram> Programs { get; }
        IList<IExternalDevice> ExternalDevices { get; }
        bool HasElectricityConnection { get; set; }
        bool HasNetworkConnection { get; set; }
        bool TurnOn();
        bool TurnOff();
        bool Install(IProgram program);
        bool Uninstall(IProgram program);
        bool Connect(IExternalDevice externalDevice);
        bool Disconnect(IExternalDevice externalDevice);
    }
}

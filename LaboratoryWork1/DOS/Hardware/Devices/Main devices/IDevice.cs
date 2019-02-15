using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public interface IDevice {
        string Title { get; }
        bool IsEnabled { get; }
        ICPU CPU { get; }
        IBattery Battery { get; }
        IInternalMemory RAM { get; }
        IExternalStorage ExternalStorage { get; }
        IOperatingSystem OperatingSystem { get; }
        IList<IExternalDevice> ExternalDevices { get; }
        bool HasElectricityConnection { get; set; }
        bool HasNetworkConnection { get; set; }
        void TurnOn();
        void TurnOff();
        void Connect(IExternalDevice externalDevice);
        void Disconnect(IExternalDevice externalDevice);
    }
}

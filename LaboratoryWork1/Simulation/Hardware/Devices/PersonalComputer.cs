using System;
using Simulation.Software;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class PersonalComputer : IDevice {
        public event EventHandler<DeviceEventArgs> OnStatusChanged;
        public event EventHandler<DeviceEventArgs> OnErrorOccurred;

        public string Title { get; }
        public IOS OS { get; }
        public ICPU CPU { get; }
        public IBattery Battery { get; set; }
        public IInternalMemory RAM { get; }
        public IExternalStorage ExternalStorage { get; }
        public List<IProgram> Programs { get; }
        public List<IExternalDevice> ExternalDevices { get; }
        public bool HasElectricityConnection { get; set; }
        public bool HasNetworkConnection { get; set; }

        public PersonalComputer(string title, IOS os, ICPU cpu, IBattery battery, IInternalMemory ram, 
            IExternalStorage externalStorage, bool hasElectricityConnection, bool hasNetworkConnection)
        {
            Title = title;
            OS = os;
            CPU = cpu;
            Battery = battery;
            RAM = ram;
            ExternalStorage = externalStorage;
            HasElectricityConnection = hasElectricityConnection;
            HasNetworkConnection = hasNetworkConnection;
        }
    }
}

using System;
using Simulation.Software;
using Simulation.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Simulation.Hardware
{
    public class Laptop : IDevice {
        private List<IExternalDevice> _externalDevices;

        public string Title { get; }
        public bool InProgress { get; private set; }
        public ICPU CPU { get; }
        public IBattery Battery { get; }
        public IInternalMemory RAM { get; }
        public IExternalStorage ExternalStorage { get; }
        public IOperatingSystem OperatingSystem { get; }
        public IList<IExternalDevice> ExternalDevices { get => _externalDevices.AsReadOnly(); }
        public bool HasElectricityConnection { get; set; }
        public bool HasNetworkConnection { get; set; }

        public event EventHandler<DeviceEventArgs> OnStatusChanged;

        public Laptop(string title, ICPU cpu, IInternalMemory ram, IExternalStorage externalStorage,
            IOperatingSystem operatingSystem, bool hasElectricityConnection, bool hasNetworkConnection)
        {
            Title = title;
            CPU = cpu;
            RAM = ram;
            ExternalStorage = externalStorage;
            OperatingSystem = operatingSystem;
            HasElectricityConnection = hasElectricityConnection;
            HasNetworkConnection = hasNetworkConnection;
            _externalDevices = new List<IExternalDevice>();
        }

        public async Task TurnOn() {
            if (InProgress)
                throw new HardwareCannotBeStartedException();
            if (!HasElectricityConnection && Battery == null)
                throw new NoElectricityConnectionException();
            InProgress = true;
            UseBattery();
            await OperatingSystem.Run();
            OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has just started working", InProgress, HasElectricityConnection, HasNetworkConnection));
        }

        public async Task TurnOff() {
            if (!InProgress)
                throw new HardwareCannotBeStoppedException();
            InProgress = false;
            await OperatingSystem.Stop();
            OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has stopped working", InProgress, HasElectricityConnection, HasNetworkConnection));
        }

        public async Task Connect(IExternalDevice externalDevice) {
            await Task.Run(() => {
                Thread.Sleep(100);
                _externalDevices.Add(externalDevice);
                OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has been successfully connected", InProgress, HasElectricityConnection, HasNetworkConnection));
            });
        }

        public async Task Disconnect(IExternalDevice externalDevice) {
            await Task.Run(() => {
                Thread.Sleep(100);
                if (!_externalDevices.Contains(externalDevice))
                    throw new UnknownDeviceException();
                _externalDevices.Remove(externalDevice);
                OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has been successfully disconnected", InProgress, HasElectricityConnection, HasNetworkConnection));
            });
        }

        private async Task UseBattery() {
            await Task.Run(() => {
                double total;
                while (InProgress) {
                    Thread.Sleep(1000);
                    total = 0d;
                    if (OperatingSystem.InProgress)
                        total += OperatingSystem.PowerUsage;
                    total += CPU.PowerUsage;
                    foreach (IProgram program in OperatingSystem.Programs)
                        if (program.InProgress)
                            total += program.PowerUsage;
                    foreach (IExternalDevice externalDevice in _externalDevices)
                        total += externalDevice.PowerUsage;
                    Battery.Use(total);
                }
            });
        }
    }
}

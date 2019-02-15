using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DOS
{
    public class Laptop : IPortableDevice {
        private List<IExternalDevice> _externalDevices;

        public string Title { get; }
        public bool IsEnabled { get; private set; }
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

        public void TurnOn() {
            if (IsEnabled)
                throw new HardwareCannotBeEnabledException("The device is already in progress");
            IsEnabled = true;
            OperatingSystem.Run();
            if (!HasElectricityConnection)
                StartUsingBattery();
            OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has been enabled", IsEnabled, HasElectricityConnection, HasNetworkConnection));
        }

        private void StartUsingBattery() {
            double total;
            while (IsEnabled) {
                Thread.Sleep(1000);
                total = 0d;
                if (OperatingSystem.IsEnabled)
                    total += OperatingSystem.PowerUsage;
                total += CPU.PowerUsage;
                foreach (IProgram program in OperatingSystem.Programs)
                    if (program.IsEnabled)
                        total += program.PowerUsage;
                foreach (IExternalDevice externalDevice in _externalDevices)
                    total += externalDevice.PowerUsage;
                try {
                    Battery.Use(total);
                }
                catch (BatteryRunOutException e) {
                    TurnOff();
                    throw new BatteryRunOutException(e.Message, e);
                }
            }
        }

        public void TurnOff() {
            if (!IsEnabled)
                throw new HardwareCannotBeDisabledException("The device is already disabled");
            IsEnabled = false;
            OperatingSystem.Stop();
            OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has been disabled", IsEnabled, HasElectricityConnection, HasNetworkConnection));
        }

        public void Connect(IExternalDevice externalDevice) {
            _externalDevices.Add(externalDevice);
            OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has been successfully connected", IsEnabled, HasElectricityConnection, HasNetworkConnection));
        }

        public void Disconnect(IExternalDevice externalDevice) {
            if (!_externalDevices.Contains(externalDevice))
                throw new UnknownHardwareException("Such external device does not exist");
            _externalDevices.Remove(externalDevice);
            OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has been successfully disconnected", IsEnabled, HasElectricityConnection, HasNetworkConnection));
        }
    }
}

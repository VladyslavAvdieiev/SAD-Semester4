using System;
using Simulation.Software;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Simulation.Hardware
{
    public class Laptop : IDevice {
        private List<IProgram> _programs;
        private List<IExternalDevice> _externalDevices;

        public event EventHandler<DeviceEventArgs> OnStatusChanged;
        public event EventHandler<DeviceEventArgs> OnErrorOccurred;

        public string Title { get; }
        public bool InProgress { get; private set; }
        public IOS OS { get; }
        public ICPU CPU { get; }
        public IBattery Battery { get; set; }
        public IInternalMemory RAM { get; }
        public IExternalStorage ExternalStorage { get; }
        public IList<IProgram> Programs { get => _programs.AsReadOnly(); }
        public IList<IExternalDevice> ExternalDevices { get => _externalDevices.AsReadOnly(); }
        public bool HasElectricityConnection { get; set; }
        public bool HasNetworkConnection { get; set; }

        public Laptop(string title, IOS os, ICPU cpu, IBattery battery, IInternalMemory ram, 
            IExternalStorage externalStorage, bool hasElectricityConnection, bool hasNetworkConnection)
        {
            Title = title;
            OS = os;
            CPU = cpu;
            Battery = battery;
            RAM = ram;
            ExternalStorage = externalStorage;
            _programs = new List<IProgram>();
            _externalDevices = new List<IExternalDevice>();
            HasElectricityConnection = hasElectricityConnection;
            HasNetworkConnection = hasNetworkConnection;
        }

        public bool TurnOn() {
            if (InProgress) {
                OnErrorOccurred?.Invoke(this, new DeviceEventArgs("The device is already in progress"));
                return false;
            }
            if (!HasElectricityConnection && Battery == null) {
                OnErrorOccurred?.Invoke(this, new DeviceEventArgs("The electricity connection troubles have just appeared"));
                return false;
            }
            try {
                InProgress = true;
                RAM.UsedSpace = CountRAMUsage();
            }
            catch (ArgumentOutOfRangeException) {
                InProgress = false;
                return false;
            }
            if (!HasElectricityConnection)
                Task.Run(() => UseBattery());
            OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has just started working"));
            return true;
        }

        public bool TurnOff() {
            if (!InProgress) {
                OnErrorOccurred?.Invoke(this, new DeviceEventArgs("The device is not in progress"));
                return false;
            }
            InProgress = false;
            RAM.Format();
            TurnOffPrograms();
            OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has just stopped working"));
            return true;
        }

        private double CountRAMUsage() {
            double total = 0d;
            total += OS.MemoryUsage;
            total += CPU.MemoryUsage;
            foreach (IProgram program in _programs)
                total += program.MemoryUsage;
            return total;
        }

        private void TurnOffPrograms() {
            foreach (IProgram program in _programs)
                if (program.InProgress)
                    program.Stop();
        }

        private void UseBattery() {
            double total = 0d;
            while (InProgress) {
                Thread.Sleep(1000);
                total = 0d;
                total += CPU.PowerUsage;
                foreach (IProgram program in _programs)
                    if (program.InProgress)
                        total += program.PowerUsage;
                foreach (IExternalDevice device in _externalDevices)
                    total += device.PowerUsage;
                try {
                    Battery.FreeCharge -= total;
                }
                catch (ArgumentOutOfRangeException) {
                    TurnOff();
                }
            }
        }

        public bool Install(IProgram program) {
            if (_programs.Contains(program)) {
                OnErrorOccurred?.Invoke(this, new DeviceEventArgs("Such program is already installed"));
                return false;
            }
            try {
                ExternalStorage.UsedSpace += program.Storage;
            }
            catch (ArgumentOutOfRangeException) {
                return false;
            }
            _programs.Add(program);
            OnStatusChanged?.Invoke(this, new DeviceEventArgs("The program has been successfully installed"));
            return true;
        }

        public bool Uninstall(IProgram program) {
            if (!_programs.Contains(program)) {
                OnErrorOccurred?.Invoke(this, new DeviceEventArgs("Such program does not exist"));
                return false;
            }
            ExternalStorage.UsedSpace -= program.Storage;
            _programs.Remove(program);
            OnStatusChanged?.Invoke(this, new DeviceEventArgs("The program has been successfully uninstalled"));
            return true;
        }

        public bool Connect(IExternalDevice externalDevice) {
            if (_externalDevices.Contains(externalDevice)) {
                OnErrorOccurred?.Invoke(this, new DeviceEventArgs("Such device is already connected"));
                return false;
            }
            _externalDevices.Add(externalDevice);
            OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has been successfully connected"));
            return true;
        }

        public bool Disconnect(IExternalDevice externalDevice) {
            if (!_externalDevices.Contains(externalDevice)) {
                OnErrorOccurred?.Invoke(this, new DeviceEventArgs("Such device does not exist"));
                return false;
            }
            _externalDevices.Remove(externalDevice);
            OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has been successfully disconnected"));
            return true;
        }
    }
}

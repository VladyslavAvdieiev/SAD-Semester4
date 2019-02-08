using System;
using Simulation.Software;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class PersonalComputer : IDevice {
        private List<IProgram> _programs;
        private List<IExternalDevice> _externalDevices;

        public event EventHandler<DeviceEventArgs> OnStatusChanged;
        public event EventHandler<DeviceEventArgs> OnErrorOccurred;

        public string Title { get; }
        public bool InProgress { get; private set; }
        public ICPU CPU { get; }
        public IBattery Battery { get; }
        public IInternalMemory RAM { get; }
        public IExternalStorage ExternalStorage { get; }
        public IList<IProgram> Programs { get => _programs.AsReadOnly(); }
        public IList<IExternalDevice> ExternalDevices { get => _externalDevices.AsReadOnly(); }
        public bool HasElectricityConnection { get; set; }
        public bool HasNetworkConnection { get; set; }

        public PersonalComputer(string title, ICPU cpu, IInternalMemory ram, 
            IExternalStorage externalStorage, bool hasElectricityConnection, bool hasNetworkConnection)
        {
            Title = title;
            CPU = cpu;
            RAM = ram;
            ExternalStorage = externalStorage;
            _programs = new List<IProgram>();
            _externalDevices = new List<IExternalDevice>();
            HasElectricityConnection = hasElectricityConnection;
            HasNetworkConnection = hasNetworkConnection;
        }

        public bool TurnOn() {
            throw new NotImplementedException();
            //if (InProgress) {
            //    OnErrorOccurred?.Invoke(this, new DeviceEventArgs("The device is already in progress"));
            //    return false;
            //}
            //if (!HasElectricityConnection) {
            //    OnErrorOccurred?.Invoke(this, new DeviceEventArgs("The electricity connection troubles have just appeared"));
            //    return false;
            //}
            //try {
            //    InProgress = true;
            //    RAM.UsedSpace = CountRAMUsage();
            //}
            //catch (ArgumentOutOfRangeException) {
            //    InProgress = false;
            //    return false;
            //}
            //OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has just started working"));
            //return true;
        }

        public bool TurnOff() {
            throw new NotImplementedException();
            //if (!InProgress) {
            //    OnErrorOccurred?.Invoke(this, new DeviceEventArgs("The device is not in progress"));
            //    return false;
            //}
            //InProgress = false;
            //TurnOffPrograms();
            //RAM.Format();
            //OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has just stopped working"));
            //return true;
        }

        private double CountRAMUsage() {
            throw new NotImplementedException();
            //double total = 0d;
            //total += OS.MemoryUsage;
            //total += CPU.MemoryUsage;
            //foreach (IProgram program in _programs)
            //    if (program.InProgress)
            //        total += program.MemoryUsage;
            //return total;
        }

        private void TurnOffPrograms() {
            throw new NotImplementedException();
            //foreach (IProgram program in _programs)
            //    if (program.InProgress)
            //        program.Stop();
        }

        public bool Install(IProgram program) {
            throw new NotImplementedException();
            //if (_programs.Contains(program)) {
            //    OnErrorOccurred?.Invoke(this, new DeviceEventArgs("Such program is already installed"));
            //    return false;
            //}
            //try {
            //    ExternalStorage.UsedSpace += program.Storage;
            //}
            //catch (ArgumentOutOfRangeException) {
            //    return false;
            //}
            //_programs.Add(program);
            //OnStatusChanged?.Invoke(this, new DeviceEventArgs("The program has been successfully installed"));
            //return true;
        }

        public bool Uninstall(IProgram program) {
            throw new NotImplementedException();
            //if (!_programs.Contains(program)) {
            //    OnErrorOccurred?.Invoke(this, new DeviceEventArgs("Such program does not exist"));
            //    return false;
            //}
            //ExternalStorage.UsedSpace -= program.Storage;
            //_programs.Remove(program);
            //OnStatusChanged?.Invoke(this, new DeviceEventArgs("The program has been successfully uninstalled"));
            //return true;
        }

        public bool Connect(IExternalDevice externalDevice) {
            throw new NotImplementedException();
            //if (_externalDevices.Contains(externalDevice)) {
            //    OnErrorOccurred?.Invoke(this, new DeviceEventArgs("Such device is already connected"));
            //    return false;
            //}
            //_externalDevices.Add(externalDevice);
            //OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has been successfully connected"));
            //return true;
        }

        public bool Disconnect(IExternalDevice externalDevice) {
            throw new NotImplementedException();
            //if (!_externalDevices.Contains(externalDevice)) {
            //    OnErrorOccurred?.Invoke(this, new DeviceEventArgs("Such device does not exist"));
            //    return false;
            //}
            //_externalDevices.Remove(externalDevice);
            //OnStatusChanged?.Invoke(this, new DeviceEventArgs("The device has been successfully disconnected"));
            //return true;
        }
    }
}

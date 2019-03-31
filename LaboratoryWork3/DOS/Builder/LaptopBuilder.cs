using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class LaptopBuilder : PortableDeviceBuilder {
        private Laptop _laptop;

        public LaptopBuilder() {
            _laptop = new Laptop();
        }

        public override DeviceBuilder Title(string title) {
            _laptop.Title = title;
            return this;
        }

        public override DeviceBuilder CPU(ICPU cpu) {
            _laptop.CPU = cpu;
            _laptop.CPU.AddOwner(_laptop);
            return this;
        }

        public override PortableDeviceBuilder Battery(IBattery battery) {
            _laptop.Battery = battery;
            _laptop.Battery.AddOwner(_laptop);
            return this;
        }

        public override DeviceBuilder RAM(IInternalMemory ram) {
            _laptop.RAM = ram;
            return this;
        }

        public override DeviceBuilder ExternalStorage(IExternalStorage externalStorage) {
            _laptop.ExternalStorage = externalStorage;
            return this;
        }

        public override DeviceBuilder OperatingSystem(IOperatingSystem operatingSystem) {
            _laptop.OperatingSystem = operatingSystem;
            _laptop.OperatingSystem.AddOwner(_laptop);
            return this;
        }

        public override DeviceBuilder HasElectricityConnection(bool hasElectricityConnection) {
            _laptop.HasElectricityConnection = hasElectricityConnection;
            return this;
        }

        public override DeviceBuilder HasNetworkConnection(bool hasNetworkConnection) {
            _laptop.HasNetworkConnection = hasNetworkConnection;
            return this;
        }

        public override IDevice Build() {
            _laptop.ExternalStorage.Load(_laptop.OperatingSystem.NeededStorage);
            return _laptop;
        }
    }
}

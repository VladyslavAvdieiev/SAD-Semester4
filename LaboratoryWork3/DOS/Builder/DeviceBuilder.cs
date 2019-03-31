using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public abstract class DeviceBuilder {
        public abstract DeviceBuilder Title(string title);
        public abstract DeviceBuilder CPU(ICPU cpu);
        public abstract DeviceBuilder RAM(IInternalMemory ram);
        public abstract DeviceBuilder ExternalStorage(IExternalStorage externalStorage);
        public abstract DeviceBuilder OperatingSystem(IOperatingSystem operatingSystem);
        public abstract DeviceBuilder HasElectricityConnection(bool hasElectricityConnection);
        public abstract DeviceBuilder HasNetworkConnection(bool hasNetworkConnection);
        public abstract IDevice Build();
    }
}

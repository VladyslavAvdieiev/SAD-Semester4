using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public abstract class PortableDeviceBuilder : DeviceBuilder {
        public abstract PortableDeviceBuilder Battery(IBattery battery);
    }
}

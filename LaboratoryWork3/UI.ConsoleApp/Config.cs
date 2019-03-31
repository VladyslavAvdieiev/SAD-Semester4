using System;
using DOS;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ConsoleApp
{
    public static class Config {

        public static IEnumerable<Battery> GetBatteries() {
            return new Battery[] {
                new Battery(title: "Asus", capacity: 5200),
                new Battery(title: "Samsung", capacity: 5200),
                new Battery(title: "Lenovo", capacity: 4400),
                new Battery(title: "HP", capacity: 2200)
            };
        }

        public static IEnumerable<CPU> GetCPUs() {
            return new CPU[] {
                new CPU(title: "Intel Core I3", cores: 4, frequency: 3.6, memoryUsage: 0.3),
                new CPU(title: "Intel Core I5", cores: 6, frequency: 2.8, memoryUsage: 0.3),
                new CPU(title: "Intel Core I7", cores: 6, frequency: 3.2, memoryUsage: 0.5),
                new CPU(title: "Intel Core I9", cores: 8, frequency: 3.6, memoryUsage: 1),
            };
        }

        public static IEnumerable<RAM> GetRAMs() {
            return new RAM[] {
                new RAM(title: "Kingstone", capacity: 4.096),
                new RAM(title: "HyperX", capacity: 4.096),
                new RAM(title: "Kingstone", capacity: 8.192),
                new RAM(title: "HyperX", capacity: 8.192),
            };
        }

        public static IEnumerable<SSD> GetSSDs() {
            return new SSD[] {
                new SSD(title: "Kingstone", capacity: 120),
                new SSD(title: "Kingstone", capacity: 240),
                new SSD(title: "Samsung", capacity: 250),
                new SSD(title: "Samsung", capacity: 500)
            };
        }

        public static IEnumerable<DOS.OperatingSystem> GetOperatingSystems() {
            return new DOS.OperatingSystem[] {
                new DOS.OperatingSystem(title: "Windows XP", powerUsage: 5, memoryUsage: 1.2, neededStorage: 15),
                new DOS.OperatingSystem(title: "Windows 7", powerUsage: 6, memoryUsage: 1, neededStorage: 22),
                new DOS.OperatingSystem(title: "Windows 10", powerUsage: 7, memoryUsage: 1.5, neededStorage: 25)
            };
        }

        public static IEnumerable<DOS.Program> GetPrograms() {
            return new DOS.Program[] {
                new DOS.Program(title: "GTA 5", needsNetworkConnection: true, powerUsage: 10, memoryUsage: 1, neededStorage: 62),
                new DOS.Program(title: "Womrs", needsNetworkConnection: false, powerUsage: 2, memoryUsage: 0.5, neededStorage: 2),
                new DOS.Program(title: "Word", needsNetworkConnection: false, powerUsage: 2, memoryUsage: 0.5, neededStorage: 8),
                new DOS.Program(title: "Visual Studio 2017", needsNetworkConnection: false, powerUsage: 8, memoryUsage: 0.3, neededStorage: 32),
            };
        }

        public static IEnumerable<ExternalDevice> GetExternalDevices() {
            return new ExternalDevice[] {
                new ExternalDevice(title: "Headphones", powerUsage: 0.2),
                new ExternalDevice(title: "Microphone", powerUsage: 0.2),
                new ExternalDevice(title: "Web camera", powerUsage: 0.2),
                new ExternalDevice(title: "Printer", powerUsage: 0.2)
            };
        }
    }
}

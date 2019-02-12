using System;
using Simulation.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class HDD : IExternalStorage {
        private double _usedSpace;

        public string Title { get; }
        public double Capacity { get; }
        public double UsedSpace {
            get => _usedSpace;
            private set {
                if (value < 0d)
                    throw new DriveIsEmptyException("The drive is already empty");
                if (value > Capacity)
                    throw new NotEnoughMemoryException("There is not enough memory");
                _usedSpace = value;
            }
        }

        public event EventHandler<MemoryEventArgs> OnSpaceChanged;

        public HDD(string title, double capacity) {
            Title = title;
            Capacity = capacity;
        }

        public async Task Load(double space) {
            await Task.Run(() => {
                Thread.Sleep(100 * (int)space);
                UsedSpace += space;
                OnSpaceChanged?.Invoke(this, new MemoryEventArgs("The drive has been loaded", Title, Capacity, UsedSpace));
            });
        }

        public async Task Unload(double space) {
            await Task.Run(() => {
                Thread.Sleep(100 * (int)space);
                UsedSpace -= space;
                OnSpaceChanged?.Invoke(this, new MemoryEventArgs("The drive has been unloaded", Title, Capacity, UsedSpace));
            });
        }

        public async Task Format() {
            await Task.Run(() => {
                Thread.Sleep(100 * (int)UsedSpace);
                UsedSpace = 0d;
                OnSpaceChanged?.Invoke(this, new MemoryEventArgs("The drive has been formatted", Title, Capacity, UsedSpace));
            });
        }
    }
}

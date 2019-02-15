using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS.Hardware.Memory
{
    public class SSD : IExternalStorage {
         private double _usedSpace;

        public string Title { get; }
        public double Capacity { get; }
        public double UsedSpace {
            get => _usedSpace;
            private set {
                if (value < 0d)
                    throw new DriveIsEmptyException("The drive is already empty");
                if (value > Capacity)
                    throw new NotEnoughMemoryException("The drive has not enough memory");
                _usedSpace = value;
            }
        }

        public event EventHandler<MemoryEventArgs> OnSpaceChanged;

        public SSD(string title, double capacity) {
            Title = title;
            Capacity = capacity;
        }

        public void Load(double space) {
            UsedSpace += space;
            OnSpaceChanged?.Invoke(this, new MemoryEventArgs("The drive has been loaded", Title, Capacity, UsedSpace));
        }

        public void Unload(double space) {
            UsedSpace -= space;
            OnSpaceChanged?.Invoke(this, new MemoryEventArgs("The drive has been unloaded", Title, Capacity, UsedSpace));
        }

        public void Format() {
            UsedSpace = 0d;
            OnSpaceChanged?.Invoke(this, new MemoryEventArgs("The drive has been disposed", Title, Capacity, UsedSpace));
        }
    }
}

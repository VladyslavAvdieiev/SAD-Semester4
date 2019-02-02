using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class Battery : IBattery {
        private double _freeCharge;

        public event EventHandler<BatteryEventArgs> OnChargeChanged;
        public event EventHandler<BatteryEventArgs> OnErrorOccurred;

        public string Title { get; }
        public double Capacity { get; }
        public double Percentage { get => 100 * FreeCharge / Capacity; }
        public double FreeCharge {
            get => _freeCharge;
            set {
                if (value < 0 || value > Capacity) {
                    OnErrorOccurred?.Invoke(this, new BatteryEventArgs("Battery run out"));
                    throw new ArgumentOutOfRangeException();
                }
                OnChargeChanged?.Invoke(this, new BatteryEventArgs("Charge has been changed"));
                _freeCharge = value;
            }
        }

        public Battery(string title, double capacity) {
            Title = title;
            Capacity = capacity;
            FreeCharge = capacity;
        }

        public bool Charge() {
            if (IsFull()) {
                OnErrorOccurred?.Invoke(this, new BatteryEventArgs("The battery is full"));
                return false;
            }
            FreeCharge = Capacity;
            OnChargeChanged?.Invoke(this, new BatteryEventArgs("The battery has been charged"));
            return true;
        }

        private bool IsFull() {
            return FreeCharge == Capacity;
        }
    }
}

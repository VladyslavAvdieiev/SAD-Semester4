using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public class Battery : IBattery {
        private double _currentCharge;

        public string Title { get; }
        public double Capacity { get; }
        public double CurrentCharge {
            get => _currentCharge;
            private set {
                if (value < 0d)
                    throw new BatteryRunOutException("The battery has just run out");
                if (value > Capacity)
                    value = Capacity;
                _currentCharge = value;
            }
        }

        public event EventHandler<BatteryEventArgs> OnChargeChanged;

        public Battery(string title, double capacity) {
            Title = title;
            Capacity = capacity;
            CurrentCharge = Capacity;
        }

        public void Use(double charge) {
            CurrentCharge -= charge;
            OnChargeChanged?.Invoke(this, new BatteryEventArgs("Charge has been changed", Title, Capacity, CurrentCharge));
        }

        public void Charge() {
            CurrentCharge = Capacity;
            OnChargeChanged?.Invoke(this, new BatteryEventArgs("The battery has been charged", Title, Capacity, CurrentCharge));
        }
    }
}

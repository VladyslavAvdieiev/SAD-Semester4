using System;
using Simulation.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class Battery : IBattery {
        private IDevice _owner;
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

        public Battery(string title, double capacity, IDevice owner) {
            Title = title;
            Capacity = capacity;
            CurrentCharge = Capacity;
            _owner = owner;
        }

        public void Use(double charge) {
            CurrentCharge -= charge;
            OnChargeChanged?.Invoke(this, new BatteryEventArgs("Charge has been changed", Title, Capacity, CurrentCharge));
        }

        public async Task Charge() {
            await Task.Run(() => {
                while (CurrentCharge != Capacity) {
                    Thread.Sleep(1000);
                    if (!_owner.HasElectricityConnection)
                        throw new NoElectricityConnectionException("There is no electricity connection");
                    CurrentCharge += 100d;
                }
                OnChargeChanged?.Invoke(this, new BatteryEventArgs("The battery has been charged", Title, Capacity, CurrentCharge));
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simulation.Hardware
{
    public class Battery : IBattery {
        public string Title { get; }
        public double Capacity { get; }
        public double CurrentCharge { get; private set; }

        public event EventHandler<BatteryEventArgs> OnChargeChanged;

        public Battery(string title, double capacity) {
            Title = title;
            Capacity = capacity;
            CurrentCharge = Capacity;
        }

        public void Use(int charge) {
            CurrentCharge -= charge;
            if (CurrentCharge < 0d) {
                CurrentCharge = 0d;
                throw new Exception();
            }
            OnChargeChanged?.Invoke(this, new BatteryEventArgs("Charge has been changed", Capacity, CurrentCharge));
        }

        public async Task Charge() {
            await Task.Run(() => {
                while (CurrentCharge < Capacity) {
                    Thread.Sleep(1000);
                    CurrentCharge += 100d;
                }
                CurrentCharge = Capacity;
                OnChargeChanged?.Invoke(this, new BatteryEventArgs("The battery has been charged", Capacity, CurrentCharge));
            });
        }
    }
}

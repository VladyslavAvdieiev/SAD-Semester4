using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS
{
    public interface IBattery {
        string Title { get; }
        double Capacity { get; }
        double CurrentCharge { get; }
        void Use(double charge);
        void Charge();
    }
}

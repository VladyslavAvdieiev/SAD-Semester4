using System;
using Simulation.Hardware;
using Simulation.Software;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.ConsoleApp
{
    class Program {

        static void Main(string[] args) {
            IDevice pc = new PersonalComputer("PC",
                new OS("Windows", 1),
                new CPU("Intel", 4, 2.8, 0.5),
                new RAM("HyperX", 8),
                new SSD("Samsung", 256),
                true,
                true);

            ((PersonalComputer)pc).OnStatusChanged += (sender, e) => Console.WriteLine(sender.ToString() + e.Message);
            ((PersonalComputer)pc).OnErrorOccurred += (sender, e) => Console.WriteLine(e.Message);
            ((SSD)pc.ExternalStorage).OnSpaceChanged += (sender, e) => Console.WriteLine(e.Message);
            ((SSD)pc.ExternalStorage).OnErrorOccurred += (sender, e) => Console.WriteLine(e.Message);
            ((RAM)pc.RAM).OnSpaceChanged += (sender, e) => Console.WriteLine(e.Message);
            ((RAM)pc.RAM).OnErrorOccurred += (sender, e) => Console.WriteLine(e.Message);

            IProgram gta = new Simulation.Software.Program("GTA 5", true, 0.5, 2, 60, pc);
            IProgram word = new Simulation.Software.Program("Word", false, 0.2, 0.2, 2, pc);

            ((Simulation.Software.Program)gta).OnStatusChanged += (sender, e) => Console.WriteLine(e.Message);
            ((Simulation.Software.Program)gta).OnErrorOccurred += (sender, e) => Console.WriteLine(e.Message);

            pc.Install(gta);
            pc.Install(word);
            pc.Connect(new ExternalDevice("Headphones", 0.5));
            pc.Connect(new ExternalDevice("Headphones", 0.5));

            pc.TurnOn();

            pc.Programs[0].Start();

            pc.TurnOff();

            Console.ReadLine();
        }
    }
}

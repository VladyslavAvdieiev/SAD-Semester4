using System;
using DOS;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace UI.ConsoleApp
{
    class Program {

        static void Main(string[] args) {

            Laptop laptop = CreateLaptop();
            SignForEvents(laptop);
            DisplayStatus(laptop);

            Console.ReadLine();
            laptop.TurnOn();

            Console.ReadLine();
            laptop.OperatingSystem.Programs[3].Run();

            Console.ReadLine();
            laptop.TurnOff();

            Console.ReadLine();
        }

        static Laptop CreateLaptop() {
            Battery battery = Config.GetBatteries().ElementAt(SelectComponent("Select Battery:", Config.GetBatteries()));
            CPU cpu = Config.GetCPUs().ElementAt(SelectComponent("Select CPU:", Config.GetCPUs()));
            RAM ram = Config.GetRAMs().ElementAt(SelectComponent("Select RAM:", Config.GetRAMs()));
            SSD ssd = Config.GetSSDs().ElementAt(SelectComponent("Select SSD:", Config.GetSSDs()));
            DOS.OperatingSystem os = Config.GetOperatingSystems().ElementAt(SelectComponent("Select OS:", Config.GetOperatingSystems()));

            bool electricity = SelectFlag("Will new laptop have an electricity connection?[y / n]: ");
            bool network = SelectFlag("Will new laptop have an network connection?[y / n]: ");

            Console.Write("Name of laptop: ");
            Laptop laptop = new Laptop(Console.ReadLine(), cpu, battery, ram, ssd, os, electricity, network);

            foreach (DOS.Program program in Config.GetPrograms())
                laptop.OperatingSystem.Install(program);
            return laptop;
        }

        static bool SelectFlag(string message) {
            Console.Write(message);
            string input = Console.ReadLine();
            if (IsCorrect(input))
                if (input == "y")
                    return true;
                else
                    return false;
            return SelectFlag("Wrong input. Try again: ");
        }

        static int SelectComponent<T>(string message, IEnumerable<T> array) {
            Console.WriteLine(message);
            Print(array);
            string input = Console.ReadLine();
            if (IsCorrect(input, array.Count()))
                return int.Parse(input);
            return SelectComponent("Wrong input. Try again:", array);
        }

        static bool IsCorrect(string input, int boundary) {
            if (int.TryParse(input, out int output))
                if (output >= 0 && output < boundary)
                    return true;
            return false;
        }

        static bool IsCorrect(string input) {
            if (input == "y" || input == "n")
                return true;
            return false;
        }

        static void Print<T>(IEnumerable<T> array) {
            for (int i = 0; i < array.Count(); i++)
                Console.WriteLine($"{i}. {array.ElementAt(i)}");
        }

        static void SignForEvents(Laptop laptop) {
            laptop.OnStatusChanged += (sender, e) => DisplayStatus(laptop);
            ((DOS.OperatingSystem)laptop.OperatingSystem).OnStatusChanged += (sender, e) => DisplayStatus(laptop);
            ((CPU)laptop.CPU).OnStatusChanged += (sender, e) => DisplayStatus(laptop);
            ((Battery)laptop.Battery).OnChargeChanged += (sender, e) => DisplayStatus(laptop);
            ((RAM)laptop.RAM).OnSpaceChanged += (sender, e) => DisplayStatus(laptop);
            ((SSD)laptop.ExternalStorage).OnSpaceChanged += (sender, e) => DisplayStatus(laptop);
            foreach (DOS.Program program in laptop.OperatingSystem.Programs)
                program.OnStatusChanged += (sender, e) => DisplayStatus(laptop);
        }

        static void DisplayStatus(Laptop laptop) {
            Console.Clear();
            Console.WriteLine($"Title:              {laptop.Title}");
            Console.WriteLine($"Device status:      {(laptop.IsEnabled ? "ON" : "OFF")}");
            Console.WriteLine($"OS status:          {(laptop.OperatingSystem.IsEnabled ? "ON" : "OFF")}");
            Console.WriteLine($"CPU status:         {(laptop.CPU.IsEnabled ? "ENABLED" : "DISABLED")}");
            Console.WriteLine($"Battery charge:     {laptop.Battery.CurrentCharge} mAh");
            Console.WriteLine($"RAM used space:     {laptop.RAM.UsedSpace} GB");
            Console.WriteLine($"SSD used space:     {laptop.ExternalStorage.UsedSpace} GB");
            Console.WriteLine($"Network status:     {(laptop.HasNetworkConnection ? "CONNECTED" : "DISCONNECTED")}");
            Console.WriteLine($"Electricity status: {(laptop.HasElectricityConnection ? "CONNECTED" : "DISCONNECTED")}");
            Console.WriteLine("Installed programs:");
            int i = 9;
            foreach (DOS.Program program in laptop.OperatingSystem.Programs) {
                Console.SetCursorPosition(20, i++);
                Console.Write($"{program.Title}: {(program.IsEnabled ? "ON" : "OFF")}");
            }
        }
    }
}

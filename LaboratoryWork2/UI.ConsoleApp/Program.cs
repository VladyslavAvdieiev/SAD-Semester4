using System;
using FileCreation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UI.ConsoleApp
{
    class Program {

        static void Main(string[] args) {

            Console.Write("Enter name of file: ");
            string name = Console.ReadLine();

            string[] variants = new string[] { "txt", "jpeg", "docx", "rtf" };
            FileNameCreator[] creators = new FileNameCreator[] { new TxtFileNameCreator(name),
                                                                 new JpegFileNameCreator(name),
                                                                 new DocxFileNameCreator(name),
                                                                 new RtfFileNameCreator(name) };

            int selection = SelectCreator(variants);

            FileCreator.Create(creators[selection]);
            Console.Write("File was created successfully");

            Console.ReadLine();
        }

        static int SelectCreator(string[] variants) {
            Console.WriteLine("Select type of file:");
            for (int i = 0; i < variants.Length; i++)
                Console.WriteLine($"{i} {variants[i]}");
           return Convert.ToInt32(Console.ReadLine());
        }
    }
}

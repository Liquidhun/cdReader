using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace readCd
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            string dir = @"R:\"; //CD meghajtó betűjele
            string newDriver = @"D:\TESZT"; //a célmeghajtó betűjele
            bool firstRun = true;
            string cdNumber;
            cdNumber = "";
            ConfigurationSettings.GetConfig("CD_ROM");
            //Saving file as backup
            //string sourceFile = Path.Combine("", "test.txt");
            //string destFile = System.IO.Path.Combine(".", "test.txt");
            //string randomName = DateTime.Today;
            Console.WriteLine();
            Console.ReadKey();
            while (true)
            {
                Console.Clear();
                if (firstRun || cdNumber=="")
                {
                    Console.WriteLine("Add meg a CD sorszámát, vagy nyomj q betűt a kilépéshez:");
                    firstRun = false;
                }
                else
                {
                    Console.WriteLine("Sikeresen feldolgozva. Add meg a következő CD sorszámát, vagy nyomj q betűt a kilépéshez:");
                }
                cdNumber = Console.ReadLine();
                if (cdNumber.ToLower() == "q")
                {
                    break;
                }
                if (cdNumber != "")
                {
                    Reader reader = new Reader(dir, newDriver, cdNumber);
                    StringBuilder sb = new StringBuilder();
                    timer.Start();
                    reader.readAll(dir, sb, newDriver);
                    timer.Stop();
                    using (StreamWriter sw = new StreamWriter(new FileStream(@"list.txt", FileMode.Append)))
                    {
                        sw.Write(sb.ToString());
                    }
                    Console.WriteLine(timer.Elapsed.TotalSeconds + " másodperc alatt futott le.");
                    //Console.ReadKey();
                }
                //else Console.Clear();

            }
        }
    }
}
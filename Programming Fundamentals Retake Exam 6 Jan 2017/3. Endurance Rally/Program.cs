using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Endurance_Rally
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            List<string> names = Console.ReadLine().Split(' ').ToList();
            List<double> zones = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            List<int> checkPoints = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            foreach (string driver in names)
            {
                double fuel = (int)driver.First();
                for (int i = 0; i < zones.Count; i++)
                {
                    if (checkPoints.Contains(i))
                    {
                        fuel += zones[i];
                    }
                    else
                    {
                        fuel -= zones[i];
                    }
                    if (fuel <= 0)
                    {
                        Console.WriteLine($"{driver} - reached {i}");
                        break;
                    }
                }
                if (fuel > 0.0)
                {
                    Console.WriteLine($"{driver} - fuel left {fuel:f2}");
                }
            }
        }
    }
}
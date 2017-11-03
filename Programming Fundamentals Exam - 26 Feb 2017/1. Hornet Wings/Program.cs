using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Hornet_Wings
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            double M = double.Parse(Console.ReadLine());
            int endurance = int.Parse(Console.ReadLine());

            double distance = (N / 1000.0) * M;

            int wigsPerTime = N / 100;
            int seconds = (int)(N / endurance) * 5;
            seconds += wigsPerTime;

            Console.WriteLine($"{distance:f2} m.");
            Console.WriteLine($"{seconds} s.");

        }
    }
}

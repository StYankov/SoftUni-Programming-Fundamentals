using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Charity_Marathon
{
    class Program
    {
        static void Main(string[] args)
        {
            int marathonDays = int.Parse(Console.ReadLine());
            int runners = int.Parse(Console.ReadLine());
            int laps = int.Parse(Console.ReadLine());
            int lapLength = int.Parse(Console.ReadLine());
            int trackCapaticy = int.Parse(Console.ReadLine());
            double moneyPerKm = double.Parse(Console.ReadLine());

            long totalCapacity = trackCapaticy * marathonDays;
            long totalRunners = (runners > totalCapacity) ? totalCapacity : runners;

            long totalMeters = laps * totalRunners * lapLength;
            long totalKm = totalMeters / 1000; // can be decimal

            decimal totalMoneyRaised = (decimal)moneyPerKm * totalKm;

            Console.WriteLine($"Money raised: {totalMoneyRaised:f2}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Centuries_to_Nanoseconds
{
    class Program
    {
        static void Main(string[] args)
        {
            const double daysInYear = 365.2422d;

            int centuries = int.Parse(Console.ReadLine());

            int years = centuries * 100;
            int days = (int)(daysInYear * years);
            int hours = days * 24;
            long minutes = hours * 60;
            long seconds = minutes * 60;
            decimal ms = seconds * 1000;
            decimal microsec = ms * 1000;
            decimal ns = microsec * 1000;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {ms} milliseconds = {microsec} microseconds = {ns} nanoseconds");
        }
    }
}

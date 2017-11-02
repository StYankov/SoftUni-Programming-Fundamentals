using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            int timeinSeconds = (hours * 60 * 60) + (minutes * 60) + seconds;

            float ms = distance / (float)timeinSeconds;
            float kmh = ms * 36 / 10;
            float mileS = kmh / 1.609f;

            Console.WriteLine(ms);
            Console.WriteLine(kmh);
            Console.WriteLine(mileS);
        }
    }
}

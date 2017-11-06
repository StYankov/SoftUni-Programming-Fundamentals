using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Sino_The_Walker
{
    class Program
    {
        static void Main(string[] args)
        {
            string leaveTime = Console.ReadLine();
            int numberOfSteps = int.Parse(Console.ReadLine());
            int timePerStep = int.Parse(Console.ReadLine());

            var timeSplit = leaveTime.Split(':');
            long hours = long.Parse(timeSplit[0]);
            long minutes = long.Parse(timeSplit[1]);
            long seconds = long.Parse(timeSplit[2]);

            long totalSeconds = (long)numberOfSteps * timePerStep + seconds;
            if (totalSeconds >= 60L)
            {
                seconds = totalSeconds % 60;
            }
            else
            {
                seconds = totalSeconds;
            }

            long reminder = totalSeconds / 60L + minutes;

            if (reminder >= 60)
            {
                minutes = reminder % 60;
            }
            else
            {
                minutes = reminder;
            }

            long hoursReminder = reminder / 60 + hours;

            if (hoursReminder >= 24)
            {
                hours = hoursReminder % 24;
            }
            else
            {
                hours = hoursReminder;
            }

            Console.WriteLine($"Time Arrival: {hours:d2}:{minutes:d2}:{seconds:d2}");

        }
    }
}
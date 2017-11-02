using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int totalLifts = 0;
            totalLifts = (int)Math.Ceiling((double)numberOfPeople / capacity);
            Console.WriteLine(totalLifts);
        }
    }
}

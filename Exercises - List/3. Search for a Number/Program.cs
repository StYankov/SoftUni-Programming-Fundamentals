using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Search_for_a_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int[] commands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<int> newArr = arr.Take(commands[0]).ToList();
            newArr = newArr.Skip(commands[1]).ToList();

            if(newArr.Find(x => x == commands[2]) != 0)
            {
                Console.WriteLine("YES!");
            }
            else Console.WriteLine("NO!");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Sum_reversed_Numbers
{
    class Program
    {
        static int reverse(int n)
        {
            int temp = 0;
            while (n != 0)
            {
                temp *= 10;
                temp += n % 10;
                n /= 10;
            }

            return temp;
        }

        static void Main(string[] args)
        {
            List<int> arr = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int sum = 0;

            foreach(var i in arr)
            {
                sum += reverse(i);
            }
            Console.WriteLine(sum);

        }
    }
}

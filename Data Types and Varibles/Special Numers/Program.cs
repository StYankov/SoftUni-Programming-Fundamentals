using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Numers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for(int i = 1; i <= n; i++)
            {
                int currentSum = sumOfDigits(i);
                if(currentSum == 5 || currentSum == 7 || currentSum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }

        static int sumOfDigits(int n)
        {
            int sumDigits = 0;
            while(n != 0)
            {
                sumDigits += n % 10;
                n /= 10;
            }
            return sumDigits;
        }
    }
}

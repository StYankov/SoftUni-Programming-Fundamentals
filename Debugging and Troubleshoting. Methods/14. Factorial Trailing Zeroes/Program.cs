using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _14.Factorial_Trailing_Zeroes
{
    class Program
    {
        
        static int TrailingZeroes(BigInteger n)
        {
            int count = 0;
            while(n > 0)
            {
                if (n % 10 == 0)
                {
                    count++;
                    n /= 10;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger f = 1;
            for (int i = 1; i <= n; i++)
            {
                f *= i;
            }
            Console.WriteLine(TrailingZeroes(f));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_Numbers
{
    class Program
    {
        static int Reverse(int n)
        {
            int result = 0;
            while(n > 0)
            {
                result *= 10;
                result += n % 10;
                n /= 10;
            }
            return result;
        }

        static bool isSymetric(int n)
        {
            return n == Reverse(n);
        }

        static bool divBy7(int n)
        {
            int sum = 0;
            while(n > 0)
            {
                sum += n % 10;
                n /= 10;
            }

            return sum % 7 == 0;
        }

        static bool hasEven(int n)
        {
            while(n > 0)
            {
                if ((n % 10) % 2 == 0) return true;
                n /= 10;
            }
            return false;
        }

        static void inRange( int max)
        {
            for(int i = 1; i <= max; i++)
            {
                if(isSymetric(i) && hasEven(i) && divBy7(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void Main(string[] args)
        {
            int max = int.Parse(Console.ReadLine());
            inRange(max);
        }
    }
}

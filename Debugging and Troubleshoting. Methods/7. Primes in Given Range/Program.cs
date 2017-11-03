using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Primes_in_Given_Range
{
    class Program
    {
        static bool IsPrime(long n)
        {
            if (n <= 1) return false;
            for (long i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            List<int> result = new List<int>();
            for(int i = startNum; i <= endNum; i++)
            {
                if (IsPrime(i))
                    result.Add(i);
            }
            return result;
        }

        static void Main(string[] args)
        {
            int min = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());

            Console.WriteLine(String.Join(", ", FindPrimesInRange(min, max)));
        }
    }
}

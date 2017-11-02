using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Sieve_of_Erathosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            bool[] sieve = Enumerable.Repeat(true, n + 1).ToArray();
            sieve[0] = false;
            sieve[1] = false;

            for(int i = 2; i <= n; i++)
            {
                if(sieve[i] == true)
                {
                    for (int j = 2 * i; j <= n; j += i)
                    {
                        sieve[j] = false;
                    }
                }
            }

            for(int i = 2; i <= n; i++)
            {
                if(sieve[i] == true)
                    Console.Write(i + " ");
            }

        }
    }
}

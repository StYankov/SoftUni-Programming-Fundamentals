using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());

            int pokeCount = 0;
            int originalN = N;
            int fiftyPercent = N / 2;

            while(N >= M)
            {
                N -= M;
                if(Y != 0 && N != 0 && N == fiftyPercent)
                {
                    N /= Y;
                }
                pokeCount++;
            }

            Console.WriteLine(N);
            Console.WriteLine(pokeCount);
        }
    }
}

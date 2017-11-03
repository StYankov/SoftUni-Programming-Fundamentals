using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Fibonacci_Numbers
{
    class Program
    {

        static long getFib(int n)
        {
            long f0 = 0;
            long f1 = 1;
            for(int i = 1; i <= n; i++)
            {
                long temp = f1;
                f1 = f1 + f0;
                f0 = temp;
            }
            return f1;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(getFib(n));
        }
    }
}

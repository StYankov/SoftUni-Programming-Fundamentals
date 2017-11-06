using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            string[] b = Console.ReadLine().Split(' ');

            int rightA = a.Length;
            int rightB = b.Length;
            int rightCommmon = 0;
            while(rightA > 0 && rightB > 0)
            {
                if (a[--rightA] == b[--rightB]) rightCommmon++;
            }

            int leftCommon = 0;
            for(int i = 0; i < a.Length && i < b.Length; i++)
            {
                if (a[i] == b[i]) leftCommon++;
            }

            Console.WriteLine(Math.Max(leftCommon, rightCommmon));
        }
    }
}

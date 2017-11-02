using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string seq = Console.ReadLine();

            for(int i = 0; i < seq.Length; i++)
            {
                Console.WriteLine($"{seq[i]} -> {(int)(seq[i] - 97)}");
            }
        }
    }
}

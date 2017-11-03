using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Numbers_in_Reverse_Order
{
    class Program
    {
        static string StringReverse(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            Console.WriteLine(StringReverse(number));
        }
    }
}

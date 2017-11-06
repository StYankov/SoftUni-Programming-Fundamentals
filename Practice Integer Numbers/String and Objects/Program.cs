using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_and_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            object res = str1 + ' ' + str2;
            string result = Convert.ToString(res);
            Console.WriteLine(result);
        }
    }
}

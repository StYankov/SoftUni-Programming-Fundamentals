using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Vowel_or_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch = Console.ReadLine()[0];
            int asciiNum = (int)ch;
            
            if(ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
            {
                Console.WriteLine("vowel");
                return;
            }

            if(asciiNum >= '0' && asciiNum <= '9')
            {
                Console.WriteLine("digit");
                return;
            }

            Console.WriteLine("other");
        }
    }
}

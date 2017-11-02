using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.Different_Integers_SIze
{
    class Program
    {
        static void Main(string[] args)
        {
            long n;
            string str = "";
            try
            {
                str = Console.ReadLine();
                n = long.Parse(str);
            }
            catch
            {
                Console.WriteLine($"{str} can't fit in any type");
                return;
            }

            Console.WriteLine($"{n} can fit in");
            if (n >= -128 && n <= 127)
                Console.WriteLine($"* sbyte");
            if (n >= 0 && n <= 255)
                Console.WriteLine($"* byte");
            if (n >= -32768 && n <= 32767)
                Console.WriteLine("* short");
            if (n >= 0 && n <= 65535)
                Console.WriteLine("* ushort");
            if(n >= -2147483648 && n <= 2417483647)
                Console.WriteLine("* int");
            if(n >= 0  && n <= 4294967295)
                Console.WriteLine("* uint");
            if(n >= long.MinValue && n <= long.MaxValue)
                Console.WriteLine("* long"); 
            
        }
    }
}

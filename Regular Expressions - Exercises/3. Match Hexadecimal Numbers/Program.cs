using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3.Match_Hexadecimal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(0x)?([A-F0-9]+)\b";

            string text = Console.ReadLine();

            foreach(Match m in Regex.Matches(text,pattern))
            {
                Console.Write(m + " ");
            }
        }
    }
}

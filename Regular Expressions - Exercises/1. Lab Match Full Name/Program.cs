using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1.Lab_Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]{1,} [A-Z][a-z]{1,}\b";

            string names = Console.ReadLine();

            MatchCollection matches = Regex.Matches(names, pattern);

            foreach(Match m in matches)
            {
                Console.Write(m.Value + " ");
            }

            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace _3.Rage_Quit
{
    class Program
    {
        static public StringBuilder resultStr = new StringBuilder();

        static void Main(string[] args)
        {
            string pattern = @"(.*?)(\d+)";
            string input = Console.ReadLine();
            ProcessInput(input, new Regex(pattern));
            Console.WriteLine("Unique symbols used: {0}", resultStr.ToString().Distinct().ToArray().Length);
            Console.WriteLine(resultStr.ToString());
        }

        private static void ProcessInput(string input, Regex regex)
        {
            MatchCollection matches = regex.Matches(input);
            foreach(Match m in matches)
            {
                string message = m.Groups[1].Value.ToUpper();
                int repeat = int.Parse(m.Groups[2].Value);

                for(int i = 0; i < repeat; i++)
                {
                    resultStr.Append(message);
                }
            }
        }
    }
}

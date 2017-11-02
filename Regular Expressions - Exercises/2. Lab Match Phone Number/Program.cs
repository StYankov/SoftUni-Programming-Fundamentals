using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2.Lab_Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?:^|\s)\+359([\s-])[2]\1[\d]{3}\1[\d]{4}\b";
            string text = Console.ReadLine();

            var list = new List<string>();
            foreach(Match m in Regex.Matches(text, pattern))
            {
                list.Add(m.Value.ToString().Trim());
            }

            Console.WriteLine(String.Join(", ", list));

        }
    }
}

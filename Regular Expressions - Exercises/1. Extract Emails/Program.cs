using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1.Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var patter = @"\s([a-z0-9][A-Za-z\._\-0-9]+)@([a-z-]+)(\.[a-z]+){1,}";

            foreach(Match m in Regex.Matches(text, patter))
            {
                Console.WriteLine(m);
            }
        }
    }
}

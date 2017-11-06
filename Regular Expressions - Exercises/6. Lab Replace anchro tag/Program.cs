using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _6.Lab_Replace_anchro_tag
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"<a.*?href.?=""(.*)"">(.*?)<\/a>";
            string replacement = @"[URL href=""$1""]$2[/URL]";
            Regex r = new Regex(pattern);

            string input = Console.ReadLine();

            while(input != "end")
            {
                if(r.IsMatch(input))
                {
                    input = r.Replace(input, replacement);
                    Console.WriteLine(input);
                }

                input = Console.ReadLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _5.Key_Replacer
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyInput = Console.ReadLine();
            string textInput = Console.ReadLine();

            string patern = $@"^([a-zA-Z]+)[\\|\\<\\\\](.+)[\\|\\<\\\\]([a-zA-Z]+)$";
            Regex regex = new Regex(patern);

            Match match = regex.Match(keyInput);
            string start = match.Groups[1].Value;
            string end = match.Groups[3].Value;

            Regex r = new Regex($"{start}(?!{end})(.*?){end}");

            string output = "";
            Match m = r.Match(textInput);

            while (m.Length != 0)
            {
                int index = m.Index + 1;
                output += m.Groups[1].Value;
                m = r.Match(textInput, index);
            }

            if (output.Length != 0)
                Console.WriteLine(output);
            else Console.WriteLine("Empty result");
        }
    }
}
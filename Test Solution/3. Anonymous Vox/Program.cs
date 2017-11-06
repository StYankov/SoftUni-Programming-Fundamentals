using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3.Anonymous_Vox
{
    class Program
    {
        static void Main(string[] args)
        {
            string placeholderPattern = @"(?<start>[a-zA-Z]+)(?<placeholder>.*)(?<end>\1)";
            Regex pattern = new Regex(placeholderPattern);
            string text = Console.ReadLine();
            string[] replaceValues = Console.ReadLine().Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            int matchIndex = 0;
            foreach(var replaceVal in replaceValues)
            {
                if (matchIndex >= text.Length) break;
                Match m = pattern.Match(text, matchIndex);
                if (m.Success == false) break;
                matchIndex += m.Groups[1].Length + replaceVal.Length;
                text = Regex.Replace(text, m.Value, $"{m.Groups[1]}{replaceVal}{m.Groups[3]}");
            }

            Console.WriteLine(text);

        }
    }
}

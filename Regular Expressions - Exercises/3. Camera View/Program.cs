using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _3.Camera_View
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string text = Console.ReadLine();
            int skip = input[0];
            int take = input[1];
            string pattern = @"(\|<)(.*?)(?=\|\<|$|\|)";

            var matches = Regex.Matches(text, pattern);
            List<string> cameras = new List<string>();
            for(int i = 0; i < matches.Count; i++)
            {
                Capture current = matches[i];
                if(current.Length > skip + 2)
                {
                    cameras.Add((new string(current.Value.Skip(skip + 2).Take(take).ToArray())));
                }
            }

            Console.WriteLine(String.Join(", ", cameras));
        }
    }
}

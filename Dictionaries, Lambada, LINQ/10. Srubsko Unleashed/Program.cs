using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _10.Srubsko_Unleashed
{
    class Program
    {
        const string pattern = @"([a-zA-Z]+\s){1,3}@([a-zA-Z0-9]+\s){1,3}[0-9]+\s[0-9]+";

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> concerts = new Dictionary<string, Dictionary<string, int>>();
 
            while (input != "End")
            {
                var matches = Regex.Matches(input, pattern);

                if (matches.Count > 0)
                {
                    string line = matches[0].Value;
                    string[] split = line.Split('@');
                    string name = split[0].Trim();
                    string[] secondSplit = split[1].Split(' ');
                    int ticketsCount = int.Parse(secondSplit.Last());
                    int ticketsPrice = int.Parse(secondSplit[secondSplit.Length - 2]);
                    string place = secondSplit[0];

                    for (int i = 1; i < secondSplit.Length - 2; i++)
                    {
                        place += " " + secondSplit[i];
                    }

                    if (!concerts.ContainsKey(place))
                    {
                        concerts.Add(place, new Dictionary<string, int>());
                    }

                    if (!concerts[place].ContainsKey(name))
                    {
                        concerts[place].Add(name, 0);
                    }

                    concerts[place][name] += ticketsCount * ticketsPrice;


                }

                input = Console.ReadLine();
            }


            foreach (var kvPair in concerts)
            {
                Console.WriteLine($"{kvPair.Key}");
                foreach (var pair in kvPair.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {pair.Key} -> {pair.Value}");
                }
            }
        }
    }
}

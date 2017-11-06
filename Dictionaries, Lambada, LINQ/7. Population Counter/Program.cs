using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Population_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, long>> report = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, long> totalPopulation = new Dictionary<string, long>();

            while(input != "report")
            {
                var tokens = input.Split('|');

                if(!report.ContainsKey(tokens[1]))
                {
                    report.Add(tokens[1], new Dictionary<string, long>());
                }

                report[tokens[1]].Add(tokens[0], int.Parse(tokens[2]));

                input = Console.ReadLine();
            }

            foreach(var kvPair in report)
            {
                long sum = 0;
                foreach(var pair in kvPair.Value)
                {
                    sum += pair.Value;
                }

                totalPopulation.Add(kvPair.Key, sum);
            }

            foreach (var i in totalPopulation.Keys.OrderByDescending(x => totalPopulation[x]))
            {
                Console.WriteLine($"{i} (total population: {totalPopulation[i]})");
                foreach(var city in  report[i].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}

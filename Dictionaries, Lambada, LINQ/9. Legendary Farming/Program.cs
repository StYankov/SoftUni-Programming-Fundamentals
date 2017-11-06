using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Legendary_Farming
{
    class Program
    {
        static string[] resources = { "motes", "shards", "fragments" };

        static void Main(string[] args)
        {
            Dictionary<string, int> junk = new Dictionary<string, int>();
            HashSet<string> valueful = new HashSet<string> { "motes", "shards", "fragments" };
            Dictionary<string, int> rubys = new Dictionary<string, int>();
            rubys.Add("fragments", 0);
            rubys.Add("motes", 0);
            rubys.Add("shards", 0);
            while(true)
            {
                var input = Console.ReadLine().ToLower().Split(' ');

                for(int i = 0; i < input.Length; i+= 2)
                {
                    int quantity = int.Parse(input[i]);
                    string name = input[i + 1];
                    if (valueful.Contains(name)) // is key material
                    {
                        rubys[name] += quantity;
                    }
                    else
                    {
                        if (!junk.ContainsKey(name))
                            junk.Add(name, 0);
                        junk[name] += quantity;
                    }
                    if(goalObtained(rubys))
                    {
                        break;
                    }
                }
                if (goalObtained(rubys)) break;

            }

            if (rubys[resources[0]] >= 250)
            {
                Console.WriteLine("Dragonwrath obtained!");
                rubys[resources[0]] -= 250;
            }

            if (rubys[resources[1]] >= 250)
            {
                Console.WriteLine("Shadowmourne obtained!");
                rubys[resources[1]] -= 250;
            }

            if (rubys[resources[2]] >= 250)
            {
                Console.WriteLine("Valanyr obtained!");
                rubys[resources[2]] -= 250;
            }


            foreach (var kvpair in rubys.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{kvpair.Key}: {kvpair.Value}");
            }

            foreach(var key in junk.Keys.OrderBy(x => x))
            {
                Console.WriteLine($"{key}: {junk[key]}");
            }
           
        }

        static bool goalObtained(Dictionary<string,int> dict)
        {
            for(int i = 0; i < resources.Length; i++)
            {
                if(dict[resources[i]] >= 250)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

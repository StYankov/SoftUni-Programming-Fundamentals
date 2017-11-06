using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string resource = Console.ReadLine();

            Dictionary<string, int> mine = new Dictionary<string, int>();

            while (resource != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                
                if(mine.ContainsKey(resource))
                {
                    mine[resource] += quantity;
                }
                else
                {
                    mine.Add(resource, quantity);
                }

                resource = Console.ReadLine();
            }

            foreach(var kvPair in mine)
            {
                Console.WriteLine($"{kvPair.Key} -> {kvPair.Value}");
            }
        }
    }
}

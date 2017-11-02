using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Logs_Aggregator
{
    class Program
    {
        public class Pair<T1, T2>
        {
            public T1 First { get; set; }
            public T2 Second { get; set; }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Pair<HashSet<string>, int>> entries = new Dictionary<string, Pair<HashSet<string>, int>>();


            for(int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                string name = input[1];
                string ip = input[0];
                int time = int.Parse(input[2]);

                if(!entries.ContainsKey(name))
                {
                    entries.Add(name, new Pair<HashSet<string>, int>());
                    entries[name].Second = 0;
                    entries[name].First = new HashSet<string>();
                }

                entries[name].First.Add(ip);
                entries[name].Second += time;
            }

            foreach(var key in entries.Keys.OrderBy(x => x))
            {
                Console.Write($"{key}: {entries[key].Second} [");
                bool first = true;
                
                foreach(string adress in entries[key].First.OrderBy(x => x))
                {
                    if (first)
                    {
                        Console.Write($"{adress}");
                        first = false;
                    }
                    else
                        Console.Write($", {adress}");
                }
                Console.WriteLine(']');
            }
        }
    }
}

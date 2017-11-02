using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> entries = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while(input != "end")
            {
                string[] tokens = input.Split(' ');
                string ip = tokens[0].Split('=')[1];
                string username = tokens[2].Split('=')[1];
                
                if(!entries.ContainsKey(username))
                {
                    entries.Add(username, new Dictionary<string, int>());
                }

                if(!entries[username].ContainsKey(ip))
                {
                    entries[username].Add(ip, 0);
                }

                entries[username][ip]++;

                input = Console.ReadLine();
            }

            foreach(var key in entries.Keys.OrderBy(x => x))
            {
                Console.WriteLine($"{key}:");
                bool first = true;
                foreach(var ip in entries[key])
                {
                    if (first)
                    {
                        Console.Write($"{ip.Key} => {ip.Value}");
                        first = false;
                    }
                    else
                    {
                        Console.Write($", {ip.Key} => {ip.Value}");
                    }
                }
                Console.WriteLine('.');
            }
        }
    }
}

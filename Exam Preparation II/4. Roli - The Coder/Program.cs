using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4.Roli___The_Coder
{
    class Program
    {
        class Event
        {
            public string Name { get; set; }
            public HashSet<string> Visitors { get; set; }

            public Event(string name)
            {
                this.Name = name;
                this.Visitors = new HashSet<string>();
            }
        }

        static Dictionary<int, Event> events = new Dictionary<int, Event>();

        static void Main(string[] args)
        {
            Regex validEvent = new Regex(@"^\d+\s+#[^\s]+");

            while (true)
            {
                string cmdLine = Console.ReadLine();
                if (cmdLine == "Time for Code") break;
                if (!validEvent.IsMatch(cmdLine)) continue;

                var inputTokens = cmdLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ProcessInput(inputTokens);
            }

            foreach(var roliEvent in events.OrderByDescending(x => x.Value.Visitors.Count).ThenBy(x => x.Value.Name))
            {
                Console.WriteLine($"{roliEvent.Value.Name} - {roliEvent.Value.Visitors.Count}");
                foreach(var visitor in roliEvent.Value.Visitors.OrderBy(x => x))
                {
                    Console.WriteLine(visitor);
                }
            }
        }

        private static void ProcessInput(string[] inputTokens)
        {
            int ID = int.Parse(inputTokens[0]);
            string eventName = inputTokens[1].Substring(1);
            string[] participants = inputTokens.Skip(2).ToArray();

            if(!events.ContainsKey(ID))
            {
                events.Add(ID, new Event(eventName));
                foreach(var person in participants)
                {
                    events[ID].Visitors.Add(person);
                }
            }
            else
            {
                if(events[ID].Name == eventName)
                {
                    foreach (var person in participants)
                        events[ID].Visitors.Add(person);
                }
            }
        }
    }
}

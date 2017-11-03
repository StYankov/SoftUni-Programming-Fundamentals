using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Hornet_Armada
{
    class App
    {
        class Legion
        {
            public int LastActivity { get; set; }
            public Dictionary<string, long> SoldierTypes = new Dictionary<string, long>();

            public Legion(int lastActivity)
            {
                this.LastActivity = lastActivity;
            }
        }

        static Dictionary<string, Legion> army = new Dictionary<string, Legion>();

        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            for(int i = 0; i < N; i++)
            {
                var inputTokens = Console.ReadLine().Split(new char[] { ' ', '=', '-', '>', ':' }, StringSplitOptions.RemoveEmptyEntries);

                ProcessInput(inputTokens);
            }

            string[] command = Console.ReadLine().Split('\\');
            if(command.Length == 2)
            {
                PrintUnordinary(command[0], command[1]);
            }
            else
            {
                PrintSoldierTypes(command[0]);
            }
        }

        private static void PrintUnordinary(string activity, string soldierType)
        {
            int legionActivity = int.Parse(activity);

            foreach(var legion in army.Where(x => x.Value.LastActivity < legionActivity && x.Value.SoldierTypes.ContainsKey(soldierType))
                .OrderByDescending(x => x.Value.SoldierTypes[soldierType]))
            {
                Console.WriteLine($"{legion.Key} -> {legion.Value.SoldierTypes[soldierType]}");
            }
        }

        private static void PrintSoldierTypes(string v)
        {
            foreach(var legion in army.Where(x => x.Value.SoldierTypes.ContainsKey(v)).OrderByDescending(x => x.Value.LastActivity))
            {
                Console.WriteLine($"{legion.Value.LastActivity} : {legion.Key}");
            }
        }

        private static void ProcessInput(string[] inputTokens)
        {
            int lastActivity = int.Parse(inputTokens[0]);
            string legionName = inputTokens[1];
            string soldierType = inputTokens[2];
            long soldierCount = long.Parse(inputTokens[3]);

            if(!army.ContainsKey(legionName))
            {
                army.Add(legionName, new Legion(lastActivity));
            }
            else
            {
                if(army[legionName].LastActivity < lastActivity)
                {
                    army[legionName].LastActivity = lastActivity;
                }
            }

            if(!army[legionName].SoldierTypes.ContainsKey(soldierType))
            {
                army[legionName].SoldierTypes.Add(soldierType, soldierCount);
            }
            else
            {
                army[legionName].SoldierTypes[soldierType] += soldierCount;
            }
        }
    }
}
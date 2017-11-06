using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3.Nether_Realms
{
    class Program
    {
        class Dragon
        {
            public string Name { get; set; }
            public int Health { get; set; }
            public double Damage { get; set; }

            public Dragon(string name, int health, double damage)
            {
                this.Name = name;
                this.Health = health;
                this.Damage = damage;
            }
        }

        static void Main(string[] args)
        {
            string[] demons = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<Dragon> participants = new List<Dragon>();

            foreach (var demon in demons)
            {
                int health = GetHealth(demon);
                double basedDMG = GetBaseDMG(demon);
                participants.Add(new Dragon(demon, health, basedDMG));
            }

            foreach(var dragon in participants.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{dragon.Name} - {dragon.Health} health, {dragon.Damage:f2} damage");
            }
        }

        private static double GetBaseDMG(string str)
        {
            Regex dmg = new Regex(@"((\-|\+)?(\d+)(\.\d+)?)");
            Regex multiplier = new Regex(@"\*|\/");
            MatchCollection matches = dmg.Matches(str);
            double totalDMG = 0.0;
            foreach(Match m in matches)
            {
                double current = double.Parse(m.Value);
                totalDMG += current;
            }

            MatchCollection modificators = multiplier.Matches(str);

            foreach(Match m in modificators)
            {
                char currentValue = m.Value[0];
                if(currentValue == '*')
                {
                    totalDMG *= 2;
                }
                else
                {
                    totalDMG /= 2;
                }
            }

            return totalDMG;
        }

        private static int GetHealth(string str)
        {
            Regex health = new Regex(@"[^\d\+\-\*\/\.]");
            MatchCollection matches = health.Matches(str);
            int sum = 0;
            foreach(Match m in matches)
            {
                sum += (int)m.Value[0];
            }
            return sum;
        }
    }
}

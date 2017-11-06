using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Dragon_Army
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, HashSet<Dragon>> collection = new Dictionary<string, HashSet<Dragon>>();

            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string type = input[0];
                string name = input[1];

                int damage;
                if (input[2] == "null")
                {
                    damage = 45;
                }
                else damage = int.Parse(input[2]);

                int health;
                if (input[3] == "null")
                {
                    health = 250;
                }
                else health = int.Parse(input[3]);

                int armour;
                if (input[4] == "null")
                {
                    armour = 10;
                }
                else armour = int.Parse(input[4]);

                Dragon current = new Dragon(name, damage, health, armour);

                if(!collection.ContainsKey(type))
                {
                    collection.Add(type, new HashSet<Dragon>());
                }
                
                if(collection[type].Contains(current))
                {
                    collection[type].Remove(current);
                    collection[type].Add(current);
                }
                else
                {
                    collection[type].Add(current);
                }
            }

            foreach(var kvPair in collection)
            {
                Console.WriteLine($"{kvPair.Key}::({kvPair.Value.Average(x => x.damage):f2}/{kvPair.Value.Average(x => x.health):f2}/{kvPair.Value.Average(x => x.armour):f2})");
                foreach(var dragon in kvPair.Value.OrderByDescending(x => x))
                {
                    Console.WriteLine($"-{dragon.name} -> damage: {dragon.damage}, health: {dragon.health}, armor: {dragon.armour}");
                }
            }

        }
        
        class Dragon : IComparable
        {
            public string name { get; set; }
            public int damage { get; set; }
            public int health { get; set; }
            public int armour { get; set; }

            public Dragon()
            {

            }

            public Dragon(string name, int damage, int health, int armour)
            {
                this.name = name;
                this.damage = damage;
                this.health = health;
                this.armour = armour;
            }

            public int CompareTo(object obj)
            {
                Dragon other = obj as Dragon;
                return other.name.CompareTo(this.name);
            }

            public override bool Equals(object obj)
            {
                Dragon other = obj as Dragon;
                return other.name == this.name;
            }

            public override int GetHashCode()
            {
                return this.name.GetHashCode();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Hornet_Assault
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] beehives = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            List<long> hornets = Console.ReadLine().Split(' ').Select(long.Parse).ToList();

            long currentHP = currentHP = hornets.Sum();

            for (long i = 0; i < beehives.Length; i++)
            {
                if (beehives[i] >= currentHP)
                {
                    beehives[i] -= currentHP;
                    hornets.RemoveAt(0);
                    if (hornets.Count == 0) break;
                    currentHP = hornets.Sum();
                }
                else
                {
                    beehives[i] -= currentHP;
                }

            }

            if (beehives.Any(x => x > 0))
            {
                Console.WriteLine(String.Join(" ", beehives.Where(x => x > 0)));
            }
            else
            {
                Console.WriteLine(String.Join(" ", hornets));
            }

        }
    }
}

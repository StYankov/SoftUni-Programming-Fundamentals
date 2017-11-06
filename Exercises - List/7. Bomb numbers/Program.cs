using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Bomb_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int[] bomb = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int indexOfBomb = arr.IndexOf(bomb[0]);

            while (indexOfBomb != -1)
            {
                int rightDetonation = indexOfBomb + bomb[1];
                if (rightDetonation > arr.Count) rightDetonation = arr.Count - 1;

                arr.RemoveRange(indexOfBomb + 1, rightDetonation - indexOfBomb);

                int leftDetonation = indexOfBomb - bomb[1];
                if (leftDetonation < 0) leftDetonation = 0;
                arr.RemoveRange(leftDetonation, indexOfBomb - leftDetonation + 1);

                indexOfBomb = arr.IndexOf(bomb[0]);
            }
            Console.WriteLine(arr.Sum());

        }
    }
}

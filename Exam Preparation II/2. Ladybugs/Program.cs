using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladyBugIndexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] field = GenerateField(fieldSize, ladyBugIndexes);

            while (true)
            {
                string cmdLine = Console.ReadLine();
                if (cmdLine == "end")
                {
                    break;
                }

                var cmdTokens = cmdLine.Split(' ');
                ProcessCommand(field, cmdTokens);
            }

            Console.WriteLine(string.Join(" ", field));
        }

        private static void ProcessCommand(int[] field, string[] cmdTokens)
        {
            int initialPozition = int.Parse(cmdTokens[0]);
            string direction = cmdTokens[1];
            int flyLength = int.Parse(cmdTokens[2]);

            if(direction == "right")
            {
                FlyRight(field, initialPozition, flyLength);
            }
            else
            {
                FlyRight(field, initialPozition, -flyLength);
            }
        }

        private static void FlyLeft(int[] field, int startPos, int flyLength)
        {
            throw new NotImplementedException();
        }

        private static void FlyRight(int[] field, int startPos, int flyLength)
        {

            if (!ValidIndex(startPos, field)) return;
            if (field[startPos] == 0) return;

            field[startPos] = 0;

            for(long i = startPos + flyLength; i >= 0 && i < field.Length; i += flyLength)
            {
                if(field[i] != 1)
                {
                    field[i] = 1;
                    break;
                }
            }
        }

        private static bool ValidIndex(long startPos, int[] field)
        {
            if (startPos < 0) return false;
            if (startPos >= field.Length) return false;
            return true;
        }

        private static int[] GenerateField(int fieldSize, int[] ladyBugIndexes)
        {
            int[] field = new int[fieldSize];

            for(int i = 0; i < ladyBugIndexes.Length; i++)
            {
                int index = ladyBugIndexes[i];
                if(index >= 0 && index < fieldSize)
                field[ladyBugIndexes[i]] = 1;
            }

            return field;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            while(true)
            {
                string cmdLine = Console.ReadLine();
                if (cmdLine == "end") break;

                var cmdTokens = cmdLine.Split(' ');

                ProcessInput(inputArray, cmdTokens);

            }

            Console.WriteLine("[{0}]", String.Join(", ", inputArray));
        }

        private static void ProcessInput(int[] inputArray, string[] cmdTokens)
        {
            string command = cmdTokens[0];
            switch(command)
            {
                case "exchange":
                    ExchangeArr(inputArray, cmdTokens);
                    break;
                case "max":
                    ArrayMax(inputArray, cmdTokens);
                    break;
                case "min":
                    ArrayMin(inputArray, cmdTokens);
                    break;
                case "first":
                    ArrayFirst(inputArray, cmdTokens);
                    break;
                case "last":
                    ArrayLast(inputArray, cmdTokens);
                    break;
            }
        }

        private static void ArrayLast(int[] inputArray, string[] cmdTokens)
        {
            int count = int.Parse(cmdTokens[1]);
            if (count < 0 || count > inputArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            string type = cmdTokens[2];

            if (type == "odd")
            {
                int itemsFound = 0;
                List<int> found = new List<int>();
                for (int i = inputArray.Length - 1; i >= 0; i--)
                {
                    if (inputArray[i] % 2 != 0)
                    {
                        found.Add(inputArray[i]);
                        itemsFound++;
                    }

                    if (itemsFound == count) break;
                }
                found.Reverse();
                Console.WriteLine("[{0}]", String.Join(", ", found));
            }
            else
            {
                int itemsFound = 0;
                List<int> found = new List<int>();
                for (int i = inputArray.Length - 1; i >= 0; i--)
                {
                    if (inputArray[i] % 2 == 0)
                    {
                        found.Add(inputArray[i]);
                        itemsFound++;
                    }

                    if (itemsFound == count) break;
                }
                found.Reverse();
                Console.WriteLine("[{0}]", String.Join(", ", found));
            }
        }

        private static void ArrayFirst(int[] inputArray, string[] cmdTokens)
        {
            int count = int.Parse(cmdTokens[1]);
            if(count < 0 || count > inputArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            string type = cmdTokens[2];

            if(type == "odd")
            {
                int itemsFound = 0;
                List<int> found = new List<int>();
                for(int i = 0; i < inputArray.Length; i++)
                {
                    if(inputArray[i] % 2 != 0)
                    {
                        found.Add(inputArray[i]);
                        itemsFound++;
                    }

                    if (itemsFound == count) break;
                }

                Console.WriteLine("[{0}]", String.Join(", ", found));
            }
            else
            {
                int itemsFound = 0;
                List<int> found = new List<int>();
                for(int i = 0; i < inputArray.Length; i++)
                {
                    if(inputArray[i] % 2 == 0)
                    {
                        found.Add(inputArray[i]);
                        itemsFound++;
                    }

                    if (itemsFound == count) break;
                }

                Console.WriteLine("[{0}]", String.Join(", ", found));
            }

        }

        private static void ArrayMin(int[] inputArray, string[] cmdTokens)
        {
            string minType = cmdTokens[1];
            if (minType == "odd")
            {
                int minIndex = -1;
                int minElement = int.MaxValue;
                for (int i = 0; i < inputArray.Length; i++)
                {
                    if (inputArray[i] % 2 != 0 && inputArray[i] <= minElement)
                    {
                        minIndex = i;
                        minElement = inputArray[i];
                    }
                }

                if (minIndex == -1)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(minIndex);
                }
            }
            else
            {
                int minIndex = -1;
                int minElement = int.MaxValue;
                for (int i = 0; i < inputArray.Length; i++)
                {
                    if (inputArray[i] % 2 == 0 && inputArray[i] <= minElement)
                    {
                        minIndex = i;
                        minElement = inputArray[i];
                    }
                }

                if (minIndex == -1)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(minIndex);
                }
            }
        }

        private static void ArrayMax(int[] inputArray, string[] cmdTokens)
        {
            string maxType = cmdTokens[1];
            if(maxType == "odd")
            {
                int maxIndex = -1;
                int maxElement = int.MinValue;
                for(int i = 0; i < inputArray.Length; i++)
                {
                    if(inputArray[i] % 2 != 0 && inputArray[i] >= maxElement)
                    {
                        maxIndex = i;
                        maxElement = inputArray[i];
                    }
                }

                if(maxIndex == -1)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(maxIndex);
                }
            }
            else
            {
                int maxIndex = -1;
                int maxElement = int.MinValue;
                for (int i = 0; i < inputArray.Length; i++)
                {
                    if (inputArray[i] % 2 == 0 && inputArray[i] >= maxElement)
                    {
                        maxIndex = i;
                        maxElement = inputArray[i];
                    }
                }

                if (maxIndex == -1)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(maxIndex);
                }
            }
        }

        private static void ExchangeArr(int[] inputArray, string[] cmdTokens)
        {
            int index = int.Parse(cmdTokens[1]);
            if(index < 0 || index >= inputArray.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            var leftPart = inputArray.Take(index + 1);
            var rightPart = inputArray.Skip(index + 1);

            var wholeArray = rightPart.Concat(leftPart);

            int coppyIndex = 0;
            foreach(var member in wholeArray.ToList())
            {
                inputArray[coppyIndex++] = member;
            }
        }
    }
}

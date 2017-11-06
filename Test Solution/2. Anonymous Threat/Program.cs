using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Anonymous_Threat
{
    class Program
    {
        static List<string> input;

        static void Main(string[] args)
        {
            input = Console.ReadLine().Split(' ').ToList();

            while(true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "3:1")
                    break;

                var commandTokens = commandLine.Split(' ');
                ProcessInput(commandTokens);
                
            }

            Console.WriteLine(String.Join(" ", input));
        }

        private static void ProcessInput(string[] commandLine)
        {
            string command = commandLine[0];
            int startIndex = int.Parse(commandLine[1]);
            int endIndex = int.Parse(commandLine[2]);

            if(command == "merge")
            {
                MergeArr(startIndex, endIndex);
            }
            else if(command == "divide")
            {
                DivideArr(startIndex, endIndex);
            }
        }

        private static void DivideArr(int index, int partitions)
        {
            string word = input[index];
            List<string> divided = new List<string>();
            if (word.Length % partitions == 0)
            {
                int step = word.Length / partitions;
                for(int i = 0; i < word.Length; i+= step)
                {
                    string current = new string(word.Skip(i).Take(step).ToArray());
                    divided.Add(current);
                }
            }
            else
            {
                int step = word.Length / partitions;
                int firstStep = step + (word.Length % partitions);
                for(int i = 0; i < word.Length - firstStep; i+= step)
                {
                    divided.Add(new string(word.Skip(i).Take(step).ToArray()));
                }

                divided.Add(word.Substring(word.Length - firstStep));
            }

            input.RemoveAt(index);
            input.InsertRange(index, divided);
        }

        private static void MergeArr(int startIndex, int endIndex)
        {
            if (startIndex < 0 && endIndex < 0) return;
            if (startIndex >= input.Count && endIndex >= input.Count) return;
            if (startIndex < 0) startIndex = 0;
            if (endIndex >= input.Count) endIndex = input.Count - 1;

            string concatStr = "";
            for(int i = startIndex; i <= endIndex; i++)
            {
                concatStr += input[i];
            }

            List<string> resultArr = new List<string>();
            for(int i = 0; i < startIndex; i++)
            {
                resultArr.Add(input[i]);
            }

            resultArr.Add(concatStr);

            for(int i = endIndex + 1; i < input.Count; i++)
            {
                resultArr.Add(input[i]);
            }

            input = resultArr;
        }
    }
}

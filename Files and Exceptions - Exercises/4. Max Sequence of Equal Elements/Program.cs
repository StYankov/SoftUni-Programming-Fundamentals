using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _4.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Create("../../output.txt").Close();
            List<int> seq = File.ReadAllText("../../input.txt").Split(' ').Select(int.Parse).ToList();
            
            int minStart = 0;
            int maxFinish = 0;

            for (int i = 0; i < seq.Count - 1; i++)
            {
                int start = i;
                int finish = i;
                if (seq[i] == seq[i + 1])
                {
                    i++;
                    while (i < seq.Count - 1 && seq[i] == seq[i + 1])
                    {
                        i++;
                    }

                    finish = i;
                    if (maxFinish - minStart < finish - start)
                    {
                        minStart = start;
                        maxFinish = finish;
                    }
                }
            }

            for (int i = minStart; i <= maxFinish; i++)
            {
                File.AppendAllText("../../output.txt",seq[i] + " ");
            }
        }
    }
}

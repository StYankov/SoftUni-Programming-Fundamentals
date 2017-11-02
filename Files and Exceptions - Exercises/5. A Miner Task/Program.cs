using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace _5.A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../input.txt");
            File.Create("../../output.txt").Close();
            string resource = sr.ReadLine();

            Dictionary<string, int> mine = new Dictionary<string, int>();

            while (resource != "stop")
            {
                int quantity = int.Parse(sr.ReadLine());

                if (mine.ContainsKey(resource))
                {
                    mine[resource] += quantity;
                }
                else
                {
                    mine.Add(resource, quantity);
                }

                resource = sr.ReadLine();
            }

            foreach (var kvPair in mine)
            {
                File.AppendAllText("../../output.txt",$"{kvPair.Key} -> {kvPair.Value}" + Environment.NewLine);
            }
        }
    }
}

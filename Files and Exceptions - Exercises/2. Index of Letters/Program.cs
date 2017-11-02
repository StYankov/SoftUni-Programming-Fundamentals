using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _2.Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {

            // reset output file
            File.WriteAllText("../../output.txt", "");

            string seq = File.ReadAllText("../../input.txt");

            for (int i = 0; i < seq.Length; i++)
            {
                File.AppendAllText("../../output.txt",($"{seq[i]} -> {(int)(seq[i] - 97)}{Environment.NewLine}"));
            }
        }
    }
}

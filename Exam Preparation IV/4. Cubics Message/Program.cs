using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace _4.Cubics_Message
{
    class Program
    {
        static Dictionary<string, string> DecryptedMessages = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            while (true)
            {
                string message = Console.ReadLine();
                if (message == "Over!") break;

                int size = int.Parse(Console.ReadLine());

                ProcessData(message, size);
            }

            foreach(var kvPair in DecryptedMessages)
            {
                Console.WriteLine($"{kvPair.Key} == {kvPair.Value}");
            }
        }

        private static void ProcessData(string message, int size)
        {
            Regex validator = new Regex(@"^(\d+)([a-zA-Z]+)([^a-zA-Z]+)?$");

            Match m = validator.Match(message);
            if (!m.Success) return;

            string decrypted = m.Groups[2].Value;

            if (decrypted.Length != size) return;

            string leftHalf = m.Groups[1].Value;
            string rightHalf = m.Groups[3].Value;

            int[] leftIndexes = GetIndexes(leftHalf);
            int[] rightIndexes = GetIndexes(rightHalf);

            StringBuilder str = new StringBuilder();
            foreach (var index in leftIndexes)
            {
                if (index >= 0 && index < decrypted.Length)
                {
                    str.Append(decrypted[index]);
                }
                else
                {
                    str.Append(" ");
                }
            }

            foreach (var index in rightIndexes)
            {
                if (index >= 0 && index < decrypted.Length)
                {
                    str.Append(decrypted[index]);
                }
                else
                {
                    str.Append(" ");
                }
            }

            DecryptedMessages.Add(decrypted, str.ToString());

        }

        private static int[] GetIndexes(string leftHalf)
        {
            MatchCollection matches = Regex.Matches(leftHalf, "\\d");
            List<int> indexes = new List<int>();

            foreach (Match m in matches)
            {
                indexes.Add(int.Parse(m.Value));
            }

            return indexes.ToArray();
        }
    }
}

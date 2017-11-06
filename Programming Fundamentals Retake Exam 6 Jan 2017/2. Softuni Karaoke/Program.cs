using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Softuni_Karaoke
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = ReadInput();
            List<string> availableSongs = ReadInput();

            Dictionary<string, HashSet<string>> results = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                var commandLine = Console.ReadLine();
                if (commandLine == "dawn") break;

                var commandTokens = commandLine.Split(',').Select(x => x.Trim()).ToList();
                string participantName = commandTokens[0];
                string song = commandTokens[1];
                string award = null;

                if (commandTokens.Count == 3)
                    award = commandTokens[2];

                if (participants.Contains(participantName) && availableSongs.Contains(song))
                {
                    if (!results.ContainsKey(participantName))
                    {
                        results.Add(participantName, new HashSet<string>());
                    }
                    if (award != null)
                        results[participantName].Add(award);
                }

            }

            bool noawards = true;
            foreach (var pair in results.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (pair.Value.Count > 0)
                {
                    Console.WriteLine($"{pair.Key}: {pair.Value.Count} awards");
                    foreach (var award in pair.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"--{award}");
                    }
                    noawards = false;
                }
            }

            if (noawards) Console.WriteLine("No awards");
        }

        private static List<string> ReadInput()
        {
            return Console.ReadLine().Split(',').Select(x => x.Trim()).ToList();
        }
    }
}
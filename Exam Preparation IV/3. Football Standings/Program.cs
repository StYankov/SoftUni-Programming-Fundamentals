using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3.Football_Standings
{
    class Program
    {
        class Team
        {
            public string Name { get; set; }
            public int Points { get; set; }
            public long Goals { get; set; }

            public Team(string name)
            {
                this.Name = name;
                this.Points = 0;
                this.Goals = 0;
            }
        }

        static void Main(string[] args)
        {

            Dictionary<string, Team> rankList = new Dictionary<string, Team>();

            string key = Console.ReadLine();
            key = Regex.Replace(key, @"([.*+?^${}()|[\]\\])", "\\$&");

            string pattern = $"{ key}(.*?){key}";

            Regex validator = new Regex(pattern);
            Regex resultsPattern = new Regex(@"(\d+):(\d+)");

            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "final")
                    break;

                string[] teams = GetTeams(inputLine, validator);
                int[] result = GetResult(inputLine, resultsPattern);
                ProccessData(teams, result, rankList);
            }

            Console.WriteLine("League standings:");
            int position = 1;
            foreach(var team in rankList.OrderByDescending(x => x.Value.Points).ThenBy(x => x.Value.Name))
            {
                Console.WriteLine($"{position++}. {team.Value.Name} {team.Value.Points}");
            }

            Console.WriteLine("Top 3 scored goals:");
            foreach(var team in rankList.OrderByDescending(x => x.Value.Goals).ThenBy(x => x.Value.Name).Take(3))
            {
                Console.WriteLine($"- {team.Value.Name} -> {team.Value.Goals}");
            }


        }

        private static void ProccessData(string[] teams, int[] result, Dictionary<string, Team> rankList)
        {
            int leftPointsTake, rightPointsTake;
            if (result[0] == result[1])
            {
                leftPointsTake = rightPointsTake = 1;
            }
            else if (result[0] > result[1])
            {
                leftPointsTake = 3;
                rightPointsTake = 0;
            }
            else
            {
                leftPointsTake = 0;
                rightPointsTake = 3;
            }

            if (!rankList.ContainsKey(teams[0]))
            {
                rankList.Add(teams[0], new Team(teams[0]));
            }
            if (!rankList.ContainsKey(teams[1]))
            {
                rankList.Add(teams[1], new Team(teams[1]));
            }

            rankList[teams[0]].Points += leftPointsTake;
            rankList[teams[0]].Goals += result[0];

            rankList[teams[1]].Points += rightPointsTake;
            rankList[teams[1]].Goals += result[1];


        }

        private static int[] GetResult(string inputLine, Regex resultsPattern)
        {
            Match match = resultsPattern.Match(inputLine);

            int left = int.Parse(match.Groups[1].Value);
            int right = int.Parse(match.Groups[2].Value);

            return new int[] { left, right };

        }

        private static string[] GetTeams(string inputLine, Regex validator)
        {
            MatchCollection matches = validator.Matches(inputLine);
            List<string> teams = new List<string>();
            foreach (Match m in matches)
            {
                string team = new string(m.Groups[1].Value.Reverse().ToArray()).ToUpper();
                teams.Add(team);
            }

            return teams.ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Teamwork_projects
{
    class Program
    {
        class Team
        {
            public List<string> Members { get; }
            public string Name { get; }

            public Team(string name, params string[] members)
            {
                this.Name = name;
                this.Members = new List<string>();

                foreach (var member in members)
                {
                    this.AddMember(member);
                }
            }

            public void AddMember(string member)
            {
                this.Members.Add(member);
            }

        }


        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            for (int i = 0; i < count; i++)
            {
                var tokens = Console.ReadLine().Split('-');

                if (!teams.ContainsKey(tokens[1]))
                {
                    if (HasTeam(tokens[0], teams))
                    {
                        Console.WriteLine($"{tokens[0]} cannot create another team!");
                        continue;
                    }
                    teams.Add(tokens[1], new Team(tokens[1], tokens[0]));
                    Console.WriteLine($"Team {tokens[1]} has been created by {tokens[0]}!");
                }
                else
                {
                    Console.WriteLine($"Team {tokens[1]} was already created!");
                }

            }

            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                var tokens = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                string team = tokens[1];
                string name = tokens[0];

                if (!teams.ContainsKey(team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else
                {
                    if (HasTeam(name, teams))
                    {
                        Console.WriteLine($"Member {name} cannot join team {team}!");
                    }
                    else
                    {
                        teams[team].AddMember(name);
                    }
                }

                input = Console.ReadLine();
            }

            foreach(var team in teams.Values.Where(x => x.Members.Count > 1).OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name))
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Members[0]}");
                foreach(var member in team.Members.Skip(1).OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach(var disbandTeam in teams.Values.Where(x => x.Members.Count <= 1).OrderBy(x => x.Name))
            {
                Console.WriteLine(disbandTeam.Name);
            }

        }

        static bool HasTeam(string user, Dictionary<string, Team> teams)
        {
            foreach (var kvp in teams)
            {
                if (kvp.Value.Members.Contains(user))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

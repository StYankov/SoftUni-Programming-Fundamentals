using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace _8.Mentor_Group
{
    class Program
    {
        class Mentee
        {
            public List<DateTime> attendances { get; }
            public List<string> comments { get; }
            public string Name { get; }

            public Mentee(string name)
            {
                this.Name = name;
                attendances = new List<DateTime>();
                comments = new List<string>();
            }

            public void AddDate(DateTime date)
            {
                attendances.Add(date);
            }
        }


        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Mentee> mentees = new Dictionary<string, Mentee>();

            while (input != "end of dates")
            {
                var tokens = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                Mentee current = new Mentee(tokens[0]);
                for (int i = 1; i < tokens.Length; i++)
                {
                    DateTime temp = DateTime.ParseExact(tokens[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    current.AddDate(temp);
                }

                if (!mentees.ContainsKey(tokens[0]))
                    mentees.Add(tokens[0], current);
                else
                {
                    mentees[tokens[0]].attendances.AddRange(current.attendances);
                }
                input = Console.ReadLine();
            }


            input = Console.ReadLine();

            while (input != "end of comments")
            {
                var tokens = input.Split('-');
                string name = tokens[0];
                string comment = tokens[1];

                if (mentees.ContainsKey(name))
                {
                    mentees[name].comments.Add(comment);
                }

                input = Console.ReadLine();
            }

            foreach (var person in mentees.OrderBy(x => x.Key))
            {
                Console.WriteLine(person.Key);
                Console.WriteLine("Comments:");
                foreach (var comment in person.Value.comments)
                {
                    Console.WriteLine($"- {comment}");
                }
                Console.WriteLine("Dates attended:");
                foreach (var date in person.Value.attendances.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {date:dd/MM/yyyy}");
                }
            }
        }
    }
}

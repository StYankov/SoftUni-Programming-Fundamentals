using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _10.Student_Groups
{
    class Program
    {
        class Student
        {
            public string Name { get; }
            public string Email { get; }
            public DateTime registrationDate { get; }

            public Student(string name, string email, string date)
            {
                this.Name = name;
                this.Email = email;
                this.registrationDate = DateTime.ParseExact(date, "d-MMM-yyyy", CultureInfo.InvariantCulture);
            }
        }

        class Town
        {
            public string Name { get; }
            public int SeatCount { get; }
            public List<Student> Students { get; }

            public Town(string name, int seats)
            {
                this.Name = name;
                this.SeatCount = seats;
                this.Students = new List<Student>();
            }

            public void AddStudent(Student s)
            {
                this.Students.Add(s);
            }
        }

        class Group
        {
            public Town town { get; }
            public List<Student> Students { get; set; }

            public Group(Town town)
            {
                this.town = town;
            }
        }


        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Town> towns = new List<Town>();
            while (input != "End") // CORRUPTED INPUT FIX 
            {
                if (input.Split('|').Length == 3)
                {
                    var splitUser = input.Split('|');
                    string name = splitUser[0].Trim();
                    string email = splitUser[1].Trim();
                    string date = splitUser[2].Trim();
                    Student s = new Student(name, email, date);
                    towns.Last().AddStudent(s);
                }
                else
                {
                    var tokens = input.Split(new string[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
                    string town = tokens[0].Trim();
                    int seats = int.Parse(tokens[1].Trim().Split(' ')[0]);

                    Town current = new Town(town, seats);
                    towns.Add(current);
                }

                input = Console.ReadLine();
            }

            var groups = DistributeStudentsIntoGroups(towns);

            Console.WriteLine($"Created {groups.Count} groups in {towns.Count} towns:");
            foreach(var group in groups.OrderBy(x=> x.town.Name))
            {
                Console.Write($"{group.town.Name} => {group.Students.First().Email}");
                foreach(var student in group.Students.Skip(1))
                {
                    Console.Write($", {student.Email}");
                }
                Console.WriteLine();
            }

        }

        static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
        {
            var groups = new List<Group>();

            foreach(var town in towns.OrderBy(x => x.Name))
            {
                var currentStudents = town.Students.OrderBy(x => x.registrationDate).ThenBy(x => x.Name).ThenBy(x => x.Email).ToList();
                for(int i = 0; i < currentStudents.Count; i+= town.SeatCount)
                {
                    int upBorder = (i + town.SeatCount >= currentStudents.Count) ? currentStudents.Count - i : town.SeatCount; 
                    Group current = new Group(town);
                    current.Students = currentStudents.Skip(i).Take(upBorder).ToList();
                    groups.Add(current);
                }
            }

            return groups;  
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Average_Grades
{
    class Student
    {
        public string name { get; set; }
        public List<double> grades { get; set; }
        public double average
        {
            get { return grades.Average(); }
        }

        public Student(string name, params double[] grades)
        {
            this.name = name;
            this.grades = new List<double>();
            foreach(var grade in grades)
            {
                this.grades.Add(grade);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for(int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                students.Add(new Student(input[0], input.Skip(1).ToArray().Select(double.Parse).ToArray()));
            }

            var passed = students.Where(x => x.average >= 5).OrderBy(x => x.name).ThenByDescending(x => x.average);

            foreach(var student in passed)
            {
                Console.WriteLine($"{student.name} -> {student.average:f2}");
            }
        }
    }
}

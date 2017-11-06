using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;

namespace _8.Average_Grades
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
            foreach (var grade in grades)
            {
                this.grades.Add(grade);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            File.Create("../../output.txt").Close();
            StreamReader stream = new StreamReader("../../input.txt");

            int n = int.Parse(stream.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < n; i++)
            {
                var input = stream.ReadLine().Split(' ');
                students.Add(new Student(input[0], input.Skip(1).ToArray().Select(double.Parse).ToArray()));
            }

            var passed = students.Where(x => x.average >= 5).OrderBy(x => x.name).ThenByDescending(x => x.average);

            foreach (var student in passed)
            {
                File.AppendAllText("../../output.txt", $"{student.name} -> {student.average:f2}" + Environment.NewLine);
            }
        }
    }
}

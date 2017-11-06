using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace _6.Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader sr = new StreamReader("../../input.txt");
            File.Create("../../output.txt").Close();
            string name = sr.ReadLine();
            Dictionary<string, string> emails = new Dictionary<string, string>();
            while (name != "stop")
            {
                string email = sr.ReadLine();
                string domain = email.Substring(email.Length - 2);
                if (domain != "us" && domain != "uk")
                {
                    emails.Add(name, email);
                }

                name = sr.ReadLine();
            }

            foreach (var kvPair in emails)
            {
                File.AppendAllText("../../output.txt",$"{kvPair.Key} -> {kvPair.Value}" + Environment.NewLine);
            }
        }
    }
}

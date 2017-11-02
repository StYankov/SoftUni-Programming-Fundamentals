using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Dictionary<string, string> emails = new Dictionary<string, string>();
            while(name != "stop")
            {
                string email = Console.ReadLine();
                string domain = email.Substring(email.Length - 2);
                if(domain != "us" && domain != "uk")
                {
                    emails.Add(name, email);
                }

                name = Console.ReadLine();
            }

            foreach(var kvPair in emails)
            {
                Console.WriteLine($"{kvPair.Key} -> {kvPair.Value}");
            }
        }
    }
}

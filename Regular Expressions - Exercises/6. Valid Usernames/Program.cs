using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _6.Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> usernames = Console.ReadLine().Split(new char[] { ' ', ',', '(', ')', '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Regex r = new Regex(@"^[A-Za-z][a-zA-Z\d_]{2,24}$");
            List<string> filtered = new List<string>();

            filtered = usernames.Where(x => r.IsMatch(x)).ToList();

            int maxLength = 0;
            string[] words = new string[2];
            for(int i = 0; i < filtered.Count - 1; i++)
            {
                int currentLength = filtered[i].Length + filtered[i + 1].Length;
                if(currentLength > maxLength)
                {
                    maxLength = currentLength;
                    words[0] = filtered[i];
                    words[1] = filtered[i + 1];
                }

            }

            foreach(var word in words)
            {
                Console.WriteLine(word);
            }
            
        }
    }
}

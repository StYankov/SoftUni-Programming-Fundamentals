using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            Dictionary<string, string> book = new Dictionary<string, string>();

            while(input[0] != "END")
            {
                string name = "";
                if(input[0] != "ListAll") // that kinda stupid but editting last Exercise
                name = input[1];

                if (input[0] == "A")
                {
                    string number = input[2];
                    if (!book.ContainsKey(name))
                        book.Add(name, number);
                    else book[name] = number;
                }
                else if(input[0] == "ListAll")
                {
                    foreach(var key in book.Keys.OrderBy(x => x))
                    {
                        Console.WriteLine($"{key} -> {book[key]}");
                    }
                }
                else// S 
                {
                    if(book.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} -> {book[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                }

                input = Console.ReadLine().Split(' ');
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Advertisement_Message
{
    class Program
    {
        class Message
        {
            string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            public List<string> messages = new List<string>();

            public Message(int number)
            {
                Random r = new Random();

                for(int i = 0; i < number; i++)
                {
                    int phraseIndex = r.Next(0, phrases.Length);
                    int eventsIndex = r.Next(0, events.Length);
                    int authorsIndex = r.Next(0, authors.Length);
                    int citiesIndex = r.Next(0, cities.Length);
                    messages.Add($"{phrases[phraseIndex]} {events[eventsIndex]} {authors[authorsIndex]} - {cities[citiesIndex]}");
                }
            }
        }


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Message m = new Message(n);
            foreach(var message in m.messages)
            {
                Console.WriteLine(message);
            }
        }
    }
}

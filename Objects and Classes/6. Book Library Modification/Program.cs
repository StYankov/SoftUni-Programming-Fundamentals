using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading;

namespace _5.Book_Library
{
    class Book
    {
        public string title { get; }
        public string author { get; }
        public string publisher { get; }
        public DateTime release { get; }
        public string isbn { get; }
        public double price { get; }

        public Book(string title, string author, string publisher, string date, string isbn, double price)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.release = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            this.isbn = isbn;
            this.price = price;
        }
    }

    class Library
    {
        public string Name { get; }
        public List<Book> Books { get; }

        public Library(string name)
        {
            this.Name = name;
            this.Books = new List<Book>();
        }

        public void AddBook(string book)
        {
            var tokens = book.Split(' ');
            Books.Add(new Book(tokens[0], tokens[1], tokens[2], tokens[3], tokens[4], double.Parse(tokens[5])));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

            Library l = new Library("My Library");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                l.AddBook(input);
            }
            DateTime latest = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture);

            var dict = new Dictionary<string, DateTime>();

            foreach(var book in l.Books)
            {
                if (!dict.ContainsKey(book.title))
                {
                    dict.Add(book.title, book.release);
                }
                else dict[book.title] = book.release;
            }

            foreach (var book in dict.Where(x => x.Value > latest).OrderBy(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{book.Key} -> {book.Value:dd.MM.yyyy}");
            }
        }
    }
}

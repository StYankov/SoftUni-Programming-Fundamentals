using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;

namespace _9.Book_Library
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
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            File.Create("../../output.txt").Close();
            Library l = new Library("My Library");

            StreamReader stream = new StreamReader("../../input.txt");

            int n = int.Parse(stream.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = stream.ReadLine();
                l.AddBook(input);
            }

            HashSet<string> allAuthors = new HashSet<string>();

            foreach (var book in l.Books)
            {
                allAuthors.Add(book.author);
            }
            Dictionary<string, double> authorPrice = new Dictionary<string, double>();

            foreach (var name in allAuthors)
            {
                double currentTotalPrice = l.Books.Where(x => x.author == name).Sum(x => x.price);
                authorPrice.Add(name, currentTotalPrice);
            }

            foreach (var author in authorPrice.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                File.AppendAllText("../../output.txt",$"{author.Key} -> {author.Value:f2}" + Environment.NewLine);
            }
        }
    }
}

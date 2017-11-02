using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

// NOT REALLY OOP SOLUTION

namespace _7.Andrey_and_Billiard
{
    class Program
    {
        class Billing
        {
            public Dictionary<string, double> Items { get; set; }
            public Dictionary<string, Dictionary<string, int>> Clients { get; set; }

            public Billing()
            {
                Items = new Dictionary<string, double>();
                Clients = new Dictionary<string, Dictionary<string, int>>();
            }
        }


        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

            int n = int.Parse(Console.ReadLine());
            Billing bill = new Billing();
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split('-');
                string name = tokens[0];
                double price = double.Parse(tokens[1]);

                if (!bill.Items.ContainsKey(name)) bill.Items.Add(name, price);
                else bill.Items[name] = price;
            }

            string input = Console.ReadLine();
            while (input != "end of clients")
            {
                var tokens = input.Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string product = tokens[1];
                int quantity = int.Parse(tokens[2]);

                if (bill.Items.ContainsKey(product))
                {
                    if (!bill.Clients.ContainsKey(name)) bill.Clients.Add(name, new Dictionary<string, int>());

                    if (!bill.Clients[name].ContainsKey(product)) bill.Clients[name].Add(product, 0);

                    bill.Clients[name][product] += quantity;
                }


                input = Console.ReadLine();
            }

            double totalBill = 0;
            foreach(var client in bill.Clients.OrderBy(x => x.Key))
            {
                Console.WriteLine(client.Key);
                double totalCurrentBill = 0;
                foreach(var smetka in client.Value)
                {
                    Console.WriteLine($"-- {smetka.Key} - {smetka.Value}");
                    totalCurrentBill += smetka.Value * bill.Items[smetka.Key];
                }
                Console.WriteLine($"Bill: {totalCurrentBill:f2}");
                totalBill += totalCurrentBill;
            }

            Console.WriteLine($"Total bill: {totalBill:f2}");
        }
    }
}

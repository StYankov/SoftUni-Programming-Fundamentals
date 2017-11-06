using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading;

namespace Exercises_7.Andrey_and_the_Billiard
{
    public class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> ProductQuantity { set; get; }
        public decimal Bill { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

            Dictionary<string, decimal> EntitiesAndPriceForProducts = new Dictionary<string, decimal>();

            int numberOfProductEntered = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfProductEntered; i++)
            {
                var productprice = Console.ReadLine().Split('-').ToList();
                string productName = productprice[0];
                decimal productPrice = decimal.Parse(productprice[1]);

                if (!EntitiesAndPriceForProducts.ContainsKey(productName))
                {
                    EntitiesAndPriceForProducts.Add(productName, productPrice);
                }
                else
                {
                    EntitiesAndPriceForProducts[productName] = productPrice;
                }
            }

            List<Customer> customers = new List<Customer>();
            var list = Console.ReadLine(); 

            while (list != "end of clients")
            {
                var customerProductAndQuantity = list.Split(new char[] { ',', '-' }).ToList();
                string customer = customerProductAndQuantity[0];
                string product = customerProductAndQuantity[1];
                int numberOfEntries = int.Parse(customerProductAndQuantity[2]);
                Customer currcustomer = new Customer();
                currcustomer.ProductQuantity = new Dictionary<string, int>();

                if (EntitiesAndPriceForProducts.ContainsKey(product))
                {
                    if (!customers.Any(x => x.Name == customerProductAndQuantity[0]))
                    {
                        currcustomer.Name = customer;
                        currcustomer.ProductQuantity.Add(product, numberOfEntries);
                        currcustomer.Bill = decimal.Parse(customerProductAndQuantity[2]) * EntitiesAndPriceForProducts[product];
                        customers.Add(currcustomer);
                    }
                    else
                    {
                        var currentCustomer = customers.Single(x => x.Name == customerProductAndQuantity[0]);
                        currentCustomer.ProductQuantity[product] += numberOfEntries;
                    }
                }

                list = Console.ReadLine();
            }

            foreach (var c in customers.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{c.Name}");

                foreach (var shoplist in c.ProductQuantity)
                {
                    Console.WriteLine($"-- {shoplist.Key} - {shoplist.Value}");
                }
                Console.WriteLine($"Bill: {c.Bill:f2}");
            }
            Console.WriteLine($"Total bill: {customers.Sum(x => x.Bill):f2}");
        }
    }
}
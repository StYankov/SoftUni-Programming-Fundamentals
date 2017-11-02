using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Softuni_Coffe_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            int N = int.Parse(Console.ReadLine());

            decimal totalPrice = 0.0m;
            for(int i = 0; i < N; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                string strDate = Console.ReadLine();
                int capsules = int.Parse(Console.ReadLine());

                DateTime date = DateTime.ParseExact(strDate, "d/M/yyyy", null);
                var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);

                decimal currentPrice = daysInMonth * pricePerCapsule * capsules;
                Console.WriteLine($"The price for the coffee is: ${currentPrice:f2}");
                totalPrice += currentPrice;
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}

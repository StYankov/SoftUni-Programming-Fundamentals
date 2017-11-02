using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Sweet_Dessert
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal cash = decimal.Parse(Console.ReadLine());
            int guest = int.Parse(Console.ReadLine());
            double bananaPrice = double.Parse(Console.ReadLine());
            double eggsPrice = double.Parse(Console.ReadLine());
            double berriesPrice = double.Parse(Console.ReadLine());

            int portions = (int)Math.Ceiling(guest / 6.0);
            decimal neededMoney = (decimal)(bananaPrice * portions * 2);
            neededMoney += (decimal)(portions * 4 * eggsPrice);
            neededMoney += (decimal)(portions * 0.2 * berriesPrice);

            if (cash >= neededMoney)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {neededMoney:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {(neededMoney - cash):f2}lv more.");
            }
        }
    }
}

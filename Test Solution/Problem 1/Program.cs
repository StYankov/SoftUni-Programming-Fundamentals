using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());

            decimal totalLoss = 0.0M;
            for(int i = 0; i < N; i++)
            {
                string[] inputTokens = Console.ReadLine().Split(' ');
                string website = inputTokens[0];
                long siteVisits = long.Parse(inputTokens[1]);
                decimal moneyPerVisit = decimal.Parse(inputTokens[2]);

                Console.WriteLine(website);
                decimal currentLoss = siteVisits * moneyPerVisit;
                totalLoss += currentLoss;
            }

            Console.WriteLine($"Total Loss: {totalLoss:f20}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(securityKey, N)}");
        }
    }
}

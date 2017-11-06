using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _4.Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string splitPatern = @"[\,\s]+";
            string winningPattern = @"(\${6,9}|\@{6,9}|#{6,9}|\^{6,9})";
            Regex winning = new Regex(winningPattern);

            string ticketsUnformatted = Console.ReadLine();

            List<string> tickets = Regex.Split(ticketsUnformatted, splitPatern).ToList();

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                if (isJackPot(ticket) && winning.IsMatch(ticket))
                {
                    Console.WriteLine($"ticket \"{ticket}\" - 10{ticket.First()} Jackpot!");
                    continue;
                }

                string leftSide = ticket.Substring(0, 10);
                string rightSide = ticket.Substring(10);

                Match left = winning.Match(leftSide);
                Match right = winning.Match(rightSide);

                if (!left.Success || !right.Success)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                    continue;
                }

                int leftLength = left.Groups[0].Value.Length;
                int rightLength = right.Groups[0].Value.Length;

                if (left.Value.First() == right.Value.First())
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(leftLength, rightLength)}{left.Value.First()}");
                }
                else // no match
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }

            }
        }

        private static bool isJackPot(string ticket)
        {
            if (ticket.Distinct().ToArray().Length == 1) return true;
            return false;
        }
    }
}
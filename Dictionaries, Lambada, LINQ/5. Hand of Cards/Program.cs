using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Hand_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ':', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, HashSet<string>> decks = new Dictionary<string, HashSet<string>>();
            Dictionary<string, int> points = new Dictionary<string, int>();

            while(input[0] != "JOKER")
            {
                if (!decks.ContainsKey(input[0]))
                {
                    decks.Add(input[0], new HashSet<string>());
                }
                List<string> cards = new List<string>();

                for(int i = 1; i < input.Length; i++)
                {
                    string currentCard = input[i];
                    if(!decks[input[0]].Contains(currentCard))
                    {
                        cards.Add(currentCard);
                        decks[input[0]].Add(currentCard);
                    }
                }

                int scoreSum = 0;
                foreach(var kvp in cards)
                {
                    scoreSum += calculatePower(kvp);
                }

                if(!points.ContainsKey(input[0]))
                {
                    points.Add(input[0], 0);
                }
                points[input[0]] += scoreSum;

                input = Console.ReadLine().Split(new char[] { ':', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            foreach(var kvp in points)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        static int calculatePower(string card)
        {
            string p, type;
            if(card.Length == 3)
            {
                p = card.Substring(0, 2);
                type = Convert.ToString(card[2]);
            }
            else
            {
                p = card.Substring(0, 1);
                type = card.Substring(1, 1);
            }
            return calculateP(p) * calculateType(type);
        }

        static int calculateP(string p)
        {
            switch(p)
            {
                case "2":
                    return 2;
                case "3":
                    return 3;
                case "4":
                    return 4;
                case "5":
                    return 5;
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "10":
                    return 10;
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;
            }
            return 0;
        }

        static int calculateType(string type)
        {
            switch (type)
            {
                case "S":
                    return 4;
                case "H":
                    return 3;
                case "D":
                    return 2;
                case "C":
                    return 1;
            }
            return 0;
        }
    }
}

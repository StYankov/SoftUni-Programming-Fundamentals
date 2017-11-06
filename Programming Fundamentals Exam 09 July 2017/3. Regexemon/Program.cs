using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.Regexemon
{
    class Program
    {
        static void Main(string[] args)
        {
            string hiddenText = Console.ReadLine();
            Regex bojomon = new Regex(@"[a-zA-Z]+-[a-zA-Z]+");
            Regex didimon = new Regex(@"[^a-zA-Z-]+");
            int turn = 0;
            int index = 0;
            while(true)
            {
                bool stop = true;
                if (turn % 2 == 0) // Didimon
                {
                    Match m = didimon.Match(hiddenText, index);
                    if(m.Success)
                    {
                        stop = false;
                        Console.WriteLine(m.Value);
                        index = m.Index + 1;
                    }
                }
                else // Bojomon
                {
                    Match m = bojomon.Match(hiddenText, index);
                    if(m.Success)
                    {
                        stop = false;
                        Console.WriteLine(m.Value);
                        index = m.Index + 1;
                    }
                }

                    if (stop) break;
                turn++;
            }
        }
    }
}

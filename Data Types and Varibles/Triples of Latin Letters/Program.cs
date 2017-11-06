using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triples_of_Latin_Letters
{
    class Program
    {
        static LinkedList<char> list = new LinkedList<char>();
        static void sequence(char start, char end, int n = 0)
        {
            if(n == 3)
            {
                Console.WriteLine(String.Join("", list));
                return;
            }

            for(char i = start; i < end; i++)
            {
                list.AddLast(i);
                sequence(i, end, n + 1);
                list.RemoveLast();
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            sequence('a', (char)((int)'a' + n));
        }
    }
}

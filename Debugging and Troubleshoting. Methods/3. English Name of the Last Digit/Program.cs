using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.English_Name_of_the_Last_Digit
{
    class Program
    {
        static string[] numWords = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        static void toWord(long n)
        {
            if (n < 0) n *= -1;
            long lastDigit = n % 10;
            Console.WriteLine(numWords[lastDigit]);
        }
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            toWord(n);
        }
    }
}

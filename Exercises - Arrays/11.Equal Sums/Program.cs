using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for(int i = 0; i < arr.Length; i++)
            {
                int leftSum = 0;
                for(int j = 0; j < i; j++)
                {
                    leftSum += arr[j];
                }

                int right = 0;
                for(int j = i + 1; j < arr.Length; j++)
                {
                    right += arr[j];
                }

                if (leftSum == right)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine("no");
        }
    }
}

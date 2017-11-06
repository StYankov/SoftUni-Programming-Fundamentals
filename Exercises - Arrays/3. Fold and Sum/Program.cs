using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int k = arr.Length / 4;

            int[] sum = new int[k * 2];
            
            for(int i = k, index = 0; i < 3 * k; i++, index++)
            {
                sum[index] = arr[i];
            }

            
            // left part

            for(int i = k - 1, index = 0; i >= 0; i--, index++)
            {
                sum[index] += arr[i];
            }

            // right part

            for (int i = 3 * k, index = sum.Length - 1; i < arr.Length; i++, index--)
            {
                sum[index] += arr[i];
            }

            Console.WriteLine(string.Join(" ", sum));

        }
    }
}

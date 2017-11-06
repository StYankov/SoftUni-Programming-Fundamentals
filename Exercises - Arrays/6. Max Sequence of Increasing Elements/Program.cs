using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Max_Sequence_of_Increasing_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int start = 0, end = 0;

            for(int i = 0; i < arr.Length - 1; i++)
            {
                if(arr[i] < arr[i + 1])
                {
                    int startIndex = i;
                    int endIndex = i + 1;
                    while (endIndex < arr.Length - 1 && arr[endIndex] < arr[endIndex + 1])
                    {
                        endIndex++;
                    }

                    if(Math.Abs(startIndex - endIndex) > Math.Abs(start - end))
                    {
                        start = startIndex;
                        end = endIndex;
                    }
                }
            }

            for(int i = start; i <= end; i++)
            {
                Console.Write(arr[i] + " ");
            }

        }
    }
}

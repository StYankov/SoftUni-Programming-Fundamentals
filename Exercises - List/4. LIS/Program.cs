using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.LIS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int[] len = new int[sequence.Count];
            int[] prev = new int[sequence.Count];
            prev[0] = -1;
            len[0] = 1;

            for(int p = 1; p < sequence.Count; p++)
            {
                // find leftmost element to satisfy the criteria: max len and max number 
                int left = 0;
                for(int j = p - 1; j >= 0; j--)
                {
                    // check if len of last 'left' is smaller than current length at index j and if num at index j is smaller than num at index p <- current num
                    if(len[j] >= len[left] && sequence[j] < sequence[p])
                    {
                        left = j;
                    }
                } 

                if(sequence[left] < sequence[p])
                {
                    len[p] = len[left] + 1;
                    prev[p] = left;
                }
                else
                {
                    len[p] = 1;
                    prev[p] = -1;
                }
            }

            int index = 0;
            for(int i = 0; i < len.Length; i++)
            {
                if (len[i] > len[index]) index = i;
            }

            List<int> result = new List<int>();

            //backtracking
            while(index != -1)
            {
                result.Insert(0, sequence[index]);
                index = prev[index];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            long sum = 0;

            while(sequence.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if(index < 0) // remove first
                {
                    int removedElement = sequence[0];
                    ReviewArr(sequence, removedElement, 1, sequence.Count);
                    sequence[0] = sequence.Last();
                    sum += removedElement;
                }
                else if(index >= sequence.Count)
                {
                    int removedElement = sequence.Last();
                    ReviewArr(sequence, removedElement, 0, sequence.Count - 1);
                    sequence[sequence.Count - 1] = sequence[0];
                    sum += removedElement;
                }
                else
                {
                    int removedElement = sequence[index];
                    sequence.RemoveAt(index);
                    ReviewArr(sequence, removedElement, 0, sequence.Count);
                    sum += removedElement;
                }
            }

            Console.WriteLine(sum);

        }

        private static void ReviewArr(List<int> sequence, int removedElement, int startIndex, int endIndex)
        {
            for(int i = startIndex; i < endIndex; i++)
            {
                if(sequence[i] <= removedElement)
                {
                    sequence[i] += removedElement;
                }
                else
                {
                    sequence[i] -= removedElement;
                }
            }
        }
    }
}

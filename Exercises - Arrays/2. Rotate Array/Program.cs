using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Rotate_Array
{
    class Program
    {
        static int[] sum;

        static void rotate(LinkedList<int> arr)
        {
            int last = arr.Last();
            arr.RemoveLast();
            arr.AddFirst(last);

            var firstElement = arr.First;
            for(int i = 0; i < sum.Length; i++)
            {
                sum[i] += firstElement.Value;
                firstElement = firstElement.Next;
            }
        }

        static void Main(string[] args)
        {
            LinkedList<int> array = new LinkedList<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            sum = new int[array.Count];
            int k = int.Parse(Console.ReadLine());
            for(int i = 0; i < k; i++)
            rotate(array);

            Console.WriteLine(String.Join(" ", sum));
            

        }
    }
}

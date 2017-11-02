using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3.Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = File.ReadAllText("../../input.txt").Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                int leftSum = 0;
                for (int j = 0; j < i; j++)
                {
                    leftSum += arr[j];
                }

                int right = 0;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    right += arr[j];
                }

                if (leftSum == right)
                {
                    File.WriteAllText("../../output.txt", Convert.ToString(i));
                    return;
                }
            }

            File.WriteAllText("../../output.txt", "no");
        }
    }
}

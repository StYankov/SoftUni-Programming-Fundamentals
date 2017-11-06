using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1.Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] arr = File.ReadAllText("../../input.txt").Split(' ').Select(int.Parse).ToArray();

            int mostOcc = 1;
            int mostOccNum = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                int currentNum = arr[i];
                int count = 1;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (currentNum == arr[j]) count++;
                }

                if (count > mostOcc)
                {
                    mostOcc = count;
                    mostOccNum = currentNum;
                }
            }

            File.WriteAllText("../../output.txt",Convert.ToString(mostOccNum));
        }
    }
}

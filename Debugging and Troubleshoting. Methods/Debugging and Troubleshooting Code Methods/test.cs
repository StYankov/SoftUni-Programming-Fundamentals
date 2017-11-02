using System;
using System.Collections.Generic;
using System.Linq;

public class BePositive_broken
{
    public static void Main()
    {
        int countSequences = int.Parse(Console.ReadLine());

        for (int i = 0; i < countSequences; i++)
        {
            int[] input = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> data = new List<int>();

            for (int j = 0; j < input.Length; j++) // before it was j < input.length - 1
            {
                int currentNum = input[j];

                if (currentNum >= 0)
                {
                    data.Add(currentNum);
                }
                else
                {
                    if (j < input.Length - 1) // check added here because of last number
                    {
                        currentNum += input[j + 1];
                    }

                    if (currentNum >= 0)
                    {
                        data.Add(currentNum);
                    }
                    j++;
                }
            }

            // REMOVED NOT NECESSARY
            //if (input.Length >= 2)
            //{
            //    if (input[input.Length - 2] >= 0 && input[input.Length - 1] >= 0)
            //    {
            //        data.Add(input[input.Length - 1]);
            //    }
            //}
            //else
            //{
            //    if (input[0] >= 0)
            //    {
            //        data.Add(input[0]);
            //    }
            //}


            if (data.Count > 0)
            {
                Console.WriteLine(string.Join(" ", data));
            }
            else
            {
                Console.WriteLine("(empty)");
            }
        }
    }
}
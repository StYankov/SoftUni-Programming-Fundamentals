using System;
using System.Collections.Generic;

public class BePositive_broken
{
    public static void Main()
    {
        int countSequences = int.Parse(Console.ReadLine());

        for (int i = 0; i < countSequences; i++)
        {
            string[] input = Console.ReadLine().Trim().Split(' ');
            var numbers = new List<int>();
            List<int> data = new List<int>();

            for (int j = 0; j < input.Length; j++)
            {
                if (!input[j].Equals(string.Empty))
                {
                    int num = int.Parse(input[j]);
                    numbers.Add(num);
                }
            }

            for (int j = 0; j < numbers.Count; j++)
            {
                int currentNum = numbers[j];

                if (currentNum >= 0)
                {
                    data.Add(currentNum);
                }
                else
                {
                    if (j < numbers.Count - 1)
                    currentNum += numbers[j + 1];
                    j++;
                    if (currentNum >= 0)
                    {
                        data.Add(currentNum);
                    }
                }
            }

            if(data.Count != 0)
            {
                Console.WriteLine(String.Join(" ", data));
            }
            else
            {
                Console.WriteLine("(empty)");
            }
        }
    }
}
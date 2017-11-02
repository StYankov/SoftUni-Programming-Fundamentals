using System;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        string pattern = @"(^|(?<=\s))(\-?[0-9]{1,})\.?(\d+)?($|(?=\s))";
        string input = Console.ReadLine();

        foreach (Match m in Regex.Matches(input, pattern))
        {
            Console.Write(m.Value + " ");
        }
    }
}

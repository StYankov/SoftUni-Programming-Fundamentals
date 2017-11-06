//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;

//namespace _3.Solution_Pack_2
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string text = Console.ReadLine();
//            //string[] placeholders = Console.ReadLine().Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
//            string temp = Console.ReadLine();
//            MatchCollection values = Regex.Matches(temp, @"{(.*?)}");
//            List<string> placeholders = new List<string>();
//            foreach(Match pl in values)
//            {
//                placeholders.Add(pl.Groups[1].Value);
//            }
//            Regex pattern = new Regex(@"(?<start>[a-zA-Z]+)(?<placeholder>.*)(?<end>\1)");

//            MatchCollection phs = pattern.Matches(text);

//            int phNumber = 0;
//            foreach (Match m in phs)
//            {
//                if (phNumber >= placeholders.Count) break;
//                string currentPlaceHolder = m.Value;
//                string replacement = $@"{m.Groups[1]}{placeholders[phNumber]}{m.Groups[3]}";
//                text = Regex.Replace(text, currentPlaceHolder, replacement);
//                phNumber++;
//            }

//            Console.WriteLine(text);
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3.Solution_Pack_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            //string[] placeholders = Console.ReadLine().Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string temp = Console.ReadLine();
            MatchCollection values = Regex.Matches(temp, @"{(.*?)}");
            List<string> placeholders = new List<string>();
            foreach (Match pl in values)
            {
                placeholders.Add(pl.Groups[1].Value);
            }
            Regex pattern = new Regex(@"(?<start>[a-zA-Z]+)(?<placeholder>.*)(?<end>\1)");

            MatchCollection phs = pattern.Matches(text);

            int phNumber = 0;
            foreach (Match m in phs)
            {
                if (phNumber >= placeholders.Count) break;
                string currentPlaceHolder = m.Value;
                string replacement = $@"{m.Groups[1]}{placeholders[phNumber]}{m.Groups[3]}";
                text = Regex.Replace(text, currentPlaceHolder, replacement);
                phNumber++;
            }


            Console.WriteLine(text);
        }
    }
}


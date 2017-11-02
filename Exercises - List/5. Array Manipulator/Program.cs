using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Array_Manipulator
{
    class Program
    {
        static void rotate(ref List<int> arr)
        {
            var first = arr[0];
            arr.RemoveAt(0);
            arr.Add(first);
        }

        static void Main(string[] args)
        {
            List<int> arr = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            arr.TrimExcess();

            string command = Console.ReadLine();
            while (command != "print")
            {
                var input = command.Split(' ');

                switch (input[0])
                {
                    case "add":
                        {
                            int index = int.Parse(input[1]);
                            int element = int.Parse(input[2]);
                            arr.Insert(index, element);
                        }
                        break;
                    case "addMany":
                        {
                            int element = int.Parse(input[1]);
                            arr.InsertRange(element, input.Skip(2).Select(int.Parse).ToArray());
                        }
                        break;
                    case "contains":
                        {
                            int element = int.Parse(input[1]);
                            if(arr.Contains(element))
                            {
                                Console.WriteLine(arr.IndexOf(element));
                            }
                            else
                            {
                                Console.WriteLine(-1);
                            }
                        }
                        break;
                    case "remove":
                        {
                            int element = int.Parse(input[1]);
                            arr.RemoveAt(element);
                        }
                        break;
                    case "shift":
                        {
                            int position = int.Parse(input[1]);
                            for(int i = 0; i < position; i++)
                            {
                                rotate(ref arr);
                            }
                        }
                        break;
                    case "sumPairs":
                        {
                            for(int i = 0; i < arr.Count; i++)
                            {
                                if (i + 1 < arr.Count)
                                {
                                    arr[i] += arr[i + 1];
                                    arr.RemoveAt(i + 1);
                                }
                            }
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("[" + string.Join(", ", arr) + "]");

            
        }
    }
}

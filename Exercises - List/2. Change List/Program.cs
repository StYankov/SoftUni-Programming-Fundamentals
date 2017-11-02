using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> seq = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while (command != "Odd" && command != "Even")
            {
                string cmd = command.Split(' ')[0];
                int element = int.Parse(command.Split(' ')[1]);

                switch (cmd)
                {
                    case "Delete":
                        {
                            List<int> temp = new List<int>();
                            foreach (var n in seq)
                            {
                                if (n != element)
                                {
                                    temp.Add(n);
                                }
                            }
                            seq = temp;
                        }
                        break;
                    case "Insert":
                        {
                            int position = int.Parse(command.Split(' ')[2]);
                            seq.Insert(position, element);
                        }
                        break;
                }
                command = Console.ReadLine();

            }

            if (command == "Odd")
            {
                foreach (var n in seq)
                {
                    if (n % 2 != 0)
                    {
                        Console.Write(n + " ");
                    }
                }
            }
            else
            {
                foreach (var n in seq)
                {
                    if (n % 2 == 0)
                    {
                        Console.Write(n + " ");
                    }
                }
            }
        }
    }
}

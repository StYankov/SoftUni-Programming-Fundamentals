using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Cube_Properties
{
    class Program
    {

        static double Face(double n)
        {
            return Math.Sqrt(2 * Math.Pow(n, 2));
        }

        static double Space(double n)
        {
            return Math.Sqrt(3 * Math.Pow(n, 2));
        }

        static double Volume(double n)
        {
            return Math.Pow(n, 3);
        }

        static double Area(double n)
        {
            return 6 * n * n;
        }

        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();

            if (type == "face")
            {
                Console.WriteLine($"{Face(number):f2}");
            }
            else if (type == "space")
            {
                Console.WriteLine($"{Space(number):f2}");
            }
            else if (type == "volume")
            {
                Console.WriteLine($"{Volume(number):f2}");
            }
            else; if(type == "area")
            {
                Console.WriteLine($"{Area(number):f2}");
            }
        }
    }
}

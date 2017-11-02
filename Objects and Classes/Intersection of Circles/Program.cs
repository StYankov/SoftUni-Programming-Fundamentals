using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersection_of_Circles
{
    class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }


    class Circle
    {
        public int radius { get; set; }
        public Point center { get; set; }

        public Circle(int x, int y, int rad)
        {
            this.center = new Point(x, y);
            this.radius = rad;
        }

        static public bool Intersect(Circle c1, Circle c2)
        {
            double distance = Math.Sqrt(Math.Pow(c1.center.x - c2.center.x, 2) + Math.Pow(c1.center.y - c2.center.y, 2));
            return c1.radius + c2.radius >= distance;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var circle1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var circle2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Circle c1 = new Circle(circle1[0], circle1[1], circle1[2]);
            Circle c2 = new Circle(circle2[0], circle2[1], circle2[2]);

            if (Circle.Intersect(c1, c2))
            {
                Console.WriteLine("Yes");
            }
            else Console.WriteLine("No");
        }
    }
}

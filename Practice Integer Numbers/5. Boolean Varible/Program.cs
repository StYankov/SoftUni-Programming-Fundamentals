using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Boolean_Varible
{
    class Program
    {
        static void Main(string[] args)
        {
            string boolean = Console.ReadLine();
            bool result = Convert.ToBoolean(boolean);
            if(result == true)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}

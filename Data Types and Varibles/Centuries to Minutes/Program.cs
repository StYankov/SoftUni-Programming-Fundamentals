﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            const double daysInYear = 365.2422d;
            int centuries = int.Parse(Console.ReadLine());

            int years = centuries * 100;
            int days = (int)(daysInYear * years);
            int hours = days * 24;
            int minutes = hours * 60;
            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
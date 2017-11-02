using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4.Weather
{
    class City
    {
        public string Town { get; set; }
        public string Weather { get; set; }
        public float Temperature { get; set; }

        public City(string city, string weather, float temp)
        {
            this.Town = city;
            this.Weather = weather;
            this.Temperature = temp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Dictionary<string, City> cities = new Dictionary<string, City>();

            string input = Console.ReadLine();
            string pattern = @"(?<code>[A-Z]{2})(?<number>\d{1,2}.\d{1,2})(?<weather>[A-Za-z]+)\|";
            Regex r = new Regex(pattern);

            while (input != "end")
            {
                Match m = r.Match(input);
                if (m.Length != 0)
                {
                    string currentCity = m.Groups["code"].ToString();
                    if (!cities.ContainsKey(currentCity))
                    {
                        cities.Add(currentCity, new City(currentCity, m.Groups["weather"].ToString(), float.Parse(m.Groups["number"].ToString())));
                    }
                    else
                    {
                        cities[currentCity] = new City(currentCity, m.Groups["weather"].ToString(), float.Parse(m.Groups["number"].ToString()));
                    }
                }


                input = Console.ReadLine();
            }

            foreach (var city in cities.OrderBy(x => x.Value.Temperature))
            {
                Console.WriteLine($"{city.Key} => {city.Value.Temperature:f2} => {city.Value.Weather}");
            }
        }
    }
}
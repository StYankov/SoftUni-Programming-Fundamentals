using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreyAndBilliard
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //PRICES
            int n = int.Parse(Console.ReadLine());

            var menu = new Dictionary<string, double>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split('-').ToArray();
                if (!menu.ContainsKey(input[0]))
                {
                    menu.Add(input[0], double.Parse(input[1]));
                }
                else
                {
                    menu[input[0]] = double.Parse(input[1]);
                }
            }
            //ORDERS
            Dictionary<string, Customer> customers = new Dictionary<string, Customer>();
            var order = Console.ReadLine().Split('-', ',').ToArray();

            while (string.Join(" ", order) != "end of clients")
            {         
                if (menu.ContainsKey(order[1]))
                {
                    if (!customers.ContainsKey(order[0]))
                    {
                        Customer c = new Customer(order[0], menu[order[1]] * int.Parse(order[2]));
                        c.Purchase.Add(order[1], int.Parse(order[2]) );
                    }
                    else
                    {
                        customers[order[0]].Purchase.Add(order[1], int.Parse(order[2]));
                    }

                }

                order = Console.ReadLine().Split('-', ',').ToArray();
            }
            //PRINTING
            double totalBill = 0;

            foreach (var customer in customers.Values.OrderBy(c => c.Name))
            {
                Console.WriteLine($"{customer.Name}");
                foreach (var item in customer.Purchase)
                {
                    Console.Write($"-- { item.Key} - { item.Value}");
                }
                Console.WriteLine($"{Environment.NewLine}" +
                $"Bill: {customer.Bill:F2}");
                totalBill += customer.Bill;
            }
            Console.WriteLine($"Total bill: {totalBill:F2}");
        }
    }

    class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> Purchase = new Dictionary<string, int>();
        public double Bill { get; set; }

        public Customer(string name, double bill)
        {
            this.Name = name;
            this.Bill = bill;
            this.Purchase = new Dictionary<string, int>();
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _4.Pokemon_Evolution
//{
//    class Program
//    {

//        class Evolution
//        {
//            public string EvolutinName { get; set; }
//            public int EvolutionIndex { get; set; }

//            public Evolution(string name, int index)
//            {
//                this.EvolutinName = name;
//                this.EvolutionIndex = index;
//            }
//        }


//        class Pokemon
//        {
//            public string Name { get; }
//            public List<Evolution> Evolutions {get;set;}

//            public Pokemon(string name)
//            {
//                this.Name = name;
//                this.Evolutions = new List<Evolution>();
//            }
//        }


//        static void Main(string[] args)
//        {
//            string input = Console.ReadLine();
//            Dictionary<string, Pokemon> pokemons = new Dictionary<string, Pokemon>();
//            while (input != "wubbalubbadubdub")
//            {
//                var tokens = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
//                tokens = tokens.Select(x => x.Trim()).ToArray();

//                if (tokens.Length == 3)
//                {
//                    string pokemonName = tokens[0];
//                    string pokemonEvo = tokens[1];
//                    int pokeIndex = int.Parse(tokens[2]);
//                    if (!pokemons.ContainsKey(pokemonName)) // IF POKEMON DOESNT EXIST CREATE IT
//                    {
//                        pokemons.Add(pokemonName, new Pokemon(pokemonName));
//                    }
//                    pokemons[pokemonName].Evolutions.Add(new Evolution(pokemonEvo, pokeIndex));

//                }
//                else
//                {
//                    string searchPokemon = tokens[0];
//                    if (pokemons.ContainsKey(searchPokemon))
//                    {
//                        Console.WriteLine($"# {searchPokemon}");
//                        foreach (var evolutions in pokemons[searchPokemon].Evolutions)
//                        {
//                            Console.WriteLine($"{evolutions.EvolutinName} <-> {evolutions.EvolutionIndex}");
//                        }
//                    }
//                }

//                input = Console.ReadLine();
//            }

//            foreach(var pokemon in pokemons.Values)
//            {
//                Console.WriteLine($"# {pokemon.Name}");
//                foreach (var evolutions in pokemon.Evolutions.OrderByDescending(x => x.EvolutionIndex))
//                {
//                    Console.WriteLine($"{evolutions.EvolutinName} <-> {evolutions.EvolutionIndex}");
//                }
//            }

//        }
//    }
//}

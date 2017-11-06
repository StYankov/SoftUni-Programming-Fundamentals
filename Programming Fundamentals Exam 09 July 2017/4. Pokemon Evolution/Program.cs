using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Pokemon_Evolution
{
    class Program
    {
        class Pokemon
        {
            public string Name { get; set; }
            public List<KeyValuePair<string, int>> Evolutions { get; set; }

            public Pokemon(string name)
            {
                this.Name = name;
                this.Evolutions = new List<KeyValuePair<string, int>>();
            }
        }

        static void Main(string[] args)
        {
            Dictionary<string, Pokemon> pokemons = new Dictionary<string, Pokemon>();
            
            while(true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "wubbalubbadubdub")
                    break;
                var inputTokens = inputLine.Split(new char[] { '-', ' ', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                ProcessData(pokemons, inputTokens);

            }

            foreach(var pokemon in pokemons)
            {
                Console.WriteLine($"# {pokemon.Key}");
                foreach(var evolution in pokemon.Value.Evolutions.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{evolution.Key} <-> {evolution.Value}");
                }
            }
        }

        private static void ProcessData(Dictionary<string, Pokemon> pokemons, string[] inputTokens)
        {
            if(inputTokens.Length == 1)
            {
                printPokemonInfo(pokemons, inputTokens[0]);
            }
            else
            {
                AddPokeEvolution(pokemons, inputTokens);
            }
        }

        private static void AddPokeEvolution(Dictionary<string, Pokemon> pokemons, string[] inputTokens)
        {
            string pokemonName = inputTokens[0];
            string pokemonEvolution = inputTokens[1];
            int evoIndex = int.Parse(inputTokens[2]);

            if(!pokemons.ContainsKey(pokemonName))
            {
                pokemons.Add(pokemonName, new Pokemon(pokemonName));
            }

            pokemons[pokemonName].Evolutions.Add(new KeyValuePair<string, int>(pokemonEvolution, evoIndex));
        }

        private static void printPokemonInfo(Dictionary<string, Pokemon> pokemons, string pokemonName)
        {
            if(pokemons.ContainsKey(pokemonName))
            {
                Console.WriteLine($"# {pokemonName}");
                foreach(var evolution in pokemons[pokemonName].Evolutions)
                {
                    Console.WriteLine($"{evolution.Key} <-> {evolution.Value}");
                }
            }
        }
    }
}

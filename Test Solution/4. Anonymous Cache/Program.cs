using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Anonymous_Cache
{
    class Program
    {
        class Data
        {
            public string Name { get; set; }
            public long DataSize { get; set; }

            public Data(string name, long data)
            {
                this.Name = name;
                this.DataSize = data;
            }
        }
        static Dictionary<string, List<Data>> datasets = new Dictionary<string, List<Data>>();
        static Dictionary<string, List<Data>> cache = new Dictionary<string, List<Data>>();

        static void Main(string[] args)
        {
            
            while(true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "thetinggoesskrra")
                    break;
                var inputTokens = commandLine.Split(new char[] { ' ', '-', '>', '|' }, StringSplitOptions.RemoveEmptyEntries);

                if(inputTokens.Length == 1)
                {
                    string dataSet = inputTokens[0];
                    if(!datasets.ContainsKey(dataSet))
                    {
                        datasets.Add(dataSet, new List<Data>());
                        if(cache.ContainsKey(dataSet))
                        {
                            var currentData = cache[dataSet];
                            foreach(var data in currentData)
                            {
                                datasets[dataSet].Add(data);
                            }
                            cache.Remove(dataSet);
                        }
                    }
                    
                }
                else
                {
                    ManageInput(inputTokens);  
                }
            }

            var sorted = datasets.OrderByDescending(x => x.Value.Sum(y => y.DataSize)).Take(1);
            foreach(var d in sorted)
            {
                Console.WriteLine($"Data Set: {d.Key}, Total Size: {d.Value.Sum(x => x.DataSize)}");
                foreach(var datakey in d.Value)
                {
                    Console.WriteLine($"$.{datakey.Name}");
                }
            }
        }

        private static void ManageInput(string[] inputTokens)
        {
            string dataKey = inputTokens[0];
            long dataSize = long.Parse(inputTokens[1]);
            string dataSet = inputTokens[2];

            if(datasets.ContainsKey(dataSet))
            {
                datasets[dataSet].Add(new Data(dataKey, dataSize)); 
            }
            else
            {
                if(!cache.ContainsKey(dataSet))
                {
                    cache.Add(dataSet, new List<Data>());
                }

                cache[dataSet].Add(new Data(dataKey,dataSize));
            }
        }
    }
}

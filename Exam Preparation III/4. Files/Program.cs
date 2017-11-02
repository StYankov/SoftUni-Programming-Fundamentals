using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//THE SOLUTION IS OVERCOMPLICATED

namespace _4.Files
{
    class Files
    {
        public Dictionary<string, long> folder { get; set; }
        public Files()
        {
            this.folder = new Dictionary<string, long>();
        }
    }

    class Program
    {
        static Dictionary<string, Dictionary<string, Files>> computer = new Dictionary<string, Dictionary<string, Files>>();

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            ProcessInput(N);

            string[] query = Console.ReadLine().Split(' ');
            string extension = query[0];
            string path = query[2];

            if (!computer.ContainsKey(path))
            {
                Console.WriteLine("No");
                return;
            }

            if(!computer[path].ContainsKey(extension))
            {
                Console.WriteLine("No");
                return;
            }

            var matches = computer[path][extension].folder;
            if (matches.Count == 0) Console.WriteLine("No");
            else
            {
                foreach (var m in matches.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine("{0} - {1} KB", m.Key, m.Value);
                }
            }
        }

        private static void ProcessInput(int n)
        {
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var splitted = input.Split(';');

                long size = long.Parse(splitted.Last());
                string root = GetRoot(splitted[0]); 
                string fileName = GetFileName(splitted[0]); 
                string extension = GetExtension(fileName);
                
                if(!computer.ContainsKey(root)) // if first dictionary doesn't contain root
                {
                    computer.Add(root, new Dictionary<string, Files>());
                }

                if(!computer[root].ContainsKey(extension)) // if root doens't contain extension
                {
                    computer[root].Add(extension, new Files());
                }

                computer[root][extension].folder[fileName] = size;
            }
        }

        private static string GetFileName(string v)
        {
            int index = v.LastIndexOf('\\');
            return v.Substring(index + 1);
        }

        private static string GetRoot(string v)
        {
            int index = v.IndexOf('\\');
            return v.Substring(0, index);
        }
        
        private static string GetExtension(string v)
        {
            int index = v.LastIndexOf('.');
            return v.Substring(index + 1);
        }
    }
}

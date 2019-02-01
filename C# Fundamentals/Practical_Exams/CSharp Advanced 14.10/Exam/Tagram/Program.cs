using System;
using System.Collections.Generic;
using System.Linq;

namespace Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> tagram = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end") break;

                string[] tokens = line.Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                if(tokens.Length == 3)
                {
                    string name = tokens[0];
                    string tag = tokens[1];
                    long likes = long.Parse(tokens[2]);

                    if (!tagram.ContainsKey(name))
                    {
                        tagram.Add(name, new Dictionary<string, long>());

                        if (!tagram[name].ContainsKey(tag))
                        {
                            tagram[name].Add(tag, likes);
                        }
                        else
                        {
                            tagram[name][tag] += likes;
                        }
                    }
                    else
                    {
                        if (!tagram[name].ContainsKey(tag))
                        {
                            tagram[name].Add(tag, likes);
                        }
                        else
                        {
                            tagram[name][tag] += likes;
                        }
                    }
                }
                else if (tokens.Length == 2)
                {
                    string target = tokens[1];

                    if (tagram.ContainsKey(target))
                    {
                        tagram.Remove(target);
                    }
                }
            }

            foreach (var pair in tagram.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Keys.Count()))
            {
                Console.WriteLine($"{pair.Key}");
                foreach (var kvp in pair.Value)
                {
                    Console.WriteLine($"- {kvp.Key}: {kvp.Value}");
                }
            }
        }
    }
}

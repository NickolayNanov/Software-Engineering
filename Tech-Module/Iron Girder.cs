using System;
using System.Collections.Generic;
using System.Linq;

namespace Iron_Girder
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> townsTime = new Dictionary<string, int>();
            Dictionary<string, int> allTowns = new Dictionary<string, int>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Slide rule") break;

                string[] tokens = line
                    .Split(new string[] { "->", ":" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (tokens[1] != "ambush")
                {
                    string town = tokens[0];
                    int time = int.Parse(tokens[1]);
                    int count = int.Parse(tokens[2]);

                    if (!townsTime.ContainsKey(town))
                    {
                        townsTime.Add(town, time);
                    }
                    else
                    {
                        if(townsTime[town] == 0)
                        {
                            townsTime[town] = time;
                        }

                        if (townsTime[town] > time)
                        {
                            townsTime[town] = time;
                        }
                    }

                    if (!allTowns.ContainsKey(town))
                    {
                        allTowns.Add(town, count);
                    }
                    else
                    {
                        allTowns[town] += count;
                    }
                }
                else 
                {
                    string town = tokens[0];
                    int passengers = int.Parse(tokens[2]);

                    if (townsTime.ContainsKey(town))
                    {
                        townsTime[town] = 0;
                    }

                    if (allTowns.ContainsKey(town))
                    {
                        allTowns[town] -= passengers;
                    }
                }
            }
            foreach (var it in townsTime.OrderBy(x => x.Value).ThenBy(x => x.Key).Where(x => x.Value != 0))
            {
                Console.WriteLine($"{it.Key} -> Time: {it.Value} -> Passengers: {allTowns[it.Key]}");
                             
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwithe
{
    class Program
    {
        static void Main(string[] args)
        {
            var dwarfs = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                string line = Console.ReadLine();

                if(line == "Once upon a time")
                {
                    break;
                }

                string[] tokens = line.Split(" <:> ");

                string name = tokens[0];
                string color = tokens[1];
                long strength = long.Parse(tokens[2]);

                if (!dwarfs.ContainsKey(name))
                {
                    dwarfs.Add(name, new Dictionary<string, long>());
                }

                if (!dwarfs[name].ContainsKey(color))
                {
                    dwarfs[name].Add(color, strength);
                }

                if(dwarfs[name][color] <= strength)
                {
                    dwarfs[name][color] = strength;
                }
            }

            foreach (var dwarf in dwarfs.OrderByDescending(x => x.Key.Count()))
            {
                foreach (var dw in dwarf.Value.OrderByDescending(x => x.Value).ThenByDescending(x => x.Key.Count()))
                {
                    Console.WriteLine($"({dw.Key}) {dwarf.Key} <-> {dw.Value}");
                }
            }
        }
    }
}

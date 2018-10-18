using System;
using System.Collections.Generic;
using System.Linq;

namespace Dicts_And_HashSets
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> dict = new Dictionary<double, int>();

            foreach (var val in values)
            {
                if (!dict.ContainsKey(val))
                {
                    dict.Add(val, 1);
                }
                else
                {
                    dict[val]++;
                }
            }

            foreach (var val in dict)
            {
                Console.WriteLine($"{val.Key} - {val.Value} times");
            }
        }
    }
}

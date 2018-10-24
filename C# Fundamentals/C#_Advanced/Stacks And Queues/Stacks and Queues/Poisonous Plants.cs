using System;
using System.Collections.Generic;
using System.Linq;

namespace Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> plants = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int days = 0;

            List<int> indexes = new List<int>();

            while (plants.Count != 0)
            {
                for (int i = 0; i < plants.Count - 1; i++)
                {
                    if (plants[i] < plants[i + 1])
                    {
                        indexes.Add(plants.IndexOf(plants[i + 1]));                        
                    }
                }

                if (indexes.Count > 0)
                {
                    foreach (var i in indexes)
                    {
                        plants[i] = -1;
                    }
                    plants = plants.Where(x => x != -1).ToList();
                    days++;
                }
                else
                {
                    break;
                }

                indexes.Clear();
            }

            Console.WriteLine(days);
        }
    }
}

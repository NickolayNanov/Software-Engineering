using System;
using System.Collections.Generic;
using System.Linq;

namespace Greedy_Times
{
    class jedyMeditation
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());

            var master = new List<string>();
            var knight = new List<string>();
            var padawan = new List<string>();
            var toshkoSlav = new List<string>();
            var yoda = new List<string>();

            for (int i = 0; i < inputLines; i++)
            {
                List<string> current = Console.ReadLine().Split().ToList();

                for (int j = 0; j < current.Count; j++)
                {
                    string currentJedy = current[j];

                    if (currentJedy.StartsWith("m"))
                    {
                        master.Add(current[j]);
                    }
                    else if (currentJedy.StartsWith("k"))
                    {
                        knight.Add(current[j]);
                    }
                    else if (currentJedy.StartsWith("p"))
                    {
                        padawan.Add(current[j]);
                    }
                    else if (currentJedy.StartsWith("t"))
                    {
                        toshkoSlav.Add(current[j]);
                    }
                    else if (currentJedy.StartsWith("s"))
                    {
                        toshkoSlav.Add(current[j]);
                    }
                    else if (currentJedy.StartsWith("y"))
                    {
                        yoda.Add(current[j]);
                    }
                }
            }

            
            if (!yoda.Any())
            {
                Console.WriteLine(string.Join(" ", toshkoSlav) + " " + string.Join(" ", master) + " " + string.Join(" ", knight) + " " + string.Join(" ", padawan));
            }
            else
            {
                Console.WriteLine(string.Join(" ", master) + " " + string.Join(" ", knight) + " " + string.Join(" ", toshkoSlav) + " " +
                    string.Join(" ", padawan));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Grains_of_Sands
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> giants = Console.ReadLine().Split().Select(long.Parse).ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Mort") break;

                string[] tokens = line.Split();

                string command = tokens[0];

                if (command == "Add")
                {
                    long grains = long.Parse(tokens[1]);
                    giants.Add(grains);
                }
                else if (command == "Remove")
                {
                    int graint = int.Parse(tokens[1]);

                    if (giants.Contains(graint))
                    {
                        long ele = giants.First(x => x == graint);
                        giants.Remove(ele);
                    }
                    else
                    {
                        try
                        {
                            giants.RemoveAt(graint);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
                else if (command == "Replace")
                {
                    long toReplace = long.Parse(tokens[1]);
                    long replacement = long.Parse(tokens[2]);

                    if (giants.Contains(toReplace))
                    {
                        long element = giants.First(x => x == toReplace);
                        int index = giants.IndexOf(element);

                        giants[index] = replacement;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "Increase")
                {
                    long value = int.Parse(tokens[1]);

                    if (giants.Contains(value))
                    {
                        long element = giants.First(x => x >= value);

                        for (int i = 0; i < giants.Count; i++)
                        {
                            giants[i] += element;
                        }
                    }
                    else
                    {
                        long element = giants[giants.Count - 1];
                        for (int i = 0; i < giants.Count; i++)
                        {
                            giants[i] += element;
                        }
                    }
                }
                else if (command == "Collapse")
                {
                    long value = long.Parse(tokens[1]);

                    giants.RemoveAll(x => x < value);

                }
            }

            Console.WriteLine(string.Join(" ", giants));
        }
    }
}

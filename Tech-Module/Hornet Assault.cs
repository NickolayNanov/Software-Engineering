    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace Hornet_Assault
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<long> beehies = Console.ReadLine().Split().Select(long.Parse).ToList();
                List<long> hornets = Console.ReadLine().Split().Select(long.Parse).ToList();

              

                for (int i = 0; i < beehies.Count; i++)
                {
               

                    if(hornets.Count == 0)
                    {
                        break;
                    }
                long power = hornets.Sum();
                    if (power > beehies[i])
                    {
                        beehies[i] = 0;
                    }
                    else
                    {
                        beehies[i] -= power;
                        hornets.RemoveAt(0);
                    }
                }
                if (beehies.Sum() > 0)
                {
                    Console.WriteLine(string.Join(" ", beehies.Where(x => x != 0).ToList()));
                }
                else
                {
                    Console.WriteLine(string.Join(" ", hornets));
                }
            }
        }
    }

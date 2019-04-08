using System;
using System.Linq;
using System.Collections.Generic;

namespace Cups_and_Bottles
{
    class Program
    {
        static int remainingLiters = 0;

        static void Main(string[] args)
        {
            int[] cupsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottlesArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupsArray);
            Stack<int> bottles = new Stack<int>(bottlesArray);

            while (true)
            {
                if(cups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
                    Console.WriteLine($"Wasted litters of water: {remainingLiters}");
                    return;
                }
                else if(bottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
                    Console.WriteLine($"Wasted litters of water: {remainingLiters}");
                    return;
                }

                int cup = cups.Peek();
                int bottle = bottles.Pop();

                if(bottle > cup)
                {
                    cups.Dequeue();
                    remainingLiters += bottle - cup;
                }
                else
                {
                    while(cup > 0)
                    {
                        if(bottle >= cup)
                        {
                            remainingLiters += bottle - cup;
                            cups.Dequeue();
                            break;
                        }

                        cup -= bottle;
                        bottle = bottles.Pop();

                    }
                }
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Truck_Tour
    {
        static void Main(string[] args)
        {
            int gasStations = int.Parse(Console.ReadLine());

            Queue<int[]> asd = new Queue<int[]>();

            for (int i = 0; i < gasStations; i++)
            {
                int[] nums = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                asd.Enqueue(nums);
            }

            int index = 0;

            while (true)
            {
                int totalFuel = 0;

                foreach (var current in asd)
                {
                    int fuel = current[0];
                    int distance = current[1];

                    totalFuel += fuel - distance;

                    if (totalFuel < 0)
                    {
                        index++;
                        int[] pumpForRemove = asd.Dequeue();
                        asd.Enqueue(pumpForRemove);
                        break;
                    }
                }

                if(totalFuel >= 0)
                {
                    break;
                }
            }
            Console.WriteLine(index);
        }
    }
}

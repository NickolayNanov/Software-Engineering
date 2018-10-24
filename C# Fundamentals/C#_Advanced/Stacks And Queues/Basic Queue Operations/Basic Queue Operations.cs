using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] items = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            int n = items[0];
            int s = items[1];
            int x = items[2];

            int[] nums = new int[n];
            nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(nums[i]);
            }

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                if(queue.Count == 0)
                {
                    Console.WriteLine(0);
                    return;
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}

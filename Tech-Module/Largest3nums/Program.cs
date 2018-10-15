using System;
using System.Linq;
using System.Collections.Generic;

namespace Largest3nums
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();

            int[] largest = numbers.OrderByDescending(x => x).Take(3).ToArray();

            Console.WriteLine(string.Join(" ", largest));
        }
    }
}

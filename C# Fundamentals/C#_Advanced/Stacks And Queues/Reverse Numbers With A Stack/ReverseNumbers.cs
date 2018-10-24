using System;
using System.Linq;
using System.Collections.Generic;

namespace Reverse_Numbers
{
    class ReverseNumbers
    {
        static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();

            Stack<long> numberReverser = new Stack<long>(numbers);

            while(numberReverser.Count != 0)
            {
                Console.Write(numberReverser.Pop() + " ");
            }
            Console.WriteLine();
        }
    }
}

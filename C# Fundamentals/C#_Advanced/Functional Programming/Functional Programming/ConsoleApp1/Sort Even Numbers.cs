using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Sort_Even_Numbers
    {
        static void Main(string[] args)
        {
            Func<string, int> Parser = n => int.Parse(n);
            Action<string> Orderer = r => Console.WriteLine(r);

            int[] nums = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(Parser)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToArray();

            Console.WriteLine(string.Join(", ", nums));


            
        }
    }
}

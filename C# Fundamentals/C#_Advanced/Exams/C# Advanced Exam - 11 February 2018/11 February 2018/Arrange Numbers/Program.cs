using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrange_Numbers
{
    class Program
    {
        private static readonly string[] IntegerNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };


        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(s => string.Join("", s.Select(ch => IntegerNames[ch - '0'])))));   
        }        
    }
}

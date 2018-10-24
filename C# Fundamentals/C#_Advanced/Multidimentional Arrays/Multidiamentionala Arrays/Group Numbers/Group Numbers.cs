using System;
using System.Linq;

namespace Group_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(decimal.MinValue);
            for (decimal i = 0.0M; i < decimal.MaxValue; i+=0.01m)
            {
                Console.WriteLine(i);
            }
        }
    }
}

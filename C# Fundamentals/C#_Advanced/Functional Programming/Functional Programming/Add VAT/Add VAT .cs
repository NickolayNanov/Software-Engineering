using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> VATing = x => x += x * 0.2;
   
            double[] prices = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x))
                .Select(x => VATing(x))
                .ToArray();

            foreach (var n in prices)
            {
                Console.WriteLine($"{n:f2}");
            }
        }
    }
}

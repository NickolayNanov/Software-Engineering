using System;

namespace Charity_Marathon
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            long runners = long.Parse(Console.ReadLine());
            int averageLaps = int.Parse(Console.ReadLine());
            long lapLength = long.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            decimal money = decimal.Parse(Console.ReadLine());

            long totalRunners = capacity * days;

            if(totalRunners > runners)
            {
                totalRunners = runners;
            }

            long totalMeters = totalRunners * averageLaps * lapLength;
            long totalKilometers = totalMeters / 1000;

            decimal allMoney = money * totalKilometers;

            Console.WriteLine($"Money raised: {allMoney:f2}");
        }
    }
}

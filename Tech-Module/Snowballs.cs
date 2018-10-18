using System;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int snowballs = int.Parse(Console.ReadLine());

            BigInteger bestSV = 0;

            int bestSnow = 0;
            int bestTime = 0;
            int bestQuantity = 0;

            int snowballSnow = 0;
            int snowballTime = 0;
            int snowballQuantity = 0;

            BigInteger snowballValue = 0;

            for (int i = 0; i < snowballs; i++)
            {
                snowballSnow = int.Parse(Console.ReadLine());
                snowballTime = int.Parse(Console.ReadLine());
                snowballQuantity = int.Parse(Console.ReadLine());

                snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuantity);

                if (snowballValue > bestSV)
                {
                    bestSV = snowballValue;
                    bestSnow = snowballSnow;
                    bestTime = snowballTime;
                    bestQuantity = snowballQuantity;
                }
            }
            Console.WriteLine($"{bestSnow} : {bestTime} = {bestSV} ({bestQuantity})");
        }
    }
}

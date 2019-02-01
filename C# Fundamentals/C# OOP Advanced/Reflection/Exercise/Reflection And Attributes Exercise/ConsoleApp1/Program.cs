using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double oldRecord = double.Parse(Console.ReadLine());

            double distanceInMeters = double.Parse(Console.ReadLine());
            double metersPerSec = double.Parse(Console.ReadLine());

            double distance = distanceInMeters * metersPerSec;
            double perFifteenSeconds = Math.Floor((distanceInMeters / 15)) * 12.5;

            double overallDistance = distance + perFifteenSeconds;

            if (oldRecord <= overallDistance)
            {
                Console.WriteLine($"No, he failed! He was {(Math.Abs(oldRecord - overallDistance)):f2} seconds slower.");
            }
            else
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {overallDistance:f2} seconds.");
            }
        }
    }
}
using System;

namespace Hornet_Wings
{
    class Program
    {
        static void Main(string[] args)
        {
            long wigsFlaps = long.Parse(Console.ReadLine());
            double distanceFor1000flaps = double.Parse(Console.ReadLine());
            long endurance = long.Parse(Console.ReadLine());

            double distance = (wigsFlaps / 1000) * distanceFor1000flaps;
            long flapsPerSecs = wigsFlaps / 100;
            long flapsWithRest = (wigsFlaps / endurance) * 5;
            long allFlaps = flapsPerSecs + flapsWithRest;

            Console.WriteLine($"{distance:f2} m.");
            Console.WriteLine($"{allFlaps} s.");
        }
    }
}

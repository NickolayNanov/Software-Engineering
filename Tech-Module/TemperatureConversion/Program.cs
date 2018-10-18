using System;

namespace TemperatureConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            double farenheit = Double.Parse(Console.ReadLine());

            double result = ConvertotToCelsius(farenheit);

            Console.WriteLine($"{result:f2}");
        }

        static double ConvertotToCelsius(double farenheit)
        {
            double celsium = (farenheit - 32) * 5 / 9;

            return celsium;
        }
    }
}

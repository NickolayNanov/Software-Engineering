using System;
using System.Text.RegularExpressions;

namespace Snowflake
{
    class Program

    {
        static void Main(string[] args)
        {
            string surfacePattern = @"[^A-Za-z0-9]+";
            string mantlePattern = @"[0-9\\_]+";
            string corePattern = @"^([^A-Za-z0-9]+)([0-9\\_]+)([A-Za-z]+)([0-9\\_]+)([^A-Za-z0-9]+)";
            // @"[A-Za-z]+";
            Regex surface = new Regex(surfacePattern);
            Regex mantle = new Regex(mantlePattern);
            Regex core = new Regex(corePattern);

            string surface1 = Console.ReadLine();
            string mantle1 = Console.ReadLine();
            string coree = Console.ReadLine();
            string mantle2 = Console.ReadLine();
            string surface2 = Console.ReadLine();

            if(surface.IsMatch(surface1) && mantle.IsMatch(mantle1) 
                && core.IsMatch(coree) && surface.IsMatch(surface2) && mantle.IsMatch(mantle2))
            {
                Console.WriteLine("Valid");

                Regex coreTo = new Regex(corePattern);
                Match match = core.Match(coree);

                int length = match.Groups[3].Length;

                Console.WriteLine(length);
            }
            else
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}

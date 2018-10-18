using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MatcHexadecimalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b(?:0x)?[0-9A-F]+\b";

            string input = Console.ReadLine();

            var hexas = Regex.Matches(input, regex)
                .Cast<Match>()
                .Select(a => a.Value)
                .ToArray();

            Console.WriteLine(string.Join(" ", hexas));
            
        }
    }
}

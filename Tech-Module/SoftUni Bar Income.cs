using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> matches = new List<string>();
            double totalPrice = 0.0;
            while (true)
            {
                string line = Console.ReadLine();

                if(line == "end of shift")
                {
                    break;
                }

                string pattern = @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[+-]?[0-9]*\.?[+-]?[0-9]+)\$";

                Regex regex = new Regex(pattern);

                if (regex.IsMatch(line))
                {
                    Match match = regex.Match(line);
                    string name = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    double price = double.Parse(match.Groups["price"].Value);
                    int count = int.Parse(match.Groups["count"].Value);
                    totalPrice += price * count;

                    string trueMatch = $"{name}: {product} - {price * count:f2}";
                    matches.Add(trueMatch);
                }
            }

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
            Console.WriteLine($"Total income: {totalPrice:f2}");
        }
    }
}

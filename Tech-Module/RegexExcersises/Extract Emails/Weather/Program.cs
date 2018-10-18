using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, KeyValuePair<double, string>> cities = new Dictionary<string, KeyValuePair<double, string>>();

            Regex regex = new Regex(@"([A-Z]{2})(\d+.\d+)([A-Za-z])+\|");

            while (true)
            {
                string line = Console.ReadLine();

                if(line == "end")
                {
                    break;
                }

                Match matches = regex.Match(line);

                if (!matches.Success)
                {
                    continue;
                }

                string city = matches.Groups[1].Value;
                double temp = double.Parse(matches.Groups[2].Value);
                string type = matches.Groups[3].Value;

                if (!cities.ContainsKey(city))
                {
                    cities.Add(city, new KeyValuePair<double, string>());
                }
                else
                {
                    cities[city] = new KeyValuePair<double, string>(temp, type);
                }
            }

            foreach (var city in cities.OrderBy(a => a.Value.Key))
            {
                Console.WriteLine($"{city.Key} => {city.Value.Key:f2} {city.Value.Value}");
            }
        }
    }
}

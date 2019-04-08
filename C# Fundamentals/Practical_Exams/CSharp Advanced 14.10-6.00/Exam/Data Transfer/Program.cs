using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Data_Transfer
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            string asd = @"([A-Za-z ]+)";
            string pattern = $@"s:([^;]*);r:([^\;]*);m--""{asd}""";

            Regex regex = new Regex(pattern);

            List<long> allDigits = new List<long>();
            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                string sender = string.Empty;
                string reciver = string.Empty;
                string message = string.Empty;

                if (regex.IsMatch(input))
                {
                    MatchCollection match = regex.Matches(input);

                    string rough = match[0].Groups[1].Value;

                    message = match[0].Groups[3].Value;
                    for (int j = 0; j < rough.Length; j++)
                    {
                        if (Char.IsNumber(rough[j]))
                        {
                            allDigits.Add((int)char.GetNumericValue(rough[j]));
                        }

                        if(Char.IsLetter(rough[j]) || rough[j] == ' ')
                        {
                            sender += rough[j];
                        }
                    }
                    
                    string roughReciver = match[0].Groups[2].Value;

                    for (int j = 0; j < roughReciver.Length; j++)
                    {
                        if (Char.IsDigit(roughReciver[j]))
                        {
                            allDigits.Add((int)char.GetNumericValue(roughReciver[j]));
                        }

                        if (Char.IsLetter(roughReciver[j]) || roughReciver[j] == ' ')
                        {
                            reciver += roughReciver[j];
                        }
                    }
                    Console.WriteLine($"{sender} says \"" +  $"{message}" + "\"" + $" to {reciver}");                    
                }                
            }
            Console.WriteLine($"Total data transferred: {allDigits.Sum()}MB");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExtractSentencesByKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[A-Za-z0-9\s,\-]+";
            string toSeatch = Console.ReadLine();
            string text = Console.ReadLine();
            Regex regex = new Regex(pattern);
            List<string> sentenses = new List<string>();
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                if (match.Value.Contains(" " + toSeatch + " "))
                {
                    Console.WriteLine(match.Value.TrimEnd('!', '?', '.'));
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Camera_Viwe
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int toSkip = numbers[0];
            int toTake = numbers[1];

            Regex pattern = new Regex(@"(?:\|<)(\w+|)");
            string text = Console.ReadLine();
            MatchCollection matches = pattern.Matches(text);           

            foreach (Match match in matches)
            {               
                char[] output = match.Value.Skip(toSkip + 2).Take(toTake).ToArray();
                words.Add(string.Join("", output));
            }

            Console.WriteLine(string.Join(", ", words));
        }
    }
}

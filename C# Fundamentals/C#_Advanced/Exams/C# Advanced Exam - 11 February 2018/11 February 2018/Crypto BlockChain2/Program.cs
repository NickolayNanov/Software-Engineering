using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Crypto_BlockChain2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Match> cryptoBlocks = new List<Match>();

            string pattern = @"{[^}0-9]*([0-9]{3,})[^{0-9]*}|\[[^\]0-9]*([0-9]{3,})[^\[0-9]*\]";

            int count = int.Parse(Console.ReadLine());
            string input = "";
            List<char> result = new List<char>();

            for (int i = 0; i < count; i++)
            {
                input += Console.ReadLine();
            }

            MatchCollection collection = Regex.Matches(input, pattern);


            AddToList(cryptoBlocks, collection);
            
            foreach (var block in cryptoBlocks)
            {     
                int length = block.Length;
                List<char> numbers = block.Groups[block.Value.StartsWith("{") ? 1 : 2].Value.ToList();

                int counter = numbers.Count / 3;

                for (int i = 0; i < counter; i++)
                {
                    int current = int.Parse(string.Join(string.Empty, numbers.Take(3)));
                    current -= length;
                    result.Add((char)current);
                    numbers.RemoveAt(0);
                    numbers.RemoveAt(0);
                    numbers.RemoveAt(0);
                }
            }

            Console.WriteLine(string.Join(string.Empty, result));
        }

        private static void AddToList(List<Match> cryptoBlocks, MatchCollection collection)
        {
            foreach (Match match in collection)
            {
                if (match.Groups[1].Value.Length % 3 == 0)
                {
                    cryptoBlocks.Add(match);
                }
            }
        }
    }
}

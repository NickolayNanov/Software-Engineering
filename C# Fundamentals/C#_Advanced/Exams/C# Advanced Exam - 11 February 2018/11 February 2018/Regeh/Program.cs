using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\[[A-Z&a-z]+\<([0-9]+)REGEH([0-9]+)\>[A-Z&a-z]+\]");

            string input = Console.ReadLine();
            MatchCollection matches = regex.Matches(input);

            List<int> numbers = new List<int>();
            string result = String.Empty;

            if(matches.Count == 0)
            {
                Console.WriteLine("");
                return;
            }

            foreach (Match match in matches)
            {
                numbers.Add(int.Parse(match.Groups[1].Value));
                numbers.Add(int.Parse(match.Groups[2].Value));
            }

            int numLength = numbers.Count;

            result += input[numbers[0]];
            int numSum = numbers[0];
            int inputLength = input.Length;

            for (int i = 1; i < numLength; i++)
            {
                numSum += numbers[i];

                if(numSum > input.Length)
                {
                    result += input[(numSum % inputLength) + 1];
                }
                else
                {
                    result += input[numSum % inputLength];
                }
            }
            Console.WriteLine(result);
        }
    }
}

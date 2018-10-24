using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace Crypto_Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string text = String.Empty;

            for (int i = 0; i < rows; i++)
            {
                text += Console.ReadLine();
            }

            Regex regex = new Regex(@"\[([^\d\[\]\{\}]*)([\d]{3,})([^\[\]\{\}]*)\]|\{([^\d\[\]\{\}]*)([\d]{3,})([^\[\]\{\}]*)\}");

            if (regex.IsMatch(text))
            {
                MatchCollection matches = regex.Matches(text);

                StringBuilder result = new StringBuilder();

                foreach (Match match in matches)
                {
                    if (match.ToString().StartsWith('{'))
                    {
                        int length = match.ToString().Length;
                        string digitsAsString = match.Groups[5].Value.ToString();

                        ParseNumber(digitsAsString, length, result);
                        
                    }
                    else if(match.ToString().StartsWith('['))
                    {
                        int length = match.ToString().Length;
                        string digitsAsString = match.Groups[5].Value.ToString();

                        ParseNumber(digitsAsString, length, result);
                    }
                }
                Console.WriteLine(result.ToString());
            }
        }

        private static void ParseNumber(string digitsAsString, int length, StringBuilder result)
        {
            if(length % 3 == 0)
            {
                while(digitsAsString.Length != 0)
                {
                    string currentString = new string(digitsAsString.Take(3).ToArray());
                    StringBuilder sb = new StringBuilder(digitsAsString);
                    sb.Remove(0, 3);
                    digitsAsString = sb.ToString();
                    int number = int.Parse(currentString);
                    int charToAdd = number - length;
                    result.Append((char)charToAdd);
                }
            }
        }
    }
}

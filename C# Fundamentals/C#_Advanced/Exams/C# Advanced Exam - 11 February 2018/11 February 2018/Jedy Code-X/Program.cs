using System;
using System.Text.RegularExpressions;

namespace Jedy_Code_X
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string text = "";

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                text += line;
            }

            string firstPattern = Console.ReadLine();
            Regex firstRegex = new Regex($@"{firstPattern}[A-Z]{{firstPattern.Length}}");

            MatchCollection matches = firstRegex.Matches(text);

            string secondPattern = Console.ReadLine();

        }
    }
}

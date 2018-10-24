using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Jedy_X
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string text = "";

            for (int i = 0; i < count; i++)
            {
                text += Console.ReadLine();
            }

            string pattern = Console.ReadLine();
            Regex regex = new Regex(pattern + @"[A-Za-z]{" + pattern.Length + "}" + "[^A-Za-z]");

            MatchCollection matches = regex.Matches(text);

            List<string> jedy = new List<string>();

            foreach (Match match in matches)
            {
                string je = match.ToString();
                je = je.Substring(pattern.Length, pattern.Length);
                jedy.Add(je);
            }

            pattern = Console.ReadLine();
            regex = new Regex(pattern + @"([A-Za-z]){" + pattern.Length + "}" + "[^A-Za-z]");

            matches = regex.Matches(text);

            List<string> messages = new List<string>();

            foreach (Match match in matches)
            {
                string me = match.ToString();
                me = me.Substring(pattern.Length, pattern.Length);
                messages.Add(me);
            }
            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();


            int index = 0;
            foreach (var j in jedy)
            {
                for (int i = index; i < indexes.Length; i++)
                {
                    index++;
                    if(messages.Count >= indexes[i])
                    {
                        Console.WriteLine($"{j} - {messages[indexes[i] - 1]}");
                        break;
                    }
                }
            }
        }
    }
}

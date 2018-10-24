using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Symbols
{
    class Program
    {
        static Dictionary<char, int> letterCounter = new Dictionary<char, int>();

        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            for (int i = 0; i < word.Length; i++)
            {
                if (!letterCounter.ContainsKey(word[i]))
                {
                    letterCounter.Add(word[i], 1);
                }
                else
                {
                    letterCounter[word[i]]++;
                }
            }


            foreach (var letter in letterCounter.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
            }
        }
    }
}

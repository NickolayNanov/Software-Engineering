using System;

namespace Count_Uppercase_Words
{
    class Count_Uppercase_Words
    {
        static void Main(string[] args)
        {
            string[] sentense = Console.ReadLine().Split();

            foreach (var word in sentense)
            {
                if (Char.IsUpper(word[0]))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}

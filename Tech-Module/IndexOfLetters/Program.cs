using System;

namespace IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int[] alphabet = new int[26];

            int count = 0;
            for (int i = 'a'; i <= 'z'; i++)
            {
                alphabet[count] = i;
                count++;
            }

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                for (int j = 0; j < alphabet.Length; j++)
                {
                    if(current == alphabet[j])
                    {
                        Console.WriteLine($"{current} -> {j}");
                    }
                }
            }
        }
    }
}

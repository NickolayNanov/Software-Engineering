using System;

namespace StringsAndTextProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] newString = new char[input.Length];

            for (int i = 0; i < input.Length - 1 / 2; i++)
            {
                newString[i] = input[input.Length - 1 - i];
            }
            
            Console.WriteLine(string.Join("", newString));
        }
    }
}

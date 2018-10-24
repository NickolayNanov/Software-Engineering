using System;
using System.Linq;

namespace Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            
            char startEnd = 'a';
            char middle = 'a';

            for (int rows = 0; rows <parameters[0]; rows++)
            {
                for (int cols = 0; cols < parameters[1]; cols++)
                {
                    Console.Write(startEnd);
                    Console.Write(middle);
                    Console.Write(startEnd);
                    Console.Write(" ");
                    middle++;
                }
                Console.WriteLine();
                startEnd++;
                middle = startEnd;
            }
        }
    }
}

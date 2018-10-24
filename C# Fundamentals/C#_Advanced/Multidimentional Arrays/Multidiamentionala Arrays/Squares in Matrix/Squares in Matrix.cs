using System;
using System.Linq;

namespace Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rows = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            char[][] jagged = new char[rows[0]][];

            for (int i = 0; i < rows[0]; i++)
            {
                jagged[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }

            int count = 0;

            for (int i = 0; i < jagged.Length - 1; i++)
            {
                for (int j = 0; j < jagged[i].Length - 1; j++)
                {
                    if (jagged[i][j] == jagged[i][j + 1]
                        && jagged[i][j] == jagged[i + 1][j]
                        && jagged[i][j] == jagged[i + 1][j + 1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
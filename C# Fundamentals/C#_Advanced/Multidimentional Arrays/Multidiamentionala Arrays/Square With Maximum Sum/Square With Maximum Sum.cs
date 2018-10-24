using System;
using System.Linq;

namespace Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int[][] matrix = new int[parameters[0]][];

            for (int i = 0; i < parameters[0]; i++)
            {
                int[] rowValues = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

                matrix[i] = rowValues;
            }

            int bestRow = 0;
            int bestCol = 0;
            int bestSum = int.MinValue;

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    int currentSum = matrix[row][col] + matrix[row][col + 1] +
                        matrix[row + 1][col] + matrix[row + 1][col + 1];

                    if(currentSum > bestSum)
                    {
                        bestCol = col;
                        bestRow = row;
                        bestSum = currentSum;
                    }
                }
            }

            Console.WriteLine($"{matrix[bestRow][bestCol]} {matrix[bestRow][bestCol + 1]}");
            Console.WriteLine($"{matrix[bestRow + 1][bestCol]} {matrix[bestRow + 1][bestCol + 1]}");
            Console.WriteLine(bestSum);
        }
    }
}

using System;
using System.Linq;

namespace Maximal_Sum
{
    class Maximal_Sum 
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            int[][] matrix = new int[rows][];
           
            for (int i = 0; i < rows; i++)
            {
                int[] current = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                matrix[i] = current;
            }

            int sum = 0;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int col = 0; col < matrix[row].Length - 2; col++)
                {
                    int currentSum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                        matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] + 
                        matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if(currentSum > sum)
                    {
                        sum = currentSum;
                        bestCol = col;
                        bestRow = row;
                    }
                }
            }
            Console.WriteLine("Sum = " + sum);
            Console.WriteLine($"{matrix[bestRow][bestCol]} {matrix[bestRow][bestCol + 1]} {matrix[bestRow][bestCol + 2]}");
            Console.WriteLine($"{matrix[bestRow + 1][bestCol]} {matrix[bestRow + 1][bestCol + 1]} {matrix[bestRow + 1][bestCol + 2]}");
            Console.WriteLine($"{matrix[bestRow + 2][bestCol]} {matrix[bestRow + 2][bestCol + 1]} {matrix[bestRow + 2][bestCol + 2]}");
        }
    }
}

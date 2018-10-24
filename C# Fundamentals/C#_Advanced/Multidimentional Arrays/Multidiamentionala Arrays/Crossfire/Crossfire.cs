using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossfire
{
    class Crossfire
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            List<List<int>> matrix = new List<List<int>>();

            FillMatrix(matrix,rows, cols);

            string input = Console.ReadLine();

            while(input != "Nuke it from orbit")
            {
                int[] coordinates = input.Split().Select(int.Parse).ToArray();
                int row = coordinates[0];
                int col = coordinates[1];
                int radius = coordinates[2];

                Attack(matrix, row, col, radius);
                
                input = Console.ReadLine();
            }

            Print(matrix);
        }

        private static void Print(List<List<int>> matrix)
        {
            foreach (var l in matrix)
            {
                Console.WriteLine(string.Join(" ", l));
            }
        }

        private static void Attack(List<List<int>> matrix, int targetRow, int targetCol, int radius)
        {
            for (int row = targetRow - radius; row <= targetRow + radius; row++)
            {
                if(IsInside(matrix, row, targetCol))
                {
                    matrix[row][targetCol] = 0;
                }
            }

            for (int col = targetCol - radius; col <= targetCol + radius; col++)
            {
                if(IsInside(matrix, targetRow, col))
                {
                    matrix[targetRow][col] = 0;
                }
            }

            for (int row = 0; row < matrix.Count; row++)
            {
                matrix[row].RemoveAll(x => x == 0);

                if(matrix[row].Count == 0)
                {
                    matrix.RemoveAt(row);
                    row--;
                }
            }
        }

        private static bool IsInside(List<List<int>> matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Count && col >= 0 && col < matrix[row].Count;
        }

        private static void FillMatrix(List<List<int>> matrix, int rows, int cols)
        {
            int counter = 1;

            for (int row = 0; row < rows; row++)
            {
                List<int> current = new List<int>();
                for (int col = 0; col < cols; col++)
                {
                    current.Add(counter++);
                }
                matrix.Add(current);
            }
        }
    }
}

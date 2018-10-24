using System;
using System.Linq;

namespace Sum_Matrix_Columns
{
    class Sum_Matrix_Columns
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            int[,] matrix = new int[parameters[0], parameters[1]];


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currentRow[j];
                }

            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int sum = 0;

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sum += matrix[j, i];
                    continue;
                }
                Console.WriteLine(sum);
            }
        }
    }
}

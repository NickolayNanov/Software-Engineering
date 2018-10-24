using System;
using System.Linq;

namespace Multidiamentionala_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int sum = 0;
            int[][] matrix = new int[parameters[0]][];

            for (int i = 0; i < matrix.Length; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = currentRow;
                sum += currentRow.Sum();
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(parameters[1]);
            Console.WriteLine(sum);
        }
    }
}

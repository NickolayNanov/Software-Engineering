using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class JedyGalaxy
    {

        static int[,] matrix;
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = dimestions[0];
            int y = dimestions[1];

            matrix = new int[x, y];
            GetMatix(x, y, matrix);

            long sum = 0;
            string command = Console.ReadLine();
         
            while (command != "Let the Force be with you")
            {
                int[] ivo = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] vader = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                sum += Move(ivo, vader);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static long Move(int[] ivoCoords, int[] vaderCoords)
        {
            long sum = 0l;

            int ivoStartRow = ivoCoords[0];
            int ivoStartCol = ivoCoords[1];

            int vaderStartRow = vaderCoords[0];
            int vaderStartCol = vaderCoords[1];

            for (int row = vaderStartRow; row >= 0; row--)
            {
                if (IsInRange(row, vaderStartCol))
                {
                    matrix[row, vaderStartCol] = 0;
                }
                vaderStartCol--;
            }

            for (int row = ivoStartRow; row >= 0; row--)
            {
                if (IsInRange(row, ivoStartCol))
                {
                    sum += matrix[row, ivoStartCol];
                }
                ivoStartCol++;
            }

            return sum;
        }

        static bool IsInRange(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        private static void GetMatix(int x, int y, int[,] matrix)
        {
            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }
    }
}

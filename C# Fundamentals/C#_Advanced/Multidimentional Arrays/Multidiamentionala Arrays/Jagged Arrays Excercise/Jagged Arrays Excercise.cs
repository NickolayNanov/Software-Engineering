using System;
using System.Linq;

namespace Jagged_Arrays_Excercise
{
    class Program
    {
        static void Main(string[] args)
        {
            long rows = long.Parse(Console.ReadLine());

            char[,] matrix = new char[rows, rows];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            long row = -1;
            long col = -1;
            bool isFound = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (isFound)
                {
                    break;
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == symbol)
                    {
                        isFound = true;
                        row = i;
                        col = j;
                        break;
                    }
                }
            }

            if (isFound)
            {
                Console.WriteLine("({0}, {1})", row, col);
            }
            else
            {
                Console.WriteLine("{0} does not occur in the matrix", symbol);
            }
        }
    }
}

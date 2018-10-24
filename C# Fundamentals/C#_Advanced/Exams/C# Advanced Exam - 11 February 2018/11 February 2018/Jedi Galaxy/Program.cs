using System;
using System.Linq;

namespace Jedi_Galaxy
{
    class Program
    {
        static int startRowGood;
        static int startColGood;

        static int startRowEvil;
        static int startColEvil;

        static int[][] matrix;

        static void Main(string[] args)
        {
            long stars = 0;

            int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            matrix = new int[rows][];

            matrix = GetMatrix(matrix, rows, cols);

            string input;

           while((input = Console.ReadLine()) != "Let the Force be with you")
           {
                int[] ivo = input.Split().Select(int.Parse).ToArray();

                startRowGood = ivo[0];
                startColGood = ivo[1];

                int[] evil = Console.ReadLine().Split().Select(int.Parse).ToArray();

                startRowEvil = evil[0];
                startColEvil = evil[1];

                for (int row = startRowEvil; row >= 0; row--)
                {
                    if (IsInRange(row, startColEvil, matrix))
                    {
                        matrix[row][startColEvil] = 0;
                    }
                    startColEvil--;
                }

                

                for (int row = startRowGood; row >= 0; row--)
                {
                    if (IsInRange(row, startColGood, matrix))
                    {
                        stars += matrix[row][startColGood];
                    }
                    startColGood++;
                }

                
            }
            Console.WriteLine(stars);
        }
        

        static bool IsInRange(int row, int col, int[][] matrix)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static int[][] GetMatrix(int[][] dim,int rows, int cols)
        {
            int count = 0;

            for (int row = 0; row < dim.Length; row++)
            {
                dim[row] = new int[cols];
                for (int col = 0; col < dim[row].Length; col++)
                {
                    dim[row][col] = count;
                    count++;
                }
            }

            matrix = dim;
            return matrix;
        }
    }
}

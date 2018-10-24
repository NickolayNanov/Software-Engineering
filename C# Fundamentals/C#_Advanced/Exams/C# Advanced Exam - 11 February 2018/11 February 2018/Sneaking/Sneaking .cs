using System;
using System.Linq;

namespace _02._Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];

            int[] samCoordinates = FillMatrix(matrix);

            string commands = Console.ReadLine();

            foreach (var command in commands)
            {
                UpdateEnemies(matrix);
                CheckEnemies(matrix);
                MoveSam(command, matrix, samCoordinates);
                CheckNickolaze(matrix);
            }
        }

        private static void CheckNickolaze(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if(matrix[row].Contains('S') && matrix[row].Contains('N'))
                {
                    matrix[row][Array.IndexOf(matrix[row], 'N')] = 'X';
                    Console.WriteLine($"Nikoladze killed!");
                    Print(matrix);
                 
                }
            }
        }

        private static void MoveSam(char command, char[][] matrix, int[] samCoordinates)
        {
            if (command == 'U')
            {
                matrix[samCoordinates[0]][samCoordinates[1]] = '.';
                matrix[--samCoordinates[0]][samCoordinates[1]] = 'S';
            }
            else if (command == 'D')
            {
                matrix[samCoordinates[0]][samCoordinates[1]] = '.';
                matrix[++samCoordinates[0]][samCoordinates[1]] = 'S';
            }
            else if (command == 'R')
            {
                matrix[samCoordinates[0]][samCoordinates[1]] = '.';
                matrix[samCoordinates[0]][++samCoordinates[1]] = 'S';
            }
            else if(command == 'L')
            {
                matrix[samCoordinates[0]][samCoordinates[1]] = '.';
                matrix[samCoordinates[0]][--samCoordinates[1]] = 'S';
            }
        }

        private static void CheckEnemies(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if(matrix[row].Contains('S') && matrix[row].Contains('d'))
                {
                    if(Array.IndexOf(matrix[row], 'S') < Array.IndexOf(matrix[row], 'd'))
                    {
                        matrix[row][Array.IndexOf(matrix[row], 'S')] = 'X';
                        Console.WriteLine($"Sam died at {row}, {Array.IndexOf(matrix[row], 'X')}");
                        Print(matrix);
                    }
                }
                else if (matrix[row].Contains('S') && matrix[row].Contains('b'))
                {
                    if (Array.IndexOf(matrix[row], 'S') > Array.IndexOf(matrix[row], 'b'))
                    {
                        matrix[row][Array.IndexOf(matrix[row], 'S')] = 'X';
                        Console.WriteLine($"Sam died at {row}, {Array.IndexOf(matrix[row], 'X')}");
                        Print(matrix);
                    }
                }
            }
        }

        private static void Print(char[][] matrix)
        {
            foreach (var line in matrix) 
            {
                Console.WriteLine(string.Join("", line));
            }
            Environment.Exit(0);
        }

        private static void UpdateEnemies(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if (matrix[row].Contains('d'))
                {
                    int indexOfEnemy = Array.IndexOf(matrix[row], 'd');

                    if(IsInside(row, indexOfEnemy - 1, matrix))
                    {
                        matrix[row][indexOfEnemy] = '.';
                        matrix[row][indexOfEnemy - 1] = 'd';
                    }
                    else
                    {                        
                        matrix[row][0] = 'b';    
                    }
                }
                else if (matrix[row].Contains('b'))
                {
                    int indexOfEnemy = Array.IndexOf(matrix[row], 'b');

                    if (IsInside(row, indexOfEnemy + 1, matrix))
                    {
                        matrix[row][indexOfEnemy] = '.';
                        matrix[row][indexOfEnemy + 1] = 'b';
                    }
                    else
                    {
                        matrix[row][matrix[row].Length - 1] = 'd';
                    }
                }
            }
        }

        private static bool IsInside(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static int[] FillMatrix(char[][] matrix)
        {
            int[] coordinates = new int[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                 matrix[row] = Console.ReadLine().ToCharArray();

                if (matrix[row].Contains('S'))
                {
                    coordinates = new int[2] { row, Array.IndexOf(matrix[row], 'S') };
                }
            }
            return coordinates;
        }
    }
}
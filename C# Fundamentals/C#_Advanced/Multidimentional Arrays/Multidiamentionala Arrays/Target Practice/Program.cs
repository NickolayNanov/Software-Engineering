using System;
using System.Collections.Generic;
using System.Linq;

namespace Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string snake = Console.ReadLine();
            int[] target = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            char[][] matrix = new char[rows][];

            GetMatrix(matrix, cols, snake);

            Shoot(matrix, target);
            Collapse(matrix);
            Print(matrix);
        }

        private static void Collapse(char[][] matrix)
        {
            Queue<char> elements = new Queue<char>(matrix.Length);
            

            for (int col = 0;  col < matrix.Length;col++)
            {
                int counter = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if(matrix[row][col] != ' ')
                    {
                        elements.Enqueue(matrix[row][col]);
                    }
                    else
                    {
                        counter++;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    matrix[row][col] = ' ';
                }

                for (int row = counter; row < matrix.Length; row++)
                {
                    matrix[row][col] = elements.Dequeue();
                }
            }
        }

        private static void Shoot(char[][] matrix, int[] target)
        {
            int targetRow = target[0];
            int targerCol = target[1];
            int radius = target[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool isInside = Math.Pow((targetRow - row), 2) + Math.Pow((targerCol - col), 2) <= Math.Pow(radius, 2);

                    if (isInside)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static void Print(char[][] matrix)
        {
            foreach (var r in matrix)
            {
                Console.WriteLine(string.Join(" ", r));
            }
        }

        private static void GetMatrix(char[][] matrix, int cols, string snake)
        {
            int counter = 0;
            bool isLeft = true;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[cols];

                if (isLeft)
                {
                   
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        counter = SetLetter(matrix, snake, counter, row, col);
                    }

                    isLeft = false;
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        counter = SetLetter(matrix, snake, counter, row, col);
                    }

                    isLeft = true;
                }
            }
        }

        private static int SetLetter(char[][] matrix, string snake, int counter, int row, int col)
        {
            if (counter > snake.Length - 1)
            {
                counter = 0;
            }

            matrix[row][col] = snake[counter++];
            return counter;
        }
    }
}

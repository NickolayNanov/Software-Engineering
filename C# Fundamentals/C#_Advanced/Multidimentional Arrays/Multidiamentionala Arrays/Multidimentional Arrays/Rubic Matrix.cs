using System;
using System.Linq;

namespace Rubic_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] diamentions = Console.ReadLine()
                  .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();

            int rows = diamentions[0];
            int cols = diamentions[1];

            int[][] rubicMatrix = new int[rows][];
            Fill(rubicMatrix, cols);

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int rolColIndex = int.Parse(tokens[0]);
                string direction = tokens[1];
                int moves = int.Parse(tokens[2]);

                if(direction == "down")
                {
                    MoveDown(rubicMatrix, rolColIndex, moves % rubicMatrix.Length);
                }
                else if(direction == "up")
                {
                    MoveUp(rubicMatrix, rolColIndex, moves % rubicMatrix.Length);
                }
                else if(direction == "left")
                {
                    MoveLeft(rubicMatrix, rolColIndex, moves % rubicMatrix[0].Length);
                }
                else if(direction == "right")
                {
                    MoveRight(rubicMatrix, rolColIndex, moves % rubicMatrix[0].Length);
                }
            }

            int counter = 1;

            for (int row = 0; row < rubicMatrix.Length; row++)
            {
                for (int col = 0; col < rubicMatrix[row].Length; col++)
                {
                    if(rubicMatrix[row][col] == counter)
                    {
                        Console.WriteLine("No swap required");
                        counter++;
                    }
                    else
                    {
                        Rearrange(rubicMatrix, row, col, counter);
                        counter++;
                    }
                }
            }

        }

        private static void Rearrange(int[][] rubicMatrix, int row, int col, int counter)
        {
            for (int targetRow = 0; targetRow < rubicMatrix.Length; targetRow++)
            {
                for (int targerCol = 0; targerCol < rubicMatrix[targetRow].Length; targerCol++)
                {
                    if(rubicMatrix[targetRow][targerCol] == counter)
                    {
                        rubicMatrix[targetRow][targerCol] = rubicMatrix[row][col];
                        rubicMatrix[row][col] = counter;

                        Console.WriteLine($"Swap ({row}, {col}) with ({targetRow}, {targerCol})");
                        return;
                    }
                }
            }
        }

        private static void MoveRight(int[][] rubicMatrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int rightMost = rubicMatrix[row][rubicMatrix[row].Length - 1];

                for (int col = rubicMatrix[row].Length - 1; col > 0; col--)
                {
                    rubicMatrix[row][col] = rubicMatrix[row][col - 1];
                }

                rubicMatrix[row][0] = rightMost;
            }
        }

        private static void MoveLeft(int[][] rubicMatrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int leftMost = rubicMatrix[row][0];

                for (int col = 0; col < rubicMatrix[row].Length - 1; col++)
                {
                    rubicMatrix[row][col] = rubicMatrix[row][col + 1];
                }

                rubicMatrix[row][rubicMatrix[row].Length - 1] = leftMost;
            }
        }

        private static void MoveUp(int[][] rubicMatrix, int col, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int firstElement = rubicMatrix[0][col];

                for (int row = 0; row < rubicMatrix.Length - 1; row++)
                {
                    rubicMatrix[row][col] = rubicMatrix[row + 1][col];
                }
                rubicMatrix[rubicMatrix.Length - 1][col] = firstElement;
            }
        }

        private static void MoveDown(int[][] rubicMatrix, int col, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = rubicMatrix[rubicMatrix.Length - 1][col];

                for (int row = rubicMatrix.Length - 1; row > 0; row--)
                {
                    rubicMatrix[row][col] = rubicMatrix[row - 1][col];
                }
                rubicMatrix[0][col] = lastElement;
            }
        }

        private static void Fill(int[][] rubicMatrix, int cols)
        {
            for (int row = 0; row < rubicMatrix.Length; row++)
            {
                rubicMatrix[row] = new int[3];
            }

            int counter = 1;

            for (int row = 0; row < rubicMatrix.Length; row++)
            {
                for (int col = 0; col < rubicMatrix[row].Length; col++)
                {
                    rubicMatrix[row][col] = counter++;
                }               
            }
        }
    }
}

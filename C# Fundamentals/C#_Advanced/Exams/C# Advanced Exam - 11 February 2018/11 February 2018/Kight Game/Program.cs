namespace _02.Knight_Game
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
   
    public class KnightGame
    {
        public static void Main()
        {
            int ranges = int.Parse(Console.ReadLine());

            char[,] board = new char[ranges, ranges];
            int[,] posibleAttack = new int[ranges, ranges];
            board = GetBoard(board);

            int removed = 0;


            while (true)
            {
                int[,] possibleAttack = new int[ranges, ranges];
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        bool isKnight = board[row, col] == 'K';

                        if (!isKnight)
                        {
                            posibleAttack[row, col] = 0;
                            continue;
                        }
                        int currentTargets = 0;
                        if (IsInRange(board, row + 2, col + 1)) currentTargets++;
                        if (IsInRange(board, row + 2, col - 1)) currentTargets++;
                        if (IsInRange(board, row - 2, col - 1)) currentTargets++;
                        if (IsInRange(board, row - 2, col + 1)) currentTargets++;
                        if (IsInRange(board, row - 1, col - 2)) currentTargets++;
                        if (IsInRange(board, row - 1, col + 2)) currentTargets++;
                        if (IsInRange(board, row + 1, col + 2)) currentTargets++;
                        if (IsInRange(board, row + 1, col - 2)) currentTargets++;

                        posibleAttack[row, col] = currentTargets;
                    }
                }

                int removeRow = -1;
                int removeCol = -1;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (posibleAttack[row, col] > (removeRow >= 0 ? posibleAttack[removeRow, removeCol] : 0))
                        {
                            removeRow = row;
                            removeCol = col;
                        }
                    }
                }

                if (removeRow == -1)
                {
                    break;
                }
                removed++;
                board[removeRow, removeCol] = '0';  
            }
            Console.WriteLine(removed);

        }
        private static char[,] GetBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] current = Console.ReadLine().ToCharArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = current[col];
                }
            }
            return board;
        }

        private static bool IsInRange(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1) && board[row,col] == 'K';
        }
    }

}
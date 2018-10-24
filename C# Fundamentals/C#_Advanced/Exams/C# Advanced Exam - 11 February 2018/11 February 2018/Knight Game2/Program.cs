using System;

namespace Knight_Game2
{
    class Program
    {
        static void Main(string[] args)
        {
            int ranges = int.Parse(Console.ReadLine());        
            char[,] board = new char[ranges, ranges];

            FillBoard(board);

            int removed = 0;

            bool gameOver = false;
            int[,] possibleAttacks = new int[ranges, ranges];

            while (!gameOver)
            {
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        bool isKnight = board[row, col] == 'K';
                        
                        if (!isKnight)
                        {
                            possibleAttacks[row, col] = 0;
                            continue;
                        }
                        int counter = 0;
                        if (IsValid(board, row + 2, col - 1)) counter++;
                        if (IsValid(board, row + 2, col + 1)) counter++;
                        if (IsValid(board, row - 2, col + 1)) counter++;
                        if (IsValid(board, row - 2, col - 1)) counter++;
                        if (IsValid(board, row - 1, col + 2)) counter++;
                        if (IsValid(board, row - 1, col - 2)) counter++;
                        if (IsValid(board, row + 1, col + 2)) counter++;
                        if (IsValid(board, row + 1, col - 2)) counter++;

                        possibleAttacks[row, col] = counter;

                        
                    }
                }

               
                    int removeRow = -1;
                    int removeCol = -1;

                    for (int row = 0; row < board.GetLength(0); row++)
                    {
                        for (int col = 0; col < board.GetLength(1); col++)
                        {
                            if(possibleAttacks[row, col] > (removeRow >= 0 ? possibleAttacks[removeRow, removeCol] : 0))
                            {
                                removeRow = row;
                                removeCol = col;
                            }
                        }
                    }

                    if(removeRow == -1)
                    {
                        break;
                    }

                    removed++;
                    board[removeRow, removeCol] = '0';
                
            }
            Console.WriteLine(removed);
        }

        private static bool IsValid(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) &&
                col >= 0 && col < board.GetLength(1)
                && board[row, col] == 'K';
        }

        private static void FillBoard(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] current = Console.ReadLine().ToCharArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = current[col];
                }
            }
        }
    }
}

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dangerous_Floor
{
    class Dangerous_Floor
    {
        static int[] currentCoordinates = new int[2];
        static int[] targetedCoordinates = new int[2];

        static void Main(string[] args)
        {
            //Четем матрицата
            //Сплитваме командата
            // --проверяваме трите усливия и ако дадено не отговори принтим

            char[][] board = new char[8][];
            FillBoard(board);

            string info = Console.ReadLine();

            while (info != "END")
            {
                string[] tokens = info
                    .Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string first = tokens[0];
                string second = tokens[1];

                char figure = first[0];
                int currentRow = (int)char.GetNumericValue(first[1]);
                int currentCol = (int)char.GetNumericValue(first[2]);

                int finalRow = (int)char.GetNumericValue(second[0]);
                int finalCol = (int)char.GetNumericValue(second[1]);

                IsMovePossible(figure, board,currentRow, currentCol, finalRow, finalCol);


                info = Console.ReadLine();
            }


        }

        private static void IsMovePossible(char figure, char[][] board, int currentRow, int currentCol, int targetRow, int targetCol)
        {
            bool isPeaseAllowed = Check(figure, board, currentRow, currentCol);
            char fig = figure;
            if (!isPeaseAllowed)
            {
                PrintNoSuchFig();
            }
            else
            {
                switch (fig)
                {
                    case 'K':

                        bool kingValid = CheckKing(board, currentRow, currentCol, targetRow, targetCol);

                        if (!kingValid)
                        {
                            PrintInvalidMove();
                        }
                        else
                        {
                            try
                            {
                                board[currentRow][currentCol] = 'x';
                            }
                            catch
                            {
                                PrintOutOfBoundries();
                            }

                            try
                            {
                                board[targetRow][targetCol] = 'K';
                            }
                            catch
                            {
                                board[currentRow][currentCol] = 'K';
                                PrintOutOfBoundries();
                            }
                        }
                        break;

                    case 'R':
                        bool rookValid = CheckRook(board, currentRow, currentCol, targetRow, targetCol);

                        if (!rookValid)
                        {
                            PrintInvalidMove();
                        }
                        else
                        {
                            try
                            {
                                board[currentRow][currentCol] = 'x';
                            }
                            catch
                            {
                                PrintOutOfBoundries();
                            }

                            try
                            {
                                board[targetRow][targetCol] = 'R';
                            }
                            catch
                            {
                                PrintOutOfBoundries();
                                board[currentRow][currentCol] = 'R';
                            }
                        }
                        break;

                    case 'B':
                        bool bishopValid = CheckBishop(board, currentRow, currentCol, targetRow, targetCol);

                        if (!bishopValid)
                        {
                            PrintInvalidMove();
                        }
                        else
                        {
                            try
                            {
                                board[currentRow][currentCol] = 'x';
                            }
                            catch
                            {
                                PrintOutOfBoundries();
                            }

                            try
                            {
                                board[targetRow][targetCol] = 'B';
                            }
                            catch
                            {
                                board[currentRow][currentCol] = 'B';
                                PrintOutOfBoundries();
                            }
                        }
                        break;
                    case 'Q':
                        bool queenValid = CheckQueen(board, currentRow, currentCol, targetRow, targetCol);

                        if (!queenValid)
                        {
                            PrintInvalidMove();
                        }
                        else
                        {
                            try
                            {
                                board[currentRow][currentCol] = 'x';
                            }
                            catch
                            {
                                PrintOutOfBoundries();
                            }

                            try
                            {
                                board[targetRow][targetCol] = 'Q';
                            }
                            catch
                            {
                                board[currentRow][currentCol] = 'x';
                                PrintOutOfBoundries();
                            }
                        }
                        break;

                    case 'P':
                        bool pawnValid = CheckPawn(currentRow, currentCol, targetRow, targetCol);

                        if (!pawnValid)
                        {
                            PrintInvalidMove();
                        }
                        else
                        {
                            try
                            {
                                board[currentRow][currentCol] = 'x';
                            }
                            catch
                            {
                                PrintOutOfBoundries();
                            }
                            try
                            {
                                board[targetRow][targetCol] = 'P';
                            }
                            catch
                            {
                                board[currentRow][currentCol] = 'x';
                                PrintOutOfBoundries();
                            }
                        }
                        break;
                }
            }
        }

        private static bool CheckPawn(int currentRow, int currentCol, int targetRow, int targetCol)
        {
            if (currentRow - targetRow == 1)
            {
                return true;
            }
            return false;
        }

        private static bool CheckQueen(char[][] board, int currentRow, int currentCol, int targetRow, int targetCol)
        {
            if(CheckRook(board, currentRow, currentCol, targetRow, targetCol) || CheckBishop(board, currentRow, currentCol, targetRow, targetCol))
            {
                return true;
            }
            return false;
        }


        private static bool CheckBishop(char[][] board, int currentRow, int currentCol, int targetRow, int targetCol)
        {
            int rowDiff = Math.Abs(currentRow - targetRow);
            int colDiff = Math.Abs(currentCol - targetCol);

            bool leftUpRow = currentCol > targetRow;
            bool leftUpCol = currentRow > targetCol;

            bool rightUpRow = currentRow > targetRow;
            bool rightUpCol = currentCol < targetCol;

            bool leftDownRow = currentRow < targetRow;
            bool leftDownCol = currentCol > targetCol;

            bool rightDownRow = currentRow < targetRow;
            bool rightDownCol = currentCol < targetCol;

            if (rowDiff == colDiff)
            {
                if ((leftUpRow && leftUpCol) || (rightUpRow && rightUpCol)
                    || (leftDownRow && leftDownCol) || (rightDownRow && rightDownCol))
                {
                    return true;
                }
            }
            return false;
            return false;
        }

        private static bool CheckRook(char[][] board, int currentRow, int currentCol, int targetRow, int targetCol)
        {
            if (currentRow == targetRow && currentCol != targetCol || currentCol == targetCol && currentRow != targetRow)
            {
                return true;
            }
            return false;
        }

        private static bool CheckKing(char[][] board, int currentRow, int currentCol, int targetRow, int targetCol)
        {
            if (Math.Abs(currentRow - targetRow) == 1 || Math.Abs(currentCol - targetCol) == 1)
            {
                return true;
            }
            return false;
        }

        private static void PrintInvalidMove()
        {
            Console.WriteLine("Invalid move!");
        }

        private static void PrintNoSuchFig()
        {
            Console.WriteLine("There is no such a piece!");
        }

        private static void PrintOutOfBoundries()
        {
            Console.WriteLine("Move go out of board!");
        }

        private static bool Check(char figure, char[][] board, int currentRow, int currentCol)
        {
            return board[currentRow][currentCol] == figure;
        }

        private static void FillBoard(char[][] board)
        {
            for (int row = 0; row < board.Length; row++)
            {
                board[row] = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }
        }
    }
}

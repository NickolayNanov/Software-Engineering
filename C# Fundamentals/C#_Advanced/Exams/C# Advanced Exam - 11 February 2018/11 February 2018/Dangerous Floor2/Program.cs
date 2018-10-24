using System;
using System.Linq;

namespace Dangerous_Floor2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = GetBoard();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split(new char[] { '-' }, 
                    StringSplitOptions.RemoveEmptyEntries);

                string first = tokens[0];
                string second = tokens[1];

                char figure = first[0];

                int startRow = (int)char.GetNumericValue(first[1]);
                int startCol = (int)char.GetNumericValue(first[2]);

                int targetRow = (int)char.GetNumericValue(second[0]);
                int targetCol = (int)char.GetNumericValue(second[1]);

                IsMovePossible(board, figure, startRow, startCol, targetRow, targetCol);

                input = Console.ReadLine();
            }
        }

        private static void IsMovePossible(char[][] board, char figure, int startRow, int startCol, int targetRow, int targetCol)
        {
            if (!Check(board, startRow, startCol, figure))
            {
                PrintInvalidPiece();
            }
            else
            {
                switch (figure)
                {
                    case 'K':
                        bool isKing = TryKing(startRow, startCol, targetRow, targetCol);

                        if (!isKing)
                        {
                            PrintInvalidMoove();
                        }
                        else
                        {
                            try
                            {
                                board[targetRow][targetCol] = 'K';
                                board[startRow][startCol] = 'x';
                            }
                            catch
                            {
                                PrintOutOfBorders();
                            }
                        }
                    break;
                    case 'P':
                        bool isPown = TryPawn(startRow, targetRow, startCol, targetCol);

                        if (!isPown)
                        {
                            PrintInvalidMoove();
                        }
                        else
                        {
                            try
                            {
                                board[targetRow][targetCol] = 'P';
                                board[startRow][startCol] = 'x';
                            }
                            catch
                            {
                                PrintOutOfBorders();
                            }
                        }
                    break;
                    case 'R':
                        bool isRook = TryRook(startRow, startCol, targetRow, targetCol);

                        if (!isRook)
                        {
                            PrintInvalidMoove();
                        }
                        else
                        {
                            try
                            {
                                board[targetRow][targetCol] = 'R';
                                board[startRow][startCol] = 'x';
                            }
                            catch
                            {
                                PrintOutOfBorders();
                            }
                        }
                    break;
                    case 'B':
                        bool isBshop = CheckBishop(startRow, startCol, targetRow, targetCol);

                        if (!isBshop)
                        {
                            PrintInvalidMoove();
                        }
                        else
                        {
                            try
                            {
                                board[targetRow][targetCol] = 'B';
                                board[startRow][startCol] = 'x';
                            }
                            catch
                            {
                                PrintOutOfBorders();
                            }
                        }
                   break;
                   case 'Q':
                        bool isQueen = TryQueen(startRow, startCol, targetRow, targetCol);

                        if (!isQueen)
                        {
                            PrintInvalidMoove();
                        }
                        else
                        {
                            try
                            {
                                board[targetRow][targetCol] = 'Q';
                                board[startRow][startCol] = 'x';
                            }
                            catch
                            {
                                PrintOutOfBorders();
                            }
                        }
                   break;
                }
            }
        }

        private static bool TryQueen(int startRow, int startCol, int targetRow, int targetCol)
        {
            return CheckBishop(startRow, startCol, targetRow, targetCol) || TryRook(startRow, startCol, targetRow, targetCol);
        }

        private static bool CheckBishop( int currentRow, int currentCol, int targetRow, int targetCol)
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
        }

        private static bool TryRook(int startRow, int startCol, int targetRow, int targetCol)
        {
            return startRow == targetRow && startCol != targetCol || startRow != targetRow && startCol == targetCol;
        }

        private static bool TryPawn(int startRow, int targetRow, int startCol, int targetCol)
        {
            return startRow - targetRow == 1 && targetCol == startCol ;
        }

        private static void PrintOutOfBorders()
        {
            Console.WriteLine("Move go out of board!");
        }

        private static bool TryKing(int startRow, int startCol, int targetRow, int targetCol)
        {
            return Math.Abs(startRow - targetRow) == 1 || Math.Abs(startCol - targetCol) == 1;
        }

        private static void PrintInvalidMoove()
        {
            Console.WriteLine("Invalid move!");
        }

        private static void PrintInvalidPiece()
        {
            Console.WriteLine("There is no such a piece!");
        }

        private static bool Check(char[][] board, int startRow, int startCol, char figure)
        {
            return board[startRow][startCol] == figure;
        }

        private static char[][] GetBoard()
        {
            char[][] matrix = new char[8][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }
            return matrix;
        }
    }
}

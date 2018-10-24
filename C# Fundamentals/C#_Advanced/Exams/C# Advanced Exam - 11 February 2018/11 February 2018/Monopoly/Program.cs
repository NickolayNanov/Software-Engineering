using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    class Program
    {
        static int hotelsCount = 0;
        static int turns = 0;
        static int money = 50;

        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimentions[0];
            int cols = dimentions[1];

            char[][] board = new char[rows][];
            GetBoard(board);
            
            for (int row = 0; row < board.Length; row++)
            {
                string currentRow = string.Join(string.Empty, board[row]);

                for (int col = 0; col < currentRow.Length; col++)
                {
                    int index = row % 2 == 0 ? col : currentRow.Length - col - 1;

                    char item = currentRow[index];
                    CheckItem(item, row, col, index);

                    money += hotelsCount * 10;
                    turns++;
                }
            }

            Console.WriteLine("Turns "  + turns);
            Console.WriteLine("Money " + money);
        }

        private static void CheckItem(char item, int row, int col, int index)
        {
            if (item.Equals('H'))
            {
                hotelsCount++;
                Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotelsCount}.");
                money -= money;
            }
            else if (item.Equals('J'))
            {               
                Console.WriteLine($"Gone to jail at turn {turns}.");
                turns += 2;
                money += 2 * (hotelsCount * 10);
            }
            else if (item.Equals('S'))
            {
                int colIndex = row % 2 == 0 ? col : index;
                int sum = Math.Min(money, (colIndex + 1) * (row + 1));
                money -= sum;
                Console.WriteLine($"Spent {sum} money at the shop.");
            }
        }

        private static void GetBoard(char[][] board)
        {
            for (int row = 0; row < board.Length; row++)
            {
                char[] current = Console.ReadLine().ToArray();
                board[row] = current;
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Radioactive_Bunnies
{
    class Radioactive__Bunnies
    {
        static char[][] jagged;

        static int playerRow;
        static int playerCol;

        static bool isDead;
        static bool isOutside;

        static void Main(string[] args)
        {
            int[] diamentions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rows = diamentions[0];
            int cols = diamentions[1];

            jagged = new char[rows][];
            FillJagged(cols);
            string comands = Console.ReadLine();

            MovePlayer(comands);
        }

        private static void MovePlayer(string comands)
        {
            for (int row = 0; row < comands.Length; row++)
            {
                char currentCommand = comands[row];

                if(currentCommand == 'U')
                {
                    Move(-1, 0);
                }
                else if(currentCommand == 'L')
                {
                    Move(0, -1);
                }
                else if(currentCommand == 'R')
                {
                    Move(0, 1);
                }
                else if(currentCommand == 'D')
                {
                    Move(1, 0);
                }

                Spread();

                if (isDead)
                {
                    Print();
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                        
                }
                else if (isOutside)
                {
                    Print();
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }

                
            }
        }

        private static void Print()
        {
            foreach (var arr in jagged)
            {
                Console.WriteLine(string.Join("", arr));
            }
        }

        private static void Spread()
        {
            Queue<int[]> indexes = new Queue<int[]>();

            for (int row = 0; row < jagged.Length; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    if(jagged[row][col] == 'B')
                    {
                        indexes.Enqueue(new int[] { row, col });
                    }
                }
            }

            while(indexes.Count > 0)
            {
                int[] current = indexes.Dequeue();

                int targetRow = current[0];
                int targetCol = current[1];


                //Up
                if(IsInside(targetRow - 1, targetCol))
                {
                    if(IsPlayer(targetRow - 1, targetCol))
                    {
                        isDead = true;
                    }
                    jagged[targetRow - 1][targetCol] = 'B';
                }

                //Down
                if (IsInside(targetRow + 1, targetCol))
                {
                    if (IsPlayer(targetRow + 1, targetCol))
                    {
                        isDead = true;
                    }
                    jagged[targetRow + 1][targetCol] = 'B';
                }

                //Left
                if (IsInside(targetRow, targetCol - 1))
                {
                    if (IsPlayer(targetRow, targetCol - 1))
                    {
                        isDead = true;
                    }
                    jagged[targetRow][targetCol - 1] = 'B';
                }

                //Right
                if (IsInside(targetRow, targetCol + 1))
                {
                    if (IsPlayer(targetRow, targetCol + 1))
                    {
                        isDead = true;
                    }
                    jagged[targetRow][targetCol + 1] = 'B';
                }
            }
        }

        private static bool IsPlayer(int row, int col)
        {
            return jagged[row][col] == 'P';
        }

        private static void Move(int row, int col)
        {
            int targetRow = playerRow + row;
            int targerCol = playerCol + col;

            if(!IsInside(targetRow, targerCol))
            {
                jagged[playerRow][playerCol] = '.';
                isOutside = true;
            }
            else if(IsBunny(targetRow, targerCol))
            {
                jagged[playerRow][playerCol] = '.';
                playerRow += row;
                playerCol += col;                
                isDead = true;
            }
            else
            {
                jagged[playerRow][playerCol] = '.';

                playerRow += row;
                playerCol += col;

                jagged[playerRow][playerCol] = 'P';
            }
        }

        private static bool IsBunny(int row, int col)
        {
            return jagged[row][col] == 'B';
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length;
        }

        private static void FillJagged(int cols)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                string line = Console.ReadLine();
                jagged[row] = new char[cols];
                
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = line[col];

                    if(jagged[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}

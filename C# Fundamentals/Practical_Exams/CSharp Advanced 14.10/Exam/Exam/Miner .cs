using System;
using System.Linq;

namespace Exam
{
    class Program
    {
        public static long coals;

        static void Main(string[] args)
        {
            long size = long.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            char[][] field = new char[size][];

            long[] miner = GetCoords(field);

            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if(field[row][col] == 'c')
                    {
                        coals++;
                    }
                }
            }

            foreach (var command in commands)
            {
                MoveMiner(field, miner, command);
                if (coals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({miner[0]}, {miner[1]})");
                    return;
                }
            }

            Console.WriteLine($"{coals} coals left. ({miner[0]}, {miner[1]})");
        }

        private static void MoveMiner(char[][] field, long[] miner, string command)
        {
            long row = miner[0];
            long col = miner[1];

            switch (command)
            {
                case "up":
                    if (GoingAway(field, row - 1, col))
                    {
                        if (field[row - 1][col] == 'e')
                        {
                            Console.WriteLine($"Game over! ({row - 1}, {col})");
                            Environment.Exit(0);
                        }
                        else if (field[row - 1][col] == 'c')
                        {
                            field[row - 1][col] = '*';
                            coals--;
                            field[row - 1][col] = 's';
                            miner[0] -= 1;
                            break;
                        }

                        field[row][col] = '*';
                        field[row - 1][col] = 's';
                        miner[0] -= 1;
                    }
                    break;
                case "down":
                    if (GoingAway(field, row + 1, col))
                    {
                        if (field[row + 1][col] == 'e')
                        {
                            Console.WriteLine($"Game over! ({row + 1}, {col})");
                            Environment.Exit(0);
                        }
                        else if (field[row + 1][col] == 'c')
                        {
                            field[row + 1][col] = '*';
                            coals--;
                            field[row + 1][col] = 's';
                            miner[0] += 1;
                            return;
                        }

                        field[row][col] = '*';
                        field[row + 1][col] = 's';
                        miner[0] += 1;
                    }
                    break;
                case "right":
                    if (GoingAway(field, row, col + 1))
                    {
                        if (field[row][col + 1] == 'e')
                        {
                            Console.WriteLine($"Game over! ({row}, {col + 1})");
                            Environment.Exit(0);
                        }
                        else if (field[row][col + 1] == 'c')
                        {
                            field[row][col + 1] = 's';
                            coals--;
                            field[row][col] = '*';
                            miner[1] += 1;
                            return;
                        }

                        field[row][col] = '*';
                        field[row][col + 1] = 's';
                        miner[1] += 1;
                    }
                    break;
                case "left":
                    if (GoingAway(field, row, col - 1))
                    {
                        if (field[row][col - 1] == 'e')
                        {
                            Console.WriteLine($"Game over! ({row}, {col - 1})");
                            Environment.Exit(0);
                        }
                        else if (field[row][col - 1] == 'c')
                        {
                            field[row][col - 1] = 's';
                            coals--;
                            field[row][col] = '*';
                            miner[1] -= 1;
                            return;
                        }

                        field[row][col] = '*';
                        field[row][col - 1] = 's';
                        miner[1] -= 1;
                    }
                    break;
            }
        }

        private static bool GoingAway(char[][] field, long row, long col)
        {
            return row >= 0 && row < field.Length && col >= 0 && col < field[row].Length;
        }

        private static long[] GetCoords(char[][] field)
        {
            long[] coords = new long[2];

            for (int row = 0; row < field.Length; row++)
            {
                field[row] = Console.ReadLine().Split().Select(char.Parse).ToArray();

                if (field[row].Contains('s'))
                {
                    coords = new long[2] { row, Array.IndexOf(field[row], 's') };
                }
            }

            return coords;
        }
    }
}///-+ 1 виж в проверките за излизане от матрицата

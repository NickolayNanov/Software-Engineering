using System;
using System.Linq;

namespace Parking_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            bool[][] parking = new bool[dimentions[0]][];

            FillMatrix(parking, dimentions[1]);

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "stop") break;

                int[] tokens = line.Split().Select(int.Parse).ToArray();

                int startRow = tokens[0];
                int targetRow = tokens[1];
                int targetCol = tokens[2];

                int forcedCol = -1;

                int distance = 0;
                if(parking[targetRow][targetCol] == true)
                {
                    if(!parking[targetRow].Any(x => x == false))
                    {
                        Console.WriteLine($"Row {targetRow} full");
                        continue;
                    }

                    for (int col = 0; col < parking[targetRow].Length; col++)
                    {
                        if(parking[targetRow][col] == false)
                        {
                            forcedCol = col;                          
                            break;
                        }
                    }

                    if (forcedCol < 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(forcedCol + 1);
                        parking[targetRow][forcedCol] = true;
                    }
                }
                else
                {
                    Console.WriteLine(Math.Abs(startRow - targetRow) + targetCol + 1);                    
                    parking[targetRow][targetCol] = true;
                }

            }

        }

        private static void FillMatrix(bool[][] parking, int col)
        {
            for (int row = 0; row < parking.Length; row++)
            {
                parking[row] = new bool[col];
            }

            for (int row = 0; row < parking.Length; row++)
            {
                parking[row][0] = true;
            }
        }
    }
}

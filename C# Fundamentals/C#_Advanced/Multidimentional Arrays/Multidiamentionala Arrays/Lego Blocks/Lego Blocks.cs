using System;
using System.Linq;

namespace P07.LegoBlocks
{
    class LegoBlocks
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] first = new int[rows][];
            int[][] second = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                first[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < rows; row++)
            {
                second[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int allElements = 0;
            bool isTrue = true;
            int length = first[0].Length + second[0].Length;

            for (int row = 0; row < rows; row++)
            {
                int currentLength = first[row].Length + second[row].Length;

                if(length != currentLength)
                {
                    isTrue = false;
                }

                allElements += currentLength;
            }

            if (isTrue)
            {
                for (int row = 0; row < rows; row++)
                {
                    int[] printable = first[row].Concat(second[row]).ToArray();

                    Console.WriteLine("[{0}]", string.Join(", ", printable));
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {allElements}");
            }
        }
    }
}
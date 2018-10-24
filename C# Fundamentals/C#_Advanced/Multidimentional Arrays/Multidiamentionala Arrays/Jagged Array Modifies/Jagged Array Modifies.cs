using System;
using System.Linq;

namespace Jagged_Array_Modifies
{
    class Program
    {
        static void Main(string[] args)
        {
            int parameter = int.Parse(Console.ReadLine());
            int[][] jagged = new int[parameter][];

            for (int i = 0; i < jagged.GetLength(0); i++)
            {
                int[] current = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jagged[i] = current;
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END") break;

                string[] tokens = line.Split();

                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if(row > jagged.GetLength(0) - 1 || row < 0 || col > jagged[0].Length - 1 || col < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (command)
                {
                    case "Add":
                        jagged[row][col] += value;
                        break;
                    case "Subtract":
                        jagged[row][col] -= value;
                        break;
                }

            }

            foreach (var arr in jagged)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}

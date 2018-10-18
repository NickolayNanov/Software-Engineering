using System;
using System.Collections.Generic;
using System.Linq;

namespace Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] field = new int[size];

            List<int> ladybugIndexes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(i => i >= 0 && i < size)
                .ToList();

            foreach (var index in ladybugIndexes)
            {
                field[index] = 1;
            }


            while (true)
            {
                
                string line = Console.ReadLine();

                if (line == "end") break;

                string[] tokens = line.Split();

                int indexLadybug = int.Parse(tokens[0]);
                string direction = tokens[1];
                int flyingLength = int.Parse(tokens[2]);

                if(direction == "left")
                {
                    flyingLength *= -1;
                }

                if(indexLadybug < 0 || indexLadybug >= size)
                {
                    continue;
                }

                if(field[indexLadybug] == 0)
                {
                    continue;
                }

                field[indexLadybug] = 0;

                int nextIndex = indexLadybug;

                while (true)
                {
                    nextIndex += flyingLength;

                    if(nextIndex < 0 || nextIndex >= size)
                    {
                        break;
                    }

                    if(field[nextIndex] == 1)
                    {
                        continue;
                    }

                    field[nextIndex] = 1;
                    break;
                }
            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}

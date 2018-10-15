using System;
using System.Linq;

namespace PairsByDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int difference = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                int currentNumber = numbers[i];

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int condition = Math.Abs(currentNumber - numbers[j]);

                    if (condition == difference)
                    {
                        count++;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}//1 5 3 4 2

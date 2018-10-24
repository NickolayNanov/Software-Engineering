using System;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parameters = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int start = parameters[0];
            int end = parameters[1];

            string condition = Console.ReadLine();

            int[] numbers = new int[end - start];
            int counter = 0;

            for (int i = start; i <= end- 1 ; i++)
            {
                numbers[counter++] = i;
            }

            if(condition == "odd")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 != 0)));
            }
            else if(condition == "even")
            {
                Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 == 0)));
            }

            
        }
    }
}

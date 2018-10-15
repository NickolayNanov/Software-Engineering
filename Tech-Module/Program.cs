using System;
using System.Linq;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr01 = Console.ReadLine().Split().ToArray();
            string[] arr02 = Console.ReadLine().Split().ToArray();
            int length = Math.Min(arr01.Length, arr02.Length);

            int counter = 0;

            for(int index = 0; index < length; index++)
            {
                if(arr01[index] == arr02[index])
                {
                    counter++;
                }
            }

            Array.Reverse(arr01);
            Array.Reverse(arr02);

            int reversedCounter = 0;

            for (int index = 0; index < length; index++)
            {
                if (arr01[index] == arr02[index])
                {
                    reversedCounter++;
                }
            }

            int longer = Math.Max(counter, reversedCounter);

            Console.WriteLine(longer);

        }
    }
}

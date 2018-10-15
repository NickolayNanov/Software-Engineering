using System;
using System.Linq;

namespace RotateAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //print

            int[] numbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            int rotations = int.Parse(Console.ReadLine());
            int[] sumArray = new int[numbers.Length];

            for (int i = 0; i < rotations; i++)
            {
                Shift(numbers);
                Sum(sumArray, numbers);

            }
            Console.WriteLine(string.Join(" ", sumArray));

        }

        private static void Sum(int[] sumArray, int[] numbers)
        {
            for (int i = 0; i < sumArray.Length; i++)
            {
                sumArray[i] += numbers[i];
            }
        }

        private static void Shift(int[] numbers)
        {
            int last = numbers[numbers.Length - 1];

            for (int i = numbers.Length - 1; i > 0; i--)
            {
                numbers[i] = numbers[i - 1];
               
            }
            numbers[0] = last;
        }
    }
}

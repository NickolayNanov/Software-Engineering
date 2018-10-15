using System;
using System.Linq;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = numbers.Length / 4;
            int[] result = new int[2 * k];

            int[] left = numbers.Take(k).ToArray();
            int[] center = numbers.Skip(k).Take(2 * k).ToArray();
            int[] right = numbers.Skip(3 * k).ToArray();

            Array.Reverse(left);
            Array.Reverse(right);

            for (int i = 0; i < 2 * k; i++)
            {
                result[i] = left[i] + center[i];
                result[i - 1] = right[i] + center[i - 1];
            }

            Console.WriteLine(string.Join(" ", result ));
        }
    }
}

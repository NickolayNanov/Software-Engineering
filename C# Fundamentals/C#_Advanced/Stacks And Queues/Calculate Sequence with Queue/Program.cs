using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculate_Sequence_with_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            List<long> numbers = new List<long>();
            queue.Enqueue(num);
            numbers.Add(num);
            for (int i = 0; i < 17; i++)
            {
                long currentNumber = queue.Dequeue();

                long a = currentNumber + 1;
                long b = currentNumber * 2 + 1;
                long c = currentNumber + 2;

                queue.Enqueue(a);
                queue.Enqueue(b);
                queue.Enqueue(c);

                numbers.Add(a);
                numbers.Add(b);
                numbers.Add(c);
            }
            Console.WriteLine(string.Join(" ", numbers.Take(50)));   
        }
    }
}

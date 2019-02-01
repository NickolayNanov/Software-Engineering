using GenericsExercise;
using System;
using System.Collections.Generic;

namespace GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            List<int> items = new List<int>();

            for (int i = 0; i < count; i++)
            {
                items.Add(int.Parse(Console.ReadLine()));
            }

            string indexes = Console.ReadLine();
            var box = new Box<int>(items);
            box.Swap(indexes);

            Console.WriteLine(box);
        }
    }
}

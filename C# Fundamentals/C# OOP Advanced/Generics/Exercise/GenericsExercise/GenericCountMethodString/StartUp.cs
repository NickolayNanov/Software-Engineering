using GenericsExercise;
using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<double> items = new List<double>();

            for (int i = 0; i < length; i++)
            {
                items.Add(double.Parse(Console.ReadLine()));
            }

            double item = double.Parse(Console.ReadLine());
            var box = new Box<double>(items);
            int count = box.CountGreaterElements(items, item);

            Console.WriteLine(count);
        }
    }
}

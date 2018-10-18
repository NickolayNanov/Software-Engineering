using System;
using System.Linq;
using System.Collections.Generic;

namespace Min_Max_Sum_Average
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> listOfNums = new List<int>(n);

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                listOfNums.Add(number);
            }

            Console.WriteLine("Sum = {0}", listOfNums.Sum());
            Console.WriteLine("Min = {0}", listOfNums.Min());
            Console.WriteLine("Max = {0}", listOfNums.Max());
            Console.WriteLine("Average = {0}", listOfNums.Average());
        }
    }
}

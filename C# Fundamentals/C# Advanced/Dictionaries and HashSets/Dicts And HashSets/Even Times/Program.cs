using System;
using System.Collections.Generic;
using System.Linq;

namespace Even_Times
{
    class Program
    {
        static Dictionary<int, int> counter = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!counter.ContainsKey(num))
                {
                    counter.Add(num, 1);
                }
                else
                {   
                    counter[num]++;
                }
            }

            foreach (var num in counter)
            {
                if(num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> chemicals = new SortedSet<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] chems = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var ch in chems)
                {
                    chemicals.Add(ch);
                }
            }

            Console.WriteLine(string.Join(" ", chemicals));
        }
    }
}

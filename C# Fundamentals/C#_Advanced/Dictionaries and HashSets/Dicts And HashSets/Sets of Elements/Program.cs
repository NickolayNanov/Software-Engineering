using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nm = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<int> firstHash = new HashSet<int>();
            HashSet<int> secondHash = new HashSet<int>();

            List<int> nums = new List<int>(nm[0] + nm[1]);
            HashSet<int> occurances = new HashSet<int>();

            for (int i = 0; i < nm[0]; i++)
            {
                int current = int.Parse(Console.ReadLine());

                firstHash.Add(current);
                nums.Add(current);
            }

            for (int i = 0; i < nm[1]; i++)
            {
                int current = int.Parse(Console.ReadLine());

                secondHash.Add(current);
                nums.Add(current);
            }

            for (int i = 0; i < nums.Count; i++)
            {
                if(firstHash.Contains(nums[i]) && secondHash.Contains(nums[i]))
                {
                    occurances.Add(nums[i]);
                }
            }

            
                Console.WriteLine(string.Join(" ", occurances));
            
        }
    }
}

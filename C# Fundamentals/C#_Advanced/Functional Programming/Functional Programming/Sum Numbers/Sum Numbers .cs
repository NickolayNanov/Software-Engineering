using System;
using System.Linq;

namespace Sum_Numbers
{
    class Sum_Numbers 
    {
        static void Main(string[] args)
        {

            int[] nums = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            Console.WriteLine(nums.Length);
            Console.WriteLine(nums.Sum());            
        }
    }
}

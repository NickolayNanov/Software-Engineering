using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_Element
{
    class Maximum_Element 
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (nums.Length == 2)
                {
                    if (nums[0] == 1)
                    {
                        stack.Push(nums[1]);
                    }                   
                }
                else
                {
                    if (nums[0] == 3)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    else if (nums[0] == 2)
                    {
                        stack.Pop();
                    }
                }
            }            
        }
    }
}

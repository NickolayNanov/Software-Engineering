using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp 
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            string item = "Ivan";

            stack.Push(item);

            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.isEmpty());
            
        }
    }
}

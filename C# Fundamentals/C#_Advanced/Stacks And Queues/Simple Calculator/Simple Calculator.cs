using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string expresion = Console.ReadLine();
            string[] tokens = expresion.Split();

            Stack<string> stack = new Stack<string>(tokens.Reverse());

            while (stack.Count > 1)
            {
                int num1 = int.Parse(stack.Pop());
                string op = stack.Pop();
                int num2 = int.Parse(stack.Pop());

                if (op == "+")
                {
                    stack.Push((num1 + num2).ToString());
                }
                else if(op == "-")
                {
                    stack.Push((num1 - num2).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}

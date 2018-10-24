using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parenthesis
{
    class Balanced_Parenthesis 
    {
        static void Main(string[] args)
        {
            Stack<char> parentesis = new Stack<char>();

            char[] opening = new char[] { '[', '(', '{' };

            string input = Console.ReadLine();
            bool isValid = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (opening.Contains(input[i]))
                {
                    parentesis.Push(input[i]);
                    continue;
                }

                if(parentesis.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (input[i] == ')' && parentesis.Peek() == '(')
                {
                    parentesis.Pop();
                }
               else if (input[i] == ']' && parentesis.Peek() == '[')
                {
                    parentesis.Pop();
                }
                else if (input[i] == '}' && parentesis.Peek() == '{')
                {
                    parentesis.Pop();
                }
            }

            if(parentesis.Count == 0 && isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}

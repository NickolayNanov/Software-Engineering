using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Text_Editor
{
    class Simple_Text_Editor
    {
        static void Main(string[] args)
        {
            string text = String.Empty;
            int iterations = int.Parse(Console.ReadLine());

            Stack<string> history = new Stack<string>();

            for (int i = 0; i < iterations; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                int command = int.Parse(tokens[0]);

                if(command == 1)
                {
                    history.Push(text);
                    text += tokens[1];
                }
                else if(command == 2)
                {
                    int length = int.Parse(tokens[1]);

                    history.Push(text);
                    text = text.Substring(0, text.Length - length);
                }
                else if(command == 3)
                {
                    int index = int.Parse(tokens[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if(command == 4)
                {
                    string current = text;
                    string newText = history.Pop();
                    text = newText;
                    
                }
            }
        }
    }
}

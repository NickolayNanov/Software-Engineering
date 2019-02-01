using System;
using System.Linq;

namespace CustomStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            string line = Console.ReadLine();

            while (line != "END")
            {
                string[] tokens = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Push":
                        stack.Push(tokens.Skip(1).ToArray());
                        break;
                }

                line = Console.ReadLine();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var element in stack)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}

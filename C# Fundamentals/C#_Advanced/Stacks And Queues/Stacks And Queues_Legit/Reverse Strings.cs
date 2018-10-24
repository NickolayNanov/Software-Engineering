using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Stacks_And_Queues
{
    class Reverse_Strings
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stringReverser = new Stack<char>(input);

            while(stringReverser.Count > 0)
            {
                Console.Write(stringReverser.Pop());
            }
            Console.WriteLine();
        }
    }
}

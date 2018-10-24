using System;
using System.Collections.Generic;

namespace Decinal_to_Binary
{
    class Program
    {
        static void Main(string[] args)
        { 
            Stack<int> binary = new Stack<int>();

            int num = int.Parse(Console.ReadLine());

            int reminder = 0;

            if(num == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while(num > 0)
            {
                reminder = num % 2;
                num /= 2;
                binary.Push(reminder);
            }

            foreach (var n in binary)
            {
                Console.Write(n);
            }
            Console.WriteLine();
        }
    }
}

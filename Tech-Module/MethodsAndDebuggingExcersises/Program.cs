using System;

namespace MethodsAndDebuggingExcersises
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            PrintLint(name);
        }

        private static void PrintLint(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}

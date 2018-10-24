using System;
using System.Linq;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string> Knighting = name => "Sir " + name;

            Console.WriteLine(string.Join("\n",
                Console.ReadLine()
                .Split()
                .Select(Knighting)));
        }
    }
}

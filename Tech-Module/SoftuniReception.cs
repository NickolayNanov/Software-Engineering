using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int peoplesCount = int.Parse(Console.ReadLine());

            int everyone = first + second + third;

            int hours = 0;
            while(peoplesCount > 0)
            {
                peoplesCount -= everyone;
                hours++;

                if(hours % 4 == 0)
                {
                    hours++;
                    continue;
                }
            }

            Console.WriteLine($"Time needed: {hours}h.");
            
        }
    }
}

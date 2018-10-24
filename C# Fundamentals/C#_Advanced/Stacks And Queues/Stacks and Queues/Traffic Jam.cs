using System;
using System.Collections.Generic;
using System.Linq;

namespace Traffic_Jam_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> crossroad = new Queue<string>();

            int count = int.Parse(Console.ReadLine());
            int counter = 0;
            while (true)
            {
                string line = Console.ReadLine();

                if(line == "end")
                {
                    break;
                }

                if (line == "green")
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (crossroad.Count > 0)
                        {
                            Console.WriteLine($"{crossroad.Dequeue()} passed!");
                            counter++;
                        }
                    }
                }
                else
                {
                    crossroad.Enqueue(line);
                }

            }
            Console.WriteLine(counter + " cars passed the crossroads.");
        }
    }
}

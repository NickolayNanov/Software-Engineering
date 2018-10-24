using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenSecs = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int duration = freeWindow;

            int cars = 0;
            int time = greenSecs;
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                if (line == "green")
                {
                    time = greenSecs;
                    continue;
                }

                if (time == 0)
                {
                    break;
                }

                Stack<char> car = new Stack<char>(line.Reverse());

                while (true)
                {
                    if (car.Count == 0)
                    {
                        cars++;
                        break;
                    }

                    if (time == 0)
                    {
                        while (freeWindow != 0)
                        {
                            freeWindow--;

                            if (car.Count == 0)
                            {
                                freeWindow = duration;
                                break;
                            }

                            car.Pop();
                        }
                        if (car.Count != 0)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{line} was hit at {car.Peek()}.");
                            return;
                        }
                    }

                    

                    time--;
                    car.Pop();
                }


            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{cars} total cars passed the crossroads.");
        }
    }
}

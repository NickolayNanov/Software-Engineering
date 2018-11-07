using System;
using System.Collections.Generic;

namespace TestForVirtual
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Figures square = new Square(3);
            Figures rectangle = new Rectangle(5.5, 4.5);
            Figures circle = new Circle(14.5, 6);

            List<Figures> figures = new List<Figures> { square, rectangle, circle };

            foreach (Figures fig in figures)
            {
                Console.WriteLine($"{fig.Type} -> {fig.Area():f2}");
            }
        }
    }
}

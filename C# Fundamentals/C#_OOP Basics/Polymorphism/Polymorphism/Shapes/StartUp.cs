using System;
using System.Collections.Generic;
using System.Linq;

namespace Shapes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IShape rectangle = new Rectangle(4, 6);
            IShape square = new Square(4);
            IShape circle = new Circle(5);
            IEnumerable<IShape> shapes = new List<IShape>()
            {
                rectangle,
                square,
                circle
            };

            var listShapes = shapes as List<IShape>;
            listShapes?.Add(new Circle(4));

            foreach (var shape in shapes)
            {
                Console.WriteLine($"{shape.CalculateArea():f2}");
            }

            IReadOnlyCollection<IShape> shapees = new List<IShape>() {rectangle, square, circle };
            Console.WriteLine(shapees.GetEnumerator());
        }
    }
}

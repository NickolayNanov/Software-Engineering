using System;

namespace Shapes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var shape = new Rectangle(7, 5);
            shape.Draw();
            shape.DoDrawing();
        }
    }
}

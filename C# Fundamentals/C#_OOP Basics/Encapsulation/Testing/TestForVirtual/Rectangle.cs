using System;
using System.Collections.Generic;
using System.Text;

namespace TestForVirtual
{
    class Rectangle : Figures
    {
        public Rectangle(double x, double y) : base(x, y)
        {
            this.X = x;
            this.Y = y;
            this.Type = "Rectangle";
        }

        public override double Area()
        {
            return this.X * this.Y;
        }
    }
}

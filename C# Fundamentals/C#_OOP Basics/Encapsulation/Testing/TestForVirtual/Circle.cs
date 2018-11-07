using System;
using System.Collections.Generic;
using System.Text;

namespace TestForVirtual
{
    public class Circle : Figures
    {
        public Circle(double x, double y) : base(x, y)
        {
            this.X = x;
            this.Y = y;
            this.Type = "Circle";
        }

        public override double Area()
        {
            return Pi * this.X * this.Y;
        }
    }
}

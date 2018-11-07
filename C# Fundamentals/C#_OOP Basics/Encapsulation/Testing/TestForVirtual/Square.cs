using System;
using System.Collections.Generic;
using System.Text;

namespace TestForVirtual
{
    public class Square : Figures
    {
        public Square(double x) : base(x)
        {
            this.X = x;
            this.Type = "Square";
        }

        public override double Area()
        {
            return this.X * this.X;
        }
    }
}

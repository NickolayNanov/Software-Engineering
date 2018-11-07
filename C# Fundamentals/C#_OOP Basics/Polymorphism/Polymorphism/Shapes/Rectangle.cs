using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Heigth { get; set; }

        public Rectangle(double width, double heigth)
        {
            this.Width = width;
            this.Heigth = heigth;
        }

        public virtual double CalculateArea()
        {
            return this.Width * this.Heigth;
        }

        protected static abstract void SayHi();

     
    }
}

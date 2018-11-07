using System;
using System.Collections.Generic;
using System.Text;

namespace TestForVirtual
{
    public class Figures
    {
        private double x;
        private double y;
        public readonly double Pi = Math.PI;
        private string type;

        public Figures(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Figures(double x) 
        {
            this.X = x;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public virtual double Area()
        {
            return this.X * this.Y;
        }
    }
}

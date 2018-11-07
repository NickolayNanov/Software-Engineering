using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double heigth;

        public Box(double length, double width, double height)
        {
            this.Length = height;
            this.width = width;
            this.heigth = height;
        }

        private double Length
        {
            set { length = value; }
        }

        public double GetVolume()
        {
            return length * width * heigth;
        }

        public double GetLateralSurfaceArea()
        {
            return 2 * length * heigth + 2 * width * heigth;
        }

        public double GetSurfaceArea()
        {
            return 2 * length * width + 2 * length * heigth + 2 * width * heigth;
        }
    }
}

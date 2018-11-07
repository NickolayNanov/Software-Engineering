using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxDataValidation
{
    public class Box
    {
        private double length;
        private double width;
        private double heigth;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Heigth = heigth;
        }

        private double Length
        {
            set
            {
                if(value <= 0)
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                    Environment.Exit(0);
                }
                Length = value;
            }
        }

        private double Width
        {
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                    Environment.Exit(0);
                }
                Width = value;
            }
        }

        private double Heigth
        {
            set
            {
                if(value <= 0)
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                    Environment.Exit(0);
                }
                Heigth = value;
            }
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

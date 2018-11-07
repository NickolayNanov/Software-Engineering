using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int heigth;

        public Rectangle(int width, int heigth)
        {
            this.Width = width;
            this.Heigth = heigth;
        }

        public int Width
        {
            get { return width; }
            private set
            {
                if (value < 4)
                {
                    throw new ArgumentException("Width must be minimum 4");
                }
                width = value;
            }
        }
        
        public int Heigth
        {
            get { return heigth; }
            private set
            {
                if(value < 4)
                {
                    throw new ArgumentException("Height must be minimum 4");
                }
                heigth = value;
            }
        }

        public void DoDrawing()
        {
            Console.WriteLine("Doing addiitonal drawing");
        }
        public void Draw()
        {
            Console.WriteLine(new String('*', this.Width));
            for (int i = 0; i < Heigth - 2; i++)
            {
                Console.WriteLine($"*{new String(' ', this.Width - 2)}*");
            }
            Console.WriteLine(new String('*', this.Width));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const char foodSymbol = '*';
        private const int foodPoint = 1;

        public FoodAsterisk(Wall wall)
            : base(wall, foodSymbol, foodPoint)
        {
        }
    }
}

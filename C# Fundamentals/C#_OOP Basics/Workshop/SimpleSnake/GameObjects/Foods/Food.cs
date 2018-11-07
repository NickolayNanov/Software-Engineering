using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private Wall wall;
        private char foodSymbol;
        private Random random;

        public Food(Wall wall, char foodSymbol, int points)
            : base(wall.LeftX, wall.TopY)
        {
            this.FoodPoints = points;   
            this.wall = wall;
            this.foodSymbol = foodSymbol; 
            this.random = new Random();
        }
        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
            this.TopY = this.random.Next(2, this.wall.TopY - 2);

            bool isPointOfSnake = snakeElements.Any(x => x.TopY == TopY && x.LeftX == LeftX);

            while (isPointOfSnake)
            {
                this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
                this.TopY = this.random.Next(2, this.wall.TopY - 2);

                isPointOfSnake = snakeElements.Any(x => x.TopY == TopY && x.LeftX == LeftX);
            }
         
            this.Draw(foodSymbol);
        }

        public bool IsFoodPoint(Point snake)
        {
            return this.LeftX == snake.LeftX && snake.TopY == TopY;
        }
    }
}

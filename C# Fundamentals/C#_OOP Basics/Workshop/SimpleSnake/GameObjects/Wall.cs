using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private int playerPoints;

        private const char wallSymbol = '\u25A0';

        public Wall(int leftX, int topY) 
            :base(leftX, topY)
        {
            InitializeWallBorders();
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.LeftX == 0 || snake.LeftX == this.LeftX || snake.TopY == 0 || snake.TopY == this.TopY - 1; 
        }

        private void InitializeWallBorders()
        {
            this.SetHorizontal(0);
            this.SetHorizontal(this.TopY - 1);
            this.SetVerticalLine(0);
            this.SetVerticalLine(this.LeftX);
        }

        private void SetHorizontal(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, wallSymbol);
                this.PlayerInfo();
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }

        public void AddPoints(int points)
        {
            this.playerPoints += points;
        }

        public void PlayerInfo()
        {
            Console.SetCursorPosition(this.LeftX + 3, 0);
            Console.Write($"Player points: {this.playerPoints}");
            Console.SetCursorPosition(this.LeftX + 3, 1);
            Console.WriteLine($"Player level: {this.playerPoints / 10}");
        }
    }
}

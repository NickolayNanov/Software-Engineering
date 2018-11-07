using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.AnimalModels;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.FoodModels;

namespace WildFarm.Models.Animals
{
    public class Bird : Animal, IBird
    {
        private double wingSize;

        public Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get => wingSize; private set => wingSize = value; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.wingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}

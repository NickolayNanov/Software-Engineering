using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.FoodModels;

namespace WildFarm.Models.Animals.AnimalModels.Birds
{
    public class Owl : Bird
    {
        private const double calories = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food, int quantity)
        {
            if (food is Meat)
            {
                this.Weight += quantity * calories;
            }
            else
            {
                throw new ArgumentException($"Owl does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

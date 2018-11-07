using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.AnimalModels.Mammals
{
    public class Mouse : Mammal
    {
        private const double calories = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food, int quantity)
        {
            if(food is Vegetable || food is Fruit)
            {
                this.Weight += quantity * calories;
            }
            else
            {
                throw new ArgumentException($"Mouse does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

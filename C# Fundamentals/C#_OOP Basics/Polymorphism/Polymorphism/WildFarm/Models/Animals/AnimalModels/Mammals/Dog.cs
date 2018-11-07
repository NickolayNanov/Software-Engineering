using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.FoodModels;

namespace WildFarm.Models.Animals.AnimalModels.Mammals
{
    public class Dog : Mammal
    {
        private const double calories = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food, int quantity)
        {
            if(food is Meat)
            {
                this.Weight += quantity * calories;
            }
            else
            {
                throw new ArgumentException($"Dog does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

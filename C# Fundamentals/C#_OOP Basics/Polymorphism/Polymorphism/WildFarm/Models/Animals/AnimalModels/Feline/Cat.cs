using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.AnimalModels.Mammals;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.FoodModels;

namespace WildFarm.Models.Animals.AnimalModels.Feline
{
    public class Cat : Feline
    {
        private const double calories = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood food, int quantity)
        {
            if(food is Vegetable || food is Meat)
            {
                this.Weight += quantity * calories;
            }
            else
            {
                throw new ArgumentException($"Cat does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

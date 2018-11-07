using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.FoodModels;

namespace WildFarm.Models.Animals.AnimalModels.Feline
{
    public class Tiger : Feline
    {
        private const double calories = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
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
                throw new ArgumentException($"Tiger does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

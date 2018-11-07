using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.AnimalModels.Birds
{
    public class Hen : Bird
    {
        private const double calories = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food, int quantity)
        {
            this.Weight += quantity * calories;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

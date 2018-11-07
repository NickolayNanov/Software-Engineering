using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.Contracts;

namespace WildFarm.Models.Animals.AnimalModels.Mammals
{
    public class Mammal : Animal, IMammal
    {
        private string livingRegion;

        public Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get => livingRegion; private set => livingRegion = value; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}

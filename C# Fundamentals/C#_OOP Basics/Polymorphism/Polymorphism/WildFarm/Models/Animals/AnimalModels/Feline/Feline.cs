using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.AnimalModels.Mammals;
using WildFarm.Models.Animals.Contracts;

namespace WildFarm.Models.Animals.AnimalModels.Feline
{
    public class Feline : Mammal
    {
        private string breed;

        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get => breed; private set => breed = value; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}

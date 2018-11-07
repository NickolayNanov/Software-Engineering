using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.AnimalModels
{
    public abstract class Animal : IAnimal
    {
        private string name;
        private double weight;
        private int foodEaten;

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get => name;  set => name = value; }
        public double Weight { get => weight;  set => weight = value; }
        public int FoodEaten { get => foodEaten; set => foodEaten = value; }

        public virtual void Eat(IFood food, int quantity)
        {

        }

        public virtual void ProduceSound()
        {

        }
       
    }
}

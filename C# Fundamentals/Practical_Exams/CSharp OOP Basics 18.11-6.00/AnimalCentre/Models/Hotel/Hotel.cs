using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Hotel
{
    public class Hotel : IHotel
    {
        private Dictionary<string, IAnimal> animals;
        private const int capacity = 10;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public int Capacity => capacity;

        public IReadOnlyDictionary<string, IAnimal> Animals { get => animals;}

        public void Accommodate(IAnimal animal)
        {
            if(this.Animals.Count == this.Capacity)
            {
                throw new InvalidOperationException("InvalidOperationException: Not enough capacity");
            }

            if (this.Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"ArgumentException: Animal {animal.Name} already exist");
            }

            this.animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"ArgumentException: Animal {animalName} does not exist");
            }

            IAnimal animal = this.Animals[animalName];
            animal.IsAdopt = true;
            animal.Owner = owner;

            this.animals.Remove(animalName);
        }
    }
}

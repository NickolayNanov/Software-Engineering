using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.AnimalModels.Birds.Factory;
using WildFarm.Models.Animals.AnimalModels.Feline;
using WildFarm.Models.Animals.AnimalModels.Feline.Factory;
using WildFarm.Models.Animals.AnimalModels.Mammals.Factory;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Foods.Factory;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine
    {
        MammalFactory mammalFactory;
        FelineFactory felineFactory;
        BirdFactory birdFactory;
        FoodFactory foodFactory;

        ICollection<IAnimal> animals;

        IAnimal animal;
        IFood food;

        public Engine()
        {
            mammalFactory = new MammalFactory();
            birdFactory = new BirdFactory();
            felineFactory = new FelineFactory();
            foodFactory = new FoodFactory();

            animals = new List<IAnimal>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while(input != "End")
            {
                try
                {
                    string[] animalInfo = input.Split();
                    string[] foodInfo = Console.ReadLine().Split();

                    string typeOfAnimal = animalInfo[0];

                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);

                    GetAnimal(animalInfo, typeOfAnimal, name, weight);

                    string foodType = foodInfo[0];
                    int foodQuantity = int.Parse(foodInfo[1]);

                    GetFood(foodType, foodQuantity);
                    
                    this.animal.Eat(food, foodQuantity);
                    this.animal.FoodEaten = foodQuantity;

                    animal.ProduceSound();
                    animals.Add(animal);
                }
                catch (ArgumentException ex)
                {
                    animal.ProduceSound();
                    Console.WriteLine(ex.Message);
                    animals.Add(animal);
                  
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                
                Console.WriteLine(animal);
            }
        }

        private void GetFood(string foodType, int foodQuantity)
        {
            food = foodFactory.CreateFood(foodType, foodQuantity);
        }

        private void GetAnimal(string[] animalInfo, string typeOfAnimal, string name, double weight)
        {
            if (typeOfAnimal.Equals("Hen") || typeOfAnimal.Equals("Owl"))
            {
                double wingSize = double.Parse(animalInfo[3]);

                animal = birdFactory.CreateBird(typeOfAnimal, name, weight, wingSize);
            }
            else if (typeOfAnimal.Equals("Mouse") || typeOfAnimal.Equals("Dog"))
            {
                string livingRegion = animalInfo[3];

                animal = mammalFactory.CreateMamal(typeOfAnimal, name, weight, livingRegion);
            }
            else if (typeOfAnimal.Equals("Cat") || typeOfAnimal.Equals("Tiger"))
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];

                animal = felineFactory.CreateFeline(typeOfAnimal, name, weight, livingRegion, breed);
            }
        }
    }
}

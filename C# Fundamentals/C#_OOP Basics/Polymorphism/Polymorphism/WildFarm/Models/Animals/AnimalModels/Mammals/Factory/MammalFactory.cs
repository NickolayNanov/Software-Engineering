using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.AnimalModels.Mammals.Factory
{
    public class MammalFactory
    {
        public Mammal CreateMamal(string type, string name, double weight, string livingRegion)
        {
            type = type.ToLower();

            switch (type)
            {
                case "dog":
                    return new Dog(name, weight, livingRegion);
                case "mouse":
                    return new Mouse(name, weight, livingRegion);

                default: return null;                
            }
        }
    }
}

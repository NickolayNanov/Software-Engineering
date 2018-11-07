using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.AnimalModels.Feline.Factory
{
    public class FelineFactory
    {
        public Feline CreateFeline(string type, string name, double weight, string livingRegion, string breed)
        {
            type = type.ToLower();

            switch (type)
            {
                case "cat":
                    return new Cat(name, weight, livingRegion, breed);
                case "tiger":
                    return new Tiger(name, weight, livingRegion, breed);

                default: return null;
            }
        }
    }
}

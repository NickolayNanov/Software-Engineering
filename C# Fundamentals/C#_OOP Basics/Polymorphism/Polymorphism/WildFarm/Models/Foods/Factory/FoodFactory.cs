using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods.FoodModels;

namespace WildFarm.Models.Foods.Factory
{
    public class FoodFactory
    {
        public Food CreateFood(string type, int quantity)
        {
            type = type.ToLower();

            switch (type)
            {
                case "vegetable":
                    return new Vegetable(quantity);
                case "fruit":
                    return new Fruit(quantity);
                case "meat":
                    return new Meat(quantity);
                case "seeds":
                    return new Seeds(quantity);

                default: return null;
            }
        }
    }
}

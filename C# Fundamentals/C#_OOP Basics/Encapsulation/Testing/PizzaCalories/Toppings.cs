using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Toppings
    {
        private string toppingType;
        private int weight;
        private double calories;

        public Toppings(string toppingType, int weigth)
        {
            this.ToppingType = toppingType;
            this.Weight = weigth;      
        }

        public string ToppingType
        {
            get { return toppingType; }
            set
            {
                if(value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    string item = Char.ToUpper(value[0]) + value.Substring(1);
                    Exception ex = new ArgumentException($"Cannot place {item} on top of your pizza.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                toppingType = value;
            }
        }
        
        public int Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    string item = Char.ToUpper(this.ToppingType[0]) + this.ToppingType.Substring(1);

                    Exception ex = new ArgumentException($"{item} weight should be in the range [1..50].");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                weight = value;
            }
        }
        
        public double Calories
        {
            get
            {
                return GetCalories();
            }
            
        }

        private double GetCalories()
        {
            double modifier = this.ToppingType.ToLower() == "meat" ? 1.2 :
                              this.ToppingType.ToLower() == "veggies" ? 0.8 :
                              this.ToppingType.ToLower() == "cheese" ? 1.1 : 0.9;

            return this.Weight * 2 * modifier;
        }
    }
}

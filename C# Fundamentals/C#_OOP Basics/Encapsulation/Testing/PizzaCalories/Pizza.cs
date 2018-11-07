using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private List<Toppings> toppings;
        private Dough dough;
        private string name;

        public Pizza(string name,Dough dough)
        {
            this.Name = name;
            this.Toppings = new List<Toppings>();
            this.Dough = dough;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Toppings> Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }

        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        private double calories;

        public double Calories
        {
            get { return GetPizzaCalories(); }
            
        }

        private double GetPizzaCalories()
        {
            double cals = 0.0;

            foreach (Toppings t in this.Toppings)
            {
                cals += t.Calories;
            }
            return cals;
        }
    }
}

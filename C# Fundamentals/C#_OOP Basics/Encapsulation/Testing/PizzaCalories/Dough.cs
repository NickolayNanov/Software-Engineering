using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechinque;

        public Dough(string flourType, string bakingTechinque, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechinque;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return flourType; }
            set
            {
                if(value.ToLower() != "wholegrain" && value.ToLower() != "white")
                {
                    Exception ex = new ArgumentException("Invalid type of dough.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechinque; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    Exception ex = new ArgumentException("Invalid type of dough.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                bakingTechinque = value;
            }
        }

        private int weight;

        public int Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    Exception ex = new ArgumentException($"Dough weight should be in the range [1..200].");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                weight = value;
            }
        }


        public double Calories { get => GetCalories(); }

        private double GetCalories()
        {
            double flourModifier = this.FlourType.ToLower() == "white" ? 1.5 : 1.0;

            double techniqueModifier = this.BakingTechnique.ToLower() == "crispy" ? 0.9 : 
                                       this.BakingTechnique.ToLower() == "chewy" ? 1.1 : 1.0;

            return (2 * this.Weight) * flourModifier * techniqueModifier;
        }
    }
}

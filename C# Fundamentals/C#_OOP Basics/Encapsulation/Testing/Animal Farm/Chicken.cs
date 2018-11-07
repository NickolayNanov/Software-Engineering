using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;

namespace AnimalFarm
{
    public class Chicken
    {
        private string name;
        private int age;

        internal Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return name; }

            set
            {
                if(string.IsNullOrWhiteSpace(value) || value == String.Empty)
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                value = name;
            }
        }

        

        public int Age
        {
            get { return age; }

            set
            {
                if(value < 0 || value > 15)
                {
                    throw new ArgumentException("Name cannot be empty.");                    
                }
            }
        }

        public double ProductPerDay()
        {
            return this.CalculateProductPerDay();
        }

        private double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }

    }
}

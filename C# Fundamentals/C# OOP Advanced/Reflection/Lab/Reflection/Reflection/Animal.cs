using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    public class Animal
    {
        private string name = "Jivotno";
        private int age = 35;

        public void Eat()
        {
            this.PrivateEat();
        }

        private void PrivateEat()
        {
            this.Age++;
        }

        public Animal()
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public override string ToString()
        {
            return $"This is a {this.GetType().Name}, which is in {this.GetType().FullName} with Name:{this.Name} and is {this.Age} years old;";
        }
    }
}

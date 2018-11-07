using System;
using System.Collections.Generic;
using System.Text;

namespace Testing
{
    class Person : IPerson
    {
        private int age;

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

        public void SayHi()
        {
            Console.WriteLine("Hello!");
        }

        public void Grow()
        {
            this.Age++;
        }        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Testing
{
    public class Mamal : IAnimal
    {
        public string Kind { get; set; }

        public void Climb()
        {
            Console.WriteLine("Climbing");
        }

        public virtual void Walk()
        {
            Console.WriteLine("Walking");
        }

        public virtual void Eat()
        {
            Console.WriteLine("Consuming milk");
        }
    }
}

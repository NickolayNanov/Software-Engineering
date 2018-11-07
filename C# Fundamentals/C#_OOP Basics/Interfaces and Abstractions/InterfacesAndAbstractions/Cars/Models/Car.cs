using Cars.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Cars
{
    public abstract class Car : ICar
    {
        private bool engine;

        public Car(string model, string colour)
        {
            if (string.IsNullOrEmpty(model))
            {
                throw new InvalidModelException("Model cannot be null or empty!");
            }
            if (string.IsNullOrEmpty(colour))
            {
                throw new InvalidColourException("Colour cannot be null or empty!");
            }

            this.Model = model;
            this.Colour = colour;
        }

        public string Model { get; set; }
        public string Colour { get; set; }

        public void Drive()
        {
            if (engine)
            {
                Console.WriteLine("Driving...");
            }
            else
            {
                Console.WriteLine("Please turn on the engine.");
            }
        }

        public virtual void StartEngine()
        {
            engine = true;
            Console.WriteLine($"You started the car engine...");
        }

        public virtual void StopEngine()
        {
            engine = false;
            Console.WriteLine($"You stopped the car engine...");
        }
    }


}

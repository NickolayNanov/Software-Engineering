using System;
using System.Collections.Generic;
using System.Text;

namespace Testing
{
    public class Car
    {
        private int fuel;
        private bool engineStarted;

        public Car(int fuel)
        {
            this.Fuel = fuel;
        }        

        public int Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        public virtual void StartEngine()
        {            
            StartMotor();
        }

        private void StartMotor()
        {
            Console.WriteLine("Motor Started.");
            TurnCrankShaft();
        }

        private void TurnCrankShaft()
        {
            Console.WriteLine("Crank shaft turned.");
            StartEngineCycle();
        }

        private void StartEngineCycle()
        {
            Console.WriteLine("Cycle Started");
            BeginCombution();
        }

        private void BeginCombution()
        {
            Console.WriteLine("Combution started...");
            this.engineStarted = true;

            if (engineStarted)
            {
                Console.WriteLine("Engine Started");
            }
        }

        public void Drive()
        {
            if (engineStarted)
            {
                if (this.Fuel > 0)
                {
                    Console.WriteLine("Driving");
                    this.Fuel--;
                }
                else
                {
                    Console.WriteLine("Not enough fuel, please refill");
                }
            }
            else
            {
                Console.WriteLine("Turn on the engine");
            }
        }

        public void Refuel(int fuel)
        {
            this.Fuel += fuel;
        }

        public void Honk()
        {
            Console.WriteLine("Honk");
        }

        public void CheckFuel()
        {
            Console.WriteLine(this.Fuel);
        }
    }
}

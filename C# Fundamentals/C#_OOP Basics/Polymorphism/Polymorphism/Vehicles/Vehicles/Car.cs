using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Car : Vehicle
    {
        public override double FuelConsumptionPerKm
        {
            get => base.FuelConsumptionPerKm;
            set => base.FuelConsumptionPerKm = value + 0.9;
        }

        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tank)
            : base(fuelQuantity, fuelConsumptionPerKm, tank)
        {
        }

        public override void Drive(double distance)
        {           
            double toTravel = this.FuelConsumptionPerKm * distance;

            if (this.FuelQuantity > toTravel)
            {
                Console.WriteLine($"Car travelled {distance} km");
                this.FuelQuantity -= this.FuelConsumptionPerKm * distance;
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        public override void Refuel(double litters)
        {
            if(litters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            if (this.Tank < litters + this.FuelQuantity)
            {
                Console.WriteLine($"Cannot fit {litters} fuel in the tank");
                return;
            }

            this.FuelQuantity += litters;
        }
    }
}

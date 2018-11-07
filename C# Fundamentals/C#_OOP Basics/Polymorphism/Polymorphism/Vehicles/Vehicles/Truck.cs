using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tank)
            : base(fuelQuantity, fuelConsumptionPerKm, tank)
        {
        }

        public override double FuelConsumptionPerKm
        {
            get => base.FuelConsumptionPerKm;
            set => base.FuelConsumptionPerKm = value + 1.6;
        }

        public override void Drive(double distance)
        {
           
            double toTravel = this.FuelConsumptionPerKm * distance;

            if (this.FuelQuantity >= toTravel)
            {
                Console.WriteLine($"Truck travelled {distance} km");
                this.FuelQuantity -= this.FuelConsumptionPerKm * distance;
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double litters)
        {
            if (litters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            double actualLitters = litters * 0.95;

            if(this.Tank < this.FuelQuantity + actualLitters)
            {
                Console.WriteLine($"Cannot fit {litters} fuel in the tank");
                return;
            }

            this.FuelQuantity += actualLitters;
        }
    }
}

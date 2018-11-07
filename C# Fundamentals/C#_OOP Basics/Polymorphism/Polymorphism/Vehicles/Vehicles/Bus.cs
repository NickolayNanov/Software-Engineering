using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tank)
            : base(fuelQuantity, fuelConsumptionPerKm, tank)
        {
        }

        public override void Refuel(double litters)
        {
            if (litters <= 0)
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

        public override void Drive(double distance)
        {
            if (!IsVehicleEmpty)
            {
                this.FuelConsumptionPerKm += 1.4;
            }

            double toTravel = this.FuelConsumptionPerKm * distance;

            if (this.FuelQuantity >= toTravel)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                this.FuelQuantity -= this.FuelConsumptionPerKm * distance;
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }
    }
}

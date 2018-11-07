using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionPerKm;
        private double tank;
        
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tank)
        {
            this.Tank = tank;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public bool IsVehicleEmpty { get; set; }

        public virtual double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if(value > this.Tank)//check
                {
                    this.Tank = 0;
                }

                fuelQuantity = value;
            }
        }
        public virtual double FuelConsumptionPerKm
        {
            get => fuelConsumptionPerKm;
            set => fuelConsumptionPerKm = value;
        }

        public double Tank
        {
            get => tank;
            set => tank = value;
        }

        public virtual void Drive(double distance)
        {
            Console.WriteLine("Driving");
        }

        public virtual void Refuel(double litters)
        {
            Console.WriteLine("Refueling");
        }
    }
}

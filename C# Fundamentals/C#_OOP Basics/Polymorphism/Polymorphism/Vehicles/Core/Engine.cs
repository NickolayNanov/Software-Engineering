using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Vehicles;

namespace Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carArgs = Console.ReadLine().Split();

            double fuel = double.Parse(carArgs[1]);
            double littersPerKm = double.Parse(carArgs[2]);
            double tank = double.Parse(carArgs[3]);

            IVehicle car = new Car(fuel, littersPerKm, tank);

            string[] truckArgs = Console.ReadLine().Split();

            fuel = double.Parse(truckArgs[1]);
            littersPerKm = double.Parse(truckArgs[2]);
            tank = double.Parse(truckArgs[3]);

            IVehicle truck = new Truck(fuel, littersPerKm, tank);

            string[] busArgs = Console.ReadLine().Split();

            fuel = double.Parse(busArgs[1]);
            littersPerKm = double.Parse(busArgs[2]);
            tank = double.Parse(busArgs[3]);

            IVehicle bus = new Bus(fuel, littersPerKm, tank);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();

                string command = inputArgs[0];
                string type = inputArgs[1];

                if (type == "Car")
                {
                    if(command == "Drive")
                    {
                        double distance = double.Parse(inputArgs[2]);
                        car.Drive(distance);
                    }
                    else if (command == "Refuel")
                    {
                        double litters = double.Parse(inputArgs[2]);
                        car.Refuel(litters);
                    }
                }
                else if (type == "Truck")
                {
                    if (command == "Drive")
                    {
                        double distance = double.Parse(inputArgs[2]);
                        truck.Drive(distance);
                    }
                    else if (command == "Refuel")
                    {
                        double litters = double.Parse(inputArgs[2]);
                        truck.Refuel(litters);
                    }
                }
                else if(type == "Bus")
                {
                    if (command == "DriveEmpty")
                    {
                        bus.IsVehicleEmpty = true;
                        double distance = double.Parse(inputArgs[2]);
                        bus.Drive(distance);
                    }
                    else if (command == "Drive")
                    {
                        bus.IsVehicleEmpty = false;
                        double distance = double.Parse(inputArgs[2]);
                        bus.Drive(distance);
                    }
                    else if (command == "Refuel")
                    {
                        double litters = double.Parse(inputArgs[2]);
                        bus.Refuel(litters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}

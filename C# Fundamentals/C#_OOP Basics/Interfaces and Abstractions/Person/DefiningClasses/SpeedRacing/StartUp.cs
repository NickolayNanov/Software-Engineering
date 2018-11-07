using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string model = tokens[0];
                int fuelAmount = int.Parse(tokens[1]);
                double fuelConsumptionFor1km = double.Parse(tokens[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

                if (!cars.ContainsKey(model))
                {
                    cars.Add(model, new Car(model, fuelAmount, fuelConsumptionFor1km));
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End") break;

                string[] tokens = line.Split();

                string model = tokens[1];
                int targetKm = int.Parse(tokens[2]);

                if (cars.ContainsKey(model) && cars[model].FuelAmount >= targetKm * cars[model].FuelConsumptionFor1km)
                {
                    cars[model].FuelAmount -= targetKm * cars[model].FuelConsumptionFor1km;
                    cars[model].KilometersTravelled += targetKm;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} {car.Value.FuelAmount:f2} {car.Value.KilometersTravelled}");
            }
        }
    }
}

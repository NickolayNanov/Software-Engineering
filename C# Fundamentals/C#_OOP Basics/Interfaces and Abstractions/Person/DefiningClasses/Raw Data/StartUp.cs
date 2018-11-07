using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];


                List<Tire> tires = new List<Tire>();
                for (int j = 0; j < 4; j+=2)
                {
                    double tirePressure = double.Parse(tokens[5 + j]);
                    int tireAge = int.Parse(tokens[6 + j]);

                    Tire tire = new Tire(tireAge, tirePressure);
                    tires.Add(tire);
                }

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
            string command = Console.ReadLine();

            List<Car> resultCars = new List<Car>();

            if(command == "fragile")
            {
                resultCars = cars
                            .Where(c => c.Cargo.CargoType == "fragile" 
                            && c.Tires.Any(t => t.Pressure < 1))
                            .ToList();
            }
            else
            {
                resultCars = cars.Where(c => c.Cargo.CargoType == "flamable"
                && c.Engine.Power > 250)
                .ToList();
            }

            foreach (var c in resultCars)
            {
                Console.WriteLine($"{c.Model}");
            }
        }
    }
}

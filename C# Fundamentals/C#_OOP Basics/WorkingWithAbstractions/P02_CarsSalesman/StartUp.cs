using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
    class CarSalesman
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];
                int power = int.Parse(parameters[1]);
                int displacement = -1;

                if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
                {
                    engines.Add(new Engine(model, power, displacement));
                }
                else if (parameters.Length == 3)
                {
                    string efficiency = parameters[2];
                    Engine engine = new Engine(model, power, efficiency);

                    engines.Add(engine);
                }
                else if (parameters.Length == 4)
                {
                    string efficiency = parameters[3];
                    Engine engine = new Engine(model, power, int.Parse(parameters[2]), efficiency);

                    engines.Add(engine);
                }
                else
                {
                    Engine engine = new Engine(model, power);
                    engines.Add(engine);
                }
            }

            int carCount = int.Parse(Console.ReadLine());


            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];
                string engineModel = parameters[1];
                Engine engine = engines.FirstOrDefault(x => x.model == engineModel);

                int weight = -1;

                if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
                {
                    Car car = new Car(model, engine, weight);

                    cars.Add(car);
                }
                else if (parameters.Length == 3)
                {
                    string color = parameters[2];
                    Car car = new Car(model, engine, color);

                    cars.Add(car);
                }
                else if (parameters.Length == 4)
                {
                    string color = parameters[3];
                    Car car = new Car(model, engine, int.Parse(parameters[2]), color);

                    cars.Add(car);
                }
                else
                {
                    Car car = new Car(model, engine);

                    cars.Add(car);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }

}

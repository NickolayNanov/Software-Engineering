using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] pizzaInput = Console.ReadLine().Split();

            string pizzaName = pizzaInput[1];

            if(pizzaName.Length < 1 || pizzaName.Length > 15)
            {
                Console.WriteLine("Pizza name should be between 1 and 15 symbols.");
                return;
            }

            Pizza pizza = null;
            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "END") break;

                string item = input[0];

                if(item == "Dough")
                {
                    string flourType = input[1];
                    string bakingTechnique = input[2];
                    int weight = int.Parse(input[3]);

                    Dough dough = new Dough(flourType, bakingTechnique, weight);
                    pizza = new Pizza(pizzaName, dough);
                }
                else if(item == "Topping")
                {
                    string toppingType = input[1];
                    int weight = int.Parse(input[2]);

                    Toppings toppings = new Toppings(toppingType, weight);
                    pizza.Toppings.Add(toppings);

                    if(pizza.Toppings.Count == 10)
                    {
                        Console.WriteLine($"Number of toppings should be in range [0..10].");
                        return;
                    }
                }                
            }
            Console.WriteLine($"{pizza.Name} - {pizza.Calories + pizza.Dough.Calories :f2} Calories.");
        }
    }
}

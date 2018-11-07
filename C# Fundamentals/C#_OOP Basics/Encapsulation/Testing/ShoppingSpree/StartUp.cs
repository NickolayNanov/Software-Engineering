using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleInput = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] productsInput = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            FillCollection(peopleInput, people);
            FillCollection(productsInput, products);

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input.Split();

                string name = tokens[0];
                string product = tokens[1];

                Person currentPerson = people.Where(x => x.Name == name).FirstOrDefault();
                Product currentProduct = products.Where(x => x.Name == product).FirstOrDefault();

                if(currentPerson.Money >= currentProduct.Cost)
                {
                    currentPerson.Products.Add(currentProduct);
                    currentPerson.Money -= currentProduct.Cost;
                    Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                }
                else
                {
                    Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                }

                input = Console.ReadLine();
            }
            foreach (var p in people)
            {
                Console.Write($"{p.Name} - ");
                if(p.Products.Count == 0)
                {
                    Console.Write("Nothing bought");
                    Console.WriteLine();
                    continue;
                }
                for (int i = 0; i < p.Products.Count; i++)
                {
                    if(i == p.Products.Count - 1)
                    {
                        Console.Write(p.Products[i].Name);
                    }
                    else
                    {
                        Console.Write(p.Products[i].Name + ", ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void FillCollection(string[] peopleInput, List<Person> people)
        {
            for (int i = 0; i < peopleInput.Length; i += 2)
            {
                Person person = new Person(peopleInput[i], int.Parse(peopleInput[i + 1]));
                people.Add(person);
            }
        }

        private static void FillCollection(string[] productsInput, List<Product> products)
        {
            for (int i = 0; i < productsInput.Length; i += 2)
            {
                Product person = new Product(productsInput[i], int.Parse(productsInput[i + 1]));
                products.Add(person);
            }
        }
    }
}

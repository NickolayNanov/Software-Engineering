using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            set
            {                
                try
                {
                    if(value == "")
                    {
                        throw new ArgumentException();
                    }
                    this.name = value;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(0);
                }
            }
        }
        
        public int Money
        {
            get { return money; }
            set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new ArgumentException();
                    }
                    this.money = value;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }
            }
        }

        private List<Product> products;

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }


    }
}

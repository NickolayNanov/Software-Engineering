using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop
{
    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (value.Length < 3)
                {
                    Exception ex = new ArgumentException("Title not valid!");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                title = value;
            }
        }
        
        public string Author
        {
            get { return author; }
            set
            {
                string[] tokens = value.ToString().Split();
                string second = tokens[1];

                if (Char.IsDigit(second[0]))
                {
                    Exception ex = new ArgumentException("Author not valid!");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                
                author = value;
            }
        }
        
        public virtual decimal Price
        {
            get { return price; }
            set
            {
                if(value <= 0.0m)
                {
                    Exception ex = new ArgumentException("Price not valid!");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                price = value;
            }
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;

        }
    }
}

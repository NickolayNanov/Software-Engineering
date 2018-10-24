using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int iters = int.Parse(Console.ReadLine());

            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < iters; i++)
            {
                string[] person = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = person[0];
                int age = int.Parse(person[1]);

                if (!people.ContainsKey(name))
                {
                    people.Add(name, age);
                }
            }

            string condition = Console.ReadLine();
            int agee = int.Parse(Console.ReadLine());

            string format = Console.ReadLine();

            if(format == "name")
            {
                if (condition == "younger")
                {
                    foreach (var p in people.Where(x => x.Value < agee))
                    {
                        Console.WriteLine($"{p.Key}");
                    }
                }
                else if (condition == "older")
                {
                    foreach (var p in people.Where(x => x.Value >= agee))
                    {
                        Console.WriteLine($"{p.Key}");
                    }
                }
            }
            else if(format == "age")
            {
                if (condition == "younger")
                {
                    foreach (var p in people.Where(x => x.Value < agee))
                    {
                        Console.WriteLine($"{p.Value}");
                    }
                }
                else if (condition == "older")
                {
                    foreach (var p in people.Where(x => x.Value >= agee))
                    {
                        Console.WriteLine($"{p.Value}");
                    }
                }
            }
            else
            {
                if (condition == "younger")
                {
                    foreach (var p in people.Where(x => x.Value < agee))
                    {
                        Console.WriteLine($"{p.Key} - {p.Value}");
                    }
                }
                else if(condition == "older")
                {
                    foreach (var p in people.Where(x => x.Value >= agee))
                    {
                        Console.WriteLine($"{p.Key} - {p.Value}");
                    }
                    
                }
            }
            
            
        }
    }
}

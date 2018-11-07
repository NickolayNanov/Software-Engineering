using System;
using System.Linq;
using System.Collections.Generic;
namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Family family = new Family() { Members = new List<Person>()};

            for (int c = 0; c < count; c++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                Person person = new Person() { Name = name, Age = age};

                family.AddMember(person);
            }

            Person oldestOne = family.GetOldestMemeber(family.Members);
                
            Console.WriteLine($"{oldestOne.Name} {oldestOne.Age}");
        }
    }
}

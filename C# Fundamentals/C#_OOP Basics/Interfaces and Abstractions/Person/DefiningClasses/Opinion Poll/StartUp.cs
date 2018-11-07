using System;
using System.Collections.Generic;

namespace Opinion_Poll
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();
            Person person = new Person();
            for (int c = 0; c < counter; c++)
            {
                string[] tokens = Console.ReadLine().Split();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                person = new Person() { Name = name, Age = age };
                people.Add(person);
            }

            List<Person> sorted = person.SortAccordingToAge(people);

            foreach (var p in sorted)
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
            }
        }
    }
}

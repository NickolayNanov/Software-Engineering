using StrategyPattern.Comparators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SortedSet<Person> setOne = new SortedSet<Person>(new NameComparator());
            SortedSet<Person> setTwo = new SortedSet<Person>(new AgeComparator());

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split()
                    .ToArray();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                var person = new Person(name, age);

                setOne.Add(person);
                setTwo.Add(person);
            }

            if(setOne.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, setOne));
                Console.WriteLine(string.Join(Environment.NewLine, setTwo));
            }
        }
    }
}

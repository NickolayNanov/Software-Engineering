using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTree
{
    public class StartUp
    {
        static List<Person> people;
        static List<string> relationships;

        static void Main(string[] args)
        {
            string mainPersonInfo = Console.ReadLine();
            
            people = new List<Person>();
            relationships = new List<string>();
            string line = Console.ReadLine();
            while (line != "End")
            {  
                if (!line.Contains('-'))
                {
                    AddMember(line);
                    line = Console.ReadLine();
                    continue;
                }

                relationships.Add(line);
                line = Console.ReadLine();
            }

            foreach (var memberInfo in relationships)
            {
                string[] tokens = memberInfo.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                Person parent = GetPerson(tokens[0]);
                Person child = GetPerson(tokens[1]);

                parent.Children.Add(child);
                child.Parents.Add(parent);
            }

            Print(mainPersonInfo);
        }

        private static void Print(string mainPersonInfo)
        {
            Person mainPerson = GetPerson(mainPersonInfo);

            Console.WriteLine($"{mainPerson.Name} {mainPerson.Birthday}");
            Console.WriteLine($"Parents:");
            foreach (var parent in mainPerson.Parents)
            {
                Console.WriteLine($"{parent.Name} {parent.Birthday}");
            }

            Console.WriteLine($"Children:");
            foreach (var child in mainPerson.Children)
            {
                Console.WriteLine($"{child.Name} {child.Birthday}");
            }
        }

        private static Person GetPerson(string input)
        {
            if (input.Contains('/'))
            {
                return people.FirstOrDefault(x => x.Birthday == input);
            }
            return people.FirstOrDefault(x => x.Name == input);
        }

        private static void AddMember(string line)
        {
            string[] tokens = line.Split();

            string name = tokens[0] + " " + tokens[1];
            string birthday = tokens[2];
            Person person = new Person(name, birthday);

            people.Add(person);
        }
    }
}

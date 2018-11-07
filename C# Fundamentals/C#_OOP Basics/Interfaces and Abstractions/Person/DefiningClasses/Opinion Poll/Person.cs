using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Opinion_Poll
{
    public class Person
    {
        public Person()
        {
            this.name = "No name";
            this.age = 1;
        }

        public Person(int age)
        {
            this.name = "No name";
            this.age = age;
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        private string name;
        private int age;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                age = value;
            }
        }

        public List<Person> SortAccordingToAge(List<Person> people)
        {
            List<Person> above30 = new List<Person>();

            foreach (var p in people)
            {
                if(p.Age > 30)
                {
                    above30.Add(p);
                }
            }
            above30 = above30.OrderBy(x => x.Name).ToList();
            return above30;
        }
    }
}

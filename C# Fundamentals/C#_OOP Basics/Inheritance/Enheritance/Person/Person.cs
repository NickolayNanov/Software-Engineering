using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private int age;
        private string name;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual int Age
        {
            get { return age; }
            protected set
            {
                if(value < 0)
                {
                    Exception ex = new ArgumentException("Age must be positive!");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                age = value;
            }
        }
        
        public virtual string Name
        {
            get { return name; }
            protected set
            {
                if(value.Length < 3)
                {
                    Exception ex = new ArgumentException("Name's length should not be less than 3 symbols!");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                name = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(String.Format("Name: {0}, Age: {1}", this.Name, this.Age));
            return sb.ToString();
        }

    }
}

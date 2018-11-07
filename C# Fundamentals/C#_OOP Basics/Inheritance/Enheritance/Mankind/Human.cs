using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Human
    {
        protected string firstName;
        protected string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    Exception ex = new ArgumentException("Expected upper case letter! Argument: firstName");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                if (value.Length <= 3)
                {
                    Exception ex = new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                firstName = value;
            }
        }
        
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (!Char.IsUpper(value[0]))
                {
                    Exception ex = new ArgumentException("Expected upper case letter! Argument: lastName");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                if (value.Length <= 2)
                {
                    Exception ex = new ArgumentException("Expected length at least 3 symbols! Argument: lastName ");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                lastName = value;
            }
        }

        
    }
}

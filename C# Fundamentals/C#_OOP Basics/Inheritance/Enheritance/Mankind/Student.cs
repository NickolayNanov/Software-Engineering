
using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return facultyNumber; }
            set
            {
                if(value.Length < 5 || value.Length > 10)
                {
                    Exception ex = new ArgumentException("Invalid faculty number!");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }

                foreach (char ch in value.ToCharArray())
                {
                    if (!Char.IsDigit(ch) && !Char.IsLetter(ch))
                    {
                        Exception ex = new ArgumentException("Invalid faculty number!");
                        Console.WriteLine(ex.Message);
                        Environment.Exit(0);
                    }
                }
                facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"First Name: {this.FirstName}" + Environment.NewLine
                + $"Last Name: {this.LastName}" + Environment.NewLine
                + $"Faculty number: {this.FacultyNumber}" + Environment.NewLine);

            return sb.ToString().Trim();
        }
    }
}

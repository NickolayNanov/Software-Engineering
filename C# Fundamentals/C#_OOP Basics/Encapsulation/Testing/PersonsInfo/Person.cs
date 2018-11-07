﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }       

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (value.Length < 3)
                {
                    Console.WriteLine("First name cannot contain fewer than 3 symbols!");
                }
                this.firstName = value;
            }
        }
        
        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (value.Length < 3)
                {
                    Console.WriteLine("First name cannot contain fewer than 3 symbols!");
                    
                }
                this.firstName = value;
            }
        }
        
        public int Age
        {
            get { return age; }
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Age cannot be zero or a negative integer!");
                    
                }
                this.age = value;
            }
        }

        private decimal salary;

        public decimal Salary
        {
            get { return salary; }
            private set
            {
                if(value < 460.0m)
                {
                    Console.WriteLine("Salary cannot be less than 460 leva!");
                    
                }
                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if(this.age > 30)
            {
                this.salary += this.salary * percentage / 100;
            }
            else
            {
                this.salary += this.salary * percentage / 200;
            }
        }

        public override string ToString()
        {
            return $"{this.firstName} {this.LastName} gets {this.salary:f2} leva.";
        }
    }
}

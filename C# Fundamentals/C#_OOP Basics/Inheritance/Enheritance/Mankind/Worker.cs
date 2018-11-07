using System;
using System.Collections.Generic;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal hoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal hoursPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.HoursPerDay = hoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return weekSalary; }
            set
            {
                if (value < 10)
                {
                    Exception ex = new ArgumentException("Expected value mismatch! Argument: weekSalary");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                weekSalary = value;
            }
        }

        public decimal HoursPerDay
        {
            get { return hoursPerDay; }
            set
            {
                if (value < 1.0m || value > 12.0m)
                {
                    Exception ex = new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                hoursPerDay = value;
            }
        }
        
        public decimal SalaryPerHour
        {
            get { return GetSalaryPerHour(); }
            
        }

        private decimal GetSalaryPerHour()
        {
            return this.WeekSalary / 5 / this.HoursPerDay;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"First Name: {this.FirstName}" + Environment.NewLine
                + $"Last Name: {this.LastName}" + Environment.NewLine
                + $"Week Salary: {this.WeekSalary:f2}" + Environment.NewLine
                + $"Hours per day: {this.HoursPerDay:f2}" + Environment.NewLine
                + $"Salary per hour: {this.SalaryPerHour:f2}");
            return sb.ToString().Trim();
        }
    }
}

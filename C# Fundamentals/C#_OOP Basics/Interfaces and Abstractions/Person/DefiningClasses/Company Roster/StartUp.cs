using System;
using System.Collections.Generic;
using System.Linq;

namespace Company_Roster
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Emploee> emploees = new List<Emploee>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string name = tokens[0];
                decimal salary = decimal.Parse(tokens[1]);
                string position = tokens[2];
                string department = tokens[3];

                Emploee emploee = new Emploee(name, salary, position, department);

                if(tokens.Length == 5)
                {
                    if(int.TryParse(tokens[4], out int result))
                    {
                        emploee.Age = result;
                    }
                    else
                    {
                        emploee.Email = tokens[4];
                    }
                }
                else if(tokens.Length == 6)
                {
                    if(int.TryParse(tokens[4], out int result))
                    {
                        emploee.Age = result;
                        emploee.Email = tokens[5];
                    }
                    else
                    {
                        emploee.Email = tokens[4];
                        emploee.Age = int.Parse(tokens[5]);
                    }
                }
                emploees.Add(emploee);
            }

            ;
            var firstOne = emploees.GroupBy(x => x.Department)
                                        .ToDictionary(x => x.Key, y => y.Select(s => s))
                                        .OrderByDescending(x => x.Value.Average(s => s.Salary))
                                        .FirstOrDefault();

            

            Console.WriteLine($"Highest Average Salary: {firstOne.Key}");

            foreach (var e in firstOne.Value.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{e.Name} {e.Salary:f2} {e.Email} {e.Age}");
            }
        }
    }
}

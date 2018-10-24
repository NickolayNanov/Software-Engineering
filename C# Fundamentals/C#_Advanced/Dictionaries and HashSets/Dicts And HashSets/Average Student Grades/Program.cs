using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split();

                string name = tokens[0];
                double currentGrade = double.Parse(tokens[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>() { currentGrade });
                }
                else
                {
                    students[name].Add(currentGrade);
                }
            }

            foreach (var s in students)
            {
                Console.WriteLine($"{s.Key} -> {string.Join(" ", s.Value)} (avg: {s.Value.Average():F2})");
              
                
            }
            
        }
    }
}

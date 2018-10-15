using System;
using System.Collections.Generic;

namespace AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resourses = new Dictionary<string, int>();

            string input;
          
            while((input = Console.ReadLine()) != "stop")
            {
                string resourse = input;
                int quantity = int.Parse(Console.ReadLine());

                if (!resourses.ContainsKey(resourse))
                {
                    resourses.Add(resourse, quantity);
                }
                else
                {
                    resourses[resourse] += quantity;
                }
            }

            foreach (var resourse in resourses)
            {
                Console.WriteLine($"{resourse.Key} -> {resourse.Value}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            var username = new Dictionary<string, int>();
            var submitions = new Dictionary<string, int>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "exam finished") break;

                string[] tokens = line.Split('-').ToArray();

                if(tokens.Length == 3)
                {
                    string name = tokens[0];
                    string language = tokens[1];
                    int points = int.Parse(tokens[2]);

                    if (!username.ContainsKey(name))
                    {
                        username.Add(name, points);
                    }
                    else
                    {
                        if(username[name] < points)
                        {
                            username[name] = points;
                        }
                    }

                    if (!submitions.ContainsKey(language))
                    {
                        submitions.Add(language, 1);
                    }
                    else
                    {
                        submitions[language]++;
                    }
                }
                else if(tokens.Length == 2)
                {
                    string name = tokens[0];
                    username.Remove(name);
                }
            }

            Console.WriteLine("Results:");
            foreach (var user in username.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }
            Console.WriteLine("Submissions:");

            foreach (var sub in submitions.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{sub.Key} - {sub.Value}");
            }
        }
    }
}

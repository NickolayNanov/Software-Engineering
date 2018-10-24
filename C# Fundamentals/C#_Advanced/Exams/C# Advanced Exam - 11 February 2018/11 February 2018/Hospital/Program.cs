using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> departments = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> doctors = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Output") break;

                string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string department = tokens[0];
                string doctor = tokens[1] + " " + tokens[2];
                string patient = tokens[3];

                if (!departments.ContainsKey(department))
                {
                    departments.Add(department, new HashSet<string>() { patient});
                }
                else
                {
                    departments[department].Add(patient);
                }

                if (!doctors.ContainsKey(doctor))
                {
                    doctors.Add(doctor, new HashSet<string>() { patient });
                }
                else
                {
                    doctors[doctor].Add(patient);
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End") break;
                line = line.Trim();
                string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if(tokens.Length == 1)
                {
                    foreach (var patient in departments[line])
                    {
                        Console.WriteLine(patient);
                    }
                }
                else if(int.TryParse(tokens[1], out int result))
                {
                    if(result > 20)//check
                    {
                        continue;
                    }

                    var patients = departments[tokens[0]];
                    var room = patients.Skip(3 * (int.Parse(tokens[1]) - 1)).Take(3).OrderBy(p => p).ToArray();

                    foreach (var patient in room)
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    var pat = doctors[line].ToList();
                    pat.Sort();

                    foreach (var p in pat)
                    {
                        Console.WriteLine(p);
                    }
                }
            }
        }
    }
}

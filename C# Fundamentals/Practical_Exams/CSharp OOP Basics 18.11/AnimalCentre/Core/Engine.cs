using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private AnimalCentre animalCenter;

        public Engine()
        {
            this.animalCenter = new AnimalCentre();
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] tokens = line.Split();

                string command = tokens[0];

                string output = string.Empty;

                if (command == "RegisterAnimal")
                {
                    string type = tokens[1];
                    string name = tokens[2];
                    int energy = int.Parse(tokens[3]);
                    int hapiness = int.Parse(tokens[4]);
                    int procedureTime = int.Parse(tokens[5]);

                    try
                    {
                        output = animalCenter.RegisterAnimal(type, name, energy, hapiness, procedureTime);
                    }
                    catch (ArgumentException ex)
                    {
                        output = ex.Message;
                    }
                    catch (InvalidOperationException ex)
                    {
                        output = ex.Message;
                    }
                }
                else if (command == "Chip")
                {
                    try
                    {
                        string name = tokens[1];
                        int time = int.Parse(tokens[2]);

                        output = animalCenter.Chip(name, time);
                    }
                    catch (ArgumentException ex)
                    {
                        output = ex.Message;
                    }
                    catch (InvalidOperationException ex)
                    {
                        output = ex.Message;
                    }
                }
                else if (command == "Vaccinate")
                {
                    try
                    {
                        string name = tokens[1];
                        int time = int.Parse(tokens[2]);

                        output = animalCenter.Vaccinate(name, time);
                    }
                    catch (ArgumentException ex)
                    {
                        output = ex.Message;
                    }
                    catch (InvalidOperationException ex)
                    {
                        output = ex.Message;
                    }
                }
                else if (command == "Fitness")
                {
                    try
                    {
                        string name = tokens[1];
                        int time = int.Parse(tokens[2]);

                        output = animalCenter.Fitness(name, time);
                    }
                    catch (ArgumentException ex)
                    {
                        output = ex.Message;
                    }
                    catch (InvalidOperationException ex)
                    {
                        output = ex.Message;
                    }
                }

                else if (command == "Play")
                {
                    try
                    {
                        string name = tokens[1];
                        int time = int.Parse(tokens[2]);

                        output = animalCenter.Play(name, time);
                    }
                    catch (ArgumentException ex)
                    {
                        output = ex.Message;
                    }
                    catch (InvalidOperationException ex)
                    {
                        output = ex.Message;
                    }
                }
                else if (command == "DentalCare")
                {
                    try
                    {
                        string name = tokens[1];
                        int time = int.Parse(tokens[2]);

                        output = animalCenter.DentalCare(name, time);
                    }
                    catch (ArgumentException ex)
                    {
                        output = ex.Message;
                    }
                    catch (InvalidOperationException ex)
                    {
                        output = ex.Message;
                    }
                }
                else if (command == "NailTrim")
                {
                    try
                    {
                        string name = tokens[1];
                        int time = int.Parse(tokens[2]);

                        output = animalCenter.NailTrim(name, time);
                    }
                    catch (ArgumentException ex)
                    {
                        output = ex.Message;
                    }
                    catch (InvalidOperationException ex)
                    {
                        output = ex.Message;
                    }
                }
                else if (command == "Adopt")
                {
                    try
                    {
                        string name = tokens[1];
                        string owner = tokens[2];

                        output = animalCenter.Adopt(name, owner);
                    }
                    catch (ArgumentException ex)
                    {
                        output = ex.Message;
                    }
                    catch (InvalidOperationException ex)
                    {
                        output = ex.Message;
                    }
                }

                else if (command == "History")
                {
                    try
                    {
                        string procedure = tokens[1];

                        output = animalCenter.History(procedure);
                    }
                    catch (ArgumentException ex)
                    {
                        output = ex.Message;
                    }
                    catch (InvalidOperationException ex)
                    {
                        output = ex.Message;
                    }
                }

                if (!string.IsNullOrEmpty(output))
                {
                    Console.WriteLine(output);
                }

                line = Console.ReadLine();
            }

            if (animalCenter.owners.Count > 0)
            {
                foreach (var kvp in animalCenter.owners?.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"--Owner: {kvp.Key}");
                    if (kvp.Value.Count > 0)
                    {
                        Console.WriteLine($"    - Adopted animals: {string.Join(" ", kvp.Value?.Select(x => $"{x?.Name}"))}");
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] tokens = input.Split();

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonType = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonType, pokemonHealth);
                Trainer trainer = new Trainer(trainerName);
                trainer.Pokemons.Add(pokemon);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, trainer);
                }
                else
                {
                    trainers[trainerName].Pokemons.Add(pokemon);
                }
                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "Fire")
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Value.Pokemons.Any(p => p.Type == "Fire"))
                        {
                            trainer.Value.BadgesCount++;
                        }
                        else
                        {
                            trainer.Value.Pokemons.ForEach(x => x.Health -= 10);
                        }
                    }
                }

                else if (command == "Electricity")
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Value.Pokemons.Any(p => p.Type == "Electricity"))
                        {
                            trainer.Value.BadgesCount++;
                        }
                        else
                        {
                            trainer.Value.Pokemons.ForEach(x => x.Health -= 10);
                        }
                    }
                }
                else if (command == "Water")
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Value.Pokemons.Any(p => p.Type == "Water"))
                        {
                            trainer.Value.BadgesCount++;
                        }
                        else
                        {
                            trainer.Value.Pokemons.ForEach(x => x.Health -= 10);
                        }
                    }
                }
                command = Console.ReadLine();
            }

            foreach (var t in trainers)
            {
                t.Value.Pokemons.RemoveAll(x => x.Health <= 0);
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Value.BadgesCount))
            {
                Console.WriteLine($"{trainer.Value.Name} {trainer.Value.BadgesCount} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}


            

          
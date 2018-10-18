using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> games = Console.ReadLine().Split(' ', '-').ToList();

            string input;

            while ((input = Console.ReadLine()) != "Play!")
            {
                string[] tokens = input.Split().ToArray();

                switch (tokens[0])
                {
                    case "Install":

                        if (!games.Contains(tokens[1]))
                        {
                            games.Add(tokens[1]);
                        }
                        break;

                    case "Uninstall":
                        if (games.Contains(tokens[1]))
                        {
                            games.Remove(tokens[1]);
                        }
                        break;
                    case "Update":
                        if (games.Contains(tokens[1]))
                        {
                            games.Remove(tokens[1]);
                            games.Add(tokens[1]);
                        }
                        break;

                    case "Expansion":

                        string[] word = tokens[1].Split('-').ToArray();
                        string splited = word[0] + ":" + word[1];

                        if (games.Contains(word[0]))
                        {
                            games.Insert(games.IndexOf(word[0]) + 1, splited);
                        }
                        
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", games));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Tseam_Account
{
    class TseamAccount
    {
        static void Main(string[] args)
        {
            List<string> games = Console.ReadLine().Split(' ').ToList();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Play!") break;

                string[] tokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                switch (command)
                {
                    case "Install":

                        string game1 = tokens[1];
                        if (!games.Contains(game1))
                        {
                            games.Add(game1);
                        }    
                        break;

                    case "Uninstall":
                        string game2 = tokens[1];
                        if (games.Contains(game2))
                        {
                            games.Remove(game2);
                        }
                        break;
                    case "Update":
                        string game3 = tokens[1];

                        if (games.Contains(game3))
                        {
                            games.Remove(game3);
                            games.Add(game3);
                        }
                        break;

                    case "Expansion":

                        string[] gameExp = tokens[1].Split('-');

                        string expansion = gameExp[0] + ":" + gameExp[1];

                        if (games.Contains(gameExp[0]))
                        {
                            int index = games.IndexOf(gameExp[0]);

                            games.Insert(index + 1, expansion);
                        }

                        break;
                }

            }

            Console.WriteLine(string.Join(" ", games));
        }
    }
}

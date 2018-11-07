using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    class StartUp
    {
        public static Dictionary<string, Team> teams;

        static void Main(string[] args)
        {
            teams = new Dictionary<string, Team>();

            string[] teamInput = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

            string nameTeam = teamInput[1];

            teams.Add(nameTeam, new Team());

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] tokens = input
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "Add")
                {
                    //>;<PlayerName>;<Endurance>;<Sprint>;<Dribble>;<Passing>;<Shooting>" 
                    string teamName = tokens[1];
                    string playerName = tokens[2];
                    int endurance = int.Parse(tokens[3]);
                    int sprint = int.Parse(tokens[4]);
                    int dribble = int.Parse(tokens[5]);
                    int passing = int.Parse(tokens[6]);
                    int shooting = int.Parse(tokens[7]);

                    int[] stats = { endurance, sprint, dribble, passing, shooting };

                    if(stats.Any(x => x < 0 || x > 100))
                    {
                        Player p = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        input = Console.ReadLine();
                        continue;
                    }

                    if (!teams.ContainsKey(teamName))
                    {
                        Exception ex = new ArgumentException($"Team {teamName} does not exist.");
                        Console.WriteLine(ex.Message);
                        input = Console.ReadLine();
                        continue;
                    }
                    
                    teams[teamName].Add(teamName, playerName, endurance, sprint, dribble, passing, shooting);
                }
                else if(command == "Remove")
                {
                    string teamName = tokens[1];
                    string playerName = tokens[2];

                    if (!teams.ContainsKey(teamName))
                    {
                        
                        Exception ex = new ArgumentException($"Team {teamName} does not exist.");
                        Console.WriteLine(ex.Message);
                        input = Console.ReadLine();
                        continue;
                    }

                    if (!teams[teamName].Players.Any(x => x.Name == playerName))
                    {
                        Exception ex = new ArgumentException($"Player {playerName} is not in {teamName} team.");
                        Console.WriteLine(ex.Message);
                        input = Console.ReadLine();
                        continue;
                    }

                    Player player = teams[teamName].Players.Where(x => x.Name == playerName).FirstOrDefault();
                    teams[teamName].Players.Remove(player);
                }
                else if(command == "Rating")
                {
                    string teamName = tokens[1];

                    if (!teams.ContainsKey(teamName))
                    {
                        Exception ex = new ArgumentException($"Team {teamName} does not exist.");
                        Console.WriteLine(ex.Message);
                        input = Console.ReadLine();
                        continue;
                    }

                    Console.WriteLine($"{teamName} - {Math.Ceiling(teams[teamName].Rating)}");
                }

                input = Console.ReadLine();
            }
        }
    }
}

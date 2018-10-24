using System;
using System.Collections.Generic;
using System.Linq;

namespace Champions_League
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> teamWins = new Dictionary<string, int>();
            Dictionary<string, HashSet<string>> teamOponents = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "stop") break;

                string[] tokens = line.Split(new char[] {'|' }, StringSplitOptions.RemoveEmptyEntries);

                string teamOne = tokens[0].TrimEnd().TrimStart();
                string teamTwo = tokens[1].TrimEnd().TrimStart(); 
                string firstScore = tokens[2].TrimEnd().TrimStart();
                string secondScore = tokens[3].TrimEnd().TrimStart();

                if (!teamOponents.ContainsKey(teamOne))
                {
                    teamOponents.Add(teamOne, new HashSet<string>() { teamTwo });
                }
                else
                {
                    teamOponents[teamOne].Add(teamTwo);
                }

                if (!teamOponents.ContainsKey(teamTwo))
                {
                    teamOponents.Add(teamTwo, new HashSet<string>() {teamOne });
                }
                else
                {
                    teamOponents[teamTwo].Add(teamOne);
                }

                if (!teamWins.ContainsKey(teamOne))
                {
                    teamWins.Add(teamOne, 0);
                }
               
                if (!teamWins.ContainsKey(teamTwo))
                {
                    teamWins.Add(teamTwo, 0);
                }
               
                string[] scores = firstScore.Split(':');

                int firstTeamHost = int.Parse(scores[0]);
                int secondTeamGuest = int.Parse(scores[1]);

                string[] scores2 = secondScore.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                int secondTeamHost = int.Parse(scores2[0]);
                int firstTeamGuest = int.Parse(scores2[1]);

                int firstTeamGoals = firstTeamHost + firstTeamGuest;
                int secondTeamGoals = secondTeamGuest + secondTeamHost; 

                if (firstTeamGoals > secondTeamGoals)
                {
                    teamWins[teamOne]++; 
                }
                else if(secondTeamGoals > firstTeamGoals)
                {
                    teamWins[teamTwo]++;
                }
                else
                {
                    if(firstTeamGuest <= secondTeamGuest && firstTeamGuest + secondTeamGuest != 0)
                    {
                        teamWins[teamTwo]++;
                    }
                    else if(firstTeamGuest >= secondTeamGuest && secondTeamHost + firstTeamGuest != 0)
                    {
                        teamWins[teamOne]++;
                    }

                }
            }

            foreach (var team in teamWins.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine(team.Key);
                Console.WriteLine("- Wins: " + team.Value);
                Console.WriteLine("- Opponents: " + string.Join(", ", teamOponents[team.Key].OrderBy(x => x)));
            }
        }
    }
}

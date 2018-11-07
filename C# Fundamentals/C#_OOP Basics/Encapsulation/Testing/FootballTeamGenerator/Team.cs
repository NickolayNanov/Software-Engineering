using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Exception ex = new ArgumentException($"A name should not be empty.");
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
                name = value;
            }
        }

        private List<Player> players;

        public List<Player> Players
        {
            get { return players; }
            set { players = value; }
        }

        private double rating;

        public double Rating
        {
            get { return GetRaiting(); }
            set { rating = value; }
        }

        private double GetRaiting()
        {
            if (this.Players == null)
            {
                this.players = new List<Player>();
                return 0.0;
            }
            return this.Players.Average(x => x.AverageStats);
        }
        
        public void Add(string teamName, string playerName, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            if(this.Players == null)
            {
                this.players = new List<Player>();
            }
            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            this.Players.Add(player);
        }

        public void Remove(string teamName, string playerName)
        {
            Player player = this.Players.Where(x => x.Name == playerName).FirstOrDefault();
            this.Players.Remove(player);
        }
    }
}

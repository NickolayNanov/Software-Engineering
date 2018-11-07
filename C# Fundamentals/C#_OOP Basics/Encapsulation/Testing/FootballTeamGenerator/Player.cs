using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        private int[] stats;
        private int averageStats;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.Stats = new int[] { this.Endurance, this.Sprint, this.Dribble, this.Passing, this.Shooting, };
        }

        public double AverageStats
        {
            get { return GetAverage(); }            
        }

        private double GetAverage()
        {
            return this.Stats.Average();
        }

        public int[] Stats
        {
            get { return stats; }
            set { stats = value; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Exception ex = new ArgumentException($"A name should not be empty.");
                    Console.WriteLine(ex.Message);                    
                }
                name = value;
            }
        }
        
        private int Endurance
        {
            get { return endurance; }
            set
            {
                if(value < 0 || value > 100)
                {
                    Exception ex = new ArgumentException("Endurance should be between 0 and 100.");
                    Console.WriteLine(ex.Message);
                }
                endurance = value;
            }
        }
        
        private int Sprint
        {
            get { return sprint; }
            set
            {
                if (value < 0 || value > 100)
                {
                    Exception ex = new ArgumentException("Sprint should be between 0 and 100.");
                    Console.WriteLine(ex.Message);
                }
                sprint = value;
            }
        }
        
        private int Dribble
        {
            get { return dribble; }
            set
            {
                if (value < 0 || value > 100)
                {
                    Exception ex = new ArgumentException("Dribble should be between 0 and 100.");
                    Console.WriteLine(ex.Message);
                }
                dribble = value;
            }
        }
        
        private int Passing
        {
            get { return passing; }
            set
            {
                if (value < 0 || value > 100)
                {
                    Exception ex = new ArgumentException("Passing should be between 0 and 100.");
                    Console.WriteLine(ex.Message);
                }
                passing = value;
            }
        }       

        private int Shooting
        {
            get { return shooting; }
            set
            {
                if (value < 0 || value > 100)
                {
                    Exception ex = new ArgumentException("Shooting should be between 0 and 100.");
                    Console.WriteLine(ex.Message);
                }
                shooting = value;
            }
        }
    }
}

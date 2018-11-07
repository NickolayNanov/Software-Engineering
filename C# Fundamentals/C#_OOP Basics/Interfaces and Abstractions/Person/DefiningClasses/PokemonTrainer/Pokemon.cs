using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Pokemon
    {
        private string name;
        private string type;
        private int health;

        public Pokemon(string name, string type, int health)
        {
            this.Name = name;
            this.Type = type;
            this.Health = health;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

    }
}

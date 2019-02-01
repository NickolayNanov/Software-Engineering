using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner;
        private bool isAdopt;
        private bool isChipped;
        private bool isVaccinated;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;

            this.Owner = "Centre";
            this.IsAdopt = false;
            this.IsAdopt = false;
            this.IsVaccinated = false;           
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Happiness
        {
            get => happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"ArgumentException: Invalid happiness");
                }

                happiness = value;
            }
        }

        public int Energy
        {
            get => energy;
            set
            {
                if(value < 0 || value > 100)
                {
                    throw new ArgumentException($"ArgumentException: Invalid energy");
                }

                energy = value;
            }
        }
        public int ProcedureTime { get => procedureTime; set => procedureTime = value; }
        public string Owner { get => owner; set => owner = value; }
        public bool IsAdopt { get => isAdopt; set => isAdopt = value; }
        public bool IsChipped { get => isChipped; set => isChipped = value; }
        public bool IsVaccinated { get => isVaccinated; set => isVaccinated = value; }
    }
}

using AnimalCentre.Models.Animals.Factory;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotel;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private Hotel hotel;
        private AnimalFactory animalFactory;

        private Chip chipped;
        private DentalCare dentalCared;
        private Fitness fitnessed;
        private NailTrim nailTrimmed;
        private Play played;
        private Vaccinate vaccineted;

        public Dictionary<string, List<IAnimal>> owners = new Dictionary<string, List<IAnimal>>();

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.animalFactory = new AnimalFactory();

            this.chipped = new Chip();
            this.dentalCared = new DentalCare();
            this.fitnessed = new Fitness();
            this.nailTrimmed = new NailTrim();
            this.played = new Play();
            this.vaccineted = new Vaccinate();
        }


        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animal = this.animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

            string result = string.Empty;


            this.hotel.Accommodate(animal);
            result = $"Animal {name} registered successfully";



            return result;
        }

        public string Chip(string name, int procedureTime)
        {
            var animal = GetAnimal(name);


            chipped.DoService(animal, procedureTime);
            string result = $"{name} had chip procedure";
            this.chipped.ProcedureHistory.Add(animal);
            return result;


        }



        public string Vaccinate(string name, int procedureTime)
        {
            var animal = GetAnimal(name);


            vaccineted.DoService(animal, procedureTime);
            string result = $"{name} had vaccination procedure";
            this.vaccineted.ProcedureHistory.Add(animal);
            return result;


        }

        public string Fitness(string name, int procedureTime)
        {
            var animal = GetAnimal(name);


            fitnessed.DoService(animal, procedureTime);
            string result = $"{name} had fitness procedure";
            this.fitnessed.ProcedureHistory.Add(animal);
            return result;


        }

        public string Play(string name, int procedureTime)
        {
            var animal = GetAnimal(name);


            played.DoService(animal, procedureTime);
            string result = $"{name} was playing for {procedureTime} hours";
            this.played.ProcedureHistory.Add(animal);
            return result;


        }

        public string DentalCare(string name, int procedureTime)
        {
            var animal = GetAnimal(name);

            dentalCared.DoService(animal, procedureTime);
            this.dentalCared.ProcedureHistory.Add(animal);
            string result = $"{name} had dental care procedure";
            return result;

        }

        public string NailTrim(string name, int procedureTime)
        {
            var animal = GetAnimal(name);

            nailTrimmed.DoService(animal, procedureTime);
            string result = $"{name} had nail trim procedure";
            this.nailTrimmed.ProcedureHistory.Add(animal);
            return result;

        }

        public string Adopt(string animalName, string owner)
        {
            var animal = GetAnimal(animalName);
            string result = string.Empty;

            if (animal.IsChipped)
            {
                this.hotel.Adopt(animalName, owner);
                result = $"{owner} adopted animal with chip";
            }
            else
            {
                this.hotel.Adopt(animalName, owner);
                result = $"{owner} adopted animal without chip";
            }


            if (!this.owners.ContainsKey(owner))
            {
                this.owners.Add(owner, new List<IAnimal>());
                this.owners[owner].Add(animal);
            }
            else
            {
                this.owners[owner].Add(animal);
            }

            return result;
        }

        public string History(string type)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{type}");

            switch (type)
            {
                case "Chip":
                    sb.AppendLine(CollectInformation(chipped));
                    break;
                case "DentalCare":
                    sb.AppendLine(CollectInformation(dentalCared));
                    break;
                case "Fitness":
                    sb.AppendLine(CollectInformation(fitnessed));
                    break;
                case "NailTrim":
                    sb.AppendLine(CollectInformation(nailTrimmed));
                    break;
                case "Play":
                    sb.AppendLine(CollectInformation(played));
                    break;
                case "Vaccinate":
                    sb.AppendLine(CollectInformation(vaccineted));
                    break;
                default: return "";
            }

            return sb.ToString().Trim();
        }

        private string CollectInformation(Procedure chipped)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var animal in chipped.ProcedureHistory)
            {
                sb.AppendLine($"    {animal.ToString()}");
            }

            return sb.ToString().Trim();
        }

        private IAnimal GetAnimal(string name)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"ArgumentException: Animal {name} does not exist");
            }
            return this.hotel.Animals[name];
        }
    }
}

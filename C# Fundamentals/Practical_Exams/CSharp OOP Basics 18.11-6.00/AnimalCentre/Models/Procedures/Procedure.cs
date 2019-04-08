using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private List<IAnimal> procedureHistory;
        protected Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }
        //само от наследниците да се ползва

        public List<IAnimal> ProcedureHistory { get => procedureHistory; private set => procedureHistory = value; }


        //private methods!!
        public string History()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var animal in this.ProcedureHistory)
            {
                sb.AppendLine(animal.ToString());
            }

            return sb.ToString().Trim();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);
      
        
    }
}

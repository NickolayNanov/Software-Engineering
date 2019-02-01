using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Fitness : Procedure
    {
        public Fitness()
        {
        }

       
        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("ArgumentException: Animal doesn't have enough procedure time");
            }

            animal.Happiness -= 3;
            animal.Energy += 10;
            animal.ProcedureTime -= procedureTime;
        }
    }
}

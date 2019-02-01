using System;
using System.Collections.Generic;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure
    {
        public NailTrim()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("ArgumentException: Animal doesn't have enough procedure time");
            }

            animal.Happiness -= 7;
            animal.ProcedureTime -= procedureTime;
        }
    }
}

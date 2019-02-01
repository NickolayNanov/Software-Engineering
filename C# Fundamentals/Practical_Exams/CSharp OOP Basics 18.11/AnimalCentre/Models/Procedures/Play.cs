using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure
    {
        public Play()
        {
        }

      

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("ArgumentException: Animal doesn't have enough procedure time");
            }

            animal.Energy -= 6;
            animal.Happiness += 12;
            animal.ProcedureTime -= procedureTime;
        }
    }
}

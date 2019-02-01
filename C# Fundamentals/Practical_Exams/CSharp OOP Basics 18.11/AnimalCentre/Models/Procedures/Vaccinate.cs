using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        public Vaccinate()
        {           
        }        

        public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("ArgumentException: Animal doesn't have enough procedure time");
            }

            animal.Energy -= 8;
            animal.IsVaccinated = true;
            animal.ProcedureTime -= procedureTime;
        }
    }
}

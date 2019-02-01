using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Comands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitTypaAsString = this.Data[1];
            this.Repository.RemoveUnit(unitTypaAsString);
            string result = unitTypaAsString + " retired!";

            return result;
        }
    }
}

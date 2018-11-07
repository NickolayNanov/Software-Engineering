using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Contracts
{
    public interface IMammal : IAnimal
    {
        string LivingRegion { get; }
    }
}

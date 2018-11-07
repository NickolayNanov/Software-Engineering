using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Contracts
{
    public interface IFeline : IAnimal, IMammal
    {
        string Breed { get; }
    }
}

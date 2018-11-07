using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        ICollection<IRepair> Repairs { get; set; }
    }
}

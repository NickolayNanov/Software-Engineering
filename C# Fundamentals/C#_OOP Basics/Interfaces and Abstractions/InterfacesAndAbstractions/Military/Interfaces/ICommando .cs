using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        ICollection<IMission> Missions { get; set; }
    }
}

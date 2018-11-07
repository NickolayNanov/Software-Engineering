using Military.Enumss;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get;}
    }   
}

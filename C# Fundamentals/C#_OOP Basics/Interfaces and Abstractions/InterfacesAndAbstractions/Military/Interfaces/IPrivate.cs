using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Interfaces
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }
}

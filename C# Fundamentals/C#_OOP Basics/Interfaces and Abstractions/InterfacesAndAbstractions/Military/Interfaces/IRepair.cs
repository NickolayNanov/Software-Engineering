using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Interfaces
{
    public interface IRepair
    {
        string PartName { get; }
        int HoursWorked { get; }
    }
}

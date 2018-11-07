using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public interface IFerari
    {
        string Driver { get; set; }

        string PushGasPedal();
        string PushBreaks();
    }
}

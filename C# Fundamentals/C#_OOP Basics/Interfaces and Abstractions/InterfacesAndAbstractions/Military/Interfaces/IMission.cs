using Military.Enumss;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Interfaces
{
    public interface IMission
    {
        string CodeName { get; set; }
        State State { get; set; }

        void CompleteMission();
        
    }
}

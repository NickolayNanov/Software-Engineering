using System;
using System.Collections.Generic;
using System.Text;

namespace TheTankGame.Core.Contracts
{
    public interface IExecutable
    {
        string Execute(IList<string> args);
    }
}

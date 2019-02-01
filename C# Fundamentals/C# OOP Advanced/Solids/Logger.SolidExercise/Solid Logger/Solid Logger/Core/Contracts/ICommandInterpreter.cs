using System;
using System.Collections.Generic;
using System.Text;

namespace Solid_Logger.Core.Contracts
{
    interface ICommandInterpreter
    {
        void AddAppender(string[] args);
        void AddMessage(string[] args);
        void PrintInfo(); 
    }
}

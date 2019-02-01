using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarraksWars.Core.Comands
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data { get => data; set => data = value; }

        public abstract string Execute();
    }
}

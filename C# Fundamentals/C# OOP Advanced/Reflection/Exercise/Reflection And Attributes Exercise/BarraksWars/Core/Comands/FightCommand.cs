using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarraksWars.Core.Comands
{
    public class FightCommand : Command
    {
        [Inject]
        private readonly IRepository repository;

        [Inject]
        private readonly IUnitFactory unitFactory;

        public FightCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);

            return string.Empty;
        }
    }
}

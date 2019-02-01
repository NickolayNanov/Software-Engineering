namespace _03BarracksFactory.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using _03BarracksFactory.Contracts;
    
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string command = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandSuffix;

            Type type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == command);

            IExecutable executable = (IExecutable)Activator.CreateInstance(type, new object[] { data, this.repository, this.unitFactory });

            return executable;
        }
    }
}

using _03BarracksFactory.Contracts;
using BarraksWars.Core.Comands;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BarraksWars.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            const string commandSuffix = "Command";
            string fullCommandName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + commandSuffix;           

            Type commandNameType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == fullCommandName);
           
            IExecutable command = (Command)Activator.CreateInstance(commandNameType, new object[] { data });

            this.InjectDependencies(command);

            return command;
        }

        private void InjectDependencies(IExecutable command)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            FieldInfo[] commandFields = command.GetType().GetFields(flags).Where(f => f.GetCustomAttribute(typeof(InjectAttribute)) != null).ToArray();
            FieldInfo[] interpreterFields = this.GetType().GetFields(flags);

            foreach (FieldInfo fieldOfCommand in commandFields)
            {
                if (interpreterFields.Any(interpreterField => interpreterField.FieldType == fieldOfCommand.FieldType))
                {
                    fieldOfCommand.SetValue(command, interpreterFields.First(interpreterField => interpreterField.FieldType == fieldOfCommand.FieldType).GetValue(this));
                }
            }
        }
    }
}

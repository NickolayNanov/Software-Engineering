namespace BillsPaymentSystem.App.Core
{
    using BillsPaymentSystem.App.Core.Commands.Contracts;
    using BillsPaymentSystem.App.Core.Contracts;
    using BillsPaymentSystem.Data;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string suffixCommand = "Command";

        public string Read(string[] args, BillsPaymentSystemContext context)
        {
            string commandAsString = args[0];
            string[] commandArgs = args.Skip(1).ToArray();

            Type commandType = Assembly
                            .GetCallingAssembly()
                            .GetTypes()
                            .FirstOrDefault(t => t.Name == commandAsString + suffixCommand);

            if(commandType == null)
            {
                throw new ArgumentNullException("Command not found!");
            }

            object command = Activator.CreateInstance(commandType, context);

            string result = ((ICommand)command).Execute(commandArgs);

            return result;
        }
    }
}

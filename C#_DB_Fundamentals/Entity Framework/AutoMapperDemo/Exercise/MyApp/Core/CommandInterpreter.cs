namespace MyApp.Core
{
    using Contracts;
    using Commands.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        private readonly string Suffix = "Command";

        public string Read(string[] inputArgs)
        {
            string commandAsString = inputArgs[0];

            inputArgs = inputArgs.Skip(1).ToArray();

            Type commandType = Assembly
                                .GetCallingAssembly()
                                .GetTypes()
                                .FirstOrDefault(t => t.Name == commandAsString + Suffix);

            if(commandType == null)
            {
                throw new ArgumentNullException("Invalid Command!");
            }

            ConstructorInfo constructor = commandType.GetConstructors()
                                          .FirstOrDefault();

            Type[] constructorParams = constructor
                                          .GetParameters()
                                          .Select(p => p.ParameterType)
                                          .ToArray();

            object[] services = constructorParams
                                          .Select(this.serviceProvider.GetService)
                                          .ToArray();

            ICommand command = (ICommand)constructor.Invoke(services);
            string result = command.Execute(inputArgs);

            return result;
        }
    }
}

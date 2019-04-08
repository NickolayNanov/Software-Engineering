namespace MyApp.Core
{
    using MyApp.Core.Contracts;
    using System;
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;

    class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider, ICommandInterpreter commandInterpreter)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            //TODO: Try catch blocks
            while (true)
            {
                string[] inputParams = Console.ReadLine()
                       .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                       .ToArray();

                ICommandInterpreter commandInterpreter = this.serviceProvider.GetService<ICommandInterpreter>();
                string result = commandInterpreter.Read(inputParams);
                Console.WriteLine(result);
            }
        }
    }
}

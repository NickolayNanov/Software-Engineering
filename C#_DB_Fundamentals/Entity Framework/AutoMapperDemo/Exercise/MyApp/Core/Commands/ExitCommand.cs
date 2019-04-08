namespace MyApp.Core.Commands
{
    using MyApp.Core.Commands.Contracts;
    using System;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] parameters)
        {
            Environment.Exit(0);
            return null;
        }
    }
}

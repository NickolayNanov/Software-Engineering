﻿namespace MyApp.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(string[] parameters);
    }
}

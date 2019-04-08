namespace MyApp.Core.Commands
{
    using AutoMapper;
    using MyApp.Core.Commands.Contracts;
    using MyApp.Data;
    using MyApp.DTOs;
    using MyApp.Models;
    using System;
    using System.Linq;

    public class SetManagerCommand : ICommand
    {
        private readonly Context context;

        public SetManagerCommand(Mapper mapper, Context context)
        {
            this.context = context;
        }

        public string Execute(string[] parameters)
        {
            int employeeId = int.Parse(parameters[0]);
            int managerId = int.Parse(parameters[1]);

            Emoloyee employee = this.context.Emoloyees.Find(employeeId);
            Emoloyee manager = this.context.Emoloyees.Find(managerId);

            if(employee == null || manager == null)
            {
                throw new ArgumentNullException($"There is not such an employee in the database.");
            }

            employee.Manager = manager;
            this.context.SaveChanges();

            return $@"{employee.FirstName} {employee.LastName}'s manager is 
                      {manager.FirstName} {manager.LastName}";
        }
    }
}

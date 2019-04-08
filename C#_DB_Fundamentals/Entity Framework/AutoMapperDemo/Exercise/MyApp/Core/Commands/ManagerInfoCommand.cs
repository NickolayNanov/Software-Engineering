namespace MyApp.Core.Commands
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using MyApp.Core.Commands.Contracts;
    using MyApp.Data;
    using MyApp.DTOs;
    using MyApp.Models;
    using System;
    using System.Linq;
    using System.Text;

    public class ManagerInfoCommand : ICommand
    {
        private readonly Context context;
        private readonly Mapper mapper;

        public ManagerInfoCommand(Context context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] parameters)
        {
            StringBuilder sb = new StringBuilder();

            int managerId = int.Parse(parameters[0]);

            Emoloyee manager = this.context
                                    .Emoloyees
                                    .Include(e => e.ManagedEmployees)
                                    .FirstOrDefault(x => x.Id == managerId);

            ManagerDTO managerDto = this.mapper.CreateMappedObject<ManagerDTO>(manager);

            if(manager == null)
            {
                throw new ArgumentNullException($"Manager with id {managerId} does not exist.");
            }

            sb.AppendLine($"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.ManagedEmployees.Count}");

            foreach (var empl in managerDto.ManagedEmployees)
            {
                sb.AppendLine($"  - {empl.FirstName} {empl.LastName} - ${empl.Salary:f2}");
            }

            return sb.ToString();
        }
    }
}

namespace MyApp.Core.Commands
{
    using AutoMapper;
    using Core.Commands.Contracts;
    using MyApp.Data;
    using MyApp.DTOs;
    using MyApp.Models;
    using System;
    using System.Linq;

    public class SetAddressCommand : ICommand
    {
        private readonly Context context;
        private readonly Mapper mapper;

        public SetAddressCommand(Context context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] parameters)
        {
            int targetingId = int.Parse(parameters[0]);
            string address = string.Join(" ", parameters.Skip(1));

            Emoloyee employee = this.context.Emoloyees.Find(targetingId);

            if (employee == null)
            {
                throw new ArgumentNullException($"Employee with id {targetingId} does not exist.");
            }

            employee.Address = address;
            this.context.SaveChanges();

            EmployeeAddressDTO employeeDTO = this.mapper.CreateMappedObject<EmployeeAddressDTO>(employee);

            return $"{employeeDTO.FirstName} {employeeDTO.LastName}'s adress was set to {employeeDTO.Address} successfuly.";
        }
    }
}

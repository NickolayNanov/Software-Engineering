namespace MyApp.Core.Commands
{
    using AutoMapper;
    using Commands.Contracts;
    using MyApp.Data;
    using MyApp.Models;
    using System;
    using System.Globalization;
    using MyApp.DTOs;

    public class SetBirthdayCommand : ICommand
    {
        private readonly Context context;
        private readonly Mapper mapper;

        public SetBirthdayCommand(Context context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] parameters)
        {
            int targetingId = int.Parse(parameters[0]);
            DateTime birthday = DateTime.ParseExact(parameters[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Emoloyee emoloyee = this.context.Emoloyees.Find(targetingId);

            if(emoloyee == null)
            {
                throw new ArgumentNullException($"Employee with id {targetingId} does not exist.");
            }

            emoloyee.Birthday = birthday;
            this.context.SaveChanges();

            SetBirthdayEmployeeDTO employeeDTO = this.mapper.CreateMappedObject<SetBirthdayEmployeeDTO>(emoloyee);

            return $"{employeeDTO.FirstName} {employeeDTO.LastName}'s birth date was set to {employeeDTO.Birthday.Value.ToString("dd-MM-yyyy")}";
        }
    }
}

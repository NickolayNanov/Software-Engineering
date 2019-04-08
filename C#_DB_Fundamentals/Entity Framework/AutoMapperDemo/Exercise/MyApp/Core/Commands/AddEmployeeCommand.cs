namespace MyApp.Core.Commands
{
    using AutoMapper;
    using MyApp.Core.Commands.Contracts;
    using MyApp.Data;
    using MyApp.DTOs;
    using MyApp.Models;

    public class AddEmployeeCommand : ICommand
    {
        private readonly Context context;
        private readonly Mapper mapper;

        public AddEmployeeCommand(Context context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] parameters)
        {
            string firstName = parameters[0];
            string lastName = parameters[1];
            decimal salary = decimal.Parse(parameters[2]);

            Emoloyee employee = new Emoloyee()
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.context.Add(employee);
            this.context.SaveChanges();

            AddEmployeeDTO employeeDTO = this.mapper.CreateMappedObject<AddEmployeeDTO>(employee);

            return $"Successfully added {employeeDTO.FirstName} {employeeDTO.LastName}";
        }
    }
}

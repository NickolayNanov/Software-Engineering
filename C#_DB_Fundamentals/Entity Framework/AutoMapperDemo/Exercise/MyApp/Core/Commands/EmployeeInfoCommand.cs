namespace MyApp.Core.Commands
{
    using AutoMapper;
    using MyApp.Core.Commands.Contracts;
    using MyApp.Data;
    using MyApp.DTOs;
    using MyApp.Models;
    using System.Text;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly Context context;
        private readonly Mapper mapper;

        public EmployeeInfoCommand(Context context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] parameters)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int targetingId = int.Parse(parameters[0]);
            Emoloyee employee = this.context.Emoloyees.Find(targetingId);

            EmployeeInfoDTO dto = mapper.CreateMappedObject<EmployeeInfoDTO>(employee);

            stringBuilder.AppendLine($"ID: {dto.Id} - {dto.FirstName}{dto.LastName} - ${dto.Salary}");
            stringBuilder.AppendLine($@"Birthday: {dto.Birthday.Value.ToString("dd-MM-yyyy")}");
            stringBuilder.AppendLine($"Address: {dto.Address}");

            return stringBuilder.ToString();
        }
    }
}

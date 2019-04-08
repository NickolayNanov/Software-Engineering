namespace MyApp.DTOs
{
    using MyApp.Models;
    using System.Collections.Generic;

    public class ManagerDTO
    {
        public ManagerDTO()
        {
            this.ManagedEmployees = new List<AddEmployeeDTO>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<AddEmployeeDTO> ManagedEmployees { get; set; }
    }
}

namespace MyApp.DTOs
{
    using System;

    public class SetBirthdayEmployeeDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }
    }
}

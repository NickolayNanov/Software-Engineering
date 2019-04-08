namespace PetClinic.DataProcessor.Dtos.Imports
{
    public class AnimalDto
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Age { get; set; }

        public PassportDto Passport { get; set; }
    }

    public class PassportDto
    {
        public string SerialNumber { get; set; }

        public string OwnerPhoneNumber { get; set; }

        public string OwnerName { get; set; }

        public string RegistrationDate { get; set; }
    }
}

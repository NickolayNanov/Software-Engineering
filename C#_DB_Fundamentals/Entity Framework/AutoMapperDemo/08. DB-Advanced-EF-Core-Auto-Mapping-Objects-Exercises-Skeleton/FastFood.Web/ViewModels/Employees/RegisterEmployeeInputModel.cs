namespace FastFood.Web.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterEmployeeInputModel
    {
        [Required]
        [MaxLength(100), MinLength(3)]
        public string Name { get; set; }

        [Required]
        [Range(16, 65)]
        public int Age { get; set; }

        public string PositionName { get; set; }

        [Required]
        [MaxLength(100), MinLength(3)]
        public string Address { get; set; }
    }
}

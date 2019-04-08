namespace MyApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Emoloyee
    {
        public Emoloyee()
        {
            this.ManagedEmployees = new List<Emoloyee>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335M")]
        public decimal Salary { get; set; }

        public DateTime? Birthday { get; set; }

        public string Address { get; set; }

        public int? ManagerId { get; set; }
        public Emoloyee Manager { get; set; }

        public List<Emoloyee> ManagedEmployees { get; set; }
    }
}

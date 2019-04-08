namespace PetClinic.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Type { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Age { get; set; }

        [Required]
        public string PassportSerialNumber { get; set; }

        [Required]
        [ForeignKey(nameof(PassportSerialNumber))]
        public Passport Passport { get; set; }

        public ICollection<Procedure> Procedures { get; set; }

        public Animal()
        {
            this.Procedures = new HashSet<Procedure>();
        }
    }
}

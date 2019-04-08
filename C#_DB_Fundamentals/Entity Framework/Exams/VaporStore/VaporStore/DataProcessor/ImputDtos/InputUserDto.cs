namespace VaporStore.DataProcessor.ImputDtos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class InputUserDto
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+$")]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        public ICollection<CardDto> Cards { get; set; }

        public InputUserDto()
        {
            this.Cards = new HashSet<CardDto>();
        }
    }

    public class CardDto
    {
        [Required]
        [RegularExpression("^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}$")]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }
    }

}
